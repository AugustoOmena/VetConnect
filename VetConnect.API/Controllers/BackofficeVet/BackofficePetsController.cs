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

public class BackofficePetsController : BaseApiController
{
    private readonly IMediator _mediator;
    private readonly SessionUser _sessionUser;

    public BackofficePetsController(IMediator mediator, ILoggedUser loggedUser, IDomainNotification notifications) : base(mediator, loggedUser, notifications)
    {
        _mediator = mediator;
        _sessionUser = loggedUser.User;
    }
    
    /// <summary>
    ///     Cria um novo para um usuário
    /// </summary>
    [HttpPost]
    [Route("v1/Backoffice/Create/Pet/ToUser/{id}")]
    public async Task<IActionResult> CreatePet([FromRoute] Guid id, [FromBody] CreatePetByBackofficeCommand command,
        CancellationToken cancellationToken)
    {
        command.SessionUser = _sessionUser;
        command.UserId = id;
        return CreateResponse(await _mediator.Send(command, CancellationToken.None));
    }
    
    /// <summary>
    ///     Listagem de usuários
    /// </summary>
    [HttpGet("v1/Backoffice/List/Users")]
    public async Task<IActionResult> ListUserPets([FromQuery] ListUserFilter filter)
    {
        return CreateResponse(await _mediator.Send(
            new UsersByBackofficeQuery()
            {
                Filter = filter,
                SessionUser = _sessionUser
            },
            CancellationToken.None));
    }
    
    
    // Deleção de um Pet para um usuário
    
    
    // Edição de um pet para um usuário
    
    
    // Obtém um Pet por Id
    
    
}