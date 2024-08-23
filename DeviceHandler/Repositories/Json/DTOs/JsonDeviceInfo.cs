using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DeviceHandler.Repositories.Json.DTOs
{
    internal class JsonDeviceInfo
    {
        [JsonPropertyName("device")]
        public JsonDevice? Device { get; set; }

        [JsonPropertyName("brigade")]
        public JsonBrigade? Brigade { get; set; }
    }
}
