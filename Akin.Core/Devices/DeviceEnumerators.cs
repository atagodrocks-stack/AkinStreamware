namespace Akin.Core.Devices;

public sealed class AudioDeviceEnumerator : IDeviceEnumerator
{
    public IReadOnlyList<DeviceDescriptor> Enumerate()
    {
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
                Notes = "Placeholder enumeration result; real Windows WASAPI implementation is pending."
            }
        };
    }
}

public sealed class VideoDeviceEnumerator : IDeviceEnumerator
{
    public IReadOnlyList<DeviceDescriptor> Enumerate()
    {
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
                Notes = "Placeholder enumeration result; real Windows Media Foundation implementation is pending."
            }
        };
    }
}
