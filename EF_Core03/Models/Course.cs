using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Core03.Models
{
    internal class Course
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public decimal Price { get; set; }

        public string Level { get; set; }

        public bool IsPublished { get; set; }

        #region Instructor-Course Relation [1:M]
        public PublishedCourses? PublishedCourse { get; set; }
        #endregion

        #region Course with Category Relation

        public int CategoryId { get; set; }
        public Category CourseCategory { get; set; }
        #endregion


    }
}
