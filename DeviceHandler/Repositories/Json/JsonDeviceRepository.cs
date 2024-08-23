using DeviceHandler.Repositories.Json.DTOs;
using DeviceHandler.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using DeviceHandler.Repository;
using DeviceHandler.Repositories.ConflictDetection;

namespace DeviceHandler.Repositories.Json
{
    public class JsonDeviceRepository : DeviceRepository
    {
        public string SourcePath { get; }
        public string ResultPath { get; }

        public JsonDeviceRepository(IConflictDetector conflictDetector, string sourcePath, string resultPath) : base(conflictDetector)
        {
            SourcePath = sourcePath;
            ResultPath = resultPath;
        }

        public override async Task<int> Save(Conflict[] conflicts)
        {
            using var fs = new FileStream(ResultPath, FileMode.Create, FileAccess.Write);
            await JsonSerializer.SerializeAsync(fs, conflicts);
            return conflicts.Length;
        }

        protected override async Task<IEnumerable<DeviceInfo>> GetDevices()
        {
            using var fs = new FileStream(SourcePath, FileMode.Open, FileAccess.Read);
            var jsonDevices = await JsonSerializer.DeserializeAsync<JsonDeviceInfo[]>(fs);

            if (jsonDevices == null)
                return [];

            var devices = new List<DeviceInfo>();
            foreach (var jsonDevice in jsonDevices)
            {
                var mapped = Mapper.Map(jsonDevice);
                if (mapped != null)
                    devices.Add(mapped);
            }
            return devices;
        }
    }
}
