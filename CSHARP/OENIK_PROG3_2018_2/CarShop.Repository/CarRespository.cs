// <copyright file="CarRespository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CarShop.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using CarShop.Data;

    /// <summary>
    /// Car Repository handler of the modellek class.
    /// </summary>
    public class CarRespository : IRepository<modellek>
    {
        /// <summary>
        /// Returns all modells as queryable.
        /// </summary>
        /// <returns>modellek.</returns>
        public virtual IQueryable<modellek> GetAll()
        {
            return DataBaseHandler.Instance.GetAllCars().AsQueryable<modellek>();
        }

        /// <summary>
        /// Updates the car's repository with the given parameters.
        /// </summary>
        /// <param name="id">id.</param>
        /// <param name="brandid">brandid.</param>
        /// <param name="name">name.</param>
        /// <param name="releasedate">date.</param>
        /// <param name="enginevolume">engine.</param>
        /// <param name="horsepower">horse.</param>
        /// <param name="baseprice">price.</param>
        /// <returns>Returns False/True.</returns>
        public bool Update(int id, int brandid, string name, DateTime releasedate, int enginevolume, int horsepower, int baseprice)
        {
            List<modellek> query = this.GetAll().Where(o => o.Id == id).Select(o2 => o2).ToList();
            if (query.Count > 0)
            {
                modellek modell = query[0];
                modell.marka_id = brandid;
                modell.nev = name;
                modell.megjelenesnapja = releasedate;
                modell.motorterfogat = enginevolume;
                modell.loero = horsepower;
                modell.alapar = baseprice;

                DataBaseHandler.Instance.SaveDB();
                return true;
            }

            return false;
        }

        /// <summary>
        /// Inserts car into the db.
        /// </summary>
        /// <param name="brandid">brand.</param>
        /// <param name="name">name.</param>
        /// <param name="releasedate">date.</param>
        /// <param name="enginevolume">engine.</param>
        /// <param name="horsepower">horse.</param>
        /// <param name="baseprice">price.</param>
        /// <returns>True/False.</returns>
        public bool Insert(int brandid, string name, DateTime releasedate, int enginevolume, int horsepower, int baseprice)
        {
            modellek modell = new modellek();
            modell.marka_id = brandid;
            modell.nev = name;
            modell.megjelenesnapja = releasedate;
            modell.motorterfogat = enginevolume;
            modell.loero = horsepower;
            modell.alapar = baseprice;
            DataBaseHandler.Instance.AddNewCar(modell);
            DataBaseHandler.Instance.SaveDB();
            return true;
        }

        /// <summary>
        /// Deletes car from the db.
        /// </summary>
        /// <param name="id">id.</param>
        /// <returns>True/False.</returns>
        public bool Delete(int id)
        {
            List<modellek> query = this.GetAll().Where(o => o.Id == id).Select(o2 => o2).ToList();
            if (query.Count > 0)
            {
                DataBaseHandler.Instance.DeleteCar(query[0]);
                DataBaseHandler.Instance.SaveDB();
                return true;
            }

            return false;
        }

        /// <summary>
        /// Returns the repository as a string.
        /// </summary>
        /// <returns>StringBuilder.</returns>
        public StringBuilder GetTableContents()
        {
            List<modellek> temp = this.GetAll().ToList();
            StringBuilder builder = new StringBuilder();
            foreach (var x in temp)
            {
                builder.AppendLine("-* ID: " + x.Id + " | NAME: " + x.nev + " | BRANDID: " + x.marka_id +
                                   " | HORSEPOWER: " + x.loero + " | BASEPRICE: " +
                                   x.alapar + " | ENGINE VOLUME: " + x.motorterfogat + " |  RELEASEDATE: " +
                                   x.megjelenesnapja);
            }

            return builder;
        }

        /// <summary>
        /// Checks if the car exists in the db.
        /// </summary>
        /// <param name="id">id.</param>
        /// <returns>True/False.</returns>
        public bool CheckIfCarIDExists(int id)
        {
            return this.GetAll().Any(o => o.Id == id);
        }

        /// <summary>
        /// Returns the average amount for brands.
        /// </summary>
        /// <param name="brandId">brandid.</param>
        /// <returns>True/False.</returns>
        public float GetAverageAmountForBrand(int brandId)
        {
            float brandcount = this.GetAll().Where(o => o.marka_id == brandId).Select(o2 => o2).ToList().Count;
            float all = this.GetAll().Select(o2 => o2).ToList().Count;
            return brandcount / all;
        }
    }
}