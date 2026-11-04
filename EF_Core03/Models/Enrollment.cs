using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Core03.Models
{
    internal class Enrollment
    {
        public DateTime EnrollmentDate { get; set; }
        public int ProgressPercent { get; set; }

        public string Status { get; set; }

        public decimal? FinalGrade { get; set; }

        #region Student with Enrollment Relation

        public int StudentId { get; set; }
        public Student EnrolledStudent { get; set; }
        #endregion

        #region Enrollment with PublishedCourses

        public int CourseId { get; set; }

        public PublishedCourses EnrolledCourse { get; set; }
        #endregion

    }
}
