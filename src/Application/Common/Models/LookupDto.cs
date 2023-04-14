using Sat.Recruitment.Application.Common.Mappings;
using Sat.Recruitment.Domain.Entities;

namespace Sat.Recruitment.Application.Common.Models;

// Note: This is currently just used to demonstrate applying multiple IMapFrom attributes.
public class LookupDto : IMapFrom<User>
{
    public int Id { get; set; }

    public string? Title { get; set; }
}
