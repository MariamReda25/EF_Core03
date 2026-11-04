using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Core03.Models
{
    internal class PublishedCourses
    {
        public DateTime PublishDate { get; set; }

        #region InstructorRelation

        public int PublisherId { get; set; }

        public Instructor Publisher { get; set; }
        #endregion


        #region CourseRelation

        public int PublisheCourseId { get; set; }

        public Course PublishedCourse { get; set; }
        #endregion

        #region Enrollmnets with PublishedCourses

        public ICollection<Enrollment> Enrollments { get; set; } = new HashSet<Enrollment>();
        #endregion
    }
}
