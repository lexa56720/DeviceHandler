using DeviceHandler.DTOs;
using DeviceHandler.Repositories.ConflictDetection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeviceHandler.Repository
{
    public abstract class DeviceRepository
    {
        private readonly IConflictDetector conflictDetector;

        internal DeviceRepository(IConflictDetector conflictDetector)
        {
            this.conflictDetector = conflictDetector;
        }

        public async Task<Conflict[]> GetConflicts()
        {
            var devices = await GetDevices();
            var conflitedDevice = await conflictDetector.GetConflictedDevices(devices);
            return ConvertToConflicts(conflitedDevice);
        }

        protected abstract Task<IEnumerable<DeviceInfo>> GetDevices();

        private Conflict[] ConvertToConflicts(IGrouping<string, DeviceInfo>[] devices)
        {
            return devices.Select(g => new Conflict()
            {
                BrigadeCode = g.Key,
                DevicesSerials = g.Select(d => d.Device.SerialNumber)
                                  .ToArray(),
            }).ToArray();
        }

        public abstract Task<int> Save(Conflict[] conflicts);
    }
}
