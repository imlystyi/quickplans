using Newtonsoft.Json;
using QuickPlans.Models;
using System.Diagnostics;

namespace QuickPlans.ViewModels;

/// <summary>
/// Represents a to-do-tasks collection model.
/// </summary>
internal class ToDoTasksCollection : QuickCollection<ToDoTask>
{
    #region Fields

    /// <summary>
    /// The path to the to-do-tasks storage file.
    /// </summary>
    public string StoragePath = Path.Combine(FileSystem.AppDataDirectory, "to_do_tasks.txt");

    #endregion 

    #region Methods

    /// <summary>
    /// Adds a new to-do-task to the storage.
    /// </summary>
    /// <param name="toDoTask">The to-do-task to be added.</param>
    public void AddToDoTask(ToDoTask toDoTask) => Container.Add(toDoTask);

    /// <summary>
    /// Removes a to-do-task from the storage.
    /// </summary>
    /// <param name="toDoTask">The to-do-task to be removed.</param>
    public void RemoveToDoTask(ToDoTask toDoTask) => Container.Remove(toDoTask);

    public override async void ReadAll()
    {
        if (!File.Exists(StoragePath))
        {
            string emptyListJsonString = JsonConvert.SerializeObject(new List<ToDoTask>());

            Task writeAsync = AsyncIO.Write(StoragePath, emptyListJsonString);
            await writeAsync.ConfigureAwait(false);
        }

        string toDoTasksJsonString = await AsyncIO.Read(StoragePath);
        List<ToDoTask>? toDoTasks = JsonConvert.DeserializeObject<List<ToDoTask>>(toDoTasksJsonString);

        if (toDoTasks is null)
            Debug.WriteLine($"Handled exception in the {nameof(ReadAll)}: deserialized {nameof(toDoTasks)} is null!", "Handled exception");
        else
        {
            Container.Clear();
            toDoTasks.ForEach(Container.Add);
        }
    }

    public override async void WriteAll()
    {
        string toDoTasksJsonString = JsonConvert.SerializeObject(Container.ToList());

        Task writeAsync = AsyncIO.Write(StoragePath, toDoTasksJsonString);
        await writeAsync.ConfigureAwait(false);
    }

    #endregion
}
