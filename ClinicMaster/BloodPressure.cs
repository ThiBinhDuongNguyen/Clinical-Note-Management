using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ClinicLibrary
{
    //Creating a subclass in vital class for BP
    public class BloodPressure : Vital
    {
        //Extended Attribute of sub class
        public int Systolic { get; set; }
        public int Diastolic { get; set; }

        //override the Status Method of parents class(Vital)s
        public override string Status
        {
            get
            {
                if (Systolic < 90 && Diastolic < 60) return "(Low)";
                if (Systolic > 130 && Diastolic > 80) return "(High)";
                return "";
            }
        }
        //Constructor
        public BloodPressure(int systolic, int diastolic)
        {
            Name = "BP";
            Systolic = systolic;
            Diastolic = diastolic;
            Value = $"{Systolic}/{Diastolic}";
            Unit = "mmHg";
        }
        //override the Tostring Method of parents class(Vital)
        public override string ToString()
        {
            return $"{Name}: {Value} {Unit} {Status}";
        }
    }
}
