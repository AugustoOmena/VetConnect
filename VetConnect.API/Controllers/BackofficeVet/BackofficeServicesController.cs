using MediatR;
using Microsoft.AspNetCore.Mvc;
using VetConnect.Api.Config;
using VetConnect.Domain.Commands.Pets.Backoffice;
using VetConnect.Domain.Contracts.Infra;
using VetConnect.Domain.Filters;
using VetConnect.Domain.Queries.Backoffice;
using VetConnect.Shared.Notifications;
using VetConnect.Shared.Security;

namespace VetConnect.API.Controllers.BackofficeVet;

public class BackofficeServicesController : BaseApiController
{
    private readonly IMediator _mediator;
    private readonly SessionUser _sessionUser;

    public BackofficeServicesController(IMediator mediator, ILoggedUser loggedUser, IDomainNotification notifications) : base(mediator, loggedUser, notifications)
    {
        _mediator = mediator;
        _sessionUser = loggedUser.User;
    }
    
    /// <summary>
    ///     Cria um novo Serviço
    /// </summary>
    [HttpPost]
    [Route("v1/Backoffice/Create/ServiceHistory")]
    public async Task<IActionResult> CreateServiceToPet([FromBody] CreateServiceByBackofficeCommand command,
        CancellationToken cancellationToken)
    {
        command.SessionUser = _sessionUser;
        return CreateResponse(await _mediator.Send(command, CancellationToken.None));
    }
    
    /// <summary>
    ///     Listagem de serviços
    /// </summary>
    [HttpGet("v1/Backoffice/ListAll/Services")]
    public async Task<IActionResult> ListServicesPets([FromQuery] ListServicesHistoryFilter filter)
    {
        return CreateResponse(await _mediator.Send(
            new ListServiceHistoryQuery()
            {
                Filter = filter,
                SessionUser = _sessionUser
            },
            CancellationToken.None));
    }
    
    /// <summary>
    ///     Deleta(desativa) um serviço do pet de acordo com o ID informado.
    /// </summary>
    [HttpDelete("v1/Backoffice/Delete/Service/{id:guid}")]
    public async Task<IActionResult> DeleteServiceById([FromRoute] Guid id)
    {
        var command = new DeleteServiceCommand()
        {
            Id = id,
            SessionUser = _sessionUser
        };
        return CreateResponse(await _mediator.Send(command, CancellationToken.None));
    }
    
    /// <summary>
    ///     Atualiza um serviço de acordo com o ID.
    /// </summary>
    [HttpPatch("v1/Backoffice/Edit/Service/{id:guid}")]
    public async Task<IActionResult> UpdateServiceById([FromRoute] Guid id, [FromBody] UpdateServiceCommand command)
    {
        command.Id = id;
        command.SessionUser = _sessionUser;
        return CreateResponse(await _mediator.Send(command, CancellationToken.None));
    }
}