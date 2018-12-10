// Enable XML documentation output
// <copyright file="DataBaseHandler.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CarShop.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Handles the projects inner read-write method calls for the database.
    /// </summary>
    public class DataBaseHandler : IDisposable
    {
        /// <summary>
        /// Holds the instance of the class.
        /// </summary>
        private static DataBaseHandler instance;

        /// <summary>
        /// Holds the database model.
        /// </summary>
        private readonly carshopdatabaseEntities1 carshopdatabaseEntities1;

        /// <summary>
        /// Prevents a default instance of the <see cref="DataBaseHandler"/> class from being created.
        /// Creates an instance for the DataBaseHandler.
        /// </summary>
        private DataBaseHandler()
        {
            this.carshopdatabaseEntities1 = new carshopdatabaseEntities1();
        }

        /// <summary>
        /// Gets the instance of the DataBaseHandler.
        /// </summary>
        public static DataBaseHandler Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DataBaseHandler();
                }

                return instance;
            }
        }

        /// <summary>
        /// Gets all Table's names from the db.
        /// </summary>
        public virtual List<string> TablesNames
        {
            get
            {
                return this.carshopdatabaseEntities1.Database.SqlQuery<string>("SELECT name FROM sys.tables ORDER BY name")
                    .ToList();
            }
        }

        /// <summary>
        /// Gets the CarShopDataBase instance.
        /// </summary>
        public virtual carshopdatabaseEntities1 CarShopDataBase
        {
            get { return this.carshopdatabaseEntities1; }
        }

        /// <summary>
        /// Adds a new brand to the database.
        /// </summary>
        /// <param name="auto">car brand.</param>
        public virtual void AddNewBrand(automarkak auto)
        {
            this.carshopdatabaseEntities1.automarkak.Add(auto);
        }

        /// <summary>
        /// Adds a new extra to the database.
        /// </summary>
        /// <param name="extra">extra.</param>
        public void AddNewExtra(extrak extra)
        {
            this.carshopdatabaseEntities1.extrak.Add(extra);
        }

        /// <summary>
        /// Adds a new car.
        /// </summary>
        /// <param name="modell">model.</param>
        public void AddNewCar(modellek modell)
        {
            this.carshopdatabaseEntities1.modellek.Add(modell);
        }

        /// <summary>
        /// Adds a new car extra to the database.
        /// </summary>
        /// <param name="me">kapcsolo.</param>
        public void AddNewCarExtra(modellextrakapcsolo me)
        {
            this.carshopdatabaseEntities1.modellextrakapcsolo.Add(me);
        }

        /// <summary>
        /// Deletes brand from the db.
        /// </summary>
        /// <param name="auto">auto.</param>
        public void DeleteBrand(automarkak auto)
        {
            if (this.carshopdatabaseEntities1.automarkak.Any(o => o.Id == auto.Id))
            {
                this.carshopdatabaseEntities1.automarkak.Remove(auto);
            }
        }

        /// <summary>
        /// Deletes an extra from the db.
        /// </summary>
        /// <param name="extra">extra.</param>
        public void DeleteExtra(extrak extra)
        {
            if (this.carshopdatabaseEntities1.extrak.Any(o => o.Id == extra.Id))
            {
                this.carshopdatabaseEntities1.extrak.Remove(extra);
            }
        }

        /// <summary>
        /// Deletes a car from the db.
        /// </summary>
        /// <param name="md">md.</param>
        public virtual void DeleteCar(modellek md)
        {
            if (this.carshopdatabaseEntities1.modellek.Any(o => o.Id == md.Id))
            {
                this.carshopdatabaseEntities1.modellek.Remove(md);
            }
        }

        /// <summary>
        /// Deletes a carextra.
        /// </summary>
        /// <param name="me">me.</param>
        public void DeleteCarExtra(modellextrakapcsolo me)
        {
            if (this.carshopdatabaseEntities1.modellextrakapcsolo.Any(o => o.Id == me.Id))
            {
                this.carshopdatabaseEntities1.modellextrakapcsolo.Remove(me);
            }
        }

        /// <summary>
        /// Returns all current brands from the database.
        /// </summary>
        /// <returns>automarkak.</returns>
        public virtual List<automarkak> GetAllBrands()
        {
            var bquery = this.carshopdatabaseEntities1.automarkak.Select(o => o);
            return bquery.ToList();
        }

        /// <summary>
        /// Returns all extras from the db.
        /// </summary>
        /// <returns>extrak.</returns>
        public virtual List<extrak> GetAllExtras()
        {
            var bquery = this.carshopdatabaseEntities1.extrak.Select(o => o);
            return bquery.ToList();
        }

        /// <summary>
        /// Returns all cars from the db.
        /// </summary>
        /// <returns>modellek.</returns>
        public virtual List<modellek> GetAllCars()
        {
            var bquery = this.carshopdatabaseEntities1.modellek.Select(o => o);
            return bquery.ToList();
        }

        /// <summary>
        /// Returns all modelextras from the db.
        /// </summary>
        /// <returns>modellextrakapcsolo.</returns>
        public virtual List<modellextrakapcsolo> GetAllModelExtraKeys()
        {
            var bquery = this.carshopdatabaseEntities1.modellextrakapcsolo.Select(o => o);
            return bquery.ToList();
        }

        /// <summary>
        /// Saves the DB.
        /// </summary>
        public virtual void SaveDB()
        {
            this.carshopdatabaseEntities1.SaveChanges();
        }

        /// <inheritdoc/>
        public void Dispose()
        {
            this.carshopdatabaseEntities1.Dispose();
        }
    }
}