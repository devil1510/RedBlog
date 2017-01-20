using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using JustBlog.Core.Objects;

namespace JustBlog.Core.Mappings
{
    public class PostMap:EntityTypeConfiguration<Post>
    {
        public PostMap()
        {
            this.HasKey(x => x.Id);
            //properties
            this.Property(x => x.Title)
                .IsRequired()
                .HasMaxLength(255);
            this.Property(x => x.UrlSlug)
               .HasMaxLength(255);
            this.Property(x => x.ShortDescription)
                .IsRequired()
              .HasMaxLength(4000);
            this.Property(x => x.Description)
                .IsRequired()
              .HasMaxLength(4000);
            this.Property(x => x.Modified)
                .IsRequired();
            this.Property(x => x.PostOn)
                .IsRequired();

            // Table & column mapping
            this.ToTable("Post");
            this.Property(x => x.Id).HasColumnName("Id");
            this.Property(x => x.Title).HasColumnName("Title");
            this.Property(x => x.UrlSlug).HasColumnName("UrlSlug");
            this.Property(x => x.ShortDescription).HasColumnName("ShortDecription");
            this.Property(x => x.Description).HasColumnName("Description");
            this.Property(x => x.PostOn).HasColumnName("PostOn");
            this.Property(x => x.Modified).HasColumnName("Modified");
            this.Property(x => x.Published).HasColumnName("Published");
        }
    }
}
