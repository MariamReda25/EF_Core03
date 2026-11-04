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
    internal class PublishedCoursesConfigurations : IEntityTypeConfiguration<PublishedCourses>
    {
        public void Configure(EntityTypeBuilder<PublishedCourses> builder)
        {

            builder.HasKey(PC => PC.PublisheCourseId);

            builder.HasOne(PC=>PC.PublishedCourse) 
                    .WithOne(C => C.PublishedCourse)
                    .HasForeignKey<PublishedCourses>(PC => PC.PublisheCourseId);


            builder.HasOne(PC => PC.Publisher)
                   .WithMany(I => I.PublishedCourses)
                   .HasForeignKey(PC => PC.PublisherId);

            builder.Property(PC => PC.PublishDate)
                    .HasDefaultValueSql("GETDATE()");
        }
    }
}
