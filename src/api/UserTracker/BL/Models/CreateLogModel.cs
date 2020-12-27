using System;

namespace UserTracker.BL.Models
{
    public class CreateLogModel
    {
        public DateTime Timestamp { get; set; }
        public string FromPage { get; set; }
        public string ToPage { get; set; }
    }
}