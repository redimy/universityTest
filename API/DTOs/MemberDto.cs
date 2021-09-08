using System.Collections.Generic;

namespace API.DTOs
{
    public class MemberDto
    {
        public int id { get; set; }
        public string username { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string avatar { get; set; }
        public ICollection<GroupDto> Groups { get; set; }
    }
}