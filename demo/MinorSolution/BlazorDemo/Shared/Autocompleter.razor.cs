using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using MudBlazor.Services;

namespace BlazorDemo.Shared;

public partial class Autocompleter<T>
{
    [Parameter] public IEnumerable<T> Data { get; set; }
    public string Query { get; set; }
    public List<NavigableItem>? Suggestions { get; set; }
    
    [Parameter] public EventCallback<T> OnItemSelect { get; set; }

    public void Autocomplete()
    {
        
        Suggestions = new List<NavigableItem>();
        foreach (var item in Data)
        {
            // reflection
            var props = item.GetType().GetProperties().Where(x => x.PropertyType == typeof(string));
            foreach (var prop in props)
            {
                var value = prop.GetValue(item) as string;
                if (value.Contains(Query))
                {
                    Suggestions.Add(new NavigableItem { Item = item });
                    break;
                }
            }
        }
    }

    public async Task HandleKeyUp(KeyboardEventArgs e)
    {
        if (e.Key == "ArrowDown")
        {
            Next();
        }
        else if (e.Key == "Enter")
        {
            await Select();
        }
        else
        {
            Autocomplete();
        }
    }

    public class NavigableItem
    {
        public T Item { get; set; }

        public bool IsHighlighted { get; set; }
    }

    public void Next()
    {
        for (int i = 0; i < Suggestions.Count; i++)
        {
            if (Suggestions[i].IsHighlighted)
            {
                Suggestions[i].IsHighlighted = false;
                Suggestions[(i + 1) % Suggestions.Count].IsHighlighted = true;
                return;
            }
        }


        Suggestions[0].IsHighlighted = true;
    }

    public async Task Select()
    {
        var kaas = Suggestions.Single(x => x.IsHighlighted).Item;
        await OnItemSelect.InvokeAsync(kaas);
    }
}