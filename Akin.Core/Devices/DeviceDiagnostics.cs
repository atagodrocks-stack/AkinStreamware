namespace Akin.Core.Devices;

public static class DeviceDiagnostics
{
    public static void PrintDeviceList(IEnumerable<DeviceDescriptor> devices)
    {
        ArgumentNullException.ThrowIfNull(devices);

        foreach (var device in devices)
        {
            Console.WriteLine($"{device.Type,-5} | {device.Direction,-12} | {device.Name} | {device.FriendlyName ?? device.Name}");
            Console.WriteLine($"  Id: {device.Id}");
            Console.WriteLine($"  State: {device.State}");
            if (!string.IsNullOrWhiteSpace(device.Notes))
            {
                Console.WriteLine($"  Notes: {device.Notes}");
            }
        }
    }
}
