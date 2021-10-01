//******************************************************
// File: ProfessorCollection.cs
//
// Purpose: Contains the class definition for ProfessorCollection.
//          Contains information for the List<Professor> _professors member variable
//          and the Find(professorId) and Find(Name) methods.
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
    public class ProfessorCollection
    {
        #region Member Variables
        [DataMember(Name ="professors")]
        private List<Professor> _professors;
        #endregion

        #region Constructor
        //****************************************************
        // Method: ProfessorCollection
        //
        // Purpose: Default Constructor
        //****************************************************
        public ProfessorCollection()
        {
            _professors = new List<Professor>();
        }
        #endregion

        #region Properties
        //Properties for member variables
        public List<Professor> Professors
        {
            get { return _professors; }
            set { _professors = value; }
        }
        #endregion

        #region Methods
        //****************************************************
        // Method: ToString
        //
        // Purpose: To show information for member variables
        //****************************************************
        public override String ToString()
        {
            string output = "";
            foreach (Professor p in _professors)
            {
                output += "ID:" + p.ID + "Name:" + p.Name + "Phone:" + p.Phone;
            };
            return output;
        }

        //****************************************************
        // Method: Find
        //
        // Purpose: To search for and find Professor object by professor id
        //****************************************************
        public Professor Find(int professorId)
        {
            Professor result = _professors.Find(x => x.ID == professorId);
            if (result != null)
            {
                return result;
            }
            else
                return null;
        }

        //****************************************************
        // Method: Find
        //
        // Purpose: To search for and find Professor object by name
        //****************************************************
        public Professor Find(string Name)
        {
            Professor result = _professors.Find(x => x.Name == Name);
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
    

