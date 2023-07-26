namespace QuickPlans;

/// <summary>
/// Provides shell behavior to supplement the default <see cref="AppShell"/> class.
/// </summary>
public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();

        // Route registering.
        Routing.RegisterRoute(nameof(Views.NotesCollectionPage), typeof(Views.NotesCollectionPage));
        Routing.RegisterRoute(nameof(Views.ToDoTasksCollectionPage), typeof(Views.ToDoTasksCollectionPage));
    }
}
