using CommunityPortal.Models.Domains;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CommunityPortal.Models.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(category => category.Id);

            builder.Property(category => category.Title)
                .IsRequired()
                .HasMaxLength(150);

            builder.HasMany(category => category.Posts)
                .WithOne(post => post.Category)
                .HasForeignKey(post => post.CategoryId);
        }
    }
}
