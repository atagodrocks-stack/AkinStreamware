using Akin.Core.Devices;

Console.WriteLine("AKIN Device Explorer");
Console.WriteLine("Phase 1 Step 1: device enumeration foundation");
Console.WriteLine("Windows WASAPI and Media Foundation device discovery is implemented in the next platform-specific layer.");

var audioDevices = new AudioDeviceEnumerator().Enumerate();
var videoDevices = new VideoDeviceEnumerator().Enumerate();

Console.WriteLine();
Console.WriteLine("Audio devices:");
DeviceDiagnostics.PrintDeviceList(audioDevices);

Console.WriteLine();
Console.WriteLine("Video devices:");
DeviceDiagnostics.PrintDeviceList(videoDevices);
