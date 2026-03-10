namespace Domain.Models;

/// <summary>
/// Giá trị nhiệt độ tại một điểm (lưu trong C00 của RealtimeData).
/// </summary>
public class TemperaturePoint
{
    public Guid LocationId { get; set; }
    public double Temperature { get; set; }
}
