using Avalonia.Controls;
using Avalonia.Layout;

namespace Frank.TorrentClient.Gui.Pages.Search.UserControls;

public class SearchBox : UserControl
{
    private TextBox _searchField;
    private Button _searchButton;
    private Action<string> _searchAction;

    public SearchBox(Action<string> searchAction)
    {
        _searchAction = searchAction;
        // Create a TextBox and a Button 
        _searchField = new TextBox { Watermark = "Enter search terms..." };
        _searchButton = new Button { Content = "Search" };

        // Handle the "Return" key and button click as a search trigger 
        _searchField.KeyUp += (sender, e) =>
        {
            if (e.Key == Avalonia.Input.Key.Enter)
            {
                Search();
            }
        };

        _searchButton.Click += (sender, e) => Search();

        // Arrange these controls in a horizontal line using a StackPanel with Horizontal orientation
        StackPanel? panel = new() { Orientation = Orientation.Horizontal };
        panel.Children.Add(_searchField);
        panel.Children.Add(_searchButton);

        // Add this panel as the content of the UserControl
        Content = panel;
    }

    private void Search()
    {
        // Invoke the search action
        _searchAction.Invoke(_searchField.Text ?? string.Empty);
    }
}