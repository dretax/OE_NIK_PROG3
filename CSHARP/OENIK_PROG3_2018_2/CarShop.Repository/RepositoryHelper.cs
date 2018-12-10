// <copyright file="RepositoryHelper.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CarShop.Repository
{
    using System.Collections.Generic;
    using CarShop.Data;

    /// <summary>
    /// This helper supports getting the specific repositories.
    /// </summary>
    public class RepositoryHelper
    {
        private readonly BrandRepository brandrepo;
        private readonly CarRespository carrepo;
        private readonly ExtraRepository extrarepo;
        private readonly CarExtraKeysRepository carExtraKeysRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="RepositoryHelper"/> class.
        /// This constructor creates each instance for the repositories.
        /// </summary>
        public RepositoryHelper()
        {
            this.brandrepo = new BrandRepository();
            this.carrepo = new CarRespository();
            this.extrarepo = new ExtraRepository();
            this.carExtraKeysRepository = new CarExtraKeysRepository();
        }

        /// <summary>
        /// Gets the brand repository.
        /// </summary>
        public virtual BrandRepository BrandRepository
        {
            get { return this.brandrepo; }
        }

        /// <summary>
        /// Gets the car repository.
        /// </summary>
        public virtual CarRespository CarRespository
        {
            get { return this.carrepo; }
        }

        /// <summary>
        /// Gets the extra repository.
        /// </summary>
        public virtual ExtraRepository ExtraRepository
        {
            get { return this.extrarepo; }
        }

        /// <summary>
        /// Gets the extra switch repository.
        /// </summary>
        public virtual CarExtraKeysRepository CarExtraKeysRepository
        {
            get { return this.carExtraKeysRepository; }
        }

        /// <summary>
        /// Returns all the table names.
        /// </summary>
        /// <returns>List of strings.</returns>
        public List<string> GetAllTableNames()
        {
            return DataBaseHandler.Instance.TablesNames;
        }
    }
}