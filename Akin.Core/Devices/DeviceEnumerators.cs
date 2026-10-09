namespace Akin.Core.Devices;

public sealed class AudioDeviceEnumerator : IDeviceEnumerator
{
    public IReadOnlyList<DeviceDescriptor> Enumerate()
    {
#if WINDOWS
        return WindowsAudioDeviceEnumerator.EnumerateAll();
#else
        return new List<DeviceDescriptor>
        {
            new()
            {
                Id = "audio-default",
                Name = "Default Audio Device",
                FriendlyName = "Default Audio Device",
                Type = DeviceType.Audio,
                Direction = DeviceDirection.InputOutput,
                State = DeviceState.Available,
                IsDefault = true,
                Notes = "Platform-specific WASAPI enumeration is available only on Windows."
            }
        };
#endif
    }
}

public sealed class VideoDeviceEnumerator : IDeviceEnumerator
{
    public IReadOnlyList<DeviceDescriptor> Enumerate()
    {
#if WINDOWS
        return WindowsVideoDeviceEnumerator.EnumerateAll();
#else
        return new List<DeviceDescriptor>
        {
            new()
            {
                Id = "video-default",
                Name = "Default Video Device",
                FriendlyName = "Default Video Device",
                Type = DeviceType.Video,
                Direction = DeviceDirection.Input,
                State = DeviceState.Available,
                Notes = "Platform-specific Media Foundation enumeration is available only on Windows."
            }
        };
#endif
    }
}
