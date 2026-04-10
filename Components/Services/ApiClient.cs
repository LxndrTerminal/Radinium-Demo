public class ApiClient
{
    private readonly IHttpClientFactory _factory;
    private readonly AuthState _auth;
    public ApiClient(IHttpClientFactory factory, AuthState auth) { _factory = factory; _auth = auth; }

    private HttpClient Client()
    {
        var c = _factory.CreateClient("ApiClient");
        if (!string.IsNullOrEmpty(_auth?.AccessToken))
            c.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", _auth.AccessToken);
        return c;
    }

    public async Task<T?> GetJsonAsync<T>(string uri, CancellationToken ct = default)
    {
        using var res = await Client().GetAsync(uri, ct);
        res.EnsureSuccessStatusCode();
        await using var stream = await res.Content.ReadAsStreamAsync(ct);
        return await System.Text.Json.JsonSerializer.DeserializeAsync<T>(stream, new System.Text.Json.JsonSerializerOptions { PropertyNameCaseInsensitive = true }, ct);
    }
}
