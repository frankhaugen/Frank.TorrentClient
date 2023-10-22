using System.Windows.Input;

namespace Frank.TorrentClient.Gui.Commands;

public class BaseCommand : ICommand
{
    private readonly Action action;

    public BaseCommand(Action action)
    {
        this.action = action;
    }

    public bool CanExecute(object? parameter)
    {
        return true;
    }

    public void Execute(object? parameter)
    {
        action.Invoke();
    }

    public event EventHandler? CanExecuteChanged;
}