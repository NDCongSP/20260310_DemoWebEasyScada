namespace Application.DTOs;

public class LocationConfigItemDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public bool Publish { get; set; } = true;
}
