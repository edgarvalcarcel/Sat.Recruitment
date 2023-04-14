using Sat.Recruitment.Application.Common.Models;
using Sat.Recruitment.Application.Users.Commands.CreateUser;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using Sat.Recruitment.WebUI.Controllers;

namespace Sat.Recruitment.API.Controllers;
[Authorize]
public class UserController : ApiControllerBase
{ 
    [HttpPost]
    public async Task<ActionResult<int>> Create(CreateUserCommand command)
    {
        return await Mediator.Send(command);
    }
}
