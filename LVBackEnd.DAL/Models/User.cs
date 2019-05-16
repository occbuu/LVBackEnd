using System;
using System.Collections.Generic;

namespace LVBackEnd.DAL.Models
{
    public partial class User
    {
        public User()
        {
            UserLog = new HashSet<UserLog>();
        }

        public int Id { get; set; }
        public string Pin { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool? Gender { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }
        public int? Pepper { get; set; }
        public DateTime? Joined { get; set; }
        public DateTime? Birthday { get; set; }
        public string Address { get; set; }
        public string Pob { get; set; }
        public string Note { get; set; }
        public string Phone { get; set; }
        public DateTime? ReminderExpire { get; set; }
        public string ReminderToken { get; set; }
        public short? Status { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }

        public virtual ICollection<UserLog> UserLog { get; set; }
    }
}
