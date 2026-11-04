using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Core03.Models
{
    internal class Category
    {
        public int CategoryId { get; set; }

        public string Name { get; set; }

        public string? Description { get; set; }

        #region Category with SubCategories Relation

        public int? SuperCategoryId { get; set; }

        public Category? SuperCatgory { get; set; }

        #endregion


        #region Category with Courses Relatoin

        public ICollection<Course> CategorizedCourses { get; set; } = new HashSet<Course>();
        #endregion
    }
}
