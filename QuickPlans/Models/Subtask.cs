namespace QuickPlans.Models
{
    /// <summary>
    /// Represents a subtask in a <see cref="ToDoTask"/> object with a certain text, completion and id.
    /// </summary>
    internal class Subtask
    {
        #region Properties
        /// <summary>
        /// Gets or sets the text of the subtask.
        /// </summary>
        /// <remarks>
        /// Can be set only with the initialization. Has <see cref="string.Empty"/> value by defaults.
        /// </remarks>
        /// <returns>
        /// The text of the subtask.
        /// </returns>
        public string Text { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the completion of the subtask.
        /// </summary>
        /// <remarks>
        /// Has <see langword="false"/> value by defaults.
        /// </remarks>
        /// <returns>
        /// The completion of the subtask.
        /// </returns>
        public bool Done { get; set; } = false;

        /// <summary>
        /// Gets or sets the id of the subtask. Generated from the full current datetime.
        /// </summary>
        /// <remarks>
        /// Can be set only with the initialization. Has the value of the full current datetime by defaults.
        /// </remarks>
        /// <returns>
        /// The id of the subtask.
        /// </returns>
        public string Id { get; set; } = DateTime.Now.ToString("yyyyMMddHHmmssfffffffK");
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="Subtask"/> class with the default values of the properties.
        /// </summary>
        public Subtask()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Subtask"/> class with the specified text, completion and id.
        /// </summary>
        /// <param name="text">The text of the subtask.</param>
        /// <param name="done">The completion of the subtask.</param>
        /// <param name="id">The id of the subtask.</param>
        public Subtask(string text, bool done, string id)
        {
            Text = text;
            Done = done;
            Id = id;
        }
        #endregion

        #region Overridden methods
        public override bool Equals(object? obj) => Equals(obj as Subtask);

        public bool Equals(Subtask? subtaskToCompare)
        {
            if (subtaskToCompare is null)
                return false;

            else
                return Id == subtaskToCompare.Id;
        }

        public static bool operator ==(Subtask lToDoPoint, Subtask rToDoPoint) => lToDoPoint.Equals(rToDoPoint);

        public static bool operator !=(Subtask lToDoPoint, Subtask rToDoPoint) => !(lToDoPoint == rToDoPoint);

        public override int GetHashCode() => Id.GetHashCode();
        #endregion

        //#region Methods of implemented interfaces
        //public object Clone() => new Subtask(Text, Done, Id);
        //#endregion
    }
}
