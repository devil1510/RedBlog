﻿using System.Data.Entity.ModelConfiguration;
using JustBlog.Core.Objects;

namespace JustBlog.Core.Mappings
{
    public class CategoryMap:EntityTypeConfiguration<Category>
    {
        public CategoryMap()
        {
            this.HasKey(x => x.Id);
            //properties
            this.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(255);
            this.Property(x => x.UrlSlug)
               .HasMaxLength(255);

            // Table & column mapping
            this.ToTable("Category");
            this.Property(x => x.Id).HasColumnName("Id");
            this.Property(x => x.Name).HasColumnName("Name");
            this.Property(x => x.UrlSlug).HasColumnName("UrlSlug");
            this.Property(x => x.Decription).HasColumnName("Description");
        }
    }
}
