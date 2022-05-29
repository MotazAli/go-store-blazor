using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GoStore.Data.Models
{
    public class CartItem
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid? ProductId { get; set; } = null;
        public Guid? CartId { get; set; } = null;
        public int Quantaty { get; set; }
        public virtual Product? Product { get; set; } = null!;
        public virtual Cart? Cart { get; set; } = null!;
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }



    public class CartItemEntityTypeConfiguration : IEntityTypeConfiguration<CartItem>
    {
        public void Configure(EntityTypeBuilder<CartItem> builder)
        {
            builder.HasKey(ci => ci.Id);
            builder
                .HasOne(ci => ci.Product)
                .WithMany(p => p.CartItems)
                .HasForeignKey(ci => ci.ProductId)
                .IsRequired(true)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(ci => ci.Cart)
                .WithMany(c => c.Items)
                .HasForeignKey(ci => ci.CartId)
                .IsRequired(true)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }


}
