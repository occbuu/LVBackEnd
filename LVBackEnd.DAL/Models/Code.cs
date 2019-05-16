using System;
using System.Collections.Generic;

namespace LVBackEnd.DAL.Models
{
    public partial class Code
    {
        public Code()
        {
            InverseParent = new HashSet<Code>();
        }

        public int Id { get; set; }
        public int? ParentId { get; set; }
        public string CodeType { get; set; }
        public string Value { get; set; }
        public string DisplayAs { get; set; }
        public int? Sequence { get; set; }
        public short? Status { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }

        public virtual CodeType CodeTypeNavigation { get; set; }
        public virtual Code Parent { get; set; }
        public virtual ICollection<Code> InverseParent { get; set; }
    }
}
