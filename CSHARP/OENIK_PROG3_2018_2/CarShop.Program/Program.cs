// <copyright file="Program.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CarShop.Program
{
    using System.Runtime.CompilerServices;

    /// <summary>
    /// Program starts here.
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Returns the HTTP URL for the Java project.
        /// </summary>
        public const string JAVAURL = "http://localhost:8080/OENIK_PROG3_2018_2/";

        private static Menu menu;

        /// <summary>
        /// This is where the program launches.
        /// </summary>
        /// <param name="args">arguments.</param>
        public static void Main(string[] args)
        {
            menu = new Menu();
            menu.Watcher();
        }
    }
}