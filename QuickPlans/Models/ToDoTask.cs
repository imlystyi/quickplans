using System.Collections.ObjectModel;

namespace QuickPlans.Models;

/// <summary>
/// Represents a model of to-do-task with a title, subtasks list, date and id.
/// </summary>
internal class ToDoTask : IPlan
{
    #region Properties

    /// <summary>
    /// Gets or sets the to-do-task title.
    /// </summary>
    /// <remarks>
    /// Has a default value of the <see cref="string.Empty"/>.
    /// </remarks>
    /// <returns>
    /// The <see cref="string"/> to-do-task title.
    /// </returns>
    public string Title { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the subtasks list.
    /// </summary>
    /// <remarks>
    /// Has a default value of the empty <seealso cref="ObservableCollection{Note}"/>.
    /// </remarks>
    /// <returns>
    /// The <see cref="ObservableCollection{T}"/> list of <see cref="Subtasks"/> objects.
    /// </returns>
    public ObservableCollection<Subtask> Subtasks { get; set; } = new ObservableCollection<Subtask>();

    /// <summary>
    /// Gets or sets the to-do-task creation date.
    /// </summary>
    /// <remarks>
    /// The date is plain text and can be any string.
    /// <br>
    /// <example>
    /// But the preferred format is general short date/time. Example:
    /// <code>
    /// "15.06.2009 13:45"
    /// </code>
    /// </example>
    /// </br>
    /// Has a default value of the <see cref="string.Empty"/>.
    /// </remarks>
    /// <returns>
    /// The <see cref="string"/> to-do-task creation date.
    /// </returns>
    public string Date { get; set; } = DateTime.Now.ToString("g");

    /// <summary>
    /// Gets or sets the unique to-do-task id.
    /// </summary>
    /// <remarks>
    /// By defaults, has a generated value by current exact time.
    /// <br>
    /// <example>
    /// Time of generation has a special format:
    /// <code>
    /// "yyyyMMddHHmmssfffffffK"
    /// </code>
    /// </example>
    /// </br>
    /// </remarks>
    /// <returns>
    /// The <see cref="int"/> to-do-task id.
    /// </returns>
    public string Id { get; set; } = DateTime.Now.ToString("yyyyMMddHHmmssfffffffK");

    #endregion

    #region Constructors

    /// <summary>
    /// Initializes a new instance of the <see cref="ToDoTask"/> class that has a default values of the properties.
    /// </summary>
    public ToDoTask()
    {
    }

    #endregion

    #region Own methods

    /// <summary>
    /// Adds a subtask in the subtasks list.
    /// </summary>
    /// <param name="subtask">The subtask to be added.</param>
    public void AddSubtask(Subtask subtask) => Subtasks.Add(subtask);

    /// <summary>
    /// Removes a subtask from the subtask list.
    /// </summary>
    /// <param name="subtask">The subtask to be removed.</param>
    public void RemoveSubtask(Subtask subtask) => Subtasks.Remove(subtask);

    #endregion
}
