using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Meeting_System.Models
{
    public class Room
    {
        public int ID { get; set; }
        public int MaxCapacity { get; set; }
        public virtual ICollection<Meeting> Meetings { get; set; }
        public double Latitude { get; set; }
        public double Longtitude { get; set; }
    }
}