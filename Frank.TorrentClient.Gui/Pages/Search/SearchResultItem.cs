using System.Windows.Input;

namespace Frank.TorrentClient.Gui.Pages.Search;

public class SearchResultItem<T>
{
    public T Data { get; set; }
    public ICommand ActionCommand { get; set; }
}