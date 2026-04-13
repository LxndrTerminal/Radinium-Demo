public class ApiClient
{
    private readonly IHttpClientFactory _factory;
    private readonly AuthState _auth;
    public ApiClient(IHttpClientFactory factory, AuthState auth) { _factory = factory; _auth = auth; }

    private HttpClient Client()
    {
        var c = _factory.CreateClient("ApiClient");
        if (!String.IsNullOrEmpty(_auth.AccessToken))
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
    
    public async Task<string> GetProductDataAsync(string productId, CancellationToken ct = default)
    {
	using var res = await Client().GetAsync($"v3/products/{productId}/product.dat", ct);
	res.EnsureSuccessStatusCode();
	return await res.Content.ReadAsStringAsync(ct);
    }

    public record ApiResult(System.Net.HttpStatusCode StatusCode, bool IsSuccess, string Content);

    public async Task<ApiResult> PostJsonAsync<TRequest>(string uri, TRequest payload, CancellationToken ct = default)
    {
        using var res = await Client().PostAsJsonAsync(uri, payload, ct);
        var content = await res.Content.ReadAsStringAsync(ct);
        return new ApiResult(res.StatusCode, res.IsSuccessStatusCode, content);
    }


    public async Task<ApiResult> DeleteAsAsync(string uri, CancellationToken ct = default)
    {
	using var res = await Client().DeleteAsync(uri, ct);
	var content = await res.Content.ReadAsStringAsync(ct);
	return new ApiResult(res.StatusCode, res.IsSuccessStatusCode, content);
    }
 
}
