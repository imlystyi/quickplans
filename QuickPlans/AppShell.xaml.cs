namespace QuickPlans;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();

        Routing.RegisterRoute(nameof(Views.NotesCollectionPage), typeof(Views.NotesCollectionPage));

        Routing.RegisterRoute(nameof(Views.ToDoTasksCollectionPage), typeof(Views.ToDoTasksCollectionPage));

        // Sets the white status bar to match the color of the application.
#if ANDROID        
        statusBarBehavior.StatusBarColor = Colors.White;
        statusBarBehavior.StatusBarStyle = CommunityToolkit.Maui.Core.StatusBarStyle.DarkContent;
#endif
    }
}
