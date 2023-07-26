/* Copyright 2023 imlystyi
* Licensed under the Apache License, Version 2.0 (the "License"); 
* you may not use this file except in compliance with the License. 
* You may obtain a copy of the License at 
* http://www.apache.org/licenses/LICENSE-2.0
* Unless required by applicable law or agreed to in writing, 
* software distributed under the License is distributed on an "AS IS" 
* BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express 
* or implied. See the License for the specific language governing 
* permissions and limitations under the License. */
using QuickPlans.Models;
using QuickPlans.ViewModels;

namespace QuickPlans.Views;

/// <summary>
/// Page that shows a collection of user to-do-tasks.
/// </summary>
public partial class ToDoTasksCollectionPage : ContentPage
{
    #region Constructors

    /// <summary>
    /// Initializes a new instance of the <see cref="ToDoTasksCollectionPage"/> class.
    /// </summary>
    public ToDoTasksCollectionPage() => InitializeComponent();

    #endregion

    #region Methods

    /// <summary>
    /// Invoked when page disappears.
    /// </summary>
    protected override void OnDisappearing()
    {
        base.OnDisappearing();

        ToDoTasksCollection toDoTaskCollection = (ToDoTasksCollection)ToDoTasksCollectionView.BindingContext;

        try
        {
            toDoTaskCollection.WriteAll();
        }
        catch (IOException)
        {
            toDoTaskCollection.WriteAll(ToDoTasksCollection.DELAY);
        }
    }

    #endregion

    #region Event handlers

    private void AddSubtaskButton_Clicked(object sender, EventArgs e)
    {
        ImageButton button = (ImageButton)sender;
        ToDoTask toDoTask = (ToDoTask)button.BindingContext;

        toDoTask.AddSubtask(new Subtask(string.Empty, false, DateTime.Now.ToString("yyyyMMddHHmmssfffffffK")));
    }

    public void AddToDoTask_Clicked(object sender, EventArgs args)
    {
        ToDoTask toDoTask = new();

        ToDoTasksCollection toDoTaskCollection = (ToDoTasksCollection)ToDoTasksCollectionView.BindingContext;
        toDoTaskCollection.AddToDoTask(toDoTask);
    }

    private void DeleteSubtaskButton_Clicked(object sender, EventArgs e)
    {
        ImageButton button = (ImageButton)sender;

        CollectionView collectionView = (CollectionView)button.Parent.Parent;

        ToDoTask toDoTask = (ToDoTask)collectionView.BindingContext;
        Subtask subtask = (Subtask)button.BindingContext;

        toDoTask.RemoveSubtask(subtask);
    }

    private void DeleteTaskButton_Clicked(object sender, EventArgs e)
    {
        ImageButton button = (ImageButton)sender;

        CollectionView collectionView = (CollectionView)button.Parent.Parent.Parent;

        ToDoTasksCollection collection = (ToDoTasksCollection)collectionView.BindingContext;
        ToDoTask toDoTask = (ToDoTask)button.BindingContext;

        collection.RemoveToDoTask(toDoTask);
    }

    private void DeleteToDoTaskButton_Clicked(object sender, EventArgs args)
    {
        ImageButton button = (ImageButton)sender;

        CollectionView collectionView = (CollectionView)button.Parent.Parent.Parent;

        ToDoTasksCollection toDoTasksCollection = (ToDoTasksCollection)collectionView.BindingContext;
        ToDoTask toDoTask = (ToDoTask)button.BindingContext;

        toDoTasksCollection.RemoveToDoTask(toDoTask);
    }

    private void SaveToDoTasks_Clicked(object sender, EventArgs args)
    {
        ToDoTasksCollection toDoTaskCollection = (ToDoTasksCollection)ToDoTasksCollectionView.BindingContext;

        try
        {
            toDoTaskCollection.WriteAll();
        }
        catch (IOException)
        {
            toDoTaskCollection.WriteAll(ToDoTasksCollection.DELAY);
        }
    }

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

    #endregion
}
