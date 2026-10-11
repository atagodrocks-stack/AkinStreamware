using System.Management;

namespace Akin.Core.Devices;

internal static class WindowsAudioDeviceEnumerator
{
    public static IReadOnlyList<DeviceDescriptor> EnumerateAll()
    {
        if (!OperatingSystem.IsWindows())
        {
            return Array.Empty<DeviceDescriptor>();
        }

        var results = new List<DeviceDescriptor>();

        try
        {
            using var searcher = new ManagementObjectSearcher(
                "SELECT DeviceID, Name, PNPDeviceID, Status FROM Win32_PnPEntity WHERE (PNPClass = 'AudioEndpoint' OR PNPClass = 'MediaCenter' OR PNPClass = 'AudioDevice')");

            foreach (ManagementObject device in searcher.Get())
            {
                var id = device["DeviceID"]?.ToString();
                var name = device["Name"]?.ToString() ?? "Unknown audio device";
                var pnpId = device["PNPDeviceID"]?.ToString();

                results.Add(new DeviceDescriptor
                {
                    Id = id ?? $"audio-{results.Count}",
                    Name = name,
                    FriendlyName = name,
                    Type = DeviceType.Audio,
                    Direction = DeviceDirection.InputOutput,
                    State = string.Equals(device["Status"]?.ToString(), "OK", StringComparison.OrdinalIgnoreCase)
                        ? DeviceState.Available
                        : DeviceState.Unavailable,
                    EndpointId = id,
                    DevicePath = pnpId,
                    IsUsb = pnpId?.IndexOf("USB", StringComparison.OrdinalIgnoreCase) >= 0,
                    IsBluetooth = pnpId?.IndexOf("BTH", StringComparison.OrdinalIgnoreCase) >= 0,
                    IsVirtual = pnpId?.IndexOf("ROOT\\VIRTUAL", StringComparison.OrdinalIgnoreCase) >= 0,
                    Notes = "Enumerated via Windows WMI (PnPEntity)."
                });
            }
        }
        catch
        {
            results.Add(new DeviceDescriptor
            {
                Id = "audio-wmi-fallback",
                Name = "Audio device enumeration failed",
                FriendlyName = "Audio device enumeration failed",
                Type = DeviceType.Audio,
                Direction = DeviceDirection.InputOutput,
                State = DeviceState.Unavailable,
                Notes = "Windows audio enumeration failed. This must be validated on a real Windows machine."
            });
        }

        return results.Count > 0 ? results : new[]
        {
            new DeviceDescriptor
            {
                Id = "audio-none-found",
                Name = "No audio devices found",
                FriendlyName = "No audio devices found",
                Type = DeviceType.Audio,
                Direction = DeviceDirection.InputOutput,
                State = DeviceState.Unavailable,
                Notes = "No audio devices were reported by Windows WMI."
            }
        };
    }
}

internal static class WindowsVideoDeviceEnumerator
{
    public static IReadOnlyList<DeviceDescriptor> EnumerateAll()
    {
        if (!OperatingSystem.IsWindows())
        {
            return Array.Empty<DeviceDescriptor>();
        }

        var results = new List<DeviceDescriptor>();

        try
        {
            using var searcher = new ManagementObjectSearcher(
                "SELECT DeviceID, Name, PNPDeviceID, Status FROM Win32_PnPEntity WHERE PNPClass = 'Camera' OR PNPClass = 'Image' OR PNPClass = 'MEDIA' OR PNPClass = 'VideoCaptureDevice'");

            foreach (ManagementObject device in searcher.Get())
            {
                var id = device["DeviceID"]?.ToString();
                var name = device["Name"]?.ToString() ?? "Unknown video device";
                var pnpId = device["PNPDeviceID"]?.ToString();

                results.Add(new DeviceDescriptor
                {
                    Id = id ?? $"video-{results.Count}",
                    Name = name,
                    FriendlyName = name,
                    Type = DeviceType.Video,
                    Direction = DeviceDirection.Input,
                    State = string.Equals(device["Status"]?.ToString(), "OK", StringComparison.OrdinalIgnoreCase)
                        ? DeviceState.Available
                        : DeviceState.Unavailable,
                    EndpointId = id,
                    DevicePath = pnpId,
                    IsUsb = pnpId?.IndexOf("USB", StringComparison.OrdinalIgnoreCase) >= 0,
                    IsVirtual = pnpId?.IndexOf("ROOT\\VIRTUAL", StringComparison.OrdinalIgnoreCase) >= 0,
                    Notes = "Enumerated via Windows WMI (PnPEntity)."
                });
            }
        }
        catch
        {
            results.Add(new DeviceDescriptor
            {
                Id = "video-wmi-fallback",
                Name = "Video device enumeration failed",
                FriendlyName = "Video device enumeration failed",
                Type = DeviceType.Video,
                Direction = DeviceDirection.Input,
                State = DeviceState.Unavailable,
                Notes = "Windows video enumeration failed. This must be validated on a real Windows machine."
            });
        }

        return results.Count > 0 ? results : new[]
        {
            new DeviceDescriptor
            {
                Id = "video-none-found",
                Name = "No video devices found",
                FriendlyName = "No video devices found",
                Type = DeviceType.Video,
                Direction = DeviceDirection.Input,
                State = DeviceState.Unavailable,
                Notes = "No video devices were reported by Windows WMI."
            }
        };
    }
}
