namespace Akin.Core.Devices;

internal static class WindowsAudioDeviceEnumerator
{
    public static IReadOnlyList<DeviceDescriptor> EnumerateAll()
    {
        if (!OperatingSystem.IsWindows())
        {
            return Array.Empty<DeviceDescriptor>();
        }

        return new[]
        {
            new DeviceDescriptor
            {
                Id = "windows-audio-placeholder",
                Name = "Windows audio device placeholder",
                FriendlyName = "Windows audio device placeholder",
                Type = DeviceType.Audio,
                Direction = DeviceDirection.InputOutput,
                State = DeviceState.Unavailable,
                Notes = "MMDevice/WASAPI enumeration is intentionally not yet implemented in this build."
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

        return new[]
        {
            new DeviceDescriptor
            {
                Id = "windows-video-placeholder",
                Name = "Windows video device placeholder",
                FriendlyName = "Windows video device placeholder",
                Type = DeviceType.Video,
                Direction = DeviceDirection.Input,
                State = DeviceState.Unavailable,
                Notes = "Media Foundation enumeration is intentionally not yet implemented in this build."
            }
        };
    }
}
