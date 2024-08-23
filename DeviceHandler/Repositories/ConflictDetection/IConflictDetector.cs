using DeviceHandler.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeviceHandler.Repositories.ConflictDetection
{
    public interface IConflictDetector
    {
        public Task<IGrouping<string, DeviceInfo>[]> GetConflictedDevices(IEnumerable<DeviceInfo> devices);

    }
}
