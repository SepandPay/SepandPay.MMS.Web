using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Filter_Sort.Models
{
    public class Course
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CourseID { get; set; }
        public string Title { get; set; }
        public int Credits { get; set; }

        public virtual ICollection<Enrollment> Enrollments { get; set; }
        public int DepartmentID { get; internal set; }
        public object Department { get; internal set; }
    }
}
