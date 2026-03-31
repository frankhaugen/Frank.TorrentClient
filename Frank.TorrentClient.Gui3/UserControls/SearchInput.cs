using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Frank.TorrentClient.Gui3.Pages;

public class SearchInput : StackPanel
{
    private readonly string _searchBoxWatermark;
    
    private readonly TextBox _searchBox = new();
    private readonly Button _searchButton = new();
    
    public SearchInput(string searchButtonText = "Search", string searchBoxWatermark = "Your search query...")
    {
        _searchBoxWatermark = searchBoxWatermark;
        _searchButton.Content = searchButtonText;
        
        Children.Add(_searchBox);
        Children.Add(_searchButton);
        
        SetWatermark();
        
        _searchBox.GotFocus += TextBox1_GotFocus;
        _searchBox.LostFocus += TextBox1_LostFocus;
        _searchButton.Click += SearchButton_Click;
        _searchBox.KeyUp += SearchBox_KeyUp;
    }
    
    public event EventHandler<string>? SearchEventRaised;

    private void SearchBox_KeyUp(object sender, KeyEventArgs e)
    {
        if (e.Key == Key.Enter)
        {
            SearchButton_Click(sender, e);
        }
    }

    private void SearchButton_Click(object sender, RoutedEventArgs e)
    {
        if (_searchBox.Text != string.Empty && _searchBox.Text != _searchBoxWatermark && _searchBox.Text != " " && SearchEventRaised != null)
        {
            SearchEventRaised?.Invoke(this, _searchBox.Text);
        }
    }

    private void TextBox1_GotFocus(object sender, RoutedEventArgs e)
    {
        if (_searchBox.Text == _searchBoxWatermark)
        {
            SetWatermark();
        }
    }

    private void TextBox1_LostFocus(object sender, RoutedEventArgs e)
    {
        if (_searchBox.Text == string.Empty)
        {
            RemoveWatermark();
        }
    }

    private void SetWatermark()
    {
        _searchBox.Text = string.Empty;
        _searchBox.Foreground = Brushes.Black;
    }
    
    private void RemoveWatermark()
    {
        _searchBox.Text = _searchBoxWatermark;
        _searchBox.Foreground = Brushes.Gray;
    }
}