using System;
using System.Collections.Generic;

namespace Individuellt_databasprojekt.Models
{
    public partial class Grade
    {
        public int Id { get; set; }
        public int? StudentId { get; set; }
        public int? CourseId { get; set; }
        public int? TeacherId { get; set; }
        public int? Grade1 { get; set; }
        public DateTime? Date { get; set; }

        public virtual Course? Course { get; set; }
        public virtual Student? Student { get; set; }
        public virtual Personnel? Teacher { get; set; }
    }
}
