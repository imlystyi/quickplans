#region Usings

using QuickPlans.Models;
using QuickPlans.ViewModels;

#endregion

namespace QuickPlans.Views;

public partial class NotesCollectionPage : ContentPage
{
    #region Contsructors

    public NotesCollectionPage() => InitializeComponent();

    #endregion

    #region Methods

    protected override void OnDisappearing()
    {
        base.OnDisappearing();

        NotesCollection notesCollection = (NotesCollection)NotesCollectionView.BindingContext;
        notesCollection.WriteAll();
    }

    #endregion

    #region Toolbar event handlers

    private void AddNoteToolbarItem_Clicked(object sender, EventArgs args)
    {
        Note note = new();

        NotesCollection notesCollection = (NotesCollection)NotesCollectionView.BindingContext;
        notesCollection.AddNote(note);
    }

    private void SaveNotesToolbarItem_Clicked(object sender, EventArgs args)
    {
        NotesCollection notesCollection = (NotesCollection)NotesCollectionView.BindingContext;
        notesCollection.WriteAll();
    }

    #endregion

    #region Buttons event handlers

    private void DeleteNoteButton_Clicked(object sender, EventArgs args)
    {
        ImageButton button = (ImageButton)sender;

        CollectionView collectionView = (CollectionView)button.Parent.Parent.Parent;

        NotesCollection notesCollection = (NotesCollection)collectionView.BindingContext;
        Note note = (Note)button.BindingContext;

        notesCollection.RemoveNote(note);
    }

    #endregion    
}
