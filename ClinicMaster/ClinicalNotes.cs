using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicLibrary
{
    //Creating a new class in the library to create a clinical note
    public class ClinicalNotes
    {
        //Attribute of the class
        public int NoteId { get; set; }
        public string PatientName { get; set; }
        public DateTime DateofBirth { get; set; }
        public List<string> Problems { get; set; }
        public string Notes { get; set; }

        //Constructor
        public ClinicalNotes(int aNoteId, string aPatientName, DateTime aDateofBirth, List<string> aProblems, string aNotes)
        {
            //Validation for fields
            NoteId = aNoteId;
            if (string.IsNullOrWhiteSpace(aPatientName))
                throw new ArgumentException("PatientName cannot be null or whitespace");
            PatientName = aPatientName;
            if (aDateofBirth > DateTime.Now)
                throw new ArgumentException("Date of Birth cannot be in the future");
            DateofBirth = aDateofBirth;
            if (aProblems == null)
            {
                Problems = new List<string>();
            }
            else { Problems = aProblems; }

            if (string.IsNullOrWhiteSpace(aNotes))
                throw new ArgumentException("Notes cannot be null or whitespace");
            Notes = aNotes;
        }
        //Override to maintain the pattern of text in file
        public override string ToString()
        {
            string problemsProcessed = "";
            for (int i = 0; i <= Problems.Count - 1; i++)
            {
                problemsProcessed += Problems[i];
                if (i < Problems.Count - 1)
                {
                    problemsProcessed += ";";
                }
            }
            string notesProcessed = Notes.Replace("\n", ";");
            return $"{NoteId}|{PatientName}|{DateofBirth}|{problemsProcessed}|{notesProcessed}";
        }
        //Read the information from file and return corresponding object
        public static ClinicalNotes fromString(string s)
        {
            string[] parts = s.Split("|");
            int aNoteId = int.Parse(parts[0]);
            string aPatientName = parts[1];
            DateTime aDateofBirth = DateTime.Parse(parts[2]);
            List<string> aProblems = new List<string>();
            string[] problemsParts = parts[3].Split(";");
            foreach (string problem in problemsParts)
            {
                aProblems.Add(problem);
            }
            string aNotes = parts[4].Replace(";", "\n");
            ClinicalNotes note = new ClinicalNotes(aNoteId, aPatientName, aDateofBirth, aProblems, aNotes);
            return note;
        }
    }
}
