using System;

namespace L4
{
    /// <summary>
    /// An abstract class for device data
    /// </summary>
    [Serializable]
    public abstract class Device : IEquatable<Device>, 
                                   IComparable<Device>
    {
        // Device data
        public string Manufactor { get; set; } 
        public string Model { get; set; }
        public string EnergyClass { get; set; }
        public string Color { get; set; }
        public double Price { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="manuf">Manufactor</param>
        /// <param name="model">Model</param>
        /// <param name="energy">Energy class</param>
        /// <param name="color">Color</param>
        /// <param name="price">Price</param>
        public Device (string manuf, string model, string energy,
                       string color, double price)
        {
            Manufactor = manuf;
            Model = model;
            EnergyClass = energy;
            Color = color;
            Price = price;
        }

        /// <summary>
        /// Returns formatted line
        /// </summary>
        /// <returns>Line with data</returns>
        public override string ToString()
        {
            return string.Format("| {0,-15} | {1,-15} | {2,-13} " +
                          "| {3,-10} | {4,5} |", Manufactor, Model, 
                          EnergyClass, Color, Price);
        }

        /// <summary>
        /// Checks the equality of two devices
        /// </summary>
        /// <param name="other">Other device</param>
        /// <returns>True or false</returns>
        public bool Equals(Device other)
        {
            return Manufactor == other.Manufactor &&
                 Model == other.Model &&
                 EnergyClass == other.EnergyClass &&
                 Color == other.Color && Price == other.Price;
        }

        /// <summary>
        /// Compares devices 
        /// </summary>
        /// <param name="other">Other device</param>
        /// <returns>Comparison</returns>
        public abstract int CompareTo(Device other);

    }
}