// <copyright file="CarExtraKeysRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CarShop.Repository
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using CarShop.Data;

    /// <summary>
    /// Switch table repository handler for the project.
    /// </summary>
    public class CarExtraKeysRepository : IRepository<modellextrakapcsolo>
    {
        /// <summary>
        /// Returns the table contents as a string.
        /// </summary>
        /// <returns>StringBuilder.</returns>
        public StringBuilder GetTableContents()
        {
            List<modellextrakapcsolo> temp = this.GetAll().ToList();
            StringBuilder builder = new StringBuilder();
            foreach (var x in temp)
            {
                builder.AppendLine("-* ID: " + x.Id + " | MODELID: " + x.modellid + " | EXTRAID: " + x.extraid);
            }

            return builder;
        }

        /// <summary>
        /// Returns all switch values from the db.
        /// </summary>
        /// <returns>modellextrakapcsolo.</returns>
        public virtual IQueryable<modellextrakapcsolo> GetAll()
        {
            return DataBaseHandler.Instance.GetAllModelExtraKeys().AsQueryable();
        }

        /// <summary>
        /// Deletes the switch from the db.
        /// </summary>
        /// <param name="id">id.</param>
        /// <returns>True/False.</returns>
        public bool Delete(int id)
        {
            List<modellextrakapcsolo> query = DataBaseHandler.Instance.GetAllModelExtraKeys().Where(o => o.Id == id).Select(o2 => o2).ToList();
            if (query.Count > 0)
            {
                DataBaseHandler.Instance.DeleteCarExtra(query[0]);
                DataBaseHandler.Instance.SaveDB();
                return true;
            }

            return false;
        }

        /// <summary>
        /// Inserts a switch into the db.
        /// </summary>
        /// <param name="carid">carid.</param>
        /// <param name="extraid">extraid.</param>
        /// <returns>True/False.</returns>
        public bool Insert(int carid, int extraid)
        {
            List<modellextrakapcsolo> query = DataBaseHandler.Instance.GetAllModelExtraKeys().Where(o => o.Id == carid).Select(o2 => o2).ToList();
            foreach (var x in query)
            {
                if (x.extraid == extraid)
                {
                    List<extrak> extrasquery = DataBaseHandler.Instance.GetAllExtras()
                        .Where(o => o.Id == extraid && o.tobbszor_hasznalhato == 0).Select(o2 => o2).ToList();

                    // Van olyan extra a kocsin amit nem lehet többször felhasználni és olyat akarunk éppen hozzáadni.
                    if (extrasquery.Count > 0)
                    {
                        return false;
                    }
                }
            }

            modellextrakapcsolo me = new modellextrakapcsolo();
            me.modellid = carid;
            me.extraid = extraid;
            DataBaseHandler.Instance.AddNewCarExtra(me);
            DataBaseHandler.Instance.SaveDB();
            return true;
        }

        /// <summary>
        /// Checks if the car switch exists in the db.
        /// </summary>
        /// <param name="id">id.</param>
        /// <returns>True/False.</returns>
        public bool DoesCarExist(int id)
        {
            List<modellek> query = DataBaseHandler.Instance.GetAllCars().Where(o => o.Id == id).Select(o2 => o2).ToList();
            return query.Count > 0;
        }

        /// <summary>
        /// Checks if the extra switch exists in the db.
        /// </summary>
        /// <param name="id">id.</param>
        /// <returns>True/False.</returns>
        public bool DoesExtraExist(int id)
        {
            List<extrak> query = DataBaseHandler.Instance.GetAllExtras().Where(o => o.Id == id).Select(o2 => o2).ToList();
            return query.Count > 0;
        }
    }
}