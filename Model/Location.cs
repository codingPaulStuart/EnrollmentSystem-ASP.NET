using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/// <summary>
/// Author: Paul Stuart
/// Date Created: 29/10/2021
/// </summary>

namespace spsModel
{
    public class Location
    {
        private string campus;
        private string roomNumber;

        public Location(string campus, string roomNumber)
        {
            this.campus = campus;
            this.roomNumber = roomNumber;
        }

        public string getCampus()
        {
            return campus;
        }

        public string getRoomNumner()
        {
            return roomNumber;
        }

        // Equals() method to determine if 2 objects are the same
        public override bool Equals(object obj)
        {
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            Location loc = obj as Location;
            return this.campus == loc.campus && this.roomNumber == loc.roomNumber;
        }

        // hashCode() method
        public override int GetHashCode()
        {
            return this.campus.GetHashCode();
        }

        public override string ToString()
        {
            return
                "Campus: " + campus + "\n" +
                "Room Number: " + roomNumber + "\n";
        }
    }


}