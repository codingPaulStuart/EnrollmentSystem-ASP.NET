using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Author: Alan Donehue
/// Date Created: 29/10/2021
/// </summary>

namespace spsModel
{
    /// <summary>
    /// A Class to identify and use an individual Subject object's information
    /// </summary>
    public class UnitsOfComptency
    {
        // getters and setters
        public string UnitID { get; set; }
        public string NationalCode { get; set; }
        public string SubjectName { get; set; }
        public string SubjectDescription { get; set; }

        // Constructors
        public UnitsOfComptency()
        {

        }
        public UnitsOfComptency(string unitID, string nationalCode, string subjectName, string subjectDescription)
        {
            UnitID = unitID;
            NationalCode = nationalCode;
            SubjectName = subjectName;
            SubjectDescription = subjectDescription;
        }

        public UnitsOfComptency(string unitID, string subjectName, string subjectDescription)
        {
            UnitID = unitID;
            SubjectName = subjectName;
            SubjectDescription = subjectDescription;
        }

        // toString() method for data display
        public override string ToString()
        {
            return "\nUnits of Competency" + 
                "\n| Unit ID: " + UnitID + 
                "| National Code: " + NationalCode + 
                "| Subject Name: " + SubjectName + 
                "\n| Subject Description: \n" + SubjectDescription;
        }

        // Equals() method to determine if 2 objects are the same
        public override bool Equals(object obj)
        {
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            UnitsOfComptency uoc = obj as UnitsOfComptency;
            return this.UnitID == uoc.UnitID;
        }

        // hashCode() method
        public override int GetHashCode()
        {
            return this.UnitID.GetHashCode();
        }




    }
}
