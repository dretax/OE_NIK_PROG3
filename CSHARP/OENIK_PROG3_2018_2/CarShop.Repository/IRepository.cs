// <copyright file="IRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CarShop.Repository
{
    using System.Linq;
    using System.Text;

    /// <summary>
    /// Initialization interface for the Repositories.
    /// </summary>
    /// <typeparam name="T">Any type of repository.</typeparam>
    public interface IRepository<T>
    {
        /// <summary>
        /// Returns the repository contents as a string.
        /// </summary>
        /// <returns>StringBuilder.</returns>
        StringBuilder GetTableContents();

        /// <summary>
        /// Returns all the elements of the repository.
        /// </summary>
        /// <returns>T type query.</returns>
        IQueryable<T> GetAll();

        /// <summary>
        /// Deletes the specific element.
        /// </summary>
        /// <param name="id">id.</param>
        /// <returns>True/False.</returns>
        bool Delete(int id);
    }
}