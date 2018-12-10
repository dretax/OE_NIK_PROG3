// <copyright file="Menu.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CarShop.Program
{
    using System;
    using System.Collections.Generic;
    using System.Net;
    using System.Text;
    using Newtonsoft.Json;

    /// <summary>
    /// This is the class which handles the display, and base functions of the
    /// menu.
    /// </summary>
    public class Menu
    {
        private bool run = true;

        /// <summary>
        /// This method keeps the main thread alive, and displays the menu.
        /// </summary>
        internal void Watcher()
        {
            this.Help();
            while (this.run)
            {
                string s = Console.ReadLine();
                int i;
                bool b = int.TryParse(s, out i);
                while (!b)
                {
                    Console.WriteLine("Hibás Opció! Listázom a lehetőségeket.");
                    this.Help();
                    s = Console.ReadLine();
                    b = int.TryParse(s, out i);
                }

                Logic.Logic logic = new Logic.Logic();
                try
                {
                    switch (i)
                    {
                        case 1:
                        {
                            Console.WriteLine("Listázom az összes elérhető adatbázis neveket.");
                            List<string> list = logic.GetAllTableNames();
                            Console.WriteLine(string.Join(", ", list));
                            break;
                        }

                        case 2:
                        {
                            List<string> list = logic.GetAllTableNames();
                            Console.WriteLine("Írd be a tábla nevét amiből listázni szeretnél!");
                            string dbname = Console.ReadLine();
                            while (!list.Contains(dbname))
                            {
                                Console.WriteLine("Írd be a tábla nevét amiből listázni szeretnél!");
                                dbname = Console.ReadLine();
                            }

                            Console.WriteLine(dbname + " LISTÁZÁS.");
                            Console.WriteLine();
                            if (dbname == "extrak")
                            {
                                Console.WriteLine(logic.GetExtrasData());
                            }
                            else if (dbname == "modellek")
                            {
                                Console.WriteLine(logic.GetCarsData());
                            }
                            else if (dbname == "automarkak")
                            {
                                Console.WriteLine(logic.GetBrandsData());
                            }
                            else if (dbname == "modellextrakapcsolo")
                            {
                                Console.WriteLine(logic.GetModelExtraKeysData());
                            }

                            break;
                        }

                        case 3:
                        {
                            List<string> list = logic.GetAllTableNames();
                            Console.WriteLine("Írd be a tábla nevét ahova hozzá kívánsz adni értéket!");
                            string dbname = Console.ReadLine();
                            while (!list.Contains(dbname))
                            {
                                Console.WriteLine("Írd be a tábla nevét ahova hozzá kívánsz adni értéket!");
                                dbname = Console.ReadLine();
                            }

                            if (dbname == "extrak")
                            {
                                // string categoryname, string name, int price, string color, bool canbeusedmoretimes
                                Console.WriteLine("Írj be egy kategória nevet.");
                                string category = Console.ReadLine();

                                Console.WriteLine("Írj be egy nevet hozzá.");
                                string name = Console.ReadLine();

                                Console.WriteLine("Írj be egy árat.");
                                string price = Console.ReadLine();
                                int pricee;
                                bool b2 = int.TryParse(price, out pricee);
                                while (!b2)
                                {
                                    Console.WriteLine("Írj be egy árat.");
                                    price = Console.ReadLine();
                                    b2 = int.TryParse(price, out pricee);
                                }

                                Console.WriteLine("Írj be egy színt.");
                                string color = Console.ReadLine();

                                Console.WriteLine("Többször használható? 0 - Nem, 1 - Igen");
                                string canbeused = Console.ReadLine();
                                int canbeusedmorenumber;
                                bool b3 = int.TryParse(canbeused, out canbeusedmorenumber);
                                while (!b3 || (canbeusedmorenumber != 0 && canbeusedmorenumber != 1))
                                {
                                    Console.WriteLine("Többször használható? 0 - Nem, 1 - Igen");
                                    canbeused = Console.ReadLine();
                                    b3 = int.TryParse(canbeused, out canbeusedmorenumber);
                                }

                                bool success = logic.InsertExtraData(category, name, pricee, color, canbeusedmorenumber == 1);
                                string text = success ? "Sikeres bevitel." : "Sikertelen bevitel";
                                Console.WriteLine(text);
                            }
                            else if (dbname == "modellek")
                            {
                                // int brandid, string name, DateTime releasedate, int enginevolume, int horsepower, int baseprice
                                Console.WriteLine(
                                    "Ahhoz, hogy egy új autót adj hozzá, már léteznie kell a márkájának az adatbázisban. Szükséged lesz az ID-jére.");
                                Console.WriteLine("Megvan már? y / n?");
                                string yorno = Console.ReadLine();
                                if (yorno != "n")
                                {
                                    BrandDoesntExist:
                                    Console.WriteLine("Írd be a márka ID-jét!");
                                    string id = Console.ReadLine();
                                    int idy;
                                    bool b2 = int.TryParse(id, out idy);
                                    while (!b2)
                                    {
                                        Console.WriteLine("Írd be a márka ID-jét!");
                                        id = Console.ReadLine();
                                        b2 = int.TryParse(id, out idy);
                                    }

                                    if (!logic.CheckIfBrandExists(idy))
                                    {
                                        Console.WriteLine("Nem létezik a márka id!");
                                        goto BrandDoesntExist;
                                    }

                                    Console.WriteLine("Írd be az autó nevét!");
                                    string carname = Console.ReadLine();

                                    Console.WriteLine("Írd be az autó megjelenésének dátumát! (yyyy-mm-dd)");
                                    string cardate = Console.ReadLine();
                                    DateTime cardatey;
                                    bool b3 = DateTime.TryParse(cardate, out cardatey);
                                    while (!b3)
                                    {
                                        Console.WriteLine("Írd be az autó megjelenésének dátumát! (yyyy-mm-dd)");
                                        cardate = Console.ReadLine();
                                        b3 = DateTime.TryParse(cardate, out cardatey);
                                    }

                                    Console.WriteLine("Írd be az autó motortérfogatát!");
                                    string carvolume = Console.ReadLine();
                                    int carvolumey;
                                    bool b4 = int.TryParse(carvolume, out carvolumey);
                                    while (!b4)
                                    {
                                        Console.WriteLine("Írd be az autó motortérfogatát!");
                                        carvolume = Console.ReadLine();
                                        b4 = int.TryParse(carvolume, out carvolumey);
                                    }

                                    Console.WriteLine("Írd be az autó lóerejét!");
                                    string carhorse = Console.ReadLine();
                                    int carhorsey;
                                    bool b5 = int.TryParse(carhorse, out carhorsey);
                                    while (!b5)
                                    {
                                        Console.WriteLine("Írd be az autó lóerejét!");
                                        carhorse = Console.ReadLine();
                                        b5 = int.TryParse(carhorse, out carhorsey);
                                    }

                                    Console.WriteLine("Írd be az autó árát!");
                                    string carprice = Console.ReadLine();
                                    int carpricey;
                                    bool b6 = int.TryParse(carprice, out carpricey);
                                    while (!b6)
                                    {
                                        Console.WriteLine("Írd be az autó árát!");
                                        carprice = Console.ReadLine();
                                        b6 = int.TryParse(carprice, out carpricey);
                                    }

                                    bool success = logic.InsertCarData(idy, carname, cardatey, carvolumey, carhorsey, carpricey);
                                    string text = success ? "Sikeres bevitel." : "Sikertelen bevitel";
                                    Console.WriteLine(text);
                                }
                            }
                            else if (dbname == "automarkak")
                            {
                                // string name, string country, string url, int foundation, int annualtraffic
                                Console.WriteLine("Írj be egy márkanevet.");
                                string name = Console.ReadLine();

                                Console.WriteLine("Írj be egy ország nevet ahonnan származik.");
                                string country = Console.ReadLine();

                                Console.WriteLine("Írd be a weboldalát a márkának.");
                                string web = Console.ReadLine();

                                Console.WriteLine("Írd be a márka alapításának évét.");
                                string foundation = Console.ReadLine();
                                int foundationy;
                                bool b2 = int.TryParse(foundation, out foundationy);
                                while (!b2)
                                {
                                    Console.WriteLine("Írd be a márka alapításának évét.");
                                    foundation = Console.ReadLine();
                                    b2 = int.TryParse(foundation, out foundationy);
                                }

                                Console.WriteLine("Írd be a márka éves forgalmát.");
                                string annual = Console.ReadLine();
                                int annualy;
                                bool b3 = int.TryParse(annual, out annualy);
                                while (!b3)
                                {
                                    Console.WriteLine("Írd be a márka éves forgalmát.");
                                    annual = Console.ReadLine();
                                    b3 = int.TryParse(annual, out annualy);
                                }

                                bool success = logic.InsertBrandData(name, country, web, foundationy, annualy);
                                string text = success ? "Sikeres bevitel." : "Sikertelen bevitel";
                                Console.WriteLine(text);
                            }
                            else if (dbname == "modellextrakapcsolo")
                            {
                                ReAddExtraShit:
                                Console.WriteLine("Írd be melyik autó idhez adjunk hozzá extrát!");
                                string carid = Console.ReadLine();
                                int caridy;
                                bool b2 = int.TryParse(carid, out caridy);
                                while (!b2)
                                {
                                    Console.WriteLine("Írd be melyik autó idhez adjunk hozzá extrát!");
                                    carid = Console.ReadLine();
                                    b2 = int.TryParse(carid, out caridy);
                                }

                                Console.WriteLine("Írd be a hozzáadandó extra idjét!");
                                string extraid = Console.ReadLine();
                                int extraidy;
                                bool b3 = int.TryParse(extraid, out extraidy);
                                while (!b3)
                                {
                                    Console.WriteLine("Írd be a hozzáadandó extra idjét!");
                                    extraid = Console.ReadLine();
                                    b3 = int.TryParse(extraid, out extraidy);
                                }

                                if (!logic.DoesCarExist(caridy))
                                {
                                    Console.WriteLine("Az autó ID nem is létezik!");
                                    goto ReAddExtraShit;
                                }

                                if (!logic.DoesExtraExist(extraidy))
                                {
                                    Console.WriteLine("Az extra ID nem is létezik!");
                                    goto ReAddExtraShit;
                                }

                                bool success = logic.InsertCarExtraData(caridy, extraidy);
                                string text = success ? "Sikeres bevitel." : "Sikertelen bevitel";
                                Console.WriteLine(text);
                            }
                            else
                            {
                                Console.WriteLine("Hibás opció!");
                            }

                            break;
                        }

                        case 4:
                        {
                            List<string> list = logic.GetAllTableNames();
                            Console.WriteLine("Írd be a tábla nevét amiből törölni szeretnél!");
                            string dbname = Console.ReadLine();
                            while (!list.Contains(dbname))
                            {
                                Console.WriteLine("Írd be a tábla nevét amiből törölni szeretnél!");
                                dbname = Console.ReadLine();
                            }

                            Console.WriteLine("Írd be a törlendő rekord azonosítóját!");
                            string idofval = Console.ReadLine();
                            int idofvaly;
                            bool b2 = int.TryParse(idofval, out idofvaly);
                            while (!b2)
                            {
                                Console.WriteLine("Írd be a törlendő rekord azonosítóját!");
                                idofval = Console.ReadLine();
                                b2 = int.TryParse(idofval, out idofvaly);
                            }

                            bool success;
                            if (dbname == "extrak")
                            {
                                success = logic.DeleteExtraData(idofvaly);
                            }
                            else if (dbname == "automarkak")
                            {
                                success = logic.DeleteBrandData(idofvaly);
                            }
                            else if (dbname == "modellek")
                            {
                                success = logic.DeleteCarData(idofvaly);
                            }
                            else
                            {
                                Console.WriteLine("Nincs ilyen opció!");
                                return;
                            }

                            string text = success ? "Sikeres törlés." : "Sikertelen törlés";
                            Console.WriteLine(text);
                            break;
                        }

                        case 5:
                        {
                            List<string> list = logic.GetAllTableNames();
                            Console.WriteLine("Írd be a tábla nevét amiben rekordot szeretnél módosítani!");
                            string dbname = Console.ReadLine();
                            while (!list.Contains(dbname))
                            {
                                Console.WriteLine("Írd be a tábla nevét amiben rekordot szeretnél módosítani!");
                                dbname = Console.ReadLine();
                            }

                            IDDoesNotExist:
                            Console.WriteLine("Írd be a kiválasztott rekord ID-jét!");
                            string dbid = Console.ReadLine();
                            int dbidy;
                            bool b2 = int.TryParse(dbid, out dbidy);
                            while (!b2)
                            {
                                Console.WriteLine("Írd be a kiválasztott rekord ID-jét!");
                                dbid = Console.ReadLine();
                                b2 = int.TryParse(dbid, out dbidy);
                            }

                            if (dbname == "extrak")
                            {
                                if (!logic.CheckIfExtraIDExists(dbidy))
                                {
                                    Console.WriteLine("Nincs ilyen ID a " + dbname + " nevű táblában!");
                                    goto IDDoesNotExist;
                                }

                                Console.WriteLine("Írj be egy kategória nevet.");
                                string category = Console.ReadLine();

                                Console.WriteLine("Írj be egy nevet hozzá.");
                                string name = Console.ReadLine();

                                Console.WriteLine("Írj be egy árat.");
                                string price = Console.ReadLine();
                                int pricee;
                                bool b22 = int.TryParse(price, out pricee);
                                while (!b22)
                                {
                                    Console.WriteLine("Írj be egy árat.");
                                    price = Console.ReadLine();
                                    b22 = int.TryParse(price, out pricee);
                                }

                                Console.WriteLine("Írj be egy színt.");
                                string color = Console.ReadLine();

                                Console.WriteLine("Többször használható? 0 - Nem, 1 - Igen");
                                string canbeused = Console.ReadLine();
                                int canbeusedmorenumber;
                                bool b3 = int.TryParse(canbeused, out canbeusedmorenumber);
                                while (!b3 || (canbeusedmorenumber != 0 && canbeusedmorenumber != 1))
                                {
                                    Console.WriteLine("Többször használható? 0 - Nem, 1 - Igen");
                                    canbeused = Console.ReadLine();
                                    b3 = int.TryParse(canbeused, out canbeusedmorenumber);
                                }

                                bool success = logic.UpdateExtraData(dbidy, category, name, pricee, color, canbeusedmorenumber == 1);
                                string text = success ? "Sikeres update." : "Sikertelen update";
                                Console.WriteLine(text);
                            }
                            else if (dbname == "automarkak")
                            {
                                if (!logic.CheckIfBrandExists(dbidy))
                                {
                                    Console.WriteLine("Nincs ilyen ID a " + dbname + " nevű táblában!");
                                    goto IDDoesNotExist;
                                }

                                Console.WriteLine("Írj be egy márkanevet.");
                                string name = Console.ReadLine();

                                Console.WriteLine("Írj be egy ország nevet ahonnan származik.");
                                string country = Console.ReadLine();

                                Console.WriteLine("Írd be a weboldalát a márkának.");
                                string web = Console.ReadLine();

                                Console.WriteLine("Írd be a márka alapításának évét.");
                                string foundation = Console.ReadLine();
                                int foundationy;
                                bool b22 = int.TryParse(foundation, out foundationy);
                                while (!b22)
                                {
                                    Console.WriteLine("Írd be a márka alapításának évét.");
                                    foundation = Console.ReadLine();
                                    b22 = int.TryParse(foundation, out foundationy);
                                }

                                Console.WriteLine("Írd be a márka éves forgalmát.");
                                string annual = Console.ReadLine();
                                int annualy;
                                bool b3 = int.TryParse(annual, out annualy);
                                while (!b3)
                                {
                                    Console.WriteLine("Írd be a márka éves forgalmát.");
                                    annual = Console.ReadLine();
                                    b3 = int.TryParse(annual, out annualy);
                                }

                                bool success = logic.UpdateBrandData(dbidy, name, country, web, foundationy, annualy);
                                string text = success ? "Sikeres update." : "Sikertelen update";
                                Console.WriteLine(text);
                            }
                            else if (dbname == "modellek")
                            {
                                if (!logic.CheckIfCarIDExists(dbidy))
                                {
                                    Console.WriteLine("Nincs ilyen ID a " + dbname + " nevű táblában!");
                                    goto IDDoesNotExist;
                                }

                                BrandDoesntExist:
                                Console.WriteLine("Írd be a márka ID-jét!");
                                string id = Console.ReadLine();
                                int idy;
                                bool b22 = int.TryParse(id, out idy);
                                while (!b22)
                                {
                                    Console.WriteLine("Írd be a márka ID-jét!");
                                    id = Console.ReadLine();
                                    b22 = int.TryParse(id, out idy);
                                }

                                if (!logic.CheckIfBrandExists(idy))
                                {
                                    Console.WriteLine("Nem létezik a márka id!");
                                    goto BrandDoesntExist;
                                }

                                Console.WriteLine("Írd be az autó nevét!");
                                string carname = Console.ReadLine();

                                Console.WriteLine("Írd be az autó megjelenésének dátumát! (yyyy-mm-dd)");
                                string cardate = Console.ReadLine();
                                DateTime cardatey;
                                bool b3 = DateTime.TryParse(cardate, out cardatey);
                                while (!b3)
                                {
                                    Console.WriteLine("Írd be az autó megjelenésének dátumát! (yyyy-mm-dd)");
                                    cardate = Console.ReadLine();
                                    b3 = DateTime.TryParse(cardate, out cardatey);
                                }

                                Console.WriteLine("Írd be az autó motortérfogatát!");
                                string carvolume = Console.ReadLine();
                                int carvolumey;
                                bool b4 = int.TryParse(carvolume, out carvolumey);
                                while (!b4)
                                {
                                    Console.WriteLine("Írd be az autó motortérfogatát!");
                                    carvolume = Console.ReadLine();
                                    b4 = int.TryParse(carvolume, out carvolumey);
                                }

                                Console.WriteLine("Írd be az autó lóerejét!");
                                string carhorse = Console.ReadLine();
                                int carhorsey;
                                bool b5 = int.TryParse(carhorse, out carhorsey);
                                while (!b5)
                                {
                                    Console.WriteLine("Írd be az autó lóerejét!");
                                    carhorse = Console.ReadLine();
                                    b5 = int.TryParse(carhorse, out carhorsey);
                                }

                                Console.WriteLine("Írd be az autó árát!");
                                string carprice = Console.ReadLine();
                                int carpricey;
                                bool b6 = int.TryParse(carprice, out carpricey);
                                while (!b6)
                                {
                                    Console.WriteLine("Írd be az autó árát!");
                                    carprice = Console.ReadLine();
                                    b6 = int.TryParse(carprice, out carpricey);
                                }

                                bool success = logic.UpdateCarData(dbidy, idy, carname, cardatey, carvolumey, carhorsey, carpricey);
                                string text = success ? "Sikeres update." : "Sikertelen update";
                                Console.WriteLine(text);
                            }
                            else if (dbname == "modellextrakapcsolo")
                            {
                                Console.WriteLine("Írd be a törlendő carextra idjét!");
                                string extraid = Console.ReadLine();
                                int extraidy;
                                bool b3 = int.TryParse(extraid, out extraidy);
                                while (!b3)
                                {
                                    Console.WriteLine("Írd be a törlendő carextra idjét!");
                                    extraid = Console.ReadLine();
                                    b3 = int.TryParse(extraid, out extraidy);
                                }

                                bool success = logic.DeleteCarExtraKey(extraidy);
                                string text = success ? "Sikeres törlés." : "Sikertelen törlés";
                                Console.WriteLine(text);
                            }
                            else
                            {
                                Console.WriteLine("Nincs ilyen opció!");
                                return;
                            }

                            break;
                        }

                        case 6:
                        {
                            List<string> list = logic.GetAllTableNames();
                            Console.WriteLine("Írd be a tábla nevét amiben átlagot szeretnél lekérdezni!");
                            string dbname = Console.ReadLine();
                            while (!list.Contains(dbname))
                            {
                                Console.WriteLine("Írd be a tábla nevét amiben átlagot szeretnél lekérdezni!");
                                dbname = Console.ReadLine();
                            }

                            if (dbname == "extrak")
                            {
                                Console.WriteLine("Írj be egy létező extra színt! Akár lehet 'nincs' is.");
                                Console.WriteLine("Ha érvénytelen a program -1-t fog visszadobni.");
                                string color = Console.ReadLine();
                                float avg = logic.GetAverageForExtraColor(color);
                                Console.WriteLine("Átlag a " + color + " színre: " + avg);
                            }
                            else if (dbname == "automarkak")
                            {
                                BrandDoesntExist:
                                Console.WriteLine("Írd be a márka ID-jét!");
                                string id = Console.ReadLine();
                                int idy;
                                bool b22 = int.TryParse(id, out idy);
                                while (!b22)
                                {
                                    Console.WriteLine("Írd be a márka ID-jét!");
                                    id = Console.ReadLine();
                                    b22 = int.TryParse(id, out idy);
                                }

                                if (!logic.CheckIfBrandExists(idy))
                                {
                                    Console.WriteLine("Nem létezik a márka id!");
                                    goto BrandDoesntExist;
                                }

                                float avg = logic.GetAverageAmountForBrand(idy);
                                Console.WriteLine("Átlag a márkákban: " + avg);
                            }
                            else if (dbname == "modellek")
                            {
                                Console.WriteLine("Írj be egy létező ország nevet!");
                                Console.WriteLine("Ha érvénytelen a program -1-t fog visszadobni.");
                                string country = Console.ReadLine();
                                float avg = logic.GetAverageAmountForBrandByCountry(country);
                                Console.WriteLine("Átlag a " + country + " országra nézve: " + avg);
                            }
                            else
                            {
                                Console.WriteLine("Nincs ilyen opció!");
                                return;
                            }

                            break;
                        }

                        case 7:
                        {
                            WebClient client = new WebClient();
                            Console.WriteLine("Adj meg egy ár minimum értéket!");
                            string pricemin = Console.ReadLine();

                            Console.WriteLine("Adj meg egy ár maximum értéket!");
                            string pricemax = Console.ReadLine();

                            Console.WriteLine("Adj meg egy minimum év értéket!");
                            string yearmin = Console.ReadLine();

                            Console.WriteLine("Adj meg egy maximum év értéket!");
                            string yearmax = Console.ReadLine();

                            Console.WriteLine("Adj meg egy minimum motortérfogat értéket!");
                            string enginevolumemin = Console.ReadLine();

                            Console.WriteLine("Adj meg egy maximum motortérfogat értéket!");
                            string enginevolumemax = Console.ReadLine();

                            Console.WriteLine("Adj meg egy minimum lóerő értéket!");
                            string horsemin = Console.ReadLine();

                            Console.WriteLine("Adj meg egy maximum lóerő értéket!");
                            string horsemax = Console.ReadLine();

                            client.Encoding = Encoding.UTF8;
                            string fullresponse = client.DownloadString(Program.JAVAURL +
                                                                          "?releasedate=" + yearmin + "-" + yearmax +
                                                                          "&enginevolume=" + enginevolumemin + "-" + enginevolumemax +
                                                                          "&horsepower=" + horsemin + "-" + horsemax +
                                                                          "&baseprice=" + pricemin + "-" + pricemax);

                            if (fullresponse.Contains("Hiba!") || fullresponse.Contains("Hibás") || fullresponse.Contains("SYNTAX"))
                            {
                                Console.WriteLine("HIBÁS LEKÉRDEZÉS: " + fullresponse);
                            }
                            else
                            {
                                Console.WriteLine("Válasz: " + fullresponse);

                                CarJSONData car = JsonConvert.DeserializeObject<CarJSONData>(fullresponse);

                                int releasedate = int.Parse(car.RELEASEDATE);
                                int enginevolume = int.Parse(car.ENGINEVOLUME);
                                int horsepower = int.Parse(car.HORSEPOWER);
                                int baseprice = int.Parse(car.BASEPRICE);

                                BrandDoesntExist:
                                Console.WriteLine("Írd be az autó márka ID-jét!");
                                string id = Console.ReadLine();
                                int idy;
                                bool b2 = int.TryParse(id, out idy);
                                while (!b2)
                                {
                                    Console.WriteLine("Írd be az autó márka ID-jét!");
                                    id = Console.ReadLine();
                                    b2 = int.TryParse(id, out idy);
                                }

                                if (!logic.CheckIfBrandExists(idy))
                                {
                                    Console.WriteLine("Nem létezik a márka id!");
                                    goto BrandDoesntExist;
                                }

                                Console.WriteLine("Adj meg egy autó típusának nevét végül a folytatáshoz!");
                                string carname = Console.ReadLine();

                                bool success = logic.InsertCarData(idy, carname, new DateTime(releasedate, 1, 10), enginevolume, horsepower, baseprice);
                                string text = success ? "Sikeres bevitel." : "Sikertelen bevitel";
                                Console.WriteLine(text);
                            }

                            break;
                        }

                        default:
                        {
                            Console.WriteLine("Hibás Opció! Listázom a lehetőségeket.");
                            this.Help();
                            break;
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Hiba történt: " + ex.Message);
                }
            }
        }

        /// <summary>
        /// Displays the options of the menu.
        /// </summary>
        private void Help()
        {
            Console.WriteLine();
            Console.WriteLine("Válassz egy opciót (Üss be egy számot)");
            Console.WriteLine("1. Entity listázás név alapján");
            Console.WriteLine("2. Adatok listázása táblából.");
            Console.WriteLine("3. Entry hozzáadás táblához.");
            Console.WriteLine("4. Entry törlés a táblából id alapján.");
            Console.WriteLine("5. Entry update táblából, összes érték egyesével.");
            Console.WriteLine("6. Átlagolás bizonyos értékeken. (NON-CRUD)");
            Console.WriteLine("7. Java Web");
        }
    }
}