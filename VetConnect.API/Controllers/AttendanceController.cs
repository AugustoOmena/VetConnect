using MediatR;
using Microsoft.AspNetCore.Mvc;
using VetConnect.Api.Config;
using VetConnect.Domain.Commands.Pets.Backoffice;
using VetConnect.Domain.Contracts.Infra;
using VetConnect.Shared.Notifications;
using VetConnect.Shared.Security;

namespace VetConnect.API.Controllers;

public class AttendanceController : BaseApiController
{
    private readonly IMediator _mediator;
    private readonly SessionUser _sessionUser;

    public AttendanceController(IMediator mediator, ILoggedUser loggedUser, IDomainNotification notifications) : base(mediator, loggedUser, notifications)
    {
        _mediator = mediator;
        _sessionUser = loggedUser.User;
    }

    /// <summary>
    ///     Atualiza um serviço de acordo com o ID.
    /// </summary>
    [HttpPatch("v1/Backoffice/Edit/Attendance/AttendanceId/{id:guid}")]
    public async Task<IActionResult> UpdateServiceById([FromRoute] Guid id, [FromBody] UpdateAttendanceCommand command)
    {
        command.Id = id;
        command.SessionUser = _sessionUser;
        command.AgentId = command.SessionUser.Id;
        return CreateResponse(await _mediator.Send(command, CancellationToken.None));
    }
}