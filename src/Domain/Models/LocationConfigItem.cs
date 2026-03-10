namespace Domain.Models;

/// <summary>
/// Một địa điểm đo nhiệt độ trong cấu hình (lưu trong C000).
/// </summary>
public class LocationConfigItem
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public bool Publish { get; set; } = true;
}
