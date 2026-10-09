namespace Akin.Core.Devices;

internal static class WindowsAudioDeviceEnumerator
{
    public static IReadOnlyList<DeviceDescriptor> EnumerateAll()
    {
        if (!OperatingSystem.IsWindows())
        {
            return Array.Empty<DeviceDescriptor>();
        }

        // This project is intentionally build-safe but not yet hardware-verified.
        // Actual MMDevice/WASAPI enumeration must be implemented and tested on a real Windows machine.
        return new[]
        {
            new DeviceDescriptor
            {
                Id = "windows-audio-placeholder",
                Name = "Windows Audio Device Placeholder",
                FriendlyName = "Windows Audio Device Placeholder",
                Type = DeviceType.Audio,
                Direction = DeviceDirection.InputOutput,
                State = DeviceState.Unavailable,
                Notes = "MMDevice/WASAPI enumeration is not yet implemented in this build. This is a compile-safe placeholder only."
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

        // This project is intentionally build-safe but not yet hardware-verified.
        // Actual Media Foundation enumeration must be implemented and tested on a real Windows machine.
        return new[]
        {
            new DeviceDescriptor
            {
                Id = "windows-video-placeholder",
                Name = "Windows Video Device Placeholder",
                FriendlyName = "Windows Video Device Placeholder",
                Type = DeviceType.Video,
                Direction = DeviceDirection.Input,
                State = DeviceState.Unavailable,
                Notes = "Media Foundation enumeration is not yet implemented in this build. This is a compile-safe placeholder only."
            }
        };
    }
}
