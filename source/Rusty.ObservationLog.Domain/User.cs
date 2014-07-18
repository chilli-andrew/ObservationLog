using System.Collections.Generic;

namespace Rusty.ObservationLog.Domain
{
    public class User
    {
        public int UserId { get; set; } 
        public string UserName { get; set; }
        public string WindowsLogon { get; set; }
        public virtual ICollection<Observation> Observations { get; set; }
    }
}