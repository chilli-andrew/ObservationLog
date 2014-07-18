using System.Data.Entity.ModelConfiguration;
using Rusty.ObservationLog.Domain;

namespace Rusty.ObservationLog.Db.Mapping
{
    public class UserMap : EntityTypeConfiguration<User>
    {
        public UserMap()
        {
            // Primary Key
            this.HasKey(t => t.UserId);

            // Properties
            // Table & Column Mappings
            this.ToTable("Users");
            this.Property(t => t.UserId).HasColumnName("UserId");
            this.Property(t => t.UserName).HasColumnName("UserName");
            this.Property(t => t.WindowsLogon).HasColumnName("WindowsLogon");
        }
    }
}
