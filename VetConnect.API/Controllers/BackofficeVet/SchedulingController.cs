using MediatR;
using Microsoft.AspNetCore.Mvc;
using VetConnect.Api.Config;
using VetConnect.Domain.Commands.Scheduling;
using VetConnect.Domain.Contracts.Infra;
using VetConnect.Domain.Filters;
using VetConnect.Domain.Queries.Users;
using VetConnect.Shared.Notifications;
using VetConnect.Shared.Security;

namespace VetConnect.API.Controllers.BackofficeVet;

public class SchedulingController : BaseApiController
{
    private readonly IMediator _mediator;
    private readonly SessionUser _sessionUser;

    public SchedulingController(IMediator mediator, ILoggedUser loggedUser, IDomainNotification notifications) : base(mediator, loggedUser, notifications)
    {
        _mediator = mediator;
        _sessionUser = loggedUser.User;
    }
    
    /// <summary>
    ///     Listagem de agendamentos
    /// </summary>
    [HttpGet("v1/Commom/Scheduling/List")]
    public async Task<IActionResult> ListUserPets([FromQuery] ListSchedulingFilter filter)
    {
        return CreateResponse(await _mediator.Send(
            new SchedulingByUserQuery()
            {
                Filter = filter,
                SessionUser = _sessionUser
            },
            CancellationToken.None));
    }
    
    
    /// <summary>
    ///     Cria um novo Agendamento
    /// </summary>
    [HttpPost]
    [Route("v1/Common/Create/Scheduling/Pet/{id}")]
    public async Task<IActionResult> CreateServiceToPet([FromRoute] Guid id, [FromBody] CreateSchedulingByUserCommand command)
    {
        command.SessionUser = _sessionUser;
        command.PetId = id;
        return CreateResponse(await _mediator.Send(command, CancellationToken.None));
    }
    
}