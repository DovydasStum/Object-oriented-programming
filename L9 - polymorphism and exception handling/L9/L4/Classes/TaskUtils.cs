using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.IO;

namespace L4
{
    /// <summary>
    /// A class for calculations
    /// </summary>
    public class TaskUtils
    {
        /// <summary>
        /// Formats row with separate cells
        /// </summary>
        /// <param name="table">Table</param>
        /// <param name="cell1">First cell</param>
        /// <param name="cell2">Second cell</param>
        /// <param name="cell3">Third cell</param>
        /// <returns>formatted row with cells</returns>
        public static TableRow FormatRowCells (Table table, string cell1,
            string cell2, string cell3, string cell4, string cell5,
            string cell6, string cell7, string cell8, string cell9,
            string cell10, string cell11, string cell12, string cell13,
            string cell14)
        {
            TableRow row = new TableRow();

            TableCell cellOne = new TableCell();
            cellOne.Text = cell1;
            row.Cells.Add(cellOne);

            TableCell cellTwo = new TableCell();
            cellTwo.Text = cell2;
            row.Cells.Add(cellTwo);

            TableCell cellThree = new TableCell();
            cellThree.Text = cell3;
            row.Cells.Add(cellThree);

            TableCell cellFour = new TableCell();
            cellFour.Text = cell4;
            row.Cells.Add(cellFour);

            TableCell cellFive = new TableCell();
            cellFive.Text = cell5;
            row.Cells.Add(cellFive);

            TableCell cellSix = new TableCell();
            cellSix.Text = cell6;
            row.Cells.Add(cellSix);

            TableCell cellSeven = new TableCell();
            cellSeven.Text = cell7;
            row.Cells.Add(cellSeven);

            TableCell cellEight = new TableCell();
            cellEight.Text = cell8;
            row.Cells.Add(cellEight);

            TableCell cellNine = new TableCell();
            cellNine.Text = cell9;
            row.Cells.Add(cellNine);

            TableCell cellTen = new TableCell();
            cellTen.Text = cell10;
            row.Cells.Add(cellTen);

            TableCell cellEleven = new TableCell();
            cellEleven.Text = cell11;
            row.Cells.Add(cellEleven);

            TableCell cellTwelve = new TableCell();
            cellTwelve.Text = cell12;
            row.Cells.Add(cellTwelve);

            TableCell cellThirteen = new TableCell();
            cellThirteen.Text = cell13;
            row.Cells.Add(cellThirteen);

            TableCell cellFourteen = new TableCell();
            cellFourteen.Text = cell14;
            row.Cells.Add(cellFourteen);

            return row;
        }

        /// <summary>
        /// Formats row with separate cells
        /// </summary>
        /// <param name="table">Table</param>
        /// <param name="cell1">First cell</param>
        /// <param name="cell2">Second cell</param>
        /// <returns>formatted row with cells</returns>
        public static TableRow FormatRowCells(Table table, string cell1,
            string cell2)
        {
            TableRow row = new TableRow();

            TableCell cellOne = new TableCell();
            cellOne.Text = cell1;
            row.Cells.Add(cellOne);

            TableCell cellTwo = new TableCell();
            cellTwo.Text = cell2;
            row.Cells.Add(cellTwo);

            return row;
        }

        /// <summary>
        /// Formats row with separate cells
        /// </summary>
        /// <param name="table">Table</param>
        /// <param name="cell1">First cell</param>
        /// <param name="cell2">Second cell</param>
        /// <param name="cell3">Third cell</param>
        /// <returns>formatted row with cells</returns>
        public static TableRow FormatRowCells(Table table, string cell1,
            string cell2, string cell3, string cell4)
        {
            TableRow row = new TableRow();

            TableCell cellOne = new TableCell();
            cellOne.Text = cell1;
            row.Cells.Add(cellOne);

            TableCell cellTwo = new TableCell();
            cellTwo.Text = cell2;
            row.Cells.Add(cellTwo);

            TableCell cellThree = new TableCell();
            cellThree.Text = cell3;
            row.Cells.Add(cellThree);

            TableCell cellFour = new TableCell();
            cellFour.Text = cell4;
            row.Cells.Add(cellFour);

            return row;
        }

        /// <summary>
        /// Formats one row
        /// </summary>
        /// <param name="table">Name of table</param>
        /// <param name="rowText">Text of row</param>
        /// <returns>Formatted row</returns>
        public static TableRow FormatRow (Table table, string rowText)
        {
            TableRow row = new TableRow();
            TableCell cell = new TableCell();
            cell.Text = rowText;
            row.Cells.Add(cell);
            return row;
        }

