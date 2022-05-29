using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GoStore.Data.Models
{
    public class Cart
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public virtual ICollection<CartItem>? Items { get; set; } = new List<CartItem>();// = Enumerable.Empty<CartItem>().ToList();
        public decimal Total { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }


    public class CartEntityTypeConfiguration : IEntityTypeConfiguration<Cart>
    {
        public void Configure(EntityTypeBuilder<Cart> builder)
        {
            builder.HasKey(x => x.Id);
            builder
                .HasMany(x => x.Items)
                .WithOne(b => b.Cart)
                .HasForeignKey(b => b.CartId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
