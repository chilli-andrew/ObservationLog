using System;
using System.Collections.Generic;

namespace Rusty.ObservationLog.Domain
{
    public class Observation
    {
        public int Id { get; set; }
        public string ObservationText { get; set; }
        public DateTime ObservationDate { get; set; }
        public List<Tag> Tags { get; set; } 
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
