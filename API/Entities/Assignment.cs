using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Entities
{
    [Table("Assignments")]
    public class Assignment
    {
        public int id { get; set; }
        public string name { get; set; }
        public Group Group { get; set; }
        public int GroupId { get; set; }
        public ICollection<Grade> Grades { get; set; }

    }
}