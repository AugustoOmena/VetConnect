using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VetConnect.Api.Config;
using VetConnect.Domain.Commands.Pets;
using VetConnect.Domain.Contracts.Infra;
using VetConnect.Shared.Notifications;
using VetConnect.Shared.Security;

namespace VetConnect.API.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class PetsController : BaseApiController
{
    private readonly IMediator _mediator;
    private readonly SessionUser _sessionUser;

    public PetsController(IMediator mediator, ILoggedUser loggedUser, IDomainNotification notifications) : base(mediator, loggedUser, notifications)
    {
        _mediator = mediator;
        _sessionUser = loggedUser.User;
    }

    [HttpPost]
    [Route("v1/Create/Pet")]
    public async Task<IActionResult> CreatePet([FromBody] CreatePetCommand command,
        CancellationToken cancellationToken)
    {
        command.SessionUser = _sessionUser;
        return CreateResponse(await _mediator.Send(command, CancellationToken.None));
    }
}