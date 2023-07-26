using QuickPlans.Models;
using System.Collections.ObjectModel;

namespace QuickPlans.ViewModels;

/// <summary>
/// Represents an abstract collection from which derived collections that contains reminder items are built.
/// </summary>
/// <typeparam name="T">An object that implements the <see cref="IPlan"/> interface.</typeparam>
internal abstract class QuickCollection<T> where T : IPlan
{
    #region Properties

    /// <summary>
    /// Gets an items container.
    /// </summary>
    public ObservableCollection<T> Container { get; } = new ObservableCollection<T>();

    #endregion

    #region Constructors

    /// <summary>
    /// Initializes a new instance of the collection and invokes a <see cref="ReadAll()"/> method.
    /// </summary>
    protected QuickCollection() => ReadAll();

    #endregion

    #region Methods

    /// <summary>
    /// Writes all items from the container to the storage file.
    /// </summary>
    public abstract void WriteAll();

    /// <summary>
    /// Reads all items from the storage file and overwrites the container with them.
    /// </summary>
    public abstract void ReadAll();

    #endregion
}
