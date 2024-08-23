using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DeviceHandler.Repositories.Json.DTOs
{
    internal class JsonBrigade
    {
        [JsonPropertyName("code")]
        public string Code { get; set; } = string.Empty;
    }
}
