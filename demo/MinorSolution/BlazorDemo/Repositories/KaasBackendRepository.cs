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
        return (await _http.GetFromJsonAsync<IEnumerable<KaasEntity>>("https://localhost:7196/api/kaas"))!;
    }

    public async Task<KaasEntity> Add(KaasEntity newKaas)
    {
        await _http.PostAsJsonAsync<KaasEntity>("https://localhost:7196/api/kaas", newKaas);
        return newKaas;
    }
}