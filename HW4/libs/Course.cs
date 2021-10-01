//******************************************************
// File: Course.cs
//
// Purpose: Contains the class definition for Course.
//          Contains information for course id, designator,
//          number, title, descripton, and credits.
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
    public class Course
    {
        #region Members

        [DataMember(Name ="id")]
        private int _id;
        [DataMember(Name ="designator")]
        private string _designator;
        [DataMember(Name ="number")]
        private string _number;
        [DataMember(Name ="title")]
        private string _title;
        [DataMember(Name ="description")]
        private string _description;
        [DataMember(Name ="credits")]
        private int _credits;

        #endregion

        //****************************************************
        // Method: Course
        //
        // Purpose: Default Constructor
        //****************************************************
        public Course()
        {
            _id = 0;
            _designator = "";
            _number = "";
            _title = "";
            _description = "";
            _credits = 0;
        }

        #region Properties

        //Properties for member variables
        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }

        public string Designator
        {
            get { return _designator; }
            set { _designator = value; }
        }

        public string Number
        {
            get { return _number; }
            set { _number = value; }
        }

        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }

        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        public int Credits
        {
            get { return _credits; }
            set { _credits = value; }
        }

        #endregion

        //****************************************************
        // Method: ToString
        //
        // Purpose: To show information on member variables
        //****************************************************
        public override string ToString()
        {
            return "ID:" + _id + "Designator:" + _designator + "Number:" + _number + "Title:" + _title + "Description:" + _description + "Credits:" + _credits;
        }
    }
}
