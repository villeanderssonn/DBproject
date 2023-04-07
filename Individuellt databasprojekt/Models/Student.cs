using System;
using System.Collections.Generic;

namespace Individuellt_databasprojekt.Models
{
    public partial class Student
    {
        public Student()
        {
            Grades = new HashSet<Grade>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Class { get; set; }
        public string? PersonalNumber { get; set; }

        public virtual ICollection<Grade> Grades { get; set; }
    }
}
