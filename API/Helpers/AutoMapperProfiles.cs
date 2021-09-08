using API.DTOs;
using API.Entities;
using AutoMapper;

namespace API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<AppUser, MemberDto>();
            CreateMap<RegisterDto, AppUser>();
            CreateMap<Assignment,AssignmentDto>();
            CreateMap<AssignmentDto,Assignment>();
            CreateMap<Group,GroupDto>();
            CreateMap<GroupDto,Group>();
            CreateMap<Grade,GradeDto>();
            CreateMap<GradeDto,Grade>();
        }
    }
}