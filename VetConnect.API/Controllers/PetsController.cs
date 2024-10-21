using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VetConnect.Api.Config;
using VetConnect.Domain.Commands.Pets;
using VetConnect.Shared.Notifications;
using VetConnect.Shared.Security;

namespace VetConnect.API.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class PetsController : BaseApiController
{
    private readonly IMediator _mediator;

    public PetsController(IMediator mediator, IDomainNotification notifications, SessionUser sessionUser) : base(notifications, mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    [Route("v1/Create/Pet")]
    public async Task<IActionResult> CreatePet(CreatePetCommand command,
        CancellationToken cancellationToken)
    {
        return CreateResponse(await _mediator.Send(command, CancellationToken.None));
    }
}