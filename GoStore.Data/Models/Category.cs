using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoStore.Data.Models
{
    public class Category
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string? Name { get; set; } = default!;
        public virtual ICollection<Product> Products { get; set; } = new List<Product>();
        public DateTime? CreatedAt { get; set; } 
        public DateTime? UpdatedAt { get; set; }


        public class CategoryEntityTypeConfiguration : IEntityTypeConfiguration<Category>
        {
            public void Configure(EntityTypeBuilder<Category> builder)
            {
                builder.HasKey(c => c.Id);
                builder.HasIndex(c => c.Name).IsUnique(true);
                builder.Property(c => c.Name).IsRequired(true);
                builder
                    .HasMany(c => c.Products)
                    .WithOne(p => p.Category)
                    .HasForeignKey(p => p.CategoryId)
                    .OnDelete(DeleteBehavior.Restrict);
            }
        }

    }
}
