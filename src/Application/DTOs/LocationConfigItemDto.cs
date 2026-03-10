namespace Application.DTOs;

public class LocationConfigItemDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public bool Publish { get; set; } = true;

    /// <summary>
    /// Path/đường dẫn khai báo cho địa điểm (VD: API path, tag name).
    /// </summary>
    public string Path { get; set; } = string.Empty;
}
