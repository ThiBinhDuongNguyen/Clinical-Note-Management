using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicLibrary
{
    //Adding a class Vital in the library
    public abstract class Vital
    {
        //Attributes of the class
        public string Name { get; set; }
        public string Value { get; set; }
        public string Unit { get; set; }
        public abstract string Status { get; }


        //Method of the Class
        public abstract override string ToString();
    }
}
