using VetConnect.Api.Config;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using VetConnect.Domain.Commands.UserClient;
using VetConnect.Shared.Notifications;

namespace VetConnect.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersController : BaseApiController
{
    private readonly IMediator _mediator;

    public UsersController(IMediator mediator, IDomainNotification notifications) : base(notifications, mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    [Route("v1/Create")]
    public async Task<IActionResult> Create(CreateClientUserByVetConnectCommand command,
        CancellationToken cancellationToken)
    {
        return CreateResponse(await _mediator.Send(command, CancellationToken.None));
    }
}

