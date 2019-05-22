using System;
using System.Collections.Generic;

namespace LVBackEnd.DAL.Models
{
    public partial class HuyLog
    {
        public int Id { get; set; }
        public double Duration { get; set; }
        public string Source { get; set; }
        public string Destination { get; set; }
        public string Protocol { get; set; }
        public int Length { get; set; }
        public string Info { get; set; }
        public string Type { get; set; }
        public string SourcePort { get; set; }
        public string DestinationPort { get; set; }
        public string MessagePhase { get; set; }
        public string ClientExchange { get; set; }
        public string CipherChange { get; set; }
        public string Ping { get; set; }
    }
}
