using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Author: Jinghua Zhong
/// Date Created: 29/10/2021
/// </summary>

namespace spsModel.Model
{

    public class Lecturer : Person
    {
        public Lecturer( string LecturerID, Person person)
         : base(person.FirstName, person.LastName, person.Email)
        {
            this.LecturerID = LecturerID;
        }

        public Lecturer(Person person)
            : base(person.FirstName,  person.LastName, person.Email)
        {

        }

    
        public string LecturerID { get; set;}
       


/*
             public static bool operator == (Lecturer x, Lecturer y)
            {
                return object.Equals(x, y);
            }

            public static bool operator !=(Lecturer x, Lecturer y)
            {
                return !object.Equals(x, y);
            }
*/
       public override bool Equals(object obj)
       {
            if (obj == null)
                return false;
            if (ReferenceEquals(obj, this))
                return true;
            if (obj.GetType() != this.GetType())
                return false;
            Lecturer lecturerB = obj as Lecturer;
            return this.LecturerID == lecturerB.LecturerID;
       }
       public override int GetHashCode()
       {
           return this.LecturerID.GetHashCode();
       }
    }
    
}


  