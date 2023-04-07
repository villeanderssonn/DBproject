using System;
using System.Collections.Generic;

namespace Individuellt_databasprojekt.Models
{
    public partial class Personnel
    {
        public Personnel()
        {
            Grades = new HashSet<Grade>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Position { get; set; }
        public DateTime? RegisterDate { get; set; }
        public string? Course { get; set; }

        public virtual ICollection<Grade> Grades { get; set; }
    }
}
