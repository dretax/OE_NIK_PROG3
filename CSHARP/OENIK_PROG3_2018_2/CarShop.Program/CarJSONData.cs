// <copyright file="CarJSONData.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CarShop.Program
{
    /// <summary>
    /// Assistance class for the JSON Data.
    /// Basically processes the received json string from the web.
    /// </summary>
    public class CarJSONData
    {
        /// <summary>
        /// Gets or sets the release date of the car.
        /// </summary>
        public string RELEASEDATE
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the engine volume of the car.
        /// </summary>
        public string ENGINEVOLUME
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the horse power of the car.
        /// </summary>
        public string HORSEPOWER
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the base price of the car.
        /// </summary>
        public string BASEPRICE
        {
            get;
            set;
        }
    }
}