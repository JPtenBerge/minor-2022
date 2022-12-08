using Demo.Shared.Entities;

namespace BlazorDemo.Repositories;

public interface IKaasRepository
{
    Task<IEnumerable<KaasEntity>> GetAll();

    Task<KaasEntity> Add(KaasEntity newKaas);
}