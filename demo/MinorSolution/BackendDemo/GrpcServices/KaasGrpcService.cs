using BackendDemo.Protos;
using Demo.Shared.Entities;
using Google.Protobuf.Collections;
using Grpc.Core;

namespace BackendDemo.GrpcServices;

public class KaasGrpcService : KaasService.KaasServiceBase
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
    // public KaasGrpcService()
    // {
    //     
    // }
    public override Task<GetAllReply> GetAll(GetAllRequest request, ServerCallContext context)
    {
        Console.WriteLine("Halllooooooo");
        var reply = new GetAllReply();

        // AutoMapper / Mapster (hip) maken dit makkelijker
        reply.Kazen.AddRange(_kazen.Select(x => new Kaas
        {
            Id = x.Id,
            Naam = x.Naam,
            ImageUrl = x.ImageUrl,
            Geur = x.Geur
        }));
        return Task.FromResult(reply);
    }

    public async override Task<AddReply> Add(AddRequest request, ServerCallContext context)
    {
        return null;
    }
}