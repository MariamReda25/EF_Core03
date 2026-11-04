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
    internal class EnrollmentConfigurations : IEntityTypeConfiguration<Enrollment>
    {
        public void Configure(EntityTypeBuilder<Enrollment> builder)
        {
            // JoinDate
            builder.Property(Enroll=>Enroll.EnrollmentDate)
                .HasDefaultValueSql("GETDATE()");

            builder.ToTable(table => table.HasCheckConstraint("Check_Status", "Status IN ('Active','Completed','Dropped')"));
            builder.ToTable(table => table.HasCheckConstraint("Check_ProgressRange", "ProgressPercent Between 0 AND 100"));

            // PK
            builder.HasKey(Enroll => new { Enroll.CourseId, Enroll.StudentId });

            // Relationship
            builder.HasOne(Enroll => Enroll.EnrolledStudent)
                .WithMany(Student => Student.Enrollments)
                .HasForeignKey(Enroll => Enroll.StudentId);

            builder.HasOne(Enroll => Enroll.EnrolledCourse)
                .WithMany(Course => Course.Enrollments)
                .HasForeignKey(Enroll => Enroll.CourseId);
        }
    }
}
