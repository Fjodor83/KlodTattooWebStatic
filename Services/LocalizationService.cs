using System.Globalization;
using System.Net.Http.Json;
using Microsoft.JSInterop;

namespace KlodTattooWebStatic.Services;

public class LocalizationService
{
    private readonly HttpClient _http;
    private readonly IJSRuntime _js;
    private Dictionary<string, string> _translations = new();
    private string _currentCulture = "it";

    public event Action? OnLanguageChanged;

    public LocalizationService(HttpClient http, IJSRuntime js)
    {
        _http = http;
        _js = js;
    }

    public string CurrentCulture => _currentCulture;

    public async Task InitializeAsync()
    {
        try
        {
            // Try to load saved language from localStorage
            var savedLang = await _js.InvokeAsync<string?>("localStorage.getItem", "language");
            if (!string.IsNullOrEmpty(savedLang) && (savedLang == "it" || savedLang == "en" || savedLang == "de"))
            {
                _currentCulture = savedLang;
            }
        }
        catch
        {
            // Fallback to Italian if localStorage fails
            _currentCulture = "it";
        }

        await LoadTranslationsAsync(_currentCulture);
    }

    public async Task SetLanguageAsync(string culture)
    {
        var cultureName = culture switch
        {
            "it" or "it-IT" => "it",
            "en" or "en-US" => "en",
            "de" or "de-DE" => "de",
            _ => "it"
        };

        if (_currentCulture == cultureName)
            return;

        _currentCulture = cultureName;
        await LoadTranslationsAsync(cultureName);

        try
        {
            await _js.InvokeVoidAsync("localStorage.setItem", "language", cultureName);
        }
        catch
        {
            // Ignore if localStorage is not available
        }

        CultureInfo.CurrentCulture = new CultureInfo(cultureName);
        CultureInfo.CurrentUICulture = new CultureInfo(cultureName);

        OnLanguageChanged?.Invoke();
    }

    private async Task LoadTranslationsAsync(string culture)
    {
        try
        {
            var translations = await _http.GetFromJsonAsync<Dictionary<string, string>>($"Resources/Localization.{culture}.json");
            _translations = translations ?? new Dictionary<string, string>();
        }
        catch
        {
            _translations = new Dictionary<string, string>();
        }
    }

    public string this[string key]
    {
        get
        {
            if (_translations.TryGetValue(key, out var value))
                return value;
            return key; // Return key if translation not found
        }
    }

    public string Get(string key) => this[key];
}
