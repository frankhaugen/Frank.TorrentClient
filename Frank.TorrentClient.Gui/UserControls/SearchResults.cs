using Avalonia.Controls;

using System.Collections.ObjectModel;
using System.Reflection;

namespace Frank.TorrentClient.Gui.UserControls;

public class SearchResults<T> : DataGrid
{
    private ObservableCollection<T> _items;

    public SearchResults()
    {
        _items = new ObservableCollection<T>();
        this.ItemsSource = _items;

        // Using reflection to generate the columns based on the public properties of T
        foreach (PropertyInfo property in typeof(T).GetProperties())
        {
            var column = new DataGridTextColumn
            {
                Header = property.Name,
                Binding = new Avalonia.Data.Binding(property.Name)
            };
            this.Columns.Add(column);
        }
    }
        
    // Method to add an item
    public void AddResult(T result)
    {
        _items.Add(result);
    }

    // Method to clear the items
    public void ClearResults()
    {
        _items.Clear();
    }
}