namespace Application.DTOs;

public class RevoConfigDto
{
    public Guid Id { get; set; }
    public string? C000 { get; set; }
    public int? ReloadIntervalSeconds { get; set; } = 10;
    public bool? Actived { get; set; } = true;
    public DateTime? CreatedAt { get; set; }
    public List<LocationConfigItemDto>? Locations { get; set; }
}
