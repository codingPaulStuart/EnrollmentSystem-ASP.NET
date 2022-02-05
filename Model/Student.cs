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
     
       
      public class Student : Person
    {
        public Student()
        {

        }

        public Student(string studentID)
        {
            StudentID = studentID;
        }

        public Student( string StudentID, Person person)
         : base(person.FirstName, person.LastName, person.Email)
        {
            this.StudentID = StudentID;
        }

        public Student(Person person)
            : base(person.FirstName,  person.LastName, person.Email)
        {

    }
    public string StudentID { get; set;}

         public override bool Equals(object obj)
            {
                if (obj == null)
                    return false;
                if (ReferenceEquals(obj, this))
                    return true;
                if (obj.GetType() != this.GetType())
                    return false;
                Student studentB = obj as Student;
                return this.StudentID == studentB.StudentID;
            }
         public override int GetHashCode()
        {
            return this.StudentID.GetHashCode();
        }




   
}


 }

