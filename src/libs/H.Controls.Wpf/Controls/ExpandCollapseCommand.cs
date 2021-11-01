using System.Windows.Input;

namespace H.Controls;

public class ExpandCollapseCommand : ICommand
{
    public NavigationView NavigationView { get; }
    public bool State { get; }

#pragma warning disable CS0067
    public event EventHandler? CanExecuteChanged;
#pragma warning restore CS0067

    public ExpandCollapseCommand(
        NavigationView navigationView,
        bool state)
    {
        NavigationView = navigationView ?? throw new ArgumentNullException(nameof(navigationView));
        State = state;
    }

    public bool CanExecute(object? parameter)
    {
        return true;
    }

    public void Execute(object? parameter)
    {
        NavigationView.IsExpanded = State;
    }
}