namespace QuickPlans;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();

        Routing.RegisterRoute(nameof(Views.NotesCollectionPage), typeof(Views.NotesCollectionPage));

        Routing.RegisterRoute(nameof(Views.ToDoTasksCollectionPage), typeof(Views.ToDoTasksCollectionPage));
    }
}
