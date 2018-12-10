// <copyright file="Logic.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CarShop.Logic
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using CarShop.Repository;

    /// <summary>
    /// Contains the logic database methods.
    /// </summary>
    public class Logic : ILogic
    {
        private RepositoryHelper helper;

        /// <summary>
        /// Initializes a new instance of the <see cref="Logic"/> class.
        /// Creates the logic, and initializes it.
        /// </summary>
        public Logic()
        {
            this.helper = new RepositoryHelper();
        }

        /// <summary>
        /// Gets the RepositoryHelper instance.
        /// </summary>
        public virtual RepositoryHelper Helper
        {
            get
            {
                return this.helper;
            }
        }

        /// <summary>
        /// Returns all table names from the DB.
        /// </summary>
        /// <returns>True/False.</returns>
        public List<string> GetAllTableNames()
        {
            return this.Helper.GetAllTableNames();
        }

        /// <summary>
        /// Update's car data to the specified parameters.
        /// </summary>
        /// <param name="iD">id.</param>
        /// <param name="brandid">brand.</param>
        /// <param name="name">name.</param>
        /// <param name="releasedate">release.</param>
        /// <param name="enginevolume">engine.</param>
        /// <param name="horsepower">horse.</param>
        /// <param name="baseprice">price.</param>
        /// <returns>True/False.</returns>
        public bool UpdateCarData(int iD, int brandid, string name, DateTime releasedate, int enginevolume, int horsepower, int baseprice)
        {
            try
            {
                return this.Helper.CarRespository.Update(iD, brandid, name, releasedate, enginevolume, horsepower, baseprice);
            }
            catch (Exception ex)
            {
                Console.WriteLine("[UPDATE FAILURE] " + iD + " IDjű autó után kaptunk egy errort: " + ex);
            }

            return false;
        }

        /// <summary>
        /// Update's brand data to the specified parameters.
        /// </summary>
        /// <param name="iD">id.</param>
        /// <param name="name">name.</param>
        /// <param name="country">country.</param>
        /// <param name="url">url.</param>
        /// <param name="foundation">foundation.</param>
        /// <param name="annualtraffic">traffic.</param>
        /// <returns>True/False.</returns>
        public bool UpdateBrandData(int iD, string name, string country, string url, int foundation, int annualtraffic)
        {
            try
            {
                return this.Helper.BrandRepository.Update(iD, name, country, url, foundation, annualtraffic);
            }
            catch (Exception ex)
            {
                Console.WriteLine("[UPDATE FAILURE] " + iD + " IDjű márka után kaptunk egy errort: " + ex);
            }

            return false;
        }

        /// <summary>
        /// Update's extra data to the specified parameters.
        /// </summary>
        /// <param name="iD">id.</param>
        /// <param name="categoryname">cat.</param>
        /// <param name="name">name.</param>
        /// <param name="price">price.</param>
        /// <param name="color">color.</param>
        /// <param name="canbeusedmoretimes">moretimes.</param>
        /// <returns>True/False.</returns>
        public bool UpdateExtraData(int iD, string categoryname, string name, int price, string color, bool canbeusedmoretimes)
        {
            try
            {
                return this.Helper.ExtraRepository.Update(iD, categoryname, name, price, color, canbeusedmoretimes);
            }
            catch (Exception ex)
            {
                Console.WriteLine("[UPDATE FAILURE] " + iD + " IDjű extra után kaptunk egy errort: " + ex);
            }

            return false;
        }

        /// <summary>
        /// Inserts cardataextra.
        /// </summary>
        /// <param name="carid">carid.</param>
        /// <param name="extraid">extraid.</param>
        /// <returns>True/False.</returns>
        public bool InsertCarExtraData(int carid, int extraid)
        {
            try
            {
                return this.Helper.CarExtraKeysRepository.Insert(carid, extraid);
            }
            catch (Exception ex)
            {
                Console.WriteLine("[INSERT FAILURE] " + carid + " idjű autó után kaptunk egy errort: " + ex);
            }

            return false;
        }

        /// <summary>
        /// Inserts a car data to the db.
        /// </summary>
        /// <param name="brandid">b.</param>
        /// <param name="name">name.</param>
        /// <param name="releasedate">date.</param>
        /// <param name="enginevolume">volume.</param>
        /// <param name="horsepower">power.</param>
        /// <param name="baseprice">price.</param>
        /// <returns>True/False.</returns>
        public bool InsertCarData(int brandid, string name, DateTime releasedate, int enginevolume, int horsepower, int baseprice)
        {
            try
            {
                return this.Helper.CarRespository.Insert(brandid, name, releasedate, enginevolume, horsepower, baseprice);
            }
            catch (Exception ex)
            {
                Console.WriteLine("[INSERT FAILURE] " + name + " nevű autó után kaptunk egy errort: " + ex);
            }

            return false;
        }

        /// <summary>
        /// Inserts brand data to the db.
        /// </summary>
        /// <param name="name">name.</param>
        /// <param name="country">country.</param>
        /// <param name="url">url.</param>
        /// <param name="foundation">foundation.</param>
        /// <param name="annualtraffic">traffic.</param>
        /// <returns>True/False.</returns>
        public virtual bool InsertBrandData(string name, string country, string url, int foundation, int annualtraffic)
        {
            try
            {
                return this.Helper.BrandRepository.Insert(name, country, url, foundation, annualtraffic);
            }
            catch (Exception ex)
            {
                Console.WriteLine("[INSERT FAILURE] " + name + " nevű márka után kaptunk egy errort: " + ex);
            }

            return false;
        }

        /// <summary>
        /// Inserts extra data to the db.
        /// </summary>
        /// <param name="categoryname">cn.</param>
        /// <param name="name">name.</param>
        /// <param name="price">price.</param>
        /// <param name="color">color.</param>
        /// <param name="canbeusedmoretimes">canbeused.</param>
        /// <returns>True/False.</returns>
        public bool InsertExtraData(string categoryname, string name, int price, string color, bool canbeusedmoretimes)
        {
            try
            {
                return this.Helper.ExtraRepository.Insert(categoryname, name, price, color, canbeusedmoretimes);
            }
            catch (Exception ex)
            {
                Console.WriteLine("[INSERT FAILURE] " + name + " nevű extra után kaptunk egy errort: " + ex);
            }

            return false;
        }

        /// <summary>
        /// Deletes a car data from the db.
        /// </summary>
        /// <param name="id">id.</param>
        /// <returns>True/False.</returns>
        public bool DeleteCarData(int id)
        {
            try
            {
                return this.Helper.CarRespository.Delete(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine("[DELETE FAILURE] " + id + " ID-jű autó törlése után kaptunk egy errort: " + ex);
            }

            return false;
        }

        /// <summary>
        /// Deletes extra data from the db.
        /// </summary>
        /// <param name="id">id.</param>
        /// <returns>True/False.</returns>
        public bool DeleteExtraData(int id)
        {
            try
            {
                return this.Helper.ExtraRepository.Delete(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine("[DELETE FAILURE] " + id + " ID-jű extra törlése után kaptunk egy errort: " + ex);
            }

            return false;
        }

        /// <summary>
        /// Deletes brand from the db.
        /// </summary>
        /// <param name="id">id.</param>
        /// <returns>True/False.</returns>
        public bool DeleteBrandData(int id)
        {
            try
            {
                return this.Helper.BrandRepository.Delete(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine("[DELETE FAILURE] " + id + " ID-jű márka törlése után kaptunk egy errort: " + ex);
            }

            return false;
        }

        /// <summary>
        /// Deletes car extra data.
        /// </summary>
        /// <param name="id">id.</param>
        /// <returns>True/False.</returns>
        public bool DeleteCarExtraKey(int id)
        {
            try
            {
                return this.Helper.CarExtraKeysRepository.Delete(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine("[DELETE FAILURE] " + id + " ID-jű carextra törlése után kaptunk egy errort: " + ex);
            }

            return false;
        }

        /// <summary>
        /// Checks if the car exists.
        /// </summary>
        /// <param name="id">id.</param>
        /// <returns>True/False.</returns>
        public bool DoesCarExist(int id)
        {
            return this.Helper.CarExtraKeysRepository.DoesCarExist(id);
        }

        /// <summary>
        /// Checks if extra exists.
        /// </summary>
        /// <param name="id">id.</param>
        /// <returns>True/False.</returns>
        public bool DoesExtraExist(int id)
        {
            return this.Helper.CarExtraKeysRepository.DoesExtraExist(id);
        }

        /// <summary>
        /// Checks if the brand exists.
        /// </summary>
        /// <param name="id">id.</param>
        /// <returns>True/False.</returns>
        public bool CheckIfBrandExists(int id)
        {
            return this.Helper.BrandRepository.CheckIfBrandExists(id);
        }

        /// <summary>
        /// Checks if the car id exists.
        /// </summary>
        /// <param name="id">id.</param>
        /// <returns>True/False.</returns>
        public bool CheckIfCarIDExists(int id)
        {
            return this.Helper.CarRespository.CheckIfCarIDExists(id);
        }

        /// <summary>
        /// Checks if the extra exits.
        /// </summary>
        /// <param name="id">id.</param>
        /// <returns>True/False.</returns>
        public bool CheckIfExtraIDExists(int id)
        {
            return this.Helper.ExtraRepository.CheckIfExtraIDExist(id);
        }

        /// <summary>
        /// Returns the brand data as a string.
        /// </summary>
        /// <returns>StringBuilder.</returns>
        public StringBuilder GetBrandsData()
        {
            return this.Helper.BrandRepository.GetTableContents();
        }

        /// <summary>
        /// Returns the extra data as a string.
        /// </summary>
        /// <returns>StringBuilder.</returns>
        public StringBuilder GetExtrasData()
        {
            return this.Helper.ExtraRepository.GetTableContents();
        }

        /// <summary>
        /// Returns the car data as a string.
        /// </summary>
        /// <returns>StringBuilder.</returns>
        public StringBuilder GetCarsData()
        {
            return this.Helper.CarRespository.GetTableContents();
        }

        /// <summary>
        /// Returns the model extra data as a string.
        /// </summary>
        /// <returns>StringBuilder.</returns>
        public StringBuilder GetModelExtraKeysData()
        {
            return this.Helper.CarExtraKeysRepository.GetTableContents();
        }

        /// <summary>
        /// Gets the average amount for the brand.
        /// </summary>
        /// <param name="brandid">brand.</param>
        /// <returns>float.</returns>
        public float GetAverageAmountForBrand(int brandid)
        {
            try
            {
                return this.Helper.CarRespository.GetAverageAmountForBrand(brandid);
            }
            catch (Exception ex)
            {
                Console.WriteLine("[GetAverageAmountForBrand FAILURE] " + brandid + " " + ex);
            }

            return -1;
        }

        /// <summary>
        /// Gets the average for the extra color.
        /// </summary>
        /// <param name="color">color.</param>
        /// <returns>float.</returns>
        public float GetAverageForExtraColor(string color)
        {
            try
            {
                return this.Helper.ExtraRepository.GetAverageForExtraColor(color);
            }
            catch (Exception ex)
            {
                Console.WriteLine("[GetAverageForExtraColor FAILURE] " + color + " " + ex);
            }

            return -1;
        }

        /// <summary>
        /// Gets the average for the brand by country.
        /// </summary>
        /// <param name="country">country.</param>
        /// <returns>float.</returns>
        public float GetAverageAmountForBrandByCountry(string country)
        {
            try
            {
                return this.Helper.BrandRepository.GetAverageAmountForBrandByCountry(country);
            }
            catch (Exception ex)
            {
                Console.WriteLine("[GetAverageAmountForBrandByCountry FAILURE] " + country + " " + ex);
            }

            return -1;
        }
    }
}