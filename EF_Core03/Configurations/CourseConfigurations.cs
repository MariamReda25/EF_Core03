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
    internal class CourseConfigurations : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.Property(Course => Course.Price)
                    .HasPrecision(10, 3);

            builder.ToTable(table=>table.HasCheckConstraint("Check_CourseLevel", "Level IN ('Beginner','Intermediate','Advanced')"));


            builder.HasOne(Course => Course.CourseCategory)
                .WithMany(Category => Category.CategorizedCourses)
                .HasForeignKey(Course => Course.CategoryId);
        }
    }
}
