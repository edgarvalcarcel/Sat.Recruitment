using AutoMapper;
using Sat.Recruitment.Application.Common.Mappings;
using Sat.Recruitment.Domain.Entities;
using Sat.Recruitment.Domain.Enums;

namespace Sat.Recruitment.Application.Users.Queries.GetUsers;
public class UserDto : IMapFrom<User>
{
    public string? Name { get; set; }
    public string? Email { get; set; }
    public string? Address { get; set; }
    public string? Phone { get; set; }
    public UserType? UserType { get; set; }
    public decimal? Money { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<User, UserDto>();
    }
}
