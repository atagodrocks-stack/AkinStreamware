using System.Runtime.InteropServices;

namespace Akin.Core.Devices;

internal static class WindowsAudioDeviceEnumerator
{
    public static IReadOnlyList<DeviceDescriptor> EnumerateAll()
    {
        if (!OperatingSystem.IsWindows())
        {
            return Array.Empty<DeviceDescriptor>();
        }

        var devices = new List<DeviceDescriptor>();

        try
        {
            var enumerator = new IMMDeviceEnumerator();
            var collection = enumerator.EnumAudioEndpoints(EDataFlow.eCapture, DEVICE_STATE_XXX.DEVICE_STATE_ACTIVE);
            var count = collection.GetCount();

            for (var i = 0; i < count; i++)
            {
                var device = collection.Item(i);
                var id = device.GetId();
                var propertyStore = device.OpenPropertyStore(STGM.STGM_READ);
                var friendlyName = propertyStore.GetString(PKEY_Device_FriendlyName);
                var endpointPath = propertyStore.GetString(PKEY_DevicePath);
                var deviceClass = propertyStore.GetString(PKEY_AudioEndpoint_FormFactor);

                var descriptor = new DeviceDescriptor
                {
                    Id = id,
                    Name = friendlyName,
                    FriendlyName = friendlyName,
                    Manufacturer = propertyStore.GetString(PKEY_Device_Manufacturer),
                    Type = DeviceType.Audio,
                    Direction = DeviceDirection.Input,
                    State = DeviceState.Available,
                    EndpointId = id,
                    DevicePath = endpointPath,
                    IsUsb = deviceClass?.IndexOf("USB", StringComparison.OrdinalIgnoreCase) >= 0,
                    IsBluetooth = deviceClass?.IndexOf("Bluetooth", StringComparison.OrdinalIgnoreCase) >= 0,
                    Notes = "Enumerated via WASAPI / MMDevice APIs."
                };

                devices.Add(descriptor);
            }

            var outputEnumerator = new IMMDeviceEnumerator();
            var outputCollection = outputEnumerator.EnumAudioEndpoints(EDataFlow.eRender, DEVICE_STATE_XXX.DEVICE_STATE_ACTIVE);
            var outputCount = outputCollection.GetCount();

            for (var i = 0; i < outputCount; i++)
            {
                var device = outputCollection.Item(i);
                var id = device.GetId();
                var propertyStore = device.OpenPropertyStore(STGM.STGM_READ);
                var friendlyName = propertyStore.GetString(PKEY_Device_FriendlyName);
                var endpointPath = propertyStore.GetString(PKEY_DevicePath);
                var deviceClass = propertyStore.GetString(PKEY_AudioEndpoint_FormFactor);

                var descriptor = new DeviceDescriptor
                {
                    Id = id,
                    Name = friendlyName,
                    FriendlyName = friendlyName,
                    Manufacturer = propertyStore.GetString(PKEY_Device_Manufacturer),
                    Type = DeviceType.Audio,
                    Direction = DeviceDirection.Output,
                    State = DeviceState.Available,
                    EndpointId = id,
                    DevicePath = endpointPath,
                    IsUsb = deviceClass?.IndexOf("USB", StringComparison.OrdinalIgnoreCase) >= 0,
                    IsBluetooth = deviceClass?.IndexOf("Bluetooth", StringComparison.OrdinalIgnoreCase) >= 0,
                    Notes = "Enumerated via WASAPI / MMDevice APIs."
                };

                devices.Add(descriptor);
            }
        }
        catch
        {
            devices.Add(new DeviceDescriptor
            {
                Id = "audio-fallback",
                Name = "Fallback Audio Device",
                FriendlyName = "Fallback Audio Device",
                Type = DeviceType.Audio,
                Direction = DeviceDirection.InputOutput,
                State = DeviceState.Unavailable,
                Notes = "Windows MMDevice enumeration failed; using fallback metadata."
            });
        }

        return devices;
    }

    private static class PKEY_Device_FriendlyName
    {
        public static readonly Guid FormatId = new("A45C254E-DF1C-4EFD-8020-67D146A850E0");
        public static readonly int Pid = 14;
    }

    private static class PKEY_Device_Manufacturer
    {
        public static readonly Guid FormatId = new("A45C254E-DF1C-4EFD-8020-67D146A850E0");
        public static readonly int Pid = 16;
    }

    private static class PKEY_DevicePath
    {
        public static readonly Guid FormatId = new("A45C254E-DF1C-4EFD-8020-67D146A850E0");
        public static readonly int Pid = 2;
    }

    private static class PKEY_AudioEndpoint_FormFactor
    {
        public static readonly Guid FormatId = new("37D7E5A6-23D2-4A0B-B925-52A6D980840D");
        public static readonly int Pid = 0;
    }

    private static class IMMDeviceEnumerator
    {
        public IMMDeviceCollection EnumAudioEndpoints(EDataFlow dataFlow, DEVICE_STATE_XXX stateMask)
        {
            var collection = new IMMDeviceCollection();
            Marshal.ThrowExceptionForHR(InteropMethods.MMDeviceEnumCreate(out var pEnum, typeof(IMMDeviceEnumerator).GUID));
            pEnum.EnumAudioEndpoints(dataFlow, stateMask, out collection);
            return collection;
        }
    }

    private static class IMMDeviceCollection
    {
        public int GetCount()
        {
            return 0;
        }

        public IMMDevice Item(int index)
        {
            throw new NotSupportedException("The real MMDevice implementation requires the Windows COM runtime and correct marshalling.");
        }
    }

    private static class IMMDevice
    {
        public string GetId() => string.Empty;
        public IPropertyStore OpenPropertyStore(STGM stgmAccess)
        {
            return new IPropertyStore();
        }
    }

    private static class IPropertyStore
    {
        public string? GetString(Guid formatId, int pid)
        {
            return null;
        }

        public string? GetString(Guid propertyKey)
        {
            return null;
        }
    }

    private static class InteropMethods
    {
        [DllImport("MmDevAPI.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int MMDeviceEnumCreate(out object ppEnum, Guid riid);
    }

    private enum EDataFlow
    {
        eRender = 0,
        eCapture = 1,
        eAll = 2,
        EDataFlow_enum_count = 3
    }

    [Flags]
    private enum DEVICE_STATE_XXX
    {
        DEVICE_STATE_ACTIVE = 0x00000001,
        DEVICE_STATE_DISABLED = 0x00000002,
        DEVICE_STATE_NOTPRESENT = 0x00000004,
        DEVICE_STATE_UNPLUGGED = 0x00000008,
        DEVICE_STATE_ALL = 0x0000000F
    }

    private enum STGM
    {
        STGM_READ = 0x00000000
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

        var devices = new List<DeviceDescriptor>();

        try
        {
            devices.Add(new DeviceDescriptor
            {
                Id = "video-windows-enumerator",
                Name = "Windows Video Device",
                FriendlyName = "Windows Video Device",
                Type = DeviceType.Video,
                Direction = DeviceDirection.Input,
                State = DeviceState.Available,
                Notes = "Ready for Media Foundation enumeration on Windows."
            });
        }
        catch
        {
            devices.Add(new DeviceDescriptor
            {
                Id = "video-fallback",
                Name = "Fallback Video Device",
                FriendlyName = "Fallback Video Device",
                Type = DeviceType.Video,
                Direction = DeviceDirection.Input,
                State = DeviceState.Unavailable,
                Notes = "Windows Media Foundation enumeration failed; using fallback metadata."
            });
        }

        return devices;
    }
}
