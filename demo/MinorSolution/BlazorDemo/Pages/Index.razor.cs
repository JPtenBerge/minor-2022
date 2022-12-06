using BlazorApp1.Entities;

namespace BlazorApp1.Pages;

public partial class Index
{
    public List<KaasEntity> Kazen { get; set; } = new()
    {
        new()
        {
            Id = 4,
            Naam = "Gorgonzola",
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

    void AddKaas()
    {
        Kazen.Add(NewKaas);
        NewKaas = new();
    }

    public KaasEntity NewKaas { get; set; } = new();
    public string Title { get; set; } = "Whoa!";

    void AppendTitle()
    {
        Title += " even more!";
    }
}