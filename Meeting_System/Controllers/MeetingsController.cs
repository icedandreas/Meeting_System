using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Meeting_System.DAL;
using Meeting_System.Models;
using System.Data.Entity.Infrastructure;

namespace Meeting_System.Controllers
{
    public class MeetingsController : Controller
    {
        private SystemContext db = new SystemContext();

        // GET: Meetings
        public ActionResult Index()
        {
            return View(db.Meetings.ToList());
        }

        // GET: Meetings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Meeting meeting = db.Meetings.Find(id);
            if (meeting == null)
            {
                return HttpNotFound();
            }
            return View(meeting);
        }

        // GET: Meetings/Create
        public ActionResult Create()
        {
            var meeting = new Meeting();
            meeting.Users = new List<User>();
            PopulateAssignedUserData(meeting);
            return View();
        }

        // POST: Meetings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Title,Description,MeetingStart,MeetingDuration,RoomId")] Meeting meeting, string[] selectedUsers)
        {
            if (selectedUsers != null)
            {
                meeting.Users = new List<User>();
                foreach (var user in selectedUsers)
                {
                    var userToAdd = db.Users.Find(int.Parse(user));
                    meeting.Users.Add(userToAdd);
                }
                
                var selectedRoom = db.Rooms.Find(meeting.RoomId);
                if (meeting.Users.Count > selectedRoom.MaxCapacity || meeting.MeetingStart <= DateTime.Now)//The meeting is not created if the room doesn't have enough capacity.
                {
                    PopulateAssignedUserData(meeting);
                    return View(meeting);
                }
            }
            if (ModelState.IsValid)
            {
                db.Meetings.Add(meeting);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            PopulateAssignedUserData(meeting);
            return View(meeting);//Remember to add a check for room capacity and another check for meetingstart
        }

        // GET: Meetings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Meeting meeting = db.Meetings
                .Include(u => u.Users)
                .Where(u => u.MeetingId == id)
                .Single();
            PopulateAssignedUserData(meeting);
            if (meeting == null)
            {
                return HttpNotFound();
            }
            return View(meeting);
        }

        // POST: Meetings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int? id, string[] selectedUsers)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var meetingsToUpdate = db.Meetings
               .Include(u => u.Users)
               .Where(u => u.MeetingId == id)
               .Single();

            if (TryUpdateModel(meetingsToUpdate, "",
               new string[] { "Title", "Description", "MeetingStart", "MeetingDuration", "RoomId" }))
            {
                UpdateMeetingUsers(selectedUsers, meetingsToUpdate);
                Meeting meeting = db.Meetings.Find(id);
                var selectedRoom = db.Rooms.Find(meeting.RoomId);
                if (meeting.Users.Count > selectedRoom.MaxCapacity || meeting.MeetingStart <= DateTime.Now)//The meeting cannot be edited if the room doesn't have enough capacity.
                {
                    PopulateAssignedUserData(meeting);
                    return View(meeting);
                }
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            PopulateAssignedUserData(meetingsToUpdate);
            return View(meetingsToUpdate);
        }

        // GET: Meetings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Meeting meeting = db.Meetings.Find(id);
            if (meeting == null)
            {
                return HttpNotFound();
            }
            return View(meeting);
        }

        // POST: Meetings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Meeting meeting = db.Meetings
                .Where(m => m.MeetingId == id)
                .Single();
            db.Meetings.Remove(meeting);

            var rooms = db.Rooms
                .Where(d => d.RoomId == id)
                .SingleOrDefault();
            if (rooms != null)
            {
                rooms.Meetings = null;
            }

            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private void PopulateAssignedUserData(Meeting meeting)
        {
            var allUsers = db.Users;
            var meetingUsers = new HashSet<int>(meeting.Users.Select(u => u.UserId));
            var viewModel = new List<AssignedUserData>();
            foreach (var user in allUsers)
            {
                viewModel.Add(new AssignedUserData
                {
                    UserId = user.UserId,
                    FullName = user.FullName,
                    Assigned = meetingUsers.Contains(user.UserId)
                });
            }
            ViewBag.Users = viewModel;
        }

        private void UpdateMeetingUsers(string[] selectedUsers, Meeting meetingsToUpdate)
        {
            if (selectedUsers == null)
            {
                meetingsToUpdate.Users = new List<User>();
                return;
            }

            var selectedUsersHS = new HashSet<string>(selectedUsers);
            var meetingUsers = new HashSet<int>
                (meetingsToUpdate.Users.Select(u => u.UserId));
            foreach (var user in db.Users)
            {
                if (selectedUsersHS.Contains(user.UserId.ToString()))
                {
                    if (!meetingUsers.Contains(user.UserId))
                    {
                        meetingsToUpdate.Users.Add(user);
                    }
                }
                else
                {
                    if (meetingUsers.Contains(user.UserId))
                    {
                        meetingsToUpdate.Users.Remove(user);
                    }
                }
            }
        }
    }
}
