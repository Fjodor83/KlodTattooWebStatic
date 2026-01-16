using System.Net.Http.Json;
using KlodTattooWebStatic.Models;

namespace KlodTattooWebStatic.Services;

public class TattooDataService
{
    private readonly HttpClient _http;
    private TattooData? _cachedData;

    public TattooDataService(HttpClient http)
    {
        _http = http;
    }

    public async Task<TattooData> GetDataAsync()
    {
        if (_cachedData != null)
            return _cachedData;

        _cachedData = await _http.GetFromJsonAsync<TattooData>("data/tattoos.json");
        return _cachedData ?? new TattooData();
    }

    public async Task<List<TattooItem>> GetAllTattoosAsync()
    {
        var data = await GetDataAsync();
        return data.Tattoos;
    }

    public async Task<List<TattooItem>> GetTattoosByCategoryAsync(string category)
    {
        var data = await GetDataAsync();
        if (string.IsNullOrEmpty(category) || category.Equals("all", StringComparison.OrdinalIgnoreCase))
            return data.Tattoos;

        return data.Tattoos.Where(t => t.Category.Equals(category, StringComparison.OrdinalIgnoreCase)).ToList();
    }

    public async Task<List<TattooCategory>> GetCategoriesAsync()
    {
        var data = await GetDataAsync();
        return data.Categories;
    }
}
