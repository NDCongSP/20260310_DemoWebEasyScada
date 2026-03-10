using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities;

/// <summary>
/// Bảng cấu hình. C000 lưu JSON danh sách địa điểm đo (id, name, publish).
/// </summary>
[Table("RevoConfigs")]
public class RevoConfig
{
    [Key]
    public Guid Id { get; set; }

    /// <summary>
    /// JSON cấu hình: danh sách địa điểm đo nhiệt độ (LocationConfigItem[]).
    /// </summary>
    public string? C000 { get; set; }

    /// <summary>
    /// Thời gian reload (giây) cho trang realtime.
    /// </summary>
    public int? ReloadIntervalSeconds { get; set; } = 10;

    public bool? Actived { get; set; } = true;

    public DateTime? CreatedAt { get; set; }
}
