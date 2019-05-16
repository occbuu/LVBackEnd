using System;
using System.Collections.Generic;

namespace LVBackEnd.DAL.Models
{
    public partial class Setting
    {
        public string Key { get; set; }
        public string Module { get; set; }
        public string DataType { get; set; }
        public string Description { get; set; }
        public string Value { get; set; }
        public short? Status { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
    }
}
