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
    /// This is a Class to provide data on a qualification
    /// </summary>

    public class Award
    {
        // Getters and setters
        public string AwardID { get; set; }
        public string AwardName { get; set; }
        public List<UnitsOfComptency> UnitsList;

        // Constructors
        public Award()
        {

        }
        public Award(string awardID, string awardName, List<UnitsOfComptency> unitsList)
        {
            AwardID = awardID;
            AwardName = awardName;
            UnitsList = unitsList;
        }

        public Award(string awardID, string awardName)
        {
            AwardID = awardID;
            AwardName = awardName;
        }

        // toString() method to display data        
        public override string ToString()
        {
            return "\nAward ID: " + AwardID + "| Award Name: " + AwardName;
        }

    }
}
