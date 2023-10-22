using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Templates;

using Frank.TorrentClient.Gui.Components.Search;

namespace Frank.TorrentClient.Gui.UserControls;

public class SearchResults<T> : UserControl
{
    private ListBox _resultsList;

    // Binded property for search results
    public static readonly DirectProperty<SearchResults<T>, IEnumerable<SearchResultItem<T>>> ItemsProperty =
        AvaloniaProperty.RegisterDirect<SearchResults<T>, IEnumerable<SearchResultItem<T>>>("Items", o => o.Items,
            (o, v) => o.Items = v);

    private IEnumerable<SearchResultItem<T>> _items;

    public IEnumerable<SearchResultItem<T>> Items
    {
        get => _items;
        set => SetAndRaise(ItemsProperty, ref _items, value);
    }

    public SearchResults()
    {
        _resultsList = new ListBox();
        _resultsList.DataTemplates.Add(new FuncDataTemplate<SearchResultItem<T>>(
            x => true,
            (_, _) =>
            {
                // Return an instance of control that represents each item in the list, e.g. some custom Panel, etc.
                // or you can create and return a control dynamically as per the item data

                return new Panel();
            }));

        Content = _resultsList;
    }
}