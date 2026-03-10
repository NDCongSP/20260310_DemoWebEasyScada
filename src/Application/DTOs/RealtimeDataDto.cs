namespace Application.DTOs;

public class RealtimeDataDto
{
    public Guid Id { get; set; }
    public string? C00 { get; set; }
    public DateTime? CreatedAt { get; set; }
    public List<TemperaturePointDto>? Temperatures { get; set; }
}
