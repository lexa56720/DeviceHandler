using DeviceHandler.Repositories.Json.DTOs;
using DeviceHandler.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeviceHandler.Repositories.Json
{
    internal class Mapper
    {
        public static DeviceInfo? Map(JsonDeviceInfo deviceInfo)
        {
            if (deviceInfo.Device == null || deviceInfo.Brigade == null)
                return null;

            return new DeviceInfo()
            {
                Brigade = Map(deviceInfo.Brigade),
                Device = Map(deviceInfo.Device)
            };
        }

        public static Device Map(JsonDevice device)
        {
            return new Device()
            {
                IsOnline = device.IsOnline,
                SerialNumber = device.SerialNumber
            };
        }

        public static Brigade Map(JsonBrigade brigade)
        {
            return new Brigade()
            {
                Code = brigade.Code
            };
        }
    }
}
