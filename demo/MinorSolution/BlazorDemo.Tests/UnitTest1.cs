using BlazorDemo.Shared;

namespace BlazorDemo.Tests;

[TestClass]
public class AutocompleteTests
{
    private List<Car> _cars;
    private Autocompleter<Car> _sut;

    [TestInitialize]
    public void Initialize()
    {
        _cars = new List<Car>
        {
            new() { Name = "KITT", UsedInPopularMedia = "Knight Rider" },
            new() { Name = "DAF 750 - truttenschudder", UsedInPopularMedia = "Jongens jongens wat een meid" },
            new() { Name = "Brum", UsedInPopularMedia = "ZAPP" },
            new() { Name = "Opel Manta", UsedInPopularMedia = "New Kids" },
            new() { Name = "Christine", UsedInPopularMedia = "Christine" },
            new() { Name = "Lelijke auto van B&A", UsedInPopularMedia = "Bassie en Adriaan" }
        };
        _sut = new Autocompleter<Car>(); // sut = system under test
        _sut.Data = _cars;
    }

    [TestMethod]
    public void Autocomplete_BasicQuery_GiveSuggestions()
    {
        _sut.Query = "u";

        _sut.Autocomplete();

        Assert.AreEqual(3, _sut.Suggestions.Count);
        var brum = _cars.Single(x => x.Name == "Brum");
        var truttenschudder = _cars.Single(x => x.Name.Contains("truttenschudder"));
        var lelijkeAuto = _cars.Single(x => x.Name == "Lelijke auto van B&A");
        CollectionAssert.Contains(_sut.Suggestions.Select(x => x.Item).ToList(), brum);
        CollectionAssert.Contains(_sut.Suggestions.Select(x => x.Item).ToList(), truttenschudder);
        CollectionAssert.Contains(_sut.Suggestions.Select(x => x.Item).ToList(), lelijkeAuto);
    }

    [TestMethod]
    public void Autocomplete_BasicQueryThatMatchesMultipleProps_GiveUniqueSuggestions()
    {
        _sut.Query = "e";

        _sut.Autocomplete();

        Assert.AreEqual(5, _sut.Suggestions.Count);
    }

    [TestMethod]
    public void Autocomplete_EmptyQuery_SuggestEverything()
    {
        _sut.Query = "";

        _sut.Autocomplete();

        CollectionAssert.AreEqual(_cars, _sut.Suggestions.Select(x => x.Item).ToList());
    }

    [TestMethod]
    public void Next_NothingHighlighted_HighlightFirstSuggestion()
    {
        _sut.Query = "e";
        _sut.Autocomplete();

        _sut.Next();

        Assert.IsTrue(_sut.Suggestions.First().IsHighlighted);
        Assert.AreEqual(1, _sut.Suggestions.Count(x => x.IsHighlighted));
    }

    [TestMethod]
    public void Next_FirstSuggestionHighlighted_HighlightSecondSuggestion()
    {
        _sut.Query = "e";
        _sut.Autocomplete();

        _sut.Next();
        _sut.Next();

        Assert.IsTrue(_sut.Suggestions[1].IsHighlighted);
        Assert.AreEqual(1, _sut.Suggestions.Count(x => x.IsHighlighted));
    }

    [TestMethod]
    public void Next_LastSuggestionHighlighted_()
    {
        _sut.Query = "e";
        _sut.Autocomplete();

        foreach (var suggestion in _sut.Suggestions)
        {
            _sut.Next();
        }
        _sut.Next();

        Assert.IsTrue(_sut.Suggestions.First().IsHighlighted);
        Assert.AreEqual(1, _sut.Suggestions.Count(x => x.IsHighlighted));
    }
    
    // and more tests:
    // nullable query, empty data, empty suggestions, ...
    // Right Boundary Inversion Correctness Exception Performance
}