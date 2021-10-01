//******************************************************
// File: CourseCollection.cs
//
// Purpose: Contains the class definition for CourseCollection.
//          Contains information for List<Course> _courses member variable
//          and contains Find(courseId) and Find(designator,number) methods.
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
    public class CourseCollection
    {
        #region Member Variables
        [DataMember(Name = "courses")]
        private List<Course> _courses;
        #endregion

        #region Constructor
        //****************************************************
        // Method: CourseCollection
        //
        // Purpose: Default Constructor
        //****************************************************
        public CourseCollection()
        {
            _courses = new List<Course>();
        }
        #endregion

        #region Properties
        //Properties for members
        public List<Course> Courses
        {
            get { return _courses; }
            set { _courses = value; }
        }
        #endregion

        #region Methods
        //****************************************************
        // Method: ToString
        //
        // Purpose: To information on member variables
        //****************************************************
        public override string ToString()
        {
            string output = "";
            foreach(Course c in Courses)
            {
                output += " ID: " + c.ID + ", Designator: " + c.Designator + ", Number: " + c.Number + ", Title: " + c.Title + ", Description: " + c.Description + ", Credits: " + c.Credits;
            };
            return output;
        }

        //****************************************************
        // Method: Find
        //
        // Purpose: To search for and find Course object by course id
        //****************************************************
        public Course Find(int courseId) 
         {
            Course result = _courses.Find(x => x.ID == courseId);
            if (result != null)
            {
                return result;
            }
            else
                return null;
         }

        //****************************************************
        // Method: ShowHeading
        //
        // Purpose: To search for and find Course object by designator and name
        //****************************************************
        public Course Find(string designator, string Number)
        {
            Course result = _courses.Find(x => x.Designator == designator && x.Number == Number);
            if (result != null)
            {
                return result;
            }
            else
                return null;
        }
        #endregion
    }
}
