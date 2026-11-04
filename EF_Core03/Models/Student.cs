using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Core03.Models
{
    internal class Student
    {
        public int Id { get; set; }

        public string FullName { get; set; }

        public string Email { get; set; }

        public DateTime DOB { get; set; }

        #region Student with Enrollment

        public ICollection<Enrollment> Enrollments { get; set; } = new HashSet<Enrollment>();
        #endregion
    }
}
