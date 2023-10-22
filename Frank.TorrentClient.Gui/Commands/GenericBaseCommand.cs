using System.Windows.Input;

namespace Frank.TorrentClient.Gui.Commands;

public class GenericBaseCommand<T> : ICommand
{
    private readonly Action<T> action;

    public GenericBaseCommand(Action<T> action)
    {
        this.action = action;
    }

    public bool CanExecute(object? parameter)
    {
        return true;
    }

    public void Execute(object? parameter)
    {
        action.Invoke((T)parameter!);
    }

    public event EventHandler? CanExecuteChanged;
}