namespace Akin.Core.Devices;

public enum DeviceDirection
{
    Input,
    Output,
    InputOutput
}

public enum DeviceType
{
    Audio,
    Video,
    Unknown
}

public enum DeviceState
{
    Available,
    Unavailable,
    Disabled,
    Faulted
}

public sealed class DeviceDescriptor
{
    public string Id { get; init; } = string.Empty;
    public string Name { get; init; } = string.Empty;
    public string? FriendlyName { get; init; }
    public string? Manufacturer { get; init; }
    public DeviceType Type { get; init; }
    public DeviceDirection Direction { get; init; }
    public DeviceState State { get; init; }
    public string? EndpointId { get; init; }
    public string? DevicePath { get; init; }
    public int? ChannelCount { get; init; }
    public int? SampleRate { get; init; }
    public bool IsDefault { get; init; }
    public bool IsUsb { get; init; }
    public bool IsBluetooth { get; init; }
    public bool IsVirtual { get; init; }
    public bool IsLoopback { get; init; }
    public string? Notes { get; init; }
}

public interface IDeviceEnumerator
{
    IReadOnlyList<DeviceDescriptor> Enumerate();
}

public interface IDeviceChangeSource
{
    event EventHandler<DeviceChangedEventArgs>? Changed;
}

public sealed class DeviceChangedEventArgs : EventArgs
{
    public DeviceDescriptor Device { get; }
    public string ChangeType { get; }

    public DeviceChangedEventArgs(DeviceDescriptor device, string changeType)
    {
        Device = device;
        ChangeType = changeType;
    }
}
