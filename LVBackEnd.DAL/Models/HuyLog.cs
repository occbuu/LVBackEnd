using System;
using System.Collections.Generic;

namespace LVBackEnd.DAL.Models
{
    public partial class HuyLog
    {
        public int Id { get; set; }
        public double? Duration { get; set; }
        public string Source { get; set; }
        public string Destination { get; set; }
        public string Protocol { get; set; }
        public int? Length { get; set; }
        public string Info { get; set; }
        public DateTime? StampTime { get; set; }
    }
}
