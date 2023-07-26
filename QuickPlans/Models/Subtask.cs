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
namespace QuickPlans.Models;

/// <summary>
/// Represents a subtask in a <see cref="ToDoTask"/> object with a certain text, completion and id.
/// </summary>
internal class Subtask : IPlan
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

    #region Methods

    public bool Equals(Subtask? subtaskToCompare)
    {
        if (subtaskToCompare is null)
            return false;
        else
            return Id == subtaskToCompare.Id;
    }

    public static bool operator ==(Subtask lToDoPoint, Subtask rToDoPoint) => lToDoPoint.Equals(rToDoPoint);

    public static bool operator !=(Subtask lToDoPoint, Subtask rToDoPoint) => !(lToDoPoint == rToDoPoint);

    public override bool Equals(object? obj) => Equals(obj as Subtask);

    public override int GetHashCode() => Id.GetHashCode();

    #endregion
}
