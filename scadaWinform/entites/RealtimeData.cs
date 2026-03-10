using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace scadaWinform;

/// <summary>
/// Bảng dữ liệu realtime. C00 lưu JSON nhiệt độ các điểm đang publish.
/// Lấy dòng mới nhất (theo CreatedAt) để hiển thị.
/// </summary>
[Table("RealtimeData")]
public class RealtimeData
{
    [Key]
    public Guid Id { get; set; }

    /// <summary>
    /// JSON nhiệt độ theo từng điểm (TemperaturePoint[]).
    /// </summary>
    public string? C00 { get; set; }

    public DateTime? CreatedAt { get; set; }
}