        /// <summary>
        /// Counts different Siemens fridges, ovens and kettles in all shops
        /// </summary>
        /// <param name="AllShops">All shops data</param>
        public static void SiemensDevices (List<DeviceRegister> AllShops,
                                           string outputFile, Table table)
        {
            foreach (DeviceRegister devicesOfOne in AllShops)
            {
                int fridgeCount;
                int ovenCount;
                int kettleCount;
                SiemensOfOneShop(devicesOfOne, out fridgeCount,
                                 out ovenCount, out kettleCount);
                
                InOutUtils.PrintSiemensTXT(devicesOfOne.ShopName,
                    fridgeCount, kettleCount, ovenCount, outputFile);
                InOutUtils.PrintSiemensWeb(table, fridgeCount,
                                           kettleCount, ovenCount,
                                           devicesOfOne.ShopName);
            }
        }

        /// <summary>
        /// Counts Siemens devices of one shop
        /// </summary>
        /// <param name="devices">Devices of one shop</param>
        /// <param name="fridgeCount">Different fridges count</param>
        /// <param name="ovenCount">Different ovens count</param>
        /// <param name="kettleCount">Different kettles count</param>
        public static void SiemensOfOneShop (DeviceRegister devices,
            out int fridgeCount, out int ovenCount, out int kettleCount)
        {
            fridgeCount = 0;
            ovenCount = 0;
            kettleCount = 0;
            for (int i = 0; i < devices.AllDevices.Count(); i++)
            {
                Device de = devices.AllDevices[i];
                if (de is Fridge && de.Manufactor.TrimStart() == "Siemens")
                {
                    fridgeCount = 1 + DifferentFridgesCount(de, devices);
                }
                if (de is Oven && de.Manufactor.TrimStart() == "Siemens")
                {
                    ovenCount = 1 + DifferentOvensCount(de, devices);
                }
                if (de is Kettle && de.Manufactor.TrimStart() == "Siemens")
                {
                    kettleCount = 1 + DifferentKettlesCount(de, devices);
                }
            }
        }

        /// <summary>
        /// Counts different Siemens fridges in one shop
        /// </summary>
        /// <param name="device">One fridge to compare</param>
        /// <param name="devices">All devices of shop</param>
        /// <returns>Different fridges count</returns>
        private static int DifferentFridgesCount (Device device,
                                         DeviceRegister devices)
        {
            int count = 0;
            foreach (Device de in devices.AllDevices)
            {
                if (de is Fridge && de.Model != device.Model
                    && de.Manufactor.TrimStart() == "Siemens")
                {
                    count++;
                }
            }
            return count;
        }

        /// <summary>
        /// Counts different Siemens ovens in one shop
        /// </summary>
        /// <param name="device">One oven to compare</param>
        /// <param name="devices">All devices of shop</param>
        /// <returns>Different ovens count</returns>
        private static int DifferentOvensCount(Device device,
                                         DeviceRegister devices)
        {
            int count = 0;
            foreach (Device de in devices.AllDevices)
            {
                if (de is Oven && de.Model != device.Model
                    && de.Manufactor.TrimStart() == "Siemens")
                {
                    count++;
                }
            }
            return count;
        }

        /// <summary>
        /// Counts different Siemens kettles in one shop
        /// </summary>
        /// <param name="device">One kettle to compare</param>
        /// <param name="devices">All devices of shop</param>
        /// <returns>Different kettles count</returns>
        private static int DifferentKettlesCount(Device device,
                                         DeviceRegister devices)
        {
            int count = 0;
            foreach (Device de in devices.AllDevices)
            {
                if (de is Kettle && de.Model != device.Model
                    && de.Manufactor.TrimStart() == "Siemens")
                {
                    count++;
                }
            }
            return count;
        }

        /// <summary>
        /// Makes a list of cheapest fridges with at least 80L capacity
        /// </summary>
        /// <param name="AllShops">All shops data</param>
        /// <param name="outputFile">Txt output file</param>
        /// <param name="table">Table to print</param>
        public static List<Device> CheapestFridges (Table table,
                      List<DeviceRegister> AllShops, string outputFile)
        {
            List<Device> Fridges = new List<Device>();
            foreach (DeviceRegister dev in AllShops)
            {
                for (int i = 0; i < dev.AllDevices.Count(); i++)
                {
                    Device device = dev.AllDevices[i];
                    if (device is Fridge && !ContainsDevice(Fridges, device))
                    {
                        Fridge fridge = device as Fridge;
                        if (fridge.Capacity >= 80)
                        {
                            Fridges.Add(fridge);
                        }
                    }
                }
            }
            return Fridges;
        }

        /// <summary>
        /// Makes a list of no more than 10 elements
        /// </summary>
        /// <param name="AllFridges">List of all fridges</param>
        /// <returns>Formatted list</returns>
        public static List<Device> Formatted10 (List<Device> AllFridges)
        {
            List<Device> New = new List<Device>();
            int counter = 10;
            if (AllFridges.Count() < 10)
            {
                counter = AllFridges.Count();
            }
            for (int i = 0; i < counter; i++)
            {
                if (!New.Contains(AllFridges[i]))
                {
                    New.Add(AllFridges[i]);
                }
            }
            return New;
        }

        /// <summary>
        /// Sorts fridges list by price
        /// </summary>
        public static void SortByPrice(List<Device> fr)
        {
            bool flag = true;
            while (flag)
            {
                flag = false;
                for (int i = 0; i < fr.Count - 1; i++)
                {
                    Device a = fr[i];
                    Device b = fr[i + 1];
                    if (a.Price > b.Price)
                    {
                        fr[i] = b;
                        fr[i + 1] = a;
                        flag = true;
                    }
                }
            }
        }

        /// <summary>
        /// Makes a list of devices which are only in one shop
        /// </summary>
        /// <param name="AllShops">All shops</param>
        /// <returns>Formatted list</returns>
        public static List<Device> DevicesOnePlaceOnly (List<DeviceRegister> AllShops)
        {
            List<Device> NewList = new List<Device>();
            foreach (DeviceRegister device in AllShops)
            {
                for (int i = 0; i < device.AllDevices.Count; i++)
                {
                    Device dev = device.AllDevices[i];
                    if (IsOnePlace(dev, AllShops))
                    {
                        NewList.Add(dev);
                    }
                }
            }
            return NewList;
        }

        /// <summary>
        /// Checks if device is available in only one shop
        /// </summary>
        /// <param name="device">Device to find</param>
        /// <param name="AllShops">All shops</param>
        /// <returns>True or false</returns>
        private static bool IsOnePlace (Device device, List<DeviceRegister> AllShops)
        {
            int counter = 0;
            foreach (DeviceRegister dev in AllShops)
            {
                for (int i = 0; i < dev.AllDevices.Count; i++)
                {
                    Device de = dev.AllDevices[i];
                    if (de.Equals(device))
                    {
                        counter++;
                    }
                }
            }
            if (counter == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Makes a list of expensive devices
        /// </summary>
        /// <param name="AllShops">All shops</param>
        /// <returns>Formatted list</returns>
        public static List<Device> Expensive (List<DeviceRegister> AllShops)
        {
            List<Device> NewList = new List<Device>();
            foreach (DeviceRegister devices in AllShops)
            {
                for (int i = 0; i < devices.AllDevices.Count(); i++)
                {
                    Device device = devices.AllDevices[i];
                    if (device is Fridge && device.Price >= 1000 &&
                        !ContainsDevice(NewList, device)
                        || device is Oven && device.Price >= 500 &&
                        !ContainsDevice(NewList, device)
                        || device is Kettle && device.Price >= 50 &&
                        !ContainsDevice(NewList, device))
                    {
                        NewList.Add(device);
                    }
                }
            }
            return NewList;
        }
        
        /// <summary>
        /// Checks if the list already contains device
        /// </summary>
        /// <param name="List">List of devices</param>
        /// <param name="device">Device to find</param>
        /// <returns>True r false</returns>
        private static bool ContainsDevice (List<Device> List, Device device)
        {
            bool flag = false;
            for (int i = 0; i < List.Count(); i++)
            {
                Device de = List[i];
                if (de.Equals(device))
                {
                    flag = true;
                }
            }
            return flag;
        }

        /// <summary>
        /// Sorts the list by device cryterium
        /// </summary>
        /// <param name="List">List of devices</param>
        public static void Sort(List<Device> List)
        {
            bool flag = true;
            while (flag)
            {
                flag = false;
                for (int i = 0; i < List.Count - 1; i++)
                {
                    Device a = List[i];
                    Device b = List[i + 1];
                    if (a.CompareTo(b) > 0)
                    {
                        List[i] = b;
                        List[i + 1] = a;
                        flag = true;
                    }
                }
            }
        }
    }
}