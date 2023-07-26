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
/// Page that shows a collection of user notes.
/// </summary>
public partial class NotesCollectionPage : ContentPage
{
    #region Contsructors

    /// <summary>
    /// Initializes a new instance of the <see cref="NotesCollectionPage"/> class.
    /// </summary>
    public NotesCollectionPage() => InitializeComponent();

    #endregion

    #region Methods

    /// <summary>
    /// Invoked when page disappears.
    /// </summary>
    protected override void OnDisappearing()
    {
        base.OnDisappearing();

        NotesCollection notesCollection = (NotesCollection)NotesCollectionView.BindingContext;

        try
        {
            notesCollection.WriteAll();
        }
        catch (IOException)
        {
            notesCollection.WriteAll(NotesCollection.DELAY);
        }
    }

    #endregion

    #region Event handlers

    private void AddNote_Clicked(object sender, EventArgs args)
    {
        Note note = new();

        NotesCollection notesCollection = (NotesCollection)NotesCollectionView.BindingContext;
        notesCollection.AddNote(note);
    }

    private void DeleteNoteButton_Clicked(object sender, EventArgs args)
    {
        ImageButton button = (ImageButton)sender;

        CollectionView collectionView = (CollectionView)button.Parent.Parent;

        NotesCollection notesCollection = (NotesCollection)collectionView.BindingContext;
        Note note = (Note)button.BindingContext;

        notesCollection.RemoveNote(note);
    }

    private void SaveNotes_Clicked(object sender, EventArgs args)
    {
        NotesCollection notesCollection = (NotesCollection)NotesCollectionView.BindingContext;

        try
        {
            notesCollection.WriteAll();
        }
        catch (IOException)
        {
            notesCollection.WriteAll(NotesCollection.DELAY);
        }
    }

    #endregion    
}
