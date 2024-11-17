using MediatR;
using Microsoft.AspNetCore.Mvc;
using VetConnect.Api.Config;
using VetConnect.Domain.Contracts.Infra;
using VetConnect.Domain.Filters;
using VetConnect.Domain.Queries.Users;
using VetConnect.Shared.Notifications;
using VetConnect.Shared.Security;

namespace VetConnect.API.Controllers;

public class ServicesController: BaseApiController
{
    private readonly IMediator _mediator;
    private readonly SessionUser _sessionUser;

    public ServicesController(IMediator mediator, ILoggedUser loggedUser, IDomainNotification notifications) : base(mediator, loggedUser, notifications)
    {
        _mediator = mediator;
        _sessionUser = loggedUser.User;
    }
    
    /// <summary>
    ///     Listagem de serviços
    /// </summary>
    [HttpGet("v1/Common/List/Services")]
    public async Task<IActionResult> ListServicesPets([FromQuery] ListServicesHistoryFilter filter)
    {
        return CreateResponse(await _mediator.Send(
            new ListServiceHistoryToUserQuery()
            {
                Filter = filter,
                SessionUser = _sessionUser
            },
            CancellationToken.None));
    }
}