using Meeting_System.Models;
using System.Data.Entity;


namespace Meeting_System.DAL
{
    public class SystemContext : DbContext
    {
        public SystemContext() : base("SystemContext")
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Meeting> Meetings { get; set; }
        public DbSet<Room> Rooms { get; set; }
    }
}