using System.ComponentModel.DataAnnotations.Schema;

namespace API.Entities
{
    [Table("Grades")]
    public class Grade
    {
        public int id { get; set; }
        public string name { get; set; }
        public float value { get; set; }
        public Assignment assignment { get; set; }
        public int assignmentId { get; set; }

    }
}