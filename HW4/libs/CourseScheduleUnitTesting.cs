//******************************************************
// File: CourseScheduleUnitTesting.cs
//
// Purpose: Contains the class definition for CourseScheduleUnitTesting.
//          Contains methods for unit testing the course class, professor
//          class, room class, and course meeting class.
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

namespace HW4
{
    public class CourseScheduleUnitTesting
    {

        #region Unit Test Methods

        public void UnitTestCourse()
        {
            Course c = new HW4.Course();
            List<Course> a = new List<Course>
            {
                new HW4.Course() {ID=0,Description="",Designator="",Title="",Number="",Credits=0 }
            };
            CourseCollection b = new CourseCollection();
            int intTest = 10;
            string stringTest = "TestString";
            

            //Sets class members to test variables
            c.ID = intTest;
            c.Designator = stringTest;
            c.Number = stringTest;
            c.Title = stringTest;
            c.Description = stringTest;
            c.Credits = intTest;
            b.Courses = a;

            //Tests class members
            if(a == b.Courses)
            {
                Console.WriteLine("Course Collection Courses Property: Pass");
            }
            else
            {
                Console.WriteLine("Course Collection Courses Property: Fail");
            }
            if (intTest == c.ID)
            {
                Console.WriteLine("Course ID Property: Pass");
            }
            else
            {
                Console.WriteLine("Course ID Property: Fail");
            }

            if (stringTest == c.Designator)
            {
                Console.WriteLine("Course Designator Property: Pass");
            }
            else
            {
                Console.WriteLine("Course Designator Property: Fail");
            }

            if (stringTest == c.Number)
            {
                Console.WriteLine("Course Number Property: Pass");
            }
            else
            {
                Console.WriteLine("Course Number Property: Fail");
            }

            if (stringTest == c.Title)
            {
                Console.WriteLine("Course Title Property: Pass");
            }
            else
            {
                Console.WriteLine("Course Title Property: Fail");
            }

            if (stringTest == c.Description)
            {
                Console.WriteLine("Course Description Property: Pass");
            }
            else
            {
                Console.WriteLine("Course Description Property: Fail");
            }

            if (intTest == c.Credits)
            {
                Console.WriteLine("Course Credits Property: Pass");
            }
            else
            {
                Console.WriteLine("Course Credits Property: Fail");
            }
        }

        public void UnitTestProfessor()
        {
            Professor p = new HW4.Professor();
            int intTest = 10;
            string stringTest = "TestString";

            //Sets class members to test variables
            p.ID = intTest;
            p.Name = stringTest;
            p.Phone = stringTest;

            //Tests class members
            if (intTest == p.ID)
            {
                Console.WriteLine("Professor ID Property: Pass");
            }
            else
            {
                Console.WriteLine("Professor ID Property: Fail");
            }

            if (stringTest == p.Name)
            {
                Console.WriteLine("Professor Name Property: Pass");
            }
            else
            {
                Console.WriteLine("Professor Name Property: Fail");
            }

            if (stringTest == p.Phone)
            {
                Console.WriteLine("Professor Phone Property: Pass");
            }
            else
            {
                Console.WriteLine("Professor Phone Property: Fail");
            }
        }

        public void UnitTestRoom()
        {
            Room r = new Room();
            int intTest = 10;
            string stringTest = "TestString";

            //Sets class members to test variables
            r.ID = intTest;
            r.Location = stringTest;
            r.Capacity = intTest;

            //Tests class members
            if (intTest == r.ID)
            {
                Console.WriteLine("Room ID Property: Pass");
            }
            else
            {
                Console.WriteLine("Room ID Property: Fail");
            }

            if (stringTest == r.Location)
            {
                Console.WriteLine("Room Location Property: Pass");
            }
            else
            {
                Console.WriteLine("Room Location Property: Fail");
            }

            if (intTest == r.Capacity)
            {
                Console.WriteLine("Room Capacity Property: Pass");
            }
            else
            {
                Console.WriteLine("Room Capacity Property: Fail");
            }

        }

        public void UnitTestCourseMeeting()
        {
            CourseMeeting cm = new CourseMeeting();
            int intTest = 10;
            string stringTest = "TestString";

            //Sets class members to test variables
            cm.RoomID = intTest;
            cm.CourseID = intTest;
            cm.ProfessorID = intTest;
            cm.DayTime = stringTest;

            //Tests class members
            if (intTest == cm.RoomID)
            {
                Console.WriteLine("Course Meeting Room ID Property: Pass");
            }
            else
            {
                Console.WriteLine("Course Meeting Room ID Property: Fail");
            }

            if (intTest == cm.CourseID)
            {
                Console.WriteLine("Course Meeting Course ID Property: Pass");
            }
            else
            {
                Console.WriteLine("Course Meeting Course ID Property: Fail");
            }

            if (intTest == cm.ProfessorID)
            {
                Console.WriteLine("Course Meeting Professor ID Property: Pass");
            }
            else
            {
                Console.WriteLine("Course Meeting Professor ID Property: Fail");
            }

            if (stringTest == cm.DayTime)
            {
                Console.WriteLine("Course Meeting Day/Time Property: Pass");
            }
            else
            {
                Console.WriteLine("Course Meeting Day/Time Property: Fail");
            }

            #endregion
        }
    }
}
