using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sat.Recruitment.Application.Common.Mappings;
using Sat.Recruitment.Domain.Entities;
using Sat.Recruitment.Domain.Enums;

namespace Sat.Recruitment.Application.Users.Queries.ExportUsers;
public class UserFileRecord : IMapFrom<User>
{
    public string? Name { get; set; }
    public string? Email { get; set; }
    public string? Address { get; set; }
    public string? Phone { get; set; }
    public UserType UserType { get; set; }
    public float Money { get; set; }
}


