using System;

namespace L4
{
    /// <summary>
    /// A class for kettle data
    /// </summary>
    [Serializable]
    public class Kettle : Device
    {
        // Kettle data
        public double Power { get; set; }
        public double Volume { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="manuf">Manufactor</param>
        /// <param name="model">Model</param>
        /// <param name="energy">Energy class</param>
        /// <param name="color">Color</param>
        /// <param name="price">Price</param>
        /// <param name="power">Power</param>
        /// <param name="vol">Volume</param>
        public Kettle(string manuf, string model, string energy,
                    string color, double price, double power,
                    double vol)
                    : base(manuf, model, energy, color, price)
        {
            Power = power;
            Volume = vol;
        }

        /// <summary>
        /// Returns formatted line
        /// </summary>
        /// <returns>Line with data</returns>
        public override string ToString()
        {
            return string.Format(base.ToString() + " {0,5} | " +
                "{1,-15} | {2,-20} | {3,-8} | {4,-6} | {5,-5} |" +
                " {6,5} | {7,10} | {8,5} |",
                "", "", "", "", "", "", Power, "", Volume);
        }

        /// <summary>
        /// Compares kettle by its power and model
        /// </summary>
        /// <param name="other">Other kettle</param>
        /// <returns>Comparison</returns>
        public override int CompareTo(Device other)
        {
            if (this.Model == other.Model)
            {
                if (other is Kettle)
                {
                    Kettle kettle = other as Kettle;
                    return this.Power.CompareTo(kettle.Power);
                }
                else
                {
                    return -1;
                }
            }
            return this.Model.CompareTo(other.Model);
        }

        /// <summary>
        /// Checks the equality of kettle
        /// </summary>
        /// <param name="other">Other kettle</param>
        /// <returns>True of false</returns>
        public bool Equals(Kettle other)
        {
            return Manufactor == other.Manufactor &&
                Model == other.Model &&
                EnergyClass == other.EnergyClass &&
                Color == other.Color && Price == other.Price
                && Power == other.Power && Volume == other.Volume;
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