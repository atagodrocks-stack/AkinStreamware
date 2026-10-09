using Akin.Core.Devices;
using Xunit;

namespace Akin.Tests.Devices;

public class DeviceEnumeratorTests
{
    [Fact]
    public void AudioDeviceEnumerator_ReturnsDefaultDevice()
    {
        var devices = new AudioDeviceEnumerator().Enumerate();

        Assert.NotEmpty(devices);
        Assert.Equal(DeviceType.Audio, devices[0].Type);
        Assert.True(devices[0].IsDefault || devices[0].Name.Contains("Default"));
    }

    [Fact]
    public void VideoDeviceEnumerator_ReturnsDefaultDevice()
    {
        var devices = new VideoDeviceEnumerator().Enumerate();

        Assert.NotEmpty(devices);
        Assert.Equal(DeviceType.Video, devices[0].Type);
        Assert.True(devices[0].Name.Contains("Default") || devices[0].FriendlyName?.Contains("Default") == true);
    }
}
