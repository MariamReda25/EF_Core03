using EF_Core03.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Core03.Configurations
{
    internal class CategoryConfigurations : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasOne(Category => Category.SuperCatgory)
                .WithMany()
                .HasForeignKey(Category => Category.SuperCategoryId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
