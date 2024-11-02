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
    ///     Cria um novo Serviço para o Pet com o Id do Pet
    /// </summary>
    [HttpPost]
    [Route("v1/Backoffice/Create/ServiceByPetId/{id}")]
    public async Task<IActionResult> CreateServiceToPet([FromRoute] Guid id, [FromBody] CreateServiceByBackofficeCommand command,
        CancellationToken cancellationToken)
    {
        command.SessionUser = _sessionUser;
        command.PetId = id;
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
}