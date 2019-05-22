using System;
using System.Collections.Generic;

namespace LVBackEnd.DAL.Models
{
    public partial class PatientData
    {
        public int Id { get; set; }
        public int? Age { get; set; }
        public bool? Sex { get; set; }
        public string Symptons { get; set; }
        public string OriginalHealth { get; set; }
        public string BloodPressure { get; set; }
        public int? BloodPressureP { get; set; }
        public int? BloodPressureN { get; set; }
        public int? Temperature { get; set; }
        public int? BloodVessel { get; set; }
        public int? NDays { get; set; }
        public string ResultDisease1 { get; set; }
        public string ResultDisease2 { get; set; }
        public short? Status { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
    }
}
