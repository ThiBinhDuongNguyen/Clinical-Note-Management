using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicLibrary
{
    //Creating a new class to Manage(Read and Write File) clinical Notes in the library
    public class ManageClinicalNotes
    {
        //Filename
        private const string fileName = "encounter-notes.txt";
        private List<ClinicalNotes> clinicalNotesList;
        //Constructor
        public ManageClinicalNotes()
        {
            clinicalNotesList = new List<ClinicalNotes>();
            if (!File.Exists(fileName))
            {
                File.Create(fileName).Dispose();
            }
            else
            {
                string[] fileLines = File.ReadAllLines(fileName);

                // Convert the array to a list and return
                for (int i = 0; i < fileLines.Length; i++)
                {
                    clinicalNotesList.Add(ClinicalNotes.fromString(fileLines[i]));
                }
            }
        }
        //Method to create a New Unique Id automatically
        public static int GetNewNoteId()
        {
            if (!File.Exists(fileName))
                return 1;

            return File.ReadAllLines(fileName).Select(line =>
            {
                var id = line.Split('|')[0];
                return int.Parse(id);
            }).DefaultIfEmpty(0).Max() + 1;
        }
        //Method to Add clinical notes
        public void AddNewClinicalNotes(ClinicalNotes clinicalNotes)
        {
            clinicalNotesList.Add(clinicalNotes);
            File.AppendAllText(fileName, clinicalNotes.ToString() + Environment.NewLine);
        }
        //Method to Delete clinical notes
        public void DeleteClinicalNotes(int deletedId)
        {
            ClinicalNotes deletedClinicalNotes = null;
            foreach (ClinicalNotes note in clinicalNotesList)
            {
                if (note.NoteId == deletedId)
                {
                    deletedClinicalNotes = note;
                    break;
                }
            }
            clinicalNotesList.Remove(deletedClinicalNotes);
            String newContent = "";
            foreach (ClinicalNotes note in clinicalNotesList)
            {
                newContent += note.ToString() + Environment.NewLine;
            }
            File.WriteAllText(fileName, newContent);
        }
        //Method to retrive all existing notes from the file 
        public List<string> getExistingNotes()
        {
            List<string> existingNotes = new List<string>();
            try
            {
                // Ensure the file exists
                if (File.Exists(fileName))
                {
                    // Read all lines of the file into a string array
                    string[] fileLines = File.ReadAllLines(fileName);

                    // Convert the array to a list and return
                    for (int i = 0; i < fileLines.Length; i++)
                    {
                        String[] parts = fileLines[i].Split('|');
                        existingNotes.Add($"{parts[1]} (Note {parts[0]})");
                    }
                }
            }
            catch (Exception ex)
            {
            }
            return existingNotes;
        }
        //Method to retrive a single existing note corresponding to given Id
        public ClinicalNotes getExistingNotesWithId(int noteId)
        {
            foreach (ClinicalNotes note in clinicalNotesList)
            {
                if (note.NoteId == noteId)
                {
                    return note;
                }
            }
            return null;
        }
        //Method to Update existing clinical notes
        public void UpdateClinicalNotes(int updatedId, ClinicalNotes clinicalNotes)
        {
            ClinicalNotes updatedClinicalNotes = null;
            foreach (ClinicalNotes note in clinicalNotesList)
            {
                if (note.NoteId == updatedId)
                {
                    note.PatientName = clinicalNotes.PatientName;
                    note.DateofBirth = clinicalNotes.DateofBirth;
                    note.Problems = clinicalNotes.Problems;
                    note.Notes = clinicalNotes.Notes;
                    break;
                }
            }
            String newContent = "";
            foreach (ClinicalNotes note in clinicalNotesList)
            {
                newContent += note.ToString() + Environment.NewLine;
            }
            File.WriteAllText(fileName, newContent);
        }
    }
}
