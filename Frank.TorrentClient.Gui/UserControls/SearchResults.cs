using Avalonia.Controls;

using System.Collections.ObjectModel;

using Avalonia.Layout;


namespace Frank.TorrentClient.Gui.UserControls;

public class SearchResults<T> : UserControl
{
    public SearchResults()
    {
        Items.VerticalAlignment = VerticalAlignment.Stretch;
        Items.HorizontalAlignment = HorizontalAlignment.Stretch;
        Items.ItemsSource = Data;
        Items.DataContext = Data;
        Content = Items;
    }

    public ObservableCollection<T> Data { get; } = new();

    public ListBox Items { get; } = new();
}