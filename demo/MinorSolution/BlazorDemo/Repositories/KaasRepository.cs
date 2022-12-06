using BlazorDemo.Entities;

namespace BlazorDemo.Repositories;

public class KaasRepository : IKaasRepository
{
    private List<KaasEntity> _kazen = new()
    {
        new()
        {
            Id = 4,
            Naam = "Gorgonzolaaaaaaa",
            Geur = "Zweet van een voet",
            ImageUrl = "https://nl.gorgonzola.com/wp-content/uploads/sites/10/2020/01/origini-head.jpg"
        },
        new()
        {
            Id = 8,
            Naam = "Gruyere",
            Geur = "Alpen",
            ImageUrl = "https://www.hollandskaashuis.nl/wp-content/uploads/2021/02/Le-Gruyere.jpg"
        },
        new()
        {
            Id = 15,
            Naam = "Parmesan",
            Geur = "Italianen",
            ImageUrl = "https://www.blok21.nl/wp-content/uploads/2020/10/Parmezaanze-kaas.jpg"
        }
    };
    
    public Task<IEnumerable<KaasEntity>> GetAll()
    {
        return Task.FromResult(_kazen.AsEnumerable());
    }

    public Task<KaasEntity> Add(KaasEntity newKaas)
    {
        newKaas.Id = _kazen.Max(x => x.Id) + 1;
        _kazen.Add(newKaas);
        return Task.FromResult(newKaas); // geupdatete entity
    }
}