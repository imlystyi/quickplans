using Newtonsoft.Json;
using QuickPlans.Models;
using System.Diagnostics;

namespace QuickPlans.ViewModels;

/// <summary>
/// Represents a notes collection model.
/// </summary>
internal class NotesCollection : QuickCollection<Note>
{
    #region Fields

    /// <summary>
    /// The path to the notes storage file.
    /// </summary>
    public readonly static string StoragePath = Path.Combine(FileSystem.AppDataDirectory, "notes.txt");

    #endregion

    #region Methods

    /// <summary>
    /// Adds a note to the storage.
    /// </summary>
    /// <param name="note">The note to be added.</param>
    public void AddNote(Note note) => Container.Add(note);

    /// <summary>
    /// Removes a note from the storage.
    /// </summary>
    /// <param name="note">The note to be removed.</param>
    public void RemoveNote(Note note) => Container.Remove(note);

    public override async void ReadAll()
    {
        if (!File.Exists(StoragePath))
        {
            string emptyListJsonString = JsonConvert.SerializeObject(new List<ToDoTask>());

            Task writeAsync = AsyncIO.Write(StoragePath, emptyListJsonString);
            await writeAsync.ConfigureAwait(false);
        }
        string notesJsonString = await AsyncIO.Read(StoragePath);
        List<Note>? notes = JsonConvert.DeserializeObject<List<Note>>(notesJsonString);

        if (notes is null)
            Debug.WriteLine($"Handled exception in the {nameof(ReadAll)}: deserialized {nameof(notes)} is null!", "Handled exception");        
        else
        {
            Container.Clear();
            notes.ForEach(Container.Add);
        }
    }

    public override async void WriteAll()
    {
        string notesJsonString = JsonConvert.SerializeObject(Container.ToList());

        Task writeAsync = AsyncIO.Write(StoragePath, notesJsonString);
        await writeAsync.ConfigureAwait(false);
    }
    #endregion
}
