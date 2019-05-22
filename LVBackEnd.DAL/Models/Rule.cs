using System;
using System.Collections.Generic;

namespace LVBackEnd.DAL.Models
{
    public partial class Rule
    {
        public int Id { get; set; }
        public string Vt { get; set; }
        public string Vp { get; set; }
        public short? RuleType { get; set; }
        public string Note { get; set; }
        public short? Status { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
    }
}
