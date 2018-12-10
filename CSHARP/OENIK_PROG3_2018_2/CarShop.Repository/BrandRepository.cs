// <copyright file="BrandRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CarShop.Repository
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using CarShop.Data;

    /// <summary>
    /// Brand repository handlers.
    /// </summary>
    public class BrandRepository : IRepository<automarkak>
    {
        /// <summary>
        /// Returns all brands.
        /// </summary>
        /// <returns>automarkak.</returns>
        public virtual IQueryable<automarkak> GetAll()
        {
            return DataBaseHandler.Instance.GetAllBrands().AsQueryable<automarkak>();
        }

        /// <summary>
        /// Updates brand with the given parameters.
        /// </summary>
        /// <param name="id">id.</param>
        /// <param name="name">name.</param>
        /// <param name="country">country.</param>
        /// <param name="url">url.</param>
        /// <param name="foundation">foundation.</param>
        /// <param name="annualtraffic">traffic.</param>
        /// <returns>True/False.</returns>
        public bool Update(int id, string name, string country, string url, int foundation, int annualtraffic)
        {
            // Egy értéket keresünk
            List<automarkak> query = this.GetAll().Where(o => o.Id == id).Select(o2 => o2).ToList();
            if (query.Count > 0)
            {
                automarkak marka = query[0];
                marka.nev = name;
                marka.orszagnev = country;
                marka.url = url;
                marka.alapitaseve = foundation;
                marka.evesforgalom = annualtraffic;
                DataBaseHandler.Instance.SaveDB();
                return true;
            }

            return false;
        }

        /// <summary>
        /// Inserts car into the repository.
        /// </summary>
        /// <param name="name">name.</param>
        /// <param name="country">country.</param>
        /// <param name="url">url.</param>
        /// <param name="foundation">foundation.</param>
        /// <param name="annualtraffic">traffic.</param>
        /// <returns>True/False.</returns>
        public virtual bool Insert(string name, string country, string url, int foundation, int annualtraffic)
        {
            automarkak auto = new automarkak();
            auto.nev = name;
            auto.orszagnev = country;
            auto.url = url;
            auto.alapitaseve = foundation;
            auto.evesforgalom = annualtraffic;
            DataBaseHandler.Instance.AddNewBrand(auto);
            DataBaseHandler.Instance.SaveDB();
            return true;
        }

        /// <summary>
        /// Deletes brand from the DB.
        /// </summary>
        /// <param name="id">id.</param>
        /// <returns>True/False.</returns>
        public bool Delete(int id)
        {
            List<automarkak> query = this.GetAll().Where(o => o.Id == id).Select(o2 => o2).ToList();
            if (query.Count > 0)
            {
                DataBaseHandler.Instance.DeleteBrand(query[0]);
                DataBaseHandler.Instance.SaveDB();
                return true;
            }

            return false;
        }

        /// <summary>
        /// Returns the brand repository contents as a string.
        /// </summary>
        /// <returns>True/False.</returns>
        public StringBuilder GetTableContents()
        {
            List<automarkak> temp = this.GetAll().ToList();
            StringBuilder builder = new StringBuilder();
            foreach (var x in temp)
            {
                builder.AppendLine("-* ID: " + x.Id + " | NAME: " + x.nev + " | COUNTRY: " + x.orszagnev + " | URL: " + x.url + " | A.TRAFFIC: " +
                                   x.evesforgalom + " | F.YEAR: " + x.alapitaseve);
            }

            return builder;
        }

        /// <summary>
        /// Gets the average amount for the brand by country.
        /// </summary>
        /// <param name="countryname">country.</param>
        /// <returns>float.</returns>
        public float GetAverageAmountForBrandByCountry(string countryname)
        {
            countryname = countryname.ToLower();
            float brandcount = this.GetAll().Where(o => o.orszagnev.ToLower() == countryname).Select(o2 => o2).ToList().Count;
            float all = this.GetAll().Select(o2 => o2).ToList().Count;
            return brandcount / all;
        }

        /// <summary>
        /// Checks if the brand exists.
        /// </summary>
        /// <param name="id">id.</param>
        /// <returns>True/False.</returns>
        public bool CheckIfBrandExists(int id)
        {
            return this.GetAll().Any(o => o.Id == id);
        }
    }
}
