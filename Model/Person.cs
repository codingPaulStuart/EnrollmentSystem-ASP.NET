using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Author: jinghua Zhong
/// Date Created: 29/10/2021
/// </summary>
/// 
namespace spsModel.Model
{

    public class Person
    {
        public Person()
        {

        }
        
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public Person(string firstName, string lastName, string email)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Email = email;
        }
}

    /*
        public string firstName;
        public string lastName;
        public string email;

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

       public Person(string firstName, string lastName, string email)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Email = email;
        }
    */
    
}
