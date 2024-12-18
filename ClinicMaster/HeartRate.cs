using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ClinicLibrary
{
    //Creating a subclass in vital class for HR
    public class HeartRate : Vital
    {
        //Extended Attribute of sub class
        public int Rate { get; set; }

        //Constructor
        public HeartRate(int rate)
        {
            Name = "HR";
            Rate = rate;
            Value = $"{Rate}";
            Unit = "bpm";
        }
        //override the status Method of parents class(Vital)
        public override string Status
        {
            get
            {
                if (Rate < 60) return "(Low)";
                if (Rate > 100) return "(High)";
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
