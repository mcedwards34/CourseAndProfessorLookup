//******************************************************
// File: CourseMeetingCollection.cs
//
// Purpose: Contains the class definition for CourseMeetingCollection.
//          Contains information for the List<CourseMeeting _courseMeetings member variable
//          and contains the FindByCourse, FindByProfessor, and FindByRoom methods.
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
    public class CourseMeetingCollection
    {
        #region Member Variables
        [DataMember(Name="courseMeetings")]
        private List<CourseMeeting> _courseMeetings;
        #endregion

        #region Constructor
        //****************************************************
        // Method: CourseMeetingCollection
        //
        // Purpose: Default Constructor
        //****************************************************
        public CourseMeetingCollection()
        {
            _courseMeetings = new List<CourseMeeting>();
        }
        #endregion

        #region Properties
        //Properties for member variables
        public List<CourseMeeting> CourseMeetings
        {
            get { return _courseMeetings; }
            set { _courseMeetings = value; }
        }
        #endregion

        #region Methods
        //****************************************************
        // Method: ToString
        //
        // Purpose: To show information on member variables
        //****************************************************
        public override string ToString()
        {
            string output = "";
            foreach (CourseMeeting cm in _courseMeetings)
            {
                output += "Room ID:" + cm.RoomID + "Course ID:" + cm.CourseID + "Professor ID:" + cm.ProfessorID + "Day/Time:" + cm.DayTime;
            };
            return output;
        }

        //****************************************************
        // Method: FindByCourse
        //
        // Purpose: To search for and find CourseMeeting object by course id
        //****************************************************
        public CourseMeeting FindByCourse(int courseId)
        {
            CourseMeeting result = _courseMeetings.Find(x => x.CourseID == courseId);
            if (result != null)
            {
                return result;
            }
            else
                return null;
        }

        //****************************************************
        // Method: FindByProfessor
        //
        // Purpose: To search for and find CourseMeeting object by professor id
        //****************************************************
        public CourseMeeting FindByProfessor(int professorId)
        {
            CourseMeeting result = _courseMeetings.Find(x => x.ProfessorID == professorId);
            if (result != null)
            {
                return result;
            }
            else
                return null;
        }

        //****************************************************
        // Method: FindByRoom
        //
        // Purpose: To search for and find CourseMeeting object by room id
        //****************************************************
        public CourseMeeting FindByRoom(int roomId)
        {
            CourseMeeting result = _courseMeetings.Find(x => x.RoomID == roomId);
            if (result != null)
            {
                return result;
            }
            else
                return null;
        }

        public CourseMeeting FindByDayTime(string daytime)
        {
            CourseMeeting result = _courseMeetings.Find(x => x.DayTime == daytime);
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
