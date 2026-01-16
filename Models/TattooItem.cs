namespace KlodTattooWebStatic.Models;

public class TattooItem
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Category { get; set; } = string.Empty;
    public string ImageUrl { get; set; } = string.Empty;
    public string CreatedDate { get; set; } = string.Empty;
}
