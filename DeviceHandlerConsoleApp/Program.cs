using DeviceHandler;
using DeviceHandler.Repositories;
using DeviceHandler.Repositories.ConflictDetection;
using DeviceHandler.Repositories.Json;

namespace DeviceHandlerConsoleApp
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var conflictHanlder = new ConflictHandler(new JsonDeviceRepository(new ConflictDetector(), "Devices.json", "Result.json"));
            var handled = await conflictHanlder.HandleConflicts();
            Console.WriteLine($"{handled} conflicts handled");
        }
    }
}
