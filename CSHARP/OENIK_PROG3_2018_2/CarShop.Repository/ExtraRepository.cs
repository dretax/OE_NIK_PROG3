// <copyright file="ExtraRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CarShop.Repository
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using CarShop.Data;

    /// <summary>
    /// Handles the extra's repository functions.
    /// </summary>
    public class ExtraRepository : IRepository<extrak>
    {
        /// <summary>
        /// Returns all the extras from the db.
        /// </summary>
        /// <returns>extrak.</returns>
        public virtual IQueryable<extrak> GetAll()
        {
            return DataBaseHandler.Instance.GetAllExtras().AsQueryable();
        }

        /// <summary>
        /// Updates the extrak's values with the given parameters.
        /// </summary>
        /// <param name="id">id.</param>
        /// <param name="categoryname">cname.</param>
        /// <param name="name">name.</param>
        /// <param name="price">price.</param>
        /// <param name="color">color.</param>
        /// <param name="canbeusedmoretimes">canbeused.</param>
        /// <returns>True/False.</returns>
        public bool Update(int id, string categoryname, string name, int price, string color, bool canbeusedmoretimes)
        {
            List<extrak> query = this.GetAll().Where(o => o.Id == id).Select(o2 => o2).ToList();
            if (query.Count > 0)
            {
                byte i = 0;
                if (canbeusedmoretimes)
                {
                    i = 1;
                }

                extrak extra = query[0];
                extra.nev = name;
                extra.kategorianev = categoryname;
                extra.ar = price;
                extra.szin = color;
                extra.tobbszor_hasznalhato = i;

                DataBaseHandler.Instance.SaveDB();
                return true;
            }

            return false;
        }

        /// <summary>
        /// Inserts Extra into the DB.
        /// </summary>
        /// <param name="categoryname">cname.</param>
        /// <param name="name">name.</param>
        /// <param name="price">price.</param>
        /// <param name="color">color.</param>
        /// <param name="canbeusedmoretimes">canbeused.</param>
        /// <returns>True/False.</returns>
        public bool Insert(string categoryname, string name, int price, string color, bool canbeusedmoretimes)
        {
            byte b = 0;
            if (canbeusedmoretimes)
            {
                b = 1;
            }

            extrak extra = new extrak();
            extra.kategorianev = categoryname;
            extra.nev = name;
            extra.ar = price;
            extra.szin = color;
            extra.tobbszor_hasznalhato = b;
            DataBaseHandler.Instance.AddNewExtra(extra);
            DataBaseHandler.Instance.SaveDB();
            return true;
        }

        /// <summary>
        /// Deletes extra from the repository.
        /// </summary>
        /// <param name="id">id.</param>
        /// <returns>True/False.</returns>
        public bool Delete(int id)
        {
            List<extrak> query = this.GetAll().Where(o => o.Id == id).Select(o2 => o2).ToList();
            if (query.Count > 0)
            {
                DataBaseHandler.Instance.DeleteExtra(query[0]);
                DataBaseHandler.Instance.SaveDB();
                return true;
            }

            return false;
        }

        /// <summary>
        /// Returns the extra repository as a string.
        /// </summary>
        /// <returns>StringBuilder.</returns>
        public StringBuilder GetTableContents()
        {
            List<extrak> temp = this.GetAll().ToList();
            StringBuilder builder = new StringBuilder();
            foreach (var x in temp)
            {
                builder.AppendLine("-* ID: " + x.Id + " | NAME: " + x.nev + " | CATEGORY: " + x.kategorianev +
                                   " | COLOR: " + x.szin + " | BASEPRICE: " +
                                   x.ar + " | CAN BE USED MULTIPLE TIMES: " + x.tobbszor_hasznalhato);
            }

            return builder;
        }

        /// <summary>
        /// Gets the average for the extra color.
        /// </summary>
        /// <param name="color">color.</param>
        /// <returns>float.</returns>
        public float GetAverageForExtraColor(string color)
        {
            color = color.ToLower();
            float brandcount = this.GetAll().Where(o => o.szin.ToLower() == color).Select(o2 => o2).ToList().Count;
            float all = this.GetAll().Select(o2 => o2).ToList().Count;
            return brandcount / all;
        }

        /// <summary>
        /// Checks if the extra exists.
        /// </summary>
        /// <param name="id">id.</param>
        /// <returns>True/False.</returns>
        public bool CheckIfExtraIDExist(int id)
        {
            return this.GetAll().Any(o => o.Id == id);
        }
    }
}