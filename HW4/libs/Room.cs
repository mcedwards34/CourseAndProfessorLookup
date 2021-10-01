//******************************************************
// File: Room.cs
//
// Purpose: Contains the class definition for Room.
//          Contains information for room id, location,
//          and capacity.
//
// Written By: Matthew Edwards
//
// Compiler: Visual Studio 2015
//
//******************************************************

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace HW4
{
    [DataContract]
    public class Room
    {
        #region Members

        [DataMember(Name ="id")]
        private int _id;
        [DataMember(Name ="locatoin")]
        private string _location;
        [DataMember(Name ="capacity")]
        private int _capacity;

        #endregion

        //****************************************************
        // Method: Room
        //
        // Purpose: Default Constructor
        //****************************************************
        public Room()
        {
            _id = 0;
            _location = "";
            _capacity = 0;
        }

        #region Properties

        //Properties for methods
        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }

        public string Location
        {
            get { return _location; }
            set { _location = value; }
        }

        public int Capacity
        {
            get { return _capacity; }
            set { _capacity = value; }
        }

        #endregion

        //****************************************************
        // Method: ToString
        //
        // Purpose: To show information on variable members
        //****************************************************
        public override string ToString()
        {
            return "ID:" + _id + "Location:" + _location + "Capacity:" + _capacity;
        }
    }
}
