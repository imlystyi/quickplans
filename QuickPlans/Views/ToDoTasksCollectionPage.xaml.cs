#region Usings

using QuickPlans.Models;
using QuickPlans.ViewModels;

#endregion

namespace QuickPlans.Views;

public partial class ToDoTasksCollectionPage : ContentPage
{
    #region Page constructors

    public ToDoTasksCollectionPage() => InitializeComponent();

    #endregion

    #region Toolbar event handlers

    public void AddToDoTaskToolbarItem_Clicked(object sender, EventArgs args)
    {
        ToDoTask toDoTask = new();

        ToDoTasksCollection toDoTaskCollection = (ToDoTasksCollection)ToDoTasksCollectionView.BindingContext;
        toDoTaskCollection.AddToDoTask(toDoTask);
    }

    private void SaveToDoTasksToolbarItem_Clicked(object sender, EventArgs args)
    {
        ToDoTasksCollection toDoTaskCollection = (ToDoTasksCollection)ToDoTasksCollectionView.BindingContext;
        toDoTaskCollection.WriteAll();
    }

    #endregion

    #region Entries/editors event handlers

    private void SubtaskTextEntry_Focused(object sender, FocusEventArgs args)
    {
        Entry entry = (Entry)sender;

        Grid grid = (Grid)entry.Parent;

        ImageButton button = (ImageButton)grid.FindByName("DeleteSubtaskButton");
        (button.IsEnabled, button.IsVisible) = (true, true);
    }

    private void SubtaskTextEntry_Unfocused(object sender, FocusEventArgs args)
    {
        Entry entry = (Entry)sender;

        Grid grid = (Grid)entry.Parent;

        ImageButton button = (ImageButton)grid.FindByName("DeleteSubtaskButton");
        (button.IsEnabled, button.IsVisible) = (false, false);
    }

    public void NewSubtaskEntry_Completed(object sender, EventArgs args)
    {
        Entry entry = (Entry)sender;

        CollectionView collectionView = (CollectionView)entry.Parent.Parent;

        ToDoTask toDoTask = (ToDoTask)collectionView.BindingContext;

        toDoTask.AddSubtask(new Subtask(entry.Text, false, DateTime.Now.ToString("yyyyMMddHHmmssfffffffK")));

        entry.Text = string.Empty;
        entry.Unfocus();       
    }

    #endregion

    #region Buttons event handlers

    private void DeleteToDoTaskButton_Clicked(object sender, EventArgs args)
    {
        ImageButton button = (ImageButton)sender;

        CollectionView collectionView = (CollectionView)button.Parent.Parent.Parent;

        ToDoTasksCollection toDoTasksCollection = (ToDoTasksCollection)collectionView.BindingContext;
        ToDoTask toDoTask = (ToDoTask)button.BindingContext;

        toDoTasksCollection.RemoveToDoTask(toDoTask);
    }

    private void DeleteSubtaskButton_Clicked(object sender, EventArgs e)
    {
        ImageButton button = (ImageButton)sender;

        CollectionView collectionView = (CollectionView)button.Parent.Parent;

        ToDoTask toDoTask = (ToDoTask)collectionView.BindingContext;
        Subtask subtask = (Subtask)button.BindingContext;

        toDoTask.RemoveSubtask(subtask);
    }

    #endregion

    #region Overridden methods

    protected override void OnDisappearing()
    {
        base.OnDisappearing();

        ToDoTasksCollection toDoTaskCollection = (ToDoTasksCollection)ToDoTasksCollectionView.BindingContext;
        toDoTaskCollection.WriteAll();
    }

    #endregion
}
