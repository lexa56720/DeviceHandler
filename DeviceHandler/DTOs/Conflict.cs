namespace DeviceHandler.DTOs
{

    public class Conflict
    {
        public string BrigadeCode { get; set; } = string.Empty;
        public string[] DevicesSerials { get; set; } = [];
    }
}
