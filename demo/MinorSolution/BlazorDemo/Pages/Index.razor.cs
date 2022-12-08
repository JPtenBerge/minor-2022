using Demo.Shared.Entities;
using BlazorDemo.Repositories;
using Microsoft.AspNetCore.Components;

namespace BlazorDemo.Pages;

public partial class Index : ComponentBase
{
    // [Inject] is only for the pages/componenten
    [Inject] public IKaasRepository KaasRepository { get; set; }
    
    public IEnumerable<KaasEntity> Kazen { get; set; }

    protected override async Task OnInitializedAsync()
    {
        Kazen = await KaasRepository.GetAll();
    }

    async Task AddKaas()
    {
        await KaasRepository.Add(NewKaas);
        NewKaas = new();
    }

    public KaasEntity NewKaas { get; set; } = new();
    public string Title { get; set; } = "Whoa!";

    void AppendTitle()
    {
        Title += " even more!";
    }
}