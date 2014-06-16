using System;
using System.Data.Entity;
namespace Rusty.ObservationLog.Db
{
    public interface IObservationContext
    {
        IDbSet<Rusty.ObservationLog.Domain.Observation> Observations { get; set; }
        IDbSet<Rusty.ObservationLog.Domain.Tag> Tags { get; set; }
        IDbSet<Rusty.ObservationLog.Domain.User> Users { get; set; }
        int SaveChanges();
        void Dispose();
    }
}
