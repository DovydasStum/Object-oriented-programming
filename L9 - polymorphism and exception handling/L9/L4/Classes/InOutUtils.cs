using System;
using System.Collections.Generic;
using System.Web;
using System.IO;
using System.Web.UI.WebControls;
using System.Text;

namespace L4
{
    /// <summary>
    /// A class for data reading and results printing
    /// </summary>
    public static class InOutUtils
    {
        /// <summary>
        /// Reads the primary data
        /// </summary>
        /// <param name="fileName">Name of input files directory</param>
        /// <returns>All shops items</returns>
        public static List<DeviceRegister> Read(string fileName)
        {
            List<DeviceRegister> AllDevices = new List<DeviceRegister>();
            foreach (string file in Directory.GetFiles(fileName, "*.txt"))
            {
                List<Device> devicesOfOne = new List<Device>();
                string[] Lines = File.ReadAllLines(file);
                string Name = Lines[0];
                string Address = Lines[1];
                string Phone = Lines[2];
                for (int i = 3; i < Lines.Length; i++)
                {

                    string[] values = Lines[i].Split(';');
                    string type = values[0];
                    string manuf = values[1];
                    string model = values[2];
                    string energy = values[3];
                    string color = values[4];
                    double price = new double();
                    try
                    {
                        price = Convert.ToDouble(values[5]);
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(string.Format("Method {0}, Message " +
                                            "{1}, Source {2}", ex.TargetSite,
                                            ex.Message, ex.Source));
                    }
                    try
                    {
                        switch (type)
                        {
                            case "Fridge":
                                {
                                    double cap = new double();
                                    string mount = values[7];
                                    string freezer = values[8];
                                    double heigth = new double();
                                    double width = new double();
                                    double depth = new double();
                                    try
                                    {
                                        cap = Convert.ToDouble(values[6]);
                                        heigth = Convert.ToDouble(values[9]);
                                        width = Convert.ToDouble(values[10]);
                                        depth = Convert.ToDouble(values[11]);
                                    }
                                    catch (Exception ex)
                                    {
                                        throw new Exception(string.Format("Method " +
                                        "{0}, Message {1}, Source {2}", ex.TargetSite,
                                        ex.Message, ex.Source));
                                    }
                                    Fridge fr = new Fridge(manuf, model, energy,
                                        color, price, cap, mount, freezer, heigth,
                                        width, depth);
                                    devicesOfOne.Add(fr);
                                    break;
                                }
                            case "Oven":
                                {
                                    double power = new double();
                                    int prog = new int();
                                    try
                                    {
                                        power = Convert.ToDouble(values[6]);
                                        prog = Convert.ToInt32(values[7]);
                                    }
                                    catch (Exception ex)
                                    {
                                        throw new Exception(string.Format("Method " +
                                        "{0}, Message {1}, Source {2}", ex.TargetSite,
                                        ex.Message, ex.Source));
                                    }
                                    Oven ov = new Oven(manuf, model, energy,
                                        color, price, power, prog);
                                    devicesOfOne.Add(ov);
                                    break;
                                }
                            case "Kettle":
                                {
                                    double power = new double();
                                    double vol = new double();
                                    try
                                    {
                                        power = Convert.ToDouble(values[6]);
                                        vol = Convert.ToDouble(values[7]);
                                    }
                                    catch (Exception ex)
                                    {
                                        throw new Exception(string.Format("Method " +
                                        "{0}, Message {1}, Source {2}", ex.TargetSite,
                                        ex.Message, ex.Source));
                                    }
                                    Kettle ke = new Kettle(manuf, model, energy,
                                        color, price, power, vol);
                                    devicesOfOne.Add(ke);
                                    break;
                                }
                            default:
                                break;
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(string.Format(" Method {0}, Message " +
                                            "{1}, Source {2}", ex.TargetSite,
                                            ex.Message, ex.Source));
                    }
                }

                DeviceRegister device = new DeviceRegister(devicesOfOne,
                                                    Name, Address, Phone);
                AllDevices.Add(device);
            }
            return AllDevices;
        }

        /// <summary>
        /// Prints all shops data to txt file
        /// </summary>
        /// <param name="fileName">Name of output file</param>
        /// <param name="AllShops">All shops data</param>
        public static void PrintAllTXT (string fileName, string title,
                                        List<DeviceRegister> AllShops)
        {
            File.AppendAllText(fileName, title);
            foreach (DeviceRegister dev in AllShops)
            {
                PrintTXT(fileName, dev);
            }
        }

        /// <summary>
        /// Prints primary data of one shop to txt file
        /// </summary>
        /// <param name="fileName">Name of output file</param>
        /// <param name="devices">Shop items</param>
        public static void PrintTXT(string fileName,
                                    DeviceRegister devices)
        {
            string dashes = new string('-', 180);
            using (var fr = File.AppendText(fileName))
            {
                fr.WriteLine("Parduotuvės pavadinimas: " + devices.ShopName);
                fr.WriteLine("Parduotuvės adresas: " + devices.ShopAddress);
                fr.WriteLine("Parduotuvės tel. nr.: " + devices.ShopPhone);
                fr.WriteLine("Parduotuvės prekės:");
                fr.WriteLine(dashes);
                fr.WriteLine(String.Format("| {0,-15} | {1,-15} | {2,-13} " +
                "| {3,-10} | {4,-5} | {5,-5} | {6,-15} | {7,-20} " +
                "| {8,-8} | {9,-5} | {10,-5} | {11,-5} | {12,-10} | " +
                "{13,-5} |", "Gamintojas", "Modelis", "Energijos kl.",
                "Spalva", "Kaina", "Talpa", "Montavimo tipas",
                "Šaldiklis", "Aukštis", "Plotis", "Gylis", "Galia",
                "Programos", "Tūris"));
                fr.WriteLine(dashes);
                for (int i = 0; i < devices.AllDevices.Count; i++)
                {
                    fr.WriteLine(devices.AllDevices[i].ToString());
                }
                fr.WriteLine(dashes);
                fr.WriteLine();
            }
        }

        /// <summary>
        /// Prints specifications of devices of all shops to the website
        /// </summary>
        /// <param name="table">Name of table</param>
        /// <param name="dev">All shops data</param>
        public static void PrintToWeb(Table table, List<DeviceRegister> dev,
                                      TextBox t1)
        {
            foreach (DeviceRegister de in dev)
            {
                table.Rows.Add(TaskUtils.FormatRow(table, de.ShopName));
                table.Rows.Add(TaskUtils.FormatRow(table, de.ShopAddress)); 
                table.Rows.Add(TaskUtils.FormatRow(table, de.ShopPhone));
                table.Rows.Add(TaskUtils.FormatRow(table, "Prekės:"));

                table.Rows.Add(TaskUtils.FormatRowCells(table, "<b>Gamintojas</b>",
                 "<b>Modelis</b>", "<b>Energijos kl.</b>", "<b>Spalva</b>",
                 "<b>Kaina</b>", "<b>Talpa</b>", "<b>Montavimo tipas</b>",
                 "<b>Šaldiklis</b>", "<b>Aukštis</b>", "<b>Plotis</b>",
                 "<b>Gylis</b>", "<b>Galia</b>", 
                 "<b>Programos</b>", "<b>Tūris</b>"));

                PrintToWeb2(table, de, t1);
            }
        }

        /// <summary>
        /// Prints specifications of devices of one shop to the web
        /// </summary>
        /// <param name="table">Name of table</param>
        /// <param name="de">Devices lists of one shop</param>
        public static void PrintToWeb2 (Table table, DeviceRegister de, TextBox t1)
        {
            for (int i = 0; i < de.AllDevices.Count; i++)
            {
                Device deviceT = de.AllDevices[i];
                if (deviceT is Fridge)
                {
                    Fridge device = deviceT as Fridge;
                    table.Rows.Add(TaskUtils.FormatRowCells(table, device.Manufactor,
                    device.Model, device.EnergyClass, device.Color, device.Price.ToString(),
                    device.Capacity.ToString(), device.MountingType, device.Freezer,
                    device.Heigth.ToString(), device.Width.ToString(),
                    device.Depth.ToString(), "", "", ""));
                }
                if (deviceT is Oven)
                {
                    Oven device = deviceT as Oven;
                    table.Rows.Add(TaskUtils.FormatRowCells(table, device.Manufactor,
                    device.Model, device.EnergyClass, device.Color, device.Price.ToString(),
                    "", "", "", "", "", "", device.Power.ToString(),
                    device.Programes.ToString(), ""));
                }
                if (deviceT is Kettle)
                {
                    Kettle device = deviceT as Kettle;
                    table.Rows.Add(TaskUtils.FormatRowCells(table, device.Manufactor,
                    device.Model, device.EnergyClass, device.Color, device.Price.ToString(),
                    "", "", "", "", "", "", device.Power.ToString(), "",
                    device.Volume.ToString()));
                }
            }
        }

        /// <summary>
        /// Prints data about Siemens products to txt file
        /// </summary>
        /// <param name="shopName">Shop name</param>
        /// <param name="Fcount">Different fridges count</param>
        /// <param name="Kcount">Different kettles count</param>
        /// <param name="Ocount">Different ovens count</param>
        /// <param name="outputFile">Results file</param>
        public static void PrintSiemensTXT (string shopName, int Fcount,
            int Kcount, int Ocount, string outputFile)
        {
            using (var fr = File.AppendText(outputFile))
            {
                fr.WriteLine($"Parduotuvės {shopName} skirtingų Siemens įrenginių kiekis:");
                fr.WriteLine("Šaldytuvai: {0}", Fcount);
                fr.WriteLine("Mikrobangų krosnelės: {0}", Ocount);
                fr.WriteLine("Virduliai: {0}", Kcount);
                fr.WriteLine();
            }
        }

        /// <summary>
        /// Prints data about Siemens products to the website
        /// </summary>
        /// <param name="table">Table to print</param>
        /// <param name="Fcount">Fridges count</param>
        /// <param name="Ocount">Ovens count</param>
        /// <param name="Kcount">Kettles count</param>
        /// <param name="shopName">Shop name</param>
        public static void PrintSiemensWeb (Table table, int Fcount, int Ocount, 
                                            int Kcount, string shopName)
        {
            table.Rows.Add(TaskUtils.FormatRow(table, shopName));
            table.Rows.Add(TaskUtils.FormatRowCells(table, "<b>Įrenginys</b>",
             "<b>Kiekis</b>"));
            table.Rows.Add(TaskUtils.FormatRowCells(table, "Šaldytuvai", 
                                                    Fcount.ToString()));
            table.Rows.Add(TaskUtils.FormatRowCells(table, "Mikrobangų krosnelės",
                                                    Ocount.ToString()));
            table.Rows.Add(TaskUtils.FormatRowCells(table, "Virduliai", 
                                                    Kcount.ToString()));
        }

        /// <summary>
        /// Prints a list of cheapest fridges to the output txt file
        /// </summary>
        /// <param name="fileName">Name of txt output file</param>
        /// <param name="Fridges">List of fridges</param>
        public static void PrintCheapestFridgesTXT (string fileName, List<Device> Fridges)
        {
            string dashes = new string('-', 53);
            using (var fr = File.AppendText(fileName))
            {
                fr.WriteLine(dashes);
                fr.WriteLine(String.Format("| {0,-15} | {1,-15} | {2,-5} " +
                "| {3,-5} |", "Gamintojas", "Modelis", "Talpa", "Kaina"));
                fr.WriteLine(dashes);
                for (int i = 0; i < Fridges.Count; i++)
                {
                    Fridge fri = Fridges[i] as Fridge;
                    fr.WriteLine(String.Format("| {0,-15} | {1,-15} | {2,5} " +
                    "| {3,5} |", fri.Manufactor, fri.Model, fri.Capacity, fri.Price));
                }
                fr.WriteLine(dashes);
                fr.WriteLine();
            }
        }

        /// <summary>
        /// Prints the cheapest fridges to the website
        /// </summary>
        /// <param name="table">Table to print</param>
        /// <param name="Fridges">List of fridges</param>
        public static void PrintCheapestFridgesWeb (Table table, List<Device> Fridges)
        {
            table.Rows.Add(TaskUtils.FormatRowCells(table, "<b>Gamintojas</b>",
                           "<b>Modelis</b>", "<b>Talpa</b>", "<b>Kaina</b>"));
            for (int i = 0; i < Fridges.Count; i++)
            {
                Fridge fr = Fridges[i] as Fridge;
                table.Rows.Add(TaskUtils.FormatRowCells(table, fr.Manufactor, fr.Model, 
                               fr.Capacity.ToString(), fr.Price.ToString()));
            }
        }

        /// <summary>
        /// Prints devices to the txt file
        /// </summary>
        /// <param name="Devices">List of devices</param>
        /// <param name="fileName">Output file name</param>
        public static void PrintListTXT (List<Device> Devices, string fileName)
        {
            string dashes = new string('-', 180);
            using (var fr = File.AppendText(fileName))
            {
                fr.WriteLine(dashes);
                fr.WriteLine(String.Format("| {0,-15} | {1,-15} | {2,-13} " +
                "| {3,-10} | {4,-5} | {5,-5} | {6,-15} | {7,-20} " +
                "| {8,-8} | {9,-5} | {10,-5} | {11,-5} | {12,-10} | " +
                "{13,-5} |", "Gamintojas", "Modelis", "Energijos kl.",
                "Spalva", "Kaina", "Talpa", "Montavimo tipas",
                "Šaldiklis", "Aukštis", "Plotis", "Gylis", "Galia",
                "Programos", "Tūris"));
                fr.WriteLine(dashes);
                for (int i = 0; i < Devices.Count; i++)
                {
                    fr.WriteLine(Devices[i].ToString());
                }
                fr.WriteLine(dashes);
                fr.WriteLine();
            }
        }

        /// <summary>
        /// Prints devices to the CSV file
        /// </summary>
        /// <param name="Devices">List of devices</param>
        /// <param name="fileName">Output file name</param>
        public static void PrintListCSV(List<Device> Devices, string fileName)
        {
            string[] Lines = new string[Devices.Count + 1];
            Lines[0] = String.Format("{0};{1};{2};{3};{4};{5};{6};" +
                       "{7};{8};{9};{10};{11};{12};{13}", "Gamintojas",
                       "Modelis", "Energijos kl.", "Spalva", "Kaina",
                       "Talpa", "Montavimo tipas", "Šaldiklis", "Aukštis",
                       "Plotis", "Gylis", "Galia", "Programos", "Tūris");
            for (int i = 0; i < Devices.Count; i++)
            {
                Device device = Devices[i];
                if (device is Fridge)
                {
                    Fridge fridge = device as Fridge;
                    Lines[i + 1] = String.Format("{0};{1};{2};{3};{4};{5};{6};" +
                                                 "{7};{8};{9};{10}",
                               fridge.Manufactor, fridge.Model, fridge.EnergyClass,
                               fridge.Color, fridge.Price, fridge.Capacity,
                               fridge.MountingType, fridge.Freezer, fridge.Heigth,
                               fridge.Width, fridge.Depth);
                }
                else if (device is Oven)
                {
                    Oven oven = device as Oven;
                    Lines[i + 1] = String.Format("{0};{1};{2};{3};{4};{5};{6};" +
                                                "{7};{8};{9};{10};{11};{12};{13}",
                               oven.Manufactor, oven.Model, oven.EnergyClass,
                               oven.Color, oven.Price, "", "", "", "", "", "",
                               oven.Power, oven.Programes, "");
                }
                else if (device is Kettle)
                {
                    Kettle kettle = device as Kettle;
                    Lines[i + 1] = String.Format("{0};{1};{2};{3};{4};{5};{6};" +
                                                "{7};{8};{9};{10};{11};{12};{13}",
                               kettle.Manufactor, kettle.Model, kettle.EnergyClass,
                               kettle.Color, kettle.Price, "", "", "", "", "", "",
                               kettle.Power, "", kettle.Volume);
                }
            }
            File.WriteAllLines(fileName, Lines, Encoding.UTF8);
        }

    }
}