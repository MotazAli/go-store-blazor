using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GoStore.Data.Models
{
    public class Product
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; } = default;
        public string Image { get; set; } = string.Empty;
        public Guid? CategoryId { get; set; } = null!;

        public virtual Category? Category { get; set; } = null!;
        public virtual ICollection<CartItem>? CartItems { get; set; } = new List<CartItem>();

        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }


        public class ProductEntityTypeConfiguration : IEntityTypeConfiguration<Product>
        {
            public void Configure(EntityTypeBuilder<Product> builder)
            {
                builder.HasKey(p => p.Id);
                builder
                    .HasOne(p => p.Category)
                    .WithMany(c => c.Products)
                    .HasForeignKey(p => p.CategoryId)
                    .IsRequired(true);
            }
        }


    }



    public enum Categories 
    {
        Electronics = 1,
        Cloths =2,
        Food = 3,
    }
}
