namespace KlodTattooWebStatic.Models;

public class TattooData
{
    public List<TattooCategory> Categories { get; set; } = new();
    public List<TattooItem> Tattoos { get; set; } = new();
}
