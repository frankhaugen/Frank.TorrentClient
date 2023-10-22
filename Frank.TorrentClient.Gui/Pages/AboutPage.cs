using System.Collections.ObjectModel;

using Avalonia.Controls;

using Frank.TorrentClient.Gui.Commands;


namespace Frank.TorrentClient.Gui.Pages;

public class AboutPage : UserControl
{
    public ObservableCollection<string> Data { get; }

    public AboutPage()
    {
        Data = new ObservableCollection<string>(new List<string>
        {
            // "Item 1",
            // "Item 2",
            // "Item 3"
        });

        ListBox listBox = new ListBox
        {
            VerticalAlignment = Avalonia.Layout.VerticalAlignment.Stretch,
            HorizontalAlignment = Avalonia.Layout.HorizontalAlignment.Stretch,
            ItemsSource = Data,
            DataContext = Data
        };

        Button button = new Button
        {
            Content = "Add item",
            VerticalAlignment = Avalonia.Layout.VerticalAlignment.Bottom,
            HorizontalAlignment = Avalonia.Layout.HorizontalAlignment.Center
        };

        button.Command = new BaseCommand(() =>
        {
            Data.Add("Item " + (Data.Count + 1));
        });

        StackPanel stackPanel = new StackPanel();
        stackPanel.Children.Add(listBox);
        stackPanel.Children.Add(button);

        Content = stackPanel;
        // Content = new TextBlock { Text = "About content goes here" };
    }
}