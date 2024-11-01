using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VetConnect.Api.Config;
using VetConnect.Domain.Commands.Pets;
using VetConnect.Domain.Contracts.Infra;
using VetConnect.Domain.Filters;
using VetConnect.Domain.Queries.Users;
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

    /// <summary>
    ///     Cria um novo Pet do usuário logado
    /// </summary>
    [HttpPost]
    [Route("v1/Create/Pet")]
    public async Task<IActionResult> CreatePet([FromBody] CreatePetCommand command,
        CancellationToken cancellationToken)
    {
        command.SessionUser = _sessionUser;
        return CreateResponse(await _mediator.Send(command, CancellationToken.None));
    }
    
    /// <summary>
    ///     Obtém lista de pets do usuário logado.
    /// </summary>
    [HttpGet("v1/List/Pets")]
    public async Task<IActionResult> ListUserPets([FromQuery] ListUserPetsFilter filter)
    {
        return CreateResponse(await _mediator.Send(
            new PetsByUserQuery()
            {
                Filter = filter,
                SessionUser = _sessionUser
            },
            CancellationToken.None));
    }
    
    /// <summary>
    ///     Atualiza um pet do usuário logado de acordo com o ID do pet informado.
    /// </summary>
    [HttpPut("v1/Edit/Pet/{id:guid}")]
    public async Task<IActionResult> UpdatePet([FromRoute] Guid id, [FromBody] UpdatePetCommand command)
    {
        command.Id = id;
        command.SessionUser = _sessionUser;
        return CreateResponse(await _mediator.Send(command, CancellationToken.None));
    }
    
    /// <summary>
    ///     Deleta(desativa) um pet do usuário de acordo com o ID informado.
    /// </summary>
    [HttpDelete("v1/Delete/Pet/{id:guid}")]
    public async Task<IActionResult> DeletePet([FromRoute] Guid id)
    {
        var command = new DeletePetCommand()
        {
            Id = id,
            SessionUser = _sessionUser
        };
        return CreateResponse(await _mediator.Send(command, CancellationToken.None));
    }
}