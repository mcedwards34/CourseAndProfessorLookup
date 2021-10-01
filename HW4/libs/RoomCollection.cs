//******************************************************
// File: RoomCollection.cs
//
// Purpose: Contains the class definition for RoomCollection.
//          Contains information for the List<Room> _rooms member variable
//          and the Find(roomId) and Find(location) methods.
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
    public class RoomCollection
    {
        #region Member Variables
        [DataMember(Name ="rooms")]
        private List<Room> _rooms;
        #endregion

        #region Constructor
        //****************************************************
        // Method: RoomCollection
        //
        // Purpose: Default Constructor
        //****************************************************
        public RoomCollection()
        {
            _rooms = new List<Room>();
        }
        #endregion

        #region Properties
        //Properties for member variables
        public List<Room> Rooms
        {
            get { return _rooms; }
            set { _rooms = value; }
        }
        #endregion

        #region Methods
        //****************************************************
        // Method: ToString
        //
        // Purpose: To show information on variable members
        //****************************************************
        public override String ToString()
        {
            string output = "";
            foreach (Room r in _rooms)
            {
                output += "ID:" + r.ID + "Location:" + r.Location + "Capacity:" + r.Capacity;
            };
            return output;
        }

        //****************************************************
        // Method: Find
        //
        // Purpose: To search for and find Room object by room id
        //****************************************************
        public Room Find(int roomId)
        {
            Room result = _rooms.Find(x => x.ID == roomId);
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
        // Purpose: To search for and find Room object by location
        //****************************************************
        public Room Find(string Location)
        {
            Room result = _rooms.Find(x => x.Location == Location);
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
