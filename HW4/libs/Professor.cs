//******************************************************
// File: Professor.cs
//
// Purpose: Contains the class definition for Professor.
//          Contains information for professor id, name,
//          and phone.
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
    public class Professor
    {
        #region Members

        [DataMember(Name ="id")]
        private int _id;
        [DataMember(Name ="name")]
        private string _name;
        [DataMember(Name ="phone")]
        private string _phone;

        #endregion

        //****************************************************
        // Method: Professor
        //
        // Purpose: Default Constructor
        //****************************************************
        public Professor()
        {
            _id = 0;
            _name = "";
            _phone = "";
        }

        #region Properties

        //Properties for methods
        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string Phone
        {
            get { return _phone; }
            set { _phone = value; }
        }

        #endregion

        //****************************************************
        // Method: ToString
        //
        // Purpose: To show information for member variables
        //****************************************************
        public override string ToString()
        {
            return "ID:" + _id + "Name:" + _name + "Phone:" + _phone;
        }
    }
}
