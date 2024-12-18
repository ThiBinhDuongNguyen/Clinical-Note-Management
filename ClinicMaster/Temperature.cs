using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ClinicLibrary
{
    //Creating a subclass in vital class for T
    public class Temperature : Vital
    {
        //Extended Attribute of sub class
        public double Temp { get; set; }

        //Constructor
        public Temperature(double temp)
        {
            Name = "T";
            Temp = temp;
            Value = $"{Temp}";
            Unit = "°C";
        }
        //override the Status Method of parents class(Vital)
        public override string Status
        {
            get
            {
                if (Temp < 36.5) return "(Low)";
                if (Temp > 37.2) return "(High)";
                return "";
            }
        }
        //override the Tostring Method of parents class(Vital)
        public override string ToString()
        {
            return $"{Name}: {Value} {Unit} {Status}";
        }
    }
}
