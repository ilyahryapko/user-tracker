using System;

namespace UserTracker.DAL.Models
{
    public class Log : BaseModel
    {
        public string UserId { get; set; }
        public DateTime Timestamp { get; set; }
        public string FromPage { get; set; }
        public string ToPage { get; set; }
    }
}