using Newtonsoft.Json;

namespace ChuckBot.Models;

public class Chuck
{
    private const string API_URL = "https://api.chucknorris.io/jokes/random";
    private HttpClient _httpClient;

    public string Id { get; set; }
    public string? IconUrl { get; set; }
    public string? Url { get; set; }
    public string? Value { get; set; }

    public Chuck()
    {
        _httpClient = new HttpClient();
    }

    public async Task<Chuck> GetRandomAsync()
    {
        var result = await _httpClient.GetAsync(API_URL);
        var json = await result.Content.ReadAsStringAsync();

        var chuck = JsonConvert.DeserializeObject<Chuck>(json);

        if (chuck == null) return this;
        
        Id = chuck.Id;
        IconUrl = chuck.IconUrl;
        Url = chuck.Url;
        Value = chuck.Value;

        return this;
    }
}