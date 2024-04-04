using System;

namespace L4
{
    /// <summary>
    /// A class for oven data
    /// </summary>
    [Serializable]
    public class Oven : Device
    {
        // Oven's data
        public double Power { get; set; }
        public int Programes { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="manuf">Manufactor</param>
        /// <param name="model">Model</param>
        /// <param name="energy">Energy class</param>
        /// <param name="color">Color</param>
        /// <param name="price">Price</param>
        /// <param name="power">Power</param>
        /// <param name="prog">Programes count</param>
        public Oven (string manuf, string model, string energy,
                    string color, double price, double power,
                    int prog) 
                    : base(manuf, model, energy, color, price)
        {
            Power = power;
            Programes = prog;
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
                "", "", "", "", "", "", Power, Programes, "");
        }

        /// <summary>
        /// Compares oven by its power and model
        /// </summary>
        /// <param name="other">Other oven</param>
        /// <returns>Comparison</returns>
        public override int CompareTo(Device other)
        {
            if (this.Model == other.Model)
            {
                if (other is Oven)
                {
                    Oven oven = other as Oven; ;
                    return this.Power.CompareTo(oven.Power);
                }
                else
                {
                    return -1;
                }
            }
            return this.Model.CompareTo(other.Model);
        }

        /// <summary>
        /// Checks the equality of oven
        /// </summary>
        /// <param name="other">Other oven</param>
        /// <returns>True of false</returns>
        public bool Equals(Oven other)
        {
            return Manufactor == other.Manufactor &&
                 Model == other.Model &&
                 EnergyClass == other.EnergyClass &&
                 Color == other.Color && Price == other.Price
                 && Power == other.Power && 
                 Programes == other.Programes;
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