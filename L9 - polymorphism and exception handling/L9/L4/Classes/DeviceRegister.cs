using System;
using System.Collections.Generic;

namespace L4
{
    /// <summary>
    /// A class for one shop data
    /// </summary>
    [Serializable]
    public class DeviceRegister
    {
        // List of devices in a shop
        public List<Device> AllDevices = new List<Device>();

        // Shop specifications
        public string ShopName { get; set; }
        public string ShopAddress { get; set; }
        public string ShopPhone { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="devices">List of devices</param>
        /// <param name="name">Name</param>
        /// <param name="address">Address</param>
        /// <param name="phone">Phone</param>
        public DeviceRegister(List<Device> devices, string name,
            string address, string phone)
        {
            AllDevices = devices;
            ShopName = name;
            ShopAddress = address;
            ShopPhone = phone;
        }

        /// <summary>
        /// Checks if the element already exists in a list
        /// </summary>
        /// <param name="device">Device</param>
        /// <returns>True or false</returns>
        public bool Contains(Device device)
        {
            return AllDevices.Contains(device);
        }

        /// <summary>
        /// Adds element to the list
        /// </summary>
        /// <param name="device">Element</param>
        public void Add(Device device)
        {
            AllDevices.Add(device);
        }

        /// <summary>
        /// Counts all elements in a list
        /// </summary>
        /// <returns>Quantity</returns>
        public int Count()
        {
            return this.AllDevices.Count;
        }

        /// <summary>
        /// Returns device by its index from the list
        /// </summary>
        /// <param name="index">Index of element</param>
        /// <returns>Device by index</returns>
        public Device Get(int index)
        {
            return AllDevices[index];
        }
    }
}