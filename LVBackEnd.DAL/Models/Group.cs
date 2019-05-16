using System;
using System.Collections.Generic;

namespace LVBackEnd.DAL.Models
{
    public partial class Group
    {
        public int Id { get; set; }
        public int? Level { get; set; }
        public int? Pid { get; set; }
        public string InitialChar { get; set; }
        public string Description { get; set; }
        public short? Status { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
    }
}
