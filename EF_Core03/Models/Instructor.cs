using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Core03.Models
{
    internal class Instructor
    {
   
        public int Id { get; set; }

        public string FullName { get; set; }

        public string Email { get; set; }

        public string? Bio { get; set; }

        public DateTime JoinDate { get; set; }

        public ICollection<PublishedCourses> PublishedCourses{ get; set; } = new HashSet<PublishedCourses>();
    }
}
