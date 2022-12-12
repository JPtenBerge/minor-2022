using Demo.Shared.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BackendDemo.Controllers;

[Route("api/kaas")]
[ApiController] // [FromBody] ModelState.IsValid
[Authorize(Policy = "alleenbob")]
public class KaasApi : ControllerBase
{
    private static List<KaasEntity> _kazen = new()
    {
        new()
        {
            Id = 4,
            Naam = "Backend Gorgonzola",
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
    
    [HttpGet]
    public ActionResult<IEnumerable<KaasEntity>> GetAll()
    {
        Console.WriteLine("Name: " + User.Identity.Name);
        return _kazen;
    }

    [HttpPost] // You aren't Gonna Need it
    public ActionResult<KaasEntity> Post(KaasEntity newKaas)
    {
        newKaas.Id = _kazen.Max(x => x.Id) + 1;
        _kazen.Add(newKaas);
        return newKaas;
    }
}