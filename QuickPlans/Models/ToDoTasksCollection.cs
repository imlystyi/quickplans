#region Usings

using System.Collections.ObjectModel;
using System.Diagnostics;
using Newtonsoft.Json;
using QuickPlans.Services;

#endregion

namespace QuickPlans.Models
{
    /// <summary>
    /// Represents a to-do-tasks collection model.
    /// </summary>
    internal class ToDoTasksCollection
    {
        #region Properties

        /// <summary>
        /// Gets a to-do-tasks storage.
        /// </summary>
        /// <remarks>
        /// Has a default value of the empty <seealso cref="ObservableCollection{Note}"/>.
        /// </remarks>
        /// <returns>
        /// The <see cref="ObservableCollection{Note}"/> storage of the <see cref="ToDoTask"/> objects.
        /// </returns>
        public ObservableCollection<ToDoTask> ToDoTasks { get; } = new ObservableCollection<ToDoTask>();

        #endregion

        #region Fields

        /// <summary>
        /// The path to the to-do-tasks storage file.
        /// </summary>
        public readonly static string ToDoTasksStoragePath = Path.Combine(FileSystem.AppDataDirectory, "to_do_tasks.txt");

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ToDoTasksCollection"/> class and calls the <see cref="LoadAll"/> method.
        /// </summary>
        public ToDoTasksCollection() => LoadAll();

        #endregion

        #region Own methods

        /// <summary>
        /// Adds a new to-do-task to the storage.
        /// </summary>
        /// <param name="toDoTask">The to-do-task to be added.</param>
        public void AddToDoTask(ToDoTask toDoTask) => ToDoTasks.Add(toDoTask);

        /// <summary>
        /// Removes a to-do-task from the storage.
        /// </summary>
        /// <param name="toDoTask">The to-do-task to be removed.</param>
        public void RemoveToDoTask(ToDoTask toDoTask) => ToDoTasks.Remove(toDoTask);

        /// <summary>
        /// Asynchronously loads all to-do-tasks from the storage file and overwrites the <see cref="ToDoTasks"/> storage with them.
        /// </summary>
        /// <remarks>
        /// The path to the storage file contains in the <see cref="ToDoTasksStoragePath"/>.
        /// </remarks>
        public async void LoadAll()
        {
            if (!File.Exists(ToDoTasksStoragePath))
            {
                string emptyListJsonString = JsonConvert.SerializeObject(new List<ToDoTask>());

                Task writeAsync = AsyncIO.Write(ToDoTasksStoragePath, emptyListJsonString);
                await writeAsync.ConfigureAwait(false);
            }

            string toDoTasksJsonString = await AsyncIO.Read(ToDoTasksStoragePath);
            List<ToDoTask>? toDoTasks = JsonConvert.DeserializeObject<List<ToDoTask>>(toDoTasksJsonString);

            if (toDoTasks is null)
            {
                Debug.WriteLine($"Handled exception in the {nameof(ToDoTasksCollection.LoadAll)}: deserialized {nameof(toDoTasks)} is null!", "Handled exception");
                return;
            }

            else
            {
                ToDoTasks.Clear();
                toDoTasks.ForEach(ToDoTasks.Add);
            }
        }

        /// <summary>
        /// Asynchronously writes all to-do-tasks from the <see cref="ToDoTasks"/> storage to the storage file.
        /// </summary>
        /// <remarks>
        /// The path to the storage file contains in the <see cref="ToDoTasksStoragePath"/>.
        /// </remarks>
        public async void WriteAll()
        {
            string toDoTasksJsonString = JsonConvert.SerializeObject(ToDoTasks.ToList());

            Task writeAsync = AsyncIO.Write(ToDoTasksStoragePath, toDoTasksJsonString);
            await writeAsync.ConfigureAwait(false);
        }
        #endregion
    }
}
