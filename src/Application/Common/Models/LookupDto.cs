using Sat.Recruitment.Application.Common.Mappings;
using Sat.Recruitment.Domain.Entities;
using Sat.Recruitment.Domain.Enums;

namespace Sat.Recruitment.Application.Common.Models;

// Note: This is currently just used to demonstrate applying multiple IMapFrom attributes.
public class LookupDto : IMapFrom<User>
{    public string? Name { get; set; }
    public string? Email { get; set; }
    public string? Address { get; set; }
    public string? Phone { get; set; }
    public UserType UserType { get; set; }
    public float Money { get; set; }
}
