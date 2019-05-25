using System;

namespace LVBackEnd.DAL.Models
{
    public partial class Suggestion
    {
        public int Id { get; set; }
        public string DiseaseCode { get; set; }
        public string ShoudDo { get; set; }
        public string ShoudNotDo { get; set; }
        public int? Type { get; set; }
        public short? Status { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
    }
}
