using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DeviceHandler.Repositories.Json.DTOs
{
    internal class JsonDevice
    {
        [JsonPropertyName("serialNumber")]
        public string SerialNumber { get; set; } = string.Empty;

        [JsonPropertyName("isOnline")]
        public bool IsOnline { get; set; }
    }
}
