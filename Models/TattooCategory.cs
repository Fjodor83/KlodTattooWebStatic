namespace KlodTattooWebStatic.Models;

public class TattooCategory
{
    public string Id { get; set; } = string.Empty;
    public string NameIt { get; set; } = string.Empty;
    public string NameEn { get; set; } = string.Empty;
    public string NameDe { get; set; } = string.Empty;
    
    public string GetName(string culture)
    {
        return culture switch
        {
            "it" or "it-IT" => NameIt,
            "en" or "en-US" => NameEn,
            "de" or "de-DE" => NameDe,
            _ => NameIt
        };
    }
}
