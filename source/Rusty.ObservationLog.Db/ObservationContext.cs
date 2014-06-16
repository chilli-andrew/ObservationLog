using System.Data.Entity;
using Rusty.ObservationLog.Domain;

namespace Rusty.ObservationLog.Db
{
    public class ObservationContext : DbContext, IObservationContext
    {
        public ObservationContext() : base("name=Observations")
        {
        }

        public IDbSet<User> Users { get; set; }
        public IDbSet<Observation>  Observations { get; set; }
        public IDbSet<Tag> Tags { get; set; } 
    }
}
