//******************************************************
// File: CourseMeeting.cs
//
// Purpose: Contains the class definition for Course.
//          Contains information for course meeting room id,
//          course id, professor id, and day/time.
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
    public class CourseMeeting
    {
        #region Members

        [DataMember(Name ="roomId")]
        private int _roomId;
        [DataMember(Name ="courseId")]
        private int _courseId;
        [DataMember(Name ="professorId")]
        private int _professorId;
        [DataMember(Name ="dayTime")]
        private string _dayTime;

        #endregion

        //****************************************************
        // Method: CourseMeeting
        //
        // Purpose: Default Constructor
        //****************************************************
        public CourseMeeting()
        {
            _roomId = 0;
            _courseId = 0;
            _professorId = 0;
            _dayTime = "";
        }

        #region Properties

        //Properties for methods
        public int RoomID
        {
            get { return _roomId; }
            set { _roomId = value; }
        }

        public int CourseID
        {
            get { return _courseId; }
            set { _courseId = value; }
        }

        public int ProfessorID
        {
            get { return _professorId; }
            set { _professorId = value; }
        }

        public string DayTime
        {
            get { return _dayTime; }
            set { _dayTime = value; }
        }

        #endregion

        //****************************************************
        // Method: ToString
        //
        // Purpose: To show information on member variables
        //****************************************************
        public override string ToString()
        {
            return "Room ID:" + _roomId + "Course ID:" + _courseId + "Professor ID:" + _professorId + "Day/Time:" + _dayTime;
        }
    }
}
