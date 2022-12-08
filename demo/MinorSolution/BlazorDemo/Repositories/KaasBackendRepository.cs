using System.Net.Http.Json;
using Demo.Shared.Entities;
using Demo.Shared.Entities;

namespace BlazorDemo.Repositories;

public class KaasBackendRepository : IKaasRepository
{
    private HttpClient _http;
    public KaasBackendRepository(HttpClient http)
    {
        _http = http;
    }
    
    public async Task<IEnumerable<KaasEntity>> GetAll()
    {
        return (await _http.GetFromJsonAsync<IEnumerable<KaasEntity>>("https://localhost:7012/api/kaas"))!;
    }

    public async Task<KaasEntity> Add(KaasEntity newKaas)
    {
        var response = await _http.PostAsJsonAsync("https://localhost:7012/api/kaas", newKaas);
        return (await response.Content.ReadFromJsonAsync<KaasEntity>())!;
    }
}