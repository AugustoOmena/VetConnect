using System.Text.Json.Serialization;
using MediatR;
using VetConnect.Domain.Results.Scheduling;
using VetConnect.Shared.Enums;
using VetConnect.Shared.Security;

namespace VetConnect.Domain.Commands.Scheduling;

public class CreateSchedulingByUserCommand : IRequest<SchedulingResult>
{
    [JsonIgnore]
    public Guid? Id { get; set; }
    
    public DateTimeOffset InitialDate { get; set; }
    
    public DateTimeOffset EndDate { get; set; }
    
    public string? Description { get; set; }
    
    public Guid ServiceId { get; set; }
    
    [JsonIgnore]
    public Guid PetId { get; set; }
    
    [JsonIgnore]
    public Guid UserId { get; set; }
    
    [JsonIgnore]
    public SessionUser? SessionUser { get; set; }
}