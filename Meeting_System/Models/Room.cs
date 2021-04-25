using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Meeting_System.Models
{
    public class Room
    {
        public Room()
        {
            this.Meetings = new List<Meeting>();
        }
        public int RoomId { get; set; }
        public int MaxCapacity { get; set; }
        public ICollection<Meeting> Meetings { get; set; }
        public double Latitude { get; set; }
        public double Longtitude { get; set; }
    }
}