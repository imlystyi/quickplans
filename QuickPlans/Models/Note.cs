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
/// Represents a model of note with a title, text, date and id.
/// </summary>
internal class Note : IPlan
{
    #region Properties

    /// <summary>
    /// Gets or sets the note title.
    /// </summary>
    /// <remarks>
    /// Has a default value of the <see cref="string.Empty"/>.
    /// </remarks>
    public string Title { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the note text.
    /// </summary>
    /// <remarks>
    /// Has a default value of <see cref="string.Empty"/>.
    /// </remarks>
    /// <returns>
    /// The <see cref="string"/> note text.
    /// </returns>
    public string Text { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the note creation date.
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
    /// The <see cref="string"/> note creation date.
    /// </returns>
    public string Date { get; set; } = DateTime.Now.ToString("g");

    /// <summary>
    /// Gets or sets the unique note id.
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
    /// The <see cref="int"/> note id.
    /// </returns>
    public string Id { get; set; } = DateTime.Now.ToString("yyyyMMddHHmmssfffffffK");

    #endregion

    #region Constructors

    /// <summary>
    /// Initializes a new instance of the <see cref="Note"/> class that has a default values of the properties.
    /// </summary>
    public Note()
    {
    }

    #endregion

    #region Methods

    public override bool Equals(object? obj) => Equals(obj as Note);

    public bool Equals(Note? note)
    {
        if (note is null)
            return false;
        else
            return Id == note.Id;
    }

    public static bool operator ==(Note lNote, Note rNote) => lNote.Equals(rNote);

    public static bool operator !=(Note lNote, Note rNote) => !(lNote == rNote);

    public override int GetHashCode() => Id.GetHashCode();

    #endregion
}
