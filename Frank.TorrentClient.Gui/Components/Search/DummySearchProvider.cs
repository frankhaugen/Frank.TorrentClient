using Frank.TorrentClient.Gui.Commands;

namespace Frank.TorrentClient.Gui.Components.Search;

public class DummySearchProvider : ISearchProvider<Person>
{
    private List<Person> _data;

    public DummySearchProvider()
    {
        // Initialize with some fictional characters 
        _data = new List<Person>
        {
            new() { Name = "Luke Skywalker", Universe = "Star Wars", Description = "A Jedi knight" },
            new() { Name = "Spock", Universe = "Star Trek", Description = "Half-human, half-Vulcan science officer" },
            new() { Name = "Sarah Connor", Universe = "Terminator", Description = "Resistance against the machines" },
            new()
            {
                Name = "Neo", Universe = "The Matrix", Description = "The One, who fights against machine overlords"
            },
            new() { Name = "Ellen Ripley", Universe = "Alien", Description = "Survivor and Xenomorph slayer" }
            // Add your sci-fi characters here...
        };
    }

    public async Task<IEnumerable<SearchResultItem<Person>>> GetSearchResults(string query)
    {
        // For simplicity we just filter data via LINQ and don't care about threading and real searching
        List<SearchResultItem<Person>>? results = _data
            .Where(x => x.Name.Contains(query, StringComparison.OrdinalIgnoreCase) ||
                        x.Universe.Contains(query, StringComparison.OrdinalIgnoreCase))
            .Select(x => new SearchResultItem<Person>
            {
                Data = x, ActionCommand = new Command(() => Console.WriteLine($"Selected: {x.Name}"))
            }).ToList();

        if (!results.Any())
        {
            results.Add(new SearchResultItem<Person>
            {
                Data = new Person { Name = "No results found" },
                ActionCommand = new Command(() => Console.WriteLine("No results found"))
            });
        }

        return await Task.FromResult(results);
    }
}