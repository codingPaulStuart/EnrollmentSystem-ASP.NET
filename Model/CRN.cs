using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using spsModel.Model;

/// <summary>
/// Author: Paul Stuart
/// Date Created: 29/10/2021
/// </summary>

namespace spsModel
{
    public class CRN
    {
        private int crnCode;
        private Subject unitName;
        private int semester;
        private int year;
        private string startDate;
        private Location classDetails;
        private string lecturerDetails;

        public CRN(int crnCode, Subject unitName, int semester, int year, string startDate, Location classDetails, string lecturerDetails)
        {
            this.crnCode = crnCode;
            this.unitName = unitName;
            this.semester = semester;
            this.year = year;
            this.startDate = startDate;
            this.classDetails = classDetails;
            this.lecturerDetails = lecturerDetails;
        }

        public CRN()
        {
        }

        public int getCrnCode()
        {
            return crnCode;
        }

        public Location getClassDetails()
        {
            return classDetails;
        }

        public override string ToString()
        {
            return
                "CRN: " + crnCode + "\n" +
                "semester: " + semester + "\n" +
                "year: " + year + "\n";       
        }

        // Equals() method to determine if 2 objects are the same
   public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            if (ReferenceEquals(obj, this))
                return true;
            if (obj.GetType() != this.GetType())
                return false;
            CRN rhs = obj as CRN;
            return this.crnCode == rhs.crnCode && this.lecturerDetails == rhs.lecturerDetails && this.startDate == rhs.startDate;
        }

        // hashCode() method
        public override int GetHashCode()
        {
            return this.crnCode.GetHashCode();
        }


    }    
}