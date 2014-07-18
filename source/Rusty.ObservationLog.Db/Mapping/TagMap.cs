using System.Data.Entity.ModelConfiguration;
using Rusty.ObservationLog.Domain;

namespace Rusty.ObservationLog.Db.Mapping
{
    public class TagMap : EntityTypeConfiguration<Tag>
    {
        public TagMap()
        {
            // Primary Key
            this.HasKey(t => t.TagId);

            // Properties
            // Table & Column Mappings
            this.ToTable("Tags");
            this.Property(t => t.TagId).HasColumnName("TagId");
            this.Property(t => t.TagText).HasColumnName("TagText");
        }
    }
}
