using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicLibrary
{
    //Creating a subclass in vital class for RR
    public class RespiratoryRate : Vital
    {
        //Extended Attribute of sub class
        public int Rate { get; set; }

        //Constructor
        public RespiratoryRate(int rate)
        {
            Name = "RR";
            Rate = rate;
            Value = $"{Rate}";
            Unit = "bpm";
        }
        //override the Status Method of parents class(Vital)
        public override string Status
        {
            get
            {
                if (Rate < 12) return "(Low)";
                if (Rate > 16) return "(High)";
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
