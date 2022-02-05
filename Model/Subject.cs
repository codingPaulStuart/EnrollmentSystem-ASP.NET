using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

/// <summary>
/// Author: Jiawei Huang
/// Date Created: 29/10/2021
/// </summary>

namespace spsModel.Model
{
    public class Subject
    {
        public string subjectDescription { get; set; }
        public string subjectCode { get; set; }
        public List<UnitsOfComptency> units;


        // All-arg constructor for Subject class ** Jiawei 01/11/2021
        public Subject(string subjectDescription, string subjectCode)
        {
            this.subjectDescription = subjectDescription;
            this.subjectCode = subjectCode;

        }

        public Subject() { }

        // Overrive equal function for Subject class ** Jiawei 01/11/2021
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            if (ReferenceEquals(obj, this))
                return true;
            if (obj.GetType() != this.GetType())
                return false;

            Subject a = obj as Subject;
            return this.subjectDescription == a.subjectDescription && this.subjectCode == a.subjectCode;
        }

        public static bool operator ==(Subject x, Subject y)

        {
            return object.Equals(x, y);
        }

        public static bool operator !=(Subject x, Subject y)
        {
            return !object.Equals(x, y);
        }

        // Overrive get hash code function for Subject class ** Jiawei 01/11/2021
        public override int GetHashCode()
        {
            int hashCode = this.subjectDescription.GetHashCode() ^ this.subjectCode.GetHashCode();
            return hashCode;
        }

        



    }
}