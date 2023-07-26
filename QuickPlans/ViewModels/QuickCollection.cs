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
    /// Reads all items from the storage file and overwrites the container with them.
    /// </summary>
    public abstract void ReadAll();

    /// <summary>
    /// Writes all items from the container to the storage file.
    /// </summary>
    public abstract void WriteAll();

    /// <summary>
    /// Writes all items from the container to the storage file with specified delay.
    /// </summary>
    /// <param name="delay">Writing delay in milliseconds.</param>
    public abstract void WriteAll(int delay);

    #endregion
}
