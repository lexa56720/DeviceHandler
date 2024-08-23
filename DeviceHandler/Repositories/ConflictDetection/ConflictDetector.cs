using DeviceHandler.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeviceHandler.Repositories.ConflictDetection
{
    public class ConflictDetector : IConflictDetector
    {
        public Task<IGrouping<string, DeviceInfo>[]> GetConflictedDevices(IEnumerable<DeviceInfo> devices)
        {
            var conflicted = devices.GroupBy(d => d.Brigade.Code)
                                    .Where(g => g.Count() > 1 && g.Any(d => d.Device.IsOnline));
            return Task.FromResult(conflicted.ToArray());
        }
    }
}
