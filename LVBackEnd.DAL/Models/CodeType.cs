using System;
using System.Collections.Generic;

namespace LVBackEnd.DAL.Models
{
    public partial class CodeType
    {
        public CodeType()
        {
            CodeNavigation = new HashSet<Code>();
        }

        public string Code { get; set; }
        public string DisplayAs { get; set; }
        public int? Sequence { get; set; }
        public short? Status { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }

        public virtual ICollection<Code> CodeNavigation { get; set; }
    }
}
