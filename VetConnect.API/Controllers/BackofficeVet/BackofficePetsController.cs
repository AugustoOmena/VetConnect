using MediatR;
using Microsoft.AspNetCore.Mvc;
using VetConnect.Api.Config;
using VetConnect.Domain.Commands.Pets;
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
    ///     Cria um novo pet para um usuário
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
    
    /// <summary>
    ///     Atualiza um Pet para um usuário a partir do id do pet
    /// </summary>
    [HttpPut("v1/Backoffice/Edit/Pet/{id:guid}")]
    public async Task<IActionResult> UpdatePet([FromRoute] Guid id, [FromBody] UpdatePetCommand command)
    {
        command.Id = id;
        command.SessionUser = _sessionUser;
        return CreateResponse(await _mediator.Send(command, CancellationToken.None));
    }
    
    
    // Deleção de um Pet para um usuário
    /// <summary>
    ///     Deleta(desativa) um pet do usuário de acordo com o ID informado.
    /// </summary>
    [HttpDelete("v1/Backoffice/Delete/Pet/{id:guid}")]
    public async Task<IActionResult> DeletePet([FromRoute] Guid id)
    {
        var command = new DeletePetCommand()
        {
            Id = id,
            SessionUser = _sessionUser
        };
        return CreateResponse(await _mediator.Send(command, CancellationToken.None));
    }
    
    /// <summary>
    /// (Backoffice) Obtém um usuáirio detalhado e seus Pets.
    /// </summary>
    [HttpGet("v1/Backoffice/GetUser/{id:guid}")]
    public async Task<IActionResult> GetUserById([FromRoute] Guid id)
    {
        var response = await _mediator.Send(
            new UserByBackofficeQuery() { Id = id }, CancellationToken.None);

        return CreateResponse(response);
    }
    
    
    /// <summary>
    /// (Backoffice) Obtém um Pet por Id.
    /// </summary>
    [HttpGet("v1/Backoffice/GetPet/{id:guid}")]
    public async Task<IActionResult> GetPetById([FromRoute] Guid id)
    {
        var response = await _mediator.Send(
            new PetByIdBackofficeQuery() { Id = id }, CancellationToken.None);

        return CreateResponse(response);
    }
    
    
}