using Sat.Recruitment.Application.Common.Models;
using Sat.Recruitment.Application.Users.Commands.CreateUser;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using Sat.Recruitment.WebUI.Controllers;
using Sat.Recruitment.Application.Users.Queries.ExportUsers;
using Sat.Recruitment.Application.Common.Exceptions;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using ValidationException = Sat.Recruitment.Application.Common.Exceptions.ValidationException;

namespace Sat.Recruitment.API.Controllers;

//Commented for hiring purposes
//[Authorize] 
public class UserController :ApiControllerBase<UserController>
{ 

    [HttpPost]
    public async Task<ActionResult<int>> Create([FromBody][Required] CreateUserCommand command)
    {
        try
        {
            return await Mediator.Send(command);
        }
        catch (ValidationException exc)
        {
            _logger.LogError(exc.Errors.ToList().FirstOrDefault().Value.LastOrDefault()); //("Not valid parameters");
            return StatusCode(400, exc.Errors.ToList().FirstOrDefault().Value.LastOrDefault());
        }
        
    }
    [HttpGet()]
    public async Task<FileResult> Get()
    {
        var vm = await Mediator.Send(new ExportUsersQuery());
        return File(vm.Content, vm.ContentType, vm.FileName);
    }
}
