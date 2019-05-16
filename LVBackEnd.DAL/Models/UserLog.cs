using System;
using System.Collections.Generic;

namespace LVBackEnd.DAL.Models
{
    public partial class UserLog
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public string Action { get; set; }
        public string Objects { get; set; }
        public string ContentBefore { get; set; }
        public string ContentAfter { get; set; }
        public short? Status { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }

        public virtual User User { get; set; }
    }
}
