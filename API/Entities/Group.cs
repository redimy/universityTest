using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Entities
{
    [Table("Groups")]
    public class Group
    {
        public int id { get; set; }
        public string name { get; set; }
        public AppUser AppUser { get; set; }
        public int AppUserId { get; set; }
        public ICollection<Assignment> Assignments { get; set; }

    }
}