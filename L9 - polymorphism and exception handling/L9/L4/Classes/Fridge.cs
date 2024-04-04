using System;

namespace L4
{
    /// <summary>
    /// A class for fridge data
    /// </summary>
    [Serializable]
    public class Fridge : Device
    {
        // Fridge data
        public double Capacity { get; set; }
        public string MountingType { get; set; }
        public string Freezer { get; set; }
        public double Heigth { get; set; }
        public double Width { get; set; }
        public double Depth { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="manuf">Manufactor</param>
        /// <param name="model">Model</param>
        /// <param name="energy">Energy class</param>
        /// <param name="color">Color</param>
        /// <param name="price">Price</param>
        /// <param name="cap">Capacity</param>
        /// <param name="mount">Mounting typee</param>
        /// <param name="freezer">Freezer  parameter</param>
        /// <param name="heigth">Heigth</param>
        /// <param name="width">Width</param>
        /// <param name="depth">Depth</param>
        public Fridge (string manuf, string model, string energy,
                    string color, double price, double cap, 
                    string mount, string freezer, double heigth,
                    double width, double depth)
                    : base (manuf, model, energy, color, price)
        {
            Capacity = cap;
            MountingType = mount;
            Freezer = freezer;
            Heigth = heigth;
            Width = width;
            Depth = depth;
        }

        /// <summary>
        /// Returns formatted line
        /// </summary>
        /// <returns>Line with data</returns>
        public override string ToString()
        {
            return string.Format(base.ToString() + " {0,5} | " +
                "{1,-15} | {2,-20} | {3,8} | {4,6} | {5,5} | " +
                "{6,5} | {7,10} | {8,5} |", Capacity, MountingType,
                Freezer, Heigth, Width, Depth, "", "", "");
        }

        /// <summary>
        /// Compares fridge by its heigth and model
        /// </summary>
        /// <param name="other">Other fridge</param>
        /// <returns>Comparison</returns>
        public override int CompareTo(Device other)
        {
            if (this.Model == other.Model)
            {
                if (other is Fridge)
                {
                    Fridge fridge = other as Fridge;
                    return this.Heigth.CompareTo(fridge.Heigth);
                }
                else
                {
                    return 1;
                }
            }
            return this.Model.CompareTo(other.Model);
        }

        /// <summary>
        /// Checks the equality of fridge
        /// </summary>
        /// <param name="other">Other fridge</param>
        /// <returns>True of false</returns>
        public bool Equals(Fridge other)
        {
            return Manufactor == other.Manufactor &&
                Model == other.Model &&
                EnergyClass == other.EnergyClass &&
                Color == other.Color && Price == other.Price
                && Capacity == other.Capacity &&
                MountingType == other.MountingType &&
                Freezer == other.Freezer &&
                Heigth == other.Heigth && Width == other.Width
                && Depth == other.Depth;
        }

        /// <summary>
        /// Returns hash code
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}