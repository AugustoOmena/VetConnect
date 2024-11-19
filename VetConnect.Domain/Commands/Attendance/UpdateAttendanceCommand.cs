using System.Text.Json.Serialization;
using MediatR;
using VetConnect.Domain.Results.Attendance;
using VetConnect.Shared.Enums;
using VetConnect.Shared.Security;

namespace VetConnect.Domain.Commands.Pets.Backoffice;

public class UpdateAttendanceCommand : IRequest<AttendanceResult>
{
    [JsonIgnore]
    public SessionUser? SessionUser { get; set; }
    
    public string? Description { get; set; }
    
    public string? Prescription { get; set; }
    
    [JsonIgnore]
    public Guid AgentId { get; set; }
    
    public EAttendanceStatus AttendanceStatus { get; set; }
    
    [JsonIgnore]
    public Guid? Id { get; set; }
}