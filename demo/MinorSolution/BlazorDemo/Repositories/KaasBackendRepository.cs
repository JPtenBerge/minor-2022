﻿using System.Net.Http.Json;
using Demo.Shared.Entities;
using Demo.Shared.Entities;
using Flurl;
using Flurl.Http;

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
        return await "https://localhost:7012/api/kaas".GetJsonAsync<IEnumerable<KaasEntity>>();
    }

    public async Task<KaasEntity> Add(KaasEntity newKaas)
    {
        return await "https://localhost:7012/api/kaas"
            .PostJsonAsync(newKaas)
            .ReceiveJson<KaasEntity>();
    }
}