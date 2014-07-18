using System.Data.Entity.ModelConfiguration;
using Rusty.ObservationLog.Domain;

namespace Rusty.ObservationLog.Db.Mapping
{
    public class ObservationMap : EntityTypeConfiguration<Observation>
    {
        public ObservationMap()
        {
            // Primary Key
            this.HasKey(t => t.ObservationId);

            // Properties
            // Table & Column Mappings
            this.ToTable("Observations");
            this.Property(t => t.ObservationId).HasColumnName("ObservationId");
            this.Property(t => t.ObservationText).HasColumnName("ObservationText");
            this.Property(t => t.ObservationDate).HasColumnName("ObservationDate");
            this.Property(t => t.UserId).HasColumnName("UserId");

            // Relationships
            this.HasRequired(t => t.User)
                .WithMany(t => t.Observations)
                .HasForeignKey(d => d.UserId);

            this.HasMany(t => t.Tags)
            .WithMany()
            .Map(x =>
            {
                x.MapLeftKey("ObservationId");
                x.MapRightKey("TagId");
                x.ToTable("ObservationTags");
            });

        }
    }
}
