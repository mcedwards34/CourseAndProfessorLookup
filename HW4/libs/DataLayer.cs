//******************************************************
// File: DataLayer.cs
//
// Purpose: Contains the class definition for DataLayer.
//          Contains information for member events for
//          adding and removing data as well as firing
//          event methods
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
using System.Runtime.Serialization.Json;
using System.IO;

namespace HW4
{
    [DataContract]
    public  class DataLayer
    {
        #region EventArgs Classes
        public class  CourseAddedEventArgs : EventArgs
        {
            public Course _course { get; set; }

            //****************************************************
            // Method: CourseAddedEventArgs
            //
            // Purpose: Constructor
            //****************************************************
            public CourseAddedEventArgs(Course c)
            {
                _course = c;
            }
        }

        public class ProfessorAddedEventArgs : EventArgs
        {
            public Professor _professor { get; set; }

            //****************************************************
            // Method: ProfessorAddedEventArgs
            //
            // Purpose: Constructor
            //****************************************************
            public ProfessorAddedEventArgs(Professor p)
            {
                _professor = p;
            }
        }

        public class RoomAddedEventArgs : EventArgs
        {
            public Room _room { get; set; }

            //****************************************************
            // Method: RoomAddedEventArgs
            //
            // Purpose: Constructor
            //****************************************************
            public RoomAddedEventArgs(Room r)
            {
                _room = r;
            }
        }

        public class CourseMeetingAddedEventArgs : EventArgs
        {
            public CourseMeeting _courseMeeting { get; set; }

            //****************************************************
            // Method: CourseMeetingAddedEventArgs
            //
            // Purpose: Constructor
            //****************************************************
            public CourseMeetingAddedEventArgs(CourseMeeting cm)
            {
                _courseMeeting = cm;
            }
        }

        public class CourseRemovedEventArgs : EventArgs
        {
            public int _courseID { get; set; }

            //****************************************************
            // Method: CourseRemovedEventArgs
            //
            // Purpose: Constructor
            //****************************************************
            public CourseRemovedEventArgs(int c)
            {
                _courseID = c;
            }
        }

        public class ProfessorRemovedEventArgs : EventArgs
        {
            public int _professorID { get; set; }

            //****************************************************
            // Method: ProfessorRemovedEventArgs
            //
            // Purpose: Constructor
            //****************************************************
            public ProfessorRemovedEventArgs(int p)
            {
                _professorID = p;
            }
        }

        public class RoomRemovedEventArgs: EventArgs
        {
            public int _roomID { get; set; }

            //****************************************************
            // Method: RoomRemovedEventArgs
            //
            // Purpose: Constructor
            //****************************************************
            public RoomRemovedEventArgs(int r)
            {
                _roomID = r;
            }
        }

        public class CourseMeetingRemovedEventArgs : EventArgs
        {
            public int _courseID { get; set; }
            public int _professorID { get; set; }
            public int _roomID { get; set; }
            public string _daytime { get; set; }

            //****************************************************
            // Method: CourseMeetingRemovedEventArgs
            //
            // Purpose: Constructor
            //****************************************************
            public CourseMeetingRemovedEventArgs(int c, int p, int r, string d)
            {
                _courseID = c;
                _professorID = p;
                _roomID = r;
                _daytime = d;
            }
        }
        #endregion

        #region Member Variables
        [DataMember(Name ="courses")]
        private CourseCollection _courses;
        [DataMember(Name ="professors")]
        private ProfessorCollection _professors;
        [DataMember(Name ="rooms")]
        private RoomCollection _rooms;
        [DataMember(Name ="courseMeetings")]
        private CourseMeetingCollection _courseMeetings;
        #endregion

        #region Properties
        public CourseCollection Courses
        {
            get { return _courses; }
            set { _courses = value; }
        }
        public ProfessorCollection Professors
        {
            get { return _professors; }
            set { _professors = value; }
        }
        public RoomCollection Rooms
        {
            get { return _rooms; }
            set { _rooms = value; }
        }
        public CourseMeetingCollection CourseMeetings
        {
            get { return _courseMeetings; }
            set { _courseMeetings = value; }
        }
        #endregion

        #region Default Constructor
        //****************************************************
        // Method: DataLayer
        //
        // Purpose: Default Constructor
        //****************************************************
        public DataLayer()
        {
            _courses = new CourseCollection();
            _professors = new ProfessorCollection();
            _rooms = new RoomCollection();
            _courseMeetings = new CourseMeetingCollection();

        }
        #endregion

