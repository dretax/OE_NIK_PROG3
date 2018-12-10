// <copyright file="ILogic.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CarShop.Logic
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// ILogic interface with the base methods for the logic class.
    /// Main methods are documented in the extended class.
    /// </summary>
    public interface ILogic
    {
        /// <summary>
        /// Gets all the table names.
        /// </summary>
        /// <returns>List of strings.</returns>
        List<string> GetAllTableNames();

        /// <summary>
        /// Inserts car data.
        /// </summary>
        /// <param name="brandid">.</param>
        /// <param name="name">name.</param>
        /// <param name="releasedate">r.</param>
        /// <param name="enginevolume">e.</param>
        /// <param name="horsepower">h.</param>
        /// <param name="baseprice">b.</param>
        /// <returns>True/False.</returns>
        bool InsertCarData(int brandid, string name, DateTime releasedate, int enginevolume, int horsepower, int baseprice);

        /// <summary>
        /// Inserts brand data to the db.
        /// </summary>
        /// <param name="name">n.</param>
        /// <param name="country">c.</param>
        /// <param name="url">u.</param>
        /// <param name="foundation">f.</param>
        /// <param name="annualtraffic">a.</param>
        /// <returns>True/False.</returns>
        bool InsertBrandData(string name, string country, string url, int foundation, int annualtraffic);

        /// <summary>
        /// Inserts extra data to the db.
        /// </summary>
        /// <param name="categoryname">c.</param>
        /// <param name="name">n.</param>
        /// <param name="price">p.</param>
        /// <param name="color">c2.</param>
        /// <param name="canbeusedmoretimes">c3.</param>
        /// <returns>True/False.</returns>
        bool InsertExtraData(string categoryname, string name, int price, string color, bool canbeusedmoretimes);

        /// <summary>
        /// Gets the extra data as a string.
        /// </summary>
        /// <returns>StringBuilder.</returns>
        StringBuilder GetExtrasData();

        /// <summary>
        /// Gets the brand data as a string.
        /// </summary>
        /// <returns>StringBuilder.</returns>
        StringBuilder GetBrandsData();

        /// <summary>
        /// Gets the car data in a string.
        /// </summary>
        /// <returns>StringBuilder.</returns>
        StringBuilder GetCarsData();

        /// <summary>
        /// Checks if the brand exists.
        /// </summary>
        /// <param name="iD">id.</param>
        /// <returns>True/False.</returns>
        bool CheckIfBrandExists(int iD);

        /// <summary>
        /// Checks if the car exists.
        /// </summary>
        /// <param name="iD">id.</param>
        /// <returns>True/False.</returns>
        bool CheckIfCarIDExists(int iD);

        /// <summary>
        /// Checks if the extra exists.
        /// </summary>
        /// <param name="iD">id.</param>
        /// <returns>True/False.</returns>
        bool CheckIfExtraIDExists(int iD);

        /// <summary>
        /// Deletes extra data.
        /// </summary>
        /// <param name="id">id.</param>
        /// <returns>True/False.</returns>
        bool DeleteExtraData(int id);

        /// <summary>
        /// Deletes car data.
        /// </summary>
        /// <param name="id">id.</param>
        /// <returns>True/False.</returns>
        bool DeleteCarData(int id);

        /// <summary>
        /// Deletes brand data.
        /// </summary>
        /// <param name="id">id.</param>
        /// <returns>True/False.</returns>
        bool DeleteBrandData(int id);
    }
}
