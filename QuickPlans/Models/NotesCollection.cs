#region Usings

using System.Collections.ObjectModel;
using System.Diagnostics;
using Newtonsoft.Json;
using QuickPlans.Services;

#endregion

namespace QuickPlans.Models
{
    /// <summary>
    /// Represents a notes collection model.
    /// </summary>
    internal class NotesCollection
    {
        #region Properties
        /// <summary>
        /// Gets a notes storage.
        /// </summary>
        /// <remarks>
        /// Has a default value of the empty <seealso cref="ObservableCollection{Note}"/>.
        /// </remarks>
        /// <returns>
        /// The <see cref="ObservableCollection{Note}"/> storage of the <see cref="Note"/> objects.
        /// </returns>
        public ObservableCollection<Note> Notes { get; } = new ObservableCollection<Note>();

        #endregion

        #region Fields

        /// <summary>
        /// The path to the notes storage file.
        /// </summary>
        public readonly static string NotesStoragePath = Path.Combine(FileSystem.AppDataDirectory, "notes.txt");

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="NotesCollection"/> class and calls the <see cref="LoadAll"/> method.
        /// </summary>
        public NotesCollection() => LoadAll();

        #endregion

        #region Methods

        /// <summary>
        /// Adds a note to the storage.
        /// </summary>
        /// <param name="note">The note to be added.</param>
        public void AddNote(Note note) => Notes.Add(note);

        /// <summary>
        /// Removes a note from the storage.
        /// </summary>
        /// <param name="note">The note to be removed.</param>
        public void RemoveNote(Note note) => Notes.Remove(note);

        /// <summary>
        /// Asynchronously loads all notes from the storage file and overwrites the <see cref="Notes"/> storage with them.
        /// </summary>
        /// <remarks>
        /// The path to the storage file contains in the <see cref="NotesStoragePath"/>.
        /// </remarks>
        public async void LoadAll()
        {
            if (!File.Exists(NotesStoragePath))
            {
                string emptyListJsonString = JsonConvert.SerializeObject(new List<ToDoTask>());

                Task writeAsync = AsyncIO.Write(NotesStoragePath, emptyListJsonString);
                await writeAsync.ConfigureAwait(false);
            }

            string notesJsonString = await AsyncIO.Read(NotesStoragePath);
            List<Note>? notes = JsonConvert.DeserializeObject<List<Note>>(notesJsonString);

            if (notes is null)
            {
                Debug.WriteLine($"Handled exception in the {nameof(NotesCollection.LoadAll)}: deserialized {nameof(notes)} is null!", "Handled exception");
                return;
            }

            else
            {
                Notes.Clear();
                notes.ForEach(Notes.Add);
            }
        }

        /// <summary>
        /// Asynchronously writes all notes from the <see cref="Notes"/> storage to the storage file.
        /// </summary>
        /// <remarks>
        /// The path to the storage file contains in the <see cref="NotesStoragePath"/>.
        /// </remarks>
        public async void WriteAll()
        {
            string notesJsonString = JsonConvert.SerializeObject(Notes.ToList());

            Task writeAsync = AsyncIO.Write(NotesStoragePath, notesJsonString);
            await writeAsync.ConfigureAwait(false);
        }
        #endregion
    }
}
