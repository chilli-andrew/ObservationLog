using System;
using System.Collections.Generic;

namespace Rusty.ObservationLog.Domain
{
    public class Observation
    {
        public int ObservationId { get; set; }
        public string ObservationText { get; set; }
        public DateTime ObservationDate { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public virtual ICollection<Tag> Tags { get; set; }
    }
}