        #region Member Events
        public event EventHandler<CourseAddedEventArgs> CourseAdded;
        public event EventHandler<ProfessorAddedEventArgs> ProfessorAdded;
        public event EventHandler<RoomAddedEventArgs> RoomAdded;
        public event EventHandler<CourseMeetingAddedEventArgs> CourseMeetingAdded;
        public event EventHandler<CourseRemovedEventArgs> CourseRemoved;
        public event EventHandler<ProfessorRemovedEventArgs> ProfessorRemoved;
        public event EventHandler<RoomRemovedEventArgs> RoomRemoved;
        public event EventHandler<CourseMeetingRemovedEventArgs> CourseMeetingRemoved;
        #endregion

        #region Member Methods

        //****************************************************
        // Method: Initialize
        //
        // Purpose: Deserializes JSON files into member variables
        //****************************************************
        public void Initialize()
        {
            FileStream reader;
            DataContractJsonSerializer inputJSON;
            //Initializes filestream for reading
            reader = new FileStream("testFile.json", FileMode.Open, FileAccess.Read);
            //Initializes JsonSerializer
            inputJSON = new DataContractJsonSerializer(typeof(CourseCollection));
            //Initializes course collection object to read in file
            _courses = (CourseCollection)inputJSON.ReadObject(reader);
            reader.Close();
        }

        //****************************************************
        // Method: AddCourse
        //
        // Purpose: Adds a new course to CourseCollection
        //          fires CourseAdded event
        //****************************************************
        public bool AddCourse(Course c)
        {
            //Adds course
            _courses.Courses.Add(c);

            FileStream writer;
            DataContractJsonSerializer outputJSON;
            //Initalizes filestream for writing
            writer = new FileStream("testFile.json", FileMode.Create, FileAccess.Write);
            //Initalizes json serializer
            outputJSON = new DataContractJsonSerializer(typeof(CourseCollection));
            //json serializer writes to file
            outputJSON.WriteObject(writer, _courses);
            writer.Close();

            if (CourseAdded != null)
            {
                CourseAddedEventArgs args = new CourseAddedEventArgs(c);
                //Fires event
                CourseAdded(this, args);
            }

            return true;
        }

        //****************************************************
        // Method: RemoveCourse
        //
        // Purpose: Removes course from CourseCollection
        //          fires CourseRemoved event
        //****************************************************
        void RemoveCourse (int courseID)
        {
            if (CourseRemoved == null)
                return;

            //Removes course
            _courses.Courses.Remove(_courses.Find(courseID));

            FileStream writer;
            DataContractJsonSerializer outputJSON;
            //Initalizes filestream for writing
            writer = new FileStream("testFile.json", FileMode.Create, FileAccess.Write);
            //Initalizes json serializer
            outputJSON = new DataContractJsonSerializer(typeof(CourseCollection));
            //json serializer writes to file
            outputJSON.WriteObject(writer, _courses);
            writer.Close();

            CourseRemovedEventArgs args = new CourseRemovedEventArgs(courseID);
            //Fires event
            CourseRemoved(this, args);
        }

        //****************************************************
        // Method: AddProfessor
        //
        // Purpose: Adds professor to ProfessorCollection
        //          fires ProfessorAdded event
        //****************************************************
        bool AddProfessor (Professor p)
        {
            if (ProfessorAdded == null)
                return false;

            //Adds professor
            _professors.Professors.Add(p);

            FileStream writer;
            DataContractJsonSerializer outputJSON;
            //Initalizes filestream for writing
            writer = new FileStream("testFile.json", FileMode.Create, FileAccess.Write);
            //Initalizes json serializer
            outputJSON = new DataContractJsonSerializer(typeof(ProfessorCollection));
            //json serializer writes to file
            outputJSON.WriteObject(writer, _professors);
            writer.Close();

            ProfessorAddedEventArgs args = new ProfessorAddedEventArgs(p);
            //Fires event
            ProfessorAdded(this, args);
            return true;
        }

        //****************************************************
        // Method: RemoveProfessor
        //
        // Purpose: Removes professor from ProfessorCollection
        //          fires ProfessorRemoved event
        //****************************************************
        void RemoveProfessor (int professorID)
        {
            if (ProfessorRemoved == null)
                return;

            //Removes professor
            _professors.Professors.Remove(_professors.Find(professorID));

            FileStream writer;
            DataContractJsonSerializer outputJSON;
            //Initalizes filestream for writing
            writer = new FileStream("testFile.json", FileMode.Create, FileAccess.Write);
            //Initalizes json serializer
            outputJSON = new DataContractJsonSerializer(typeof(ProfessorCollection));
            //json serializer writes to file
            outputJSON.WriteObject(writer, _professors);
            writer.Close();

            ProfessorRemovedEventArgs args = new ProfessorRemovedEventArgs(professorID);
            //Fires event
            ProfessorRemoved(this, args);
        }

        //****************************************************
        // Method: AddRoom
        //
        // Purpose: Adds room to RoomCollection
        //          fires RoomAdded event
        //****************************************************
        bool AddRoom(Room r)
        {
            if (RoomAdded == null)
                return false;

            //Adds room
            _rooms.Rooms.Add(r);

            FileStream writer;
            DataContractJsonSerializer outputJSON;
            //Initalizes filestream for writing
            writer = new FileStream("testFile.json", FileMode.Create, FileAccess.Write);
            //Initalizes json serializer
            outputJSON = new DataContractJsonSerializer(typeof(RoomCollection));
            //json serializer writes to file
            outputJSON.WriteObject(writer, _rooms);
            writer.Close();

            RoomAddedEventArgs args = new RoomAddedEventArgs(r);
            //Fires event
            RoomAdded(this, args);
            return true;
        }

        //****************************************************
        // Method: RemoveRoom
        //
        // Purpose: Removes room from RoomCollection
        //          fires RoomRemoved event
        //****************************************************
        void RemoveRoom(int roomID)
        {
            if (RoomRemoved == null)
                return;

            //Removes room
            _rooms.Rooms.Remove(_rooms.Find(roomID));

            FileStream writer;
            DataContractJsonSerializer outputJSON;
            //Initalizes filestream for writing
            writer = new FileStream("testFile.json", FileMode.Create, FileAccess.Write);
            //Initalizes json serializer
            outputJSON = new DataContractJsonSerializer(typeof(RoomCollection));
            //json serializer writes to file
            outputJSON.WriteObject(writer, _rooms);
            writer.Close();

            RoomRemovedEventArgs args = new RoomRemovedEventArgs(roomID);
            //Fires event
            RoomRemoved(this, args);

        }

        //****************************************************
        // Method: AddCourseMeeting
        //
        // Purpose: Adds course meeting to CourseMeetingCollection
        //          fires CourseMeetingAdded event
        //****************************************************
        bool AddCourseMeeting(CourseMeeting cm)
        {
            if (CourseMeetingAdded == null)
                return false;

            //Adds course meeting
            _courseMeetings.CourseMeetings.Add(cm);

            FileStream writer;
            DataContractJsonSerializer outputJSON;
            //Initalizes filestream for writing
            writer = new FileStream("testFile.json", FileMode.Create, FileAccess.Write);
            //Initalizes json serializer
            outputJSON = new DataContractJsonSerializer(typeof(CourseMeetingCollection));
            //json serializer writes to file
            outputJSON.WriteObject(writer, _courseMeetings);
            writer.Close();

            CourseMeetingAddedEventArgs args = new CourseMeetingAddedEventArgs(cm);
            //Fires event
            CourseMeetingAdded(this, args);
            return true;
        }

        //****************************************************
        // Method: RemoveCourseMeeting
        //
        // Purpose: Removes course meeting from CourseMeetingCollection
        //          fires CourseMeetingRemoved event
        //****************************************************
        void RemoveCourseMeeting(int courseID, int professorID, int roomID, string daytime)
        {
            if (CourseMeetingRemoved == null)
                return;

            //Removes course meeting
            _courseMeetings.CourseMeetings.Remove(_courseMeetings.FindByCourse(roomID));
            _courseMeetings.CourseMeetings.Remove(_courseMeetings.FindByProfessor(professorID));
            _courseMeetings.CourseMeetings.Remove(_courseMeetings.FindByRoom(roomID));
            _courseMeetings.CourseMeetings.Remove(_courseMeetings.FindByDayTime(daytime));

            FileStream writer;
            DataContractJsonSerializer outputJSON;
            //Initalizes filestream for writing
            writer = new FileStream("testFile.json", FileMode.Create, FileAccess.Write);
            //Initalizes json serializer
            outputJSON = new DataContractJsonSerializer(typeof(CourseMeetingCollection));
            //json serializer writes to file
            outputJSON.WriteObject(writer, _courseMeetings);
            writer.Close();

            CourseMeetingRemovedEventArgs args = new CourseMeetingRemovedEventArgs(courseID,professorID,roomID,daytime);
            //Fires event
            CourseMeetingRemoved(this, args);
        }
        #endregion
    }
}
