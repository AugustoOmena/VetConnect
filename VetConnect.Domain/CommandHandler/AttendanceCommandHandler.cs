using MediatR;
using VetConnect.Domain.Commands.Pets.Backoffice;
using VetConnect.Domain.Contracts.Repositories;
using VetConnect.Domain.Results.Attendance;
using VetConnect.Shared.Notifications;
using VetConnect.Shared.Persistence;

namespace VetConnect.Domain.CommandHandler;

public class AttendanceCommandHandler: BaseCommandHandler,
    IRequestHandler<UpdateAttendanceCommand, AttendanceResult>
{
    private readonly IAttendance _attendance;
    private readonly IScheduling _scheduling;
    
    public AttendanceCommandHandler(IUnitOfWork uow, IDomainNotification notifications, IAttendance attendance, IScheduling scheduling) : base(uow, notifications)
    {
        _attendance = attendance;
        _scheduling = scheduling;
    }

    public async Task<AttendanceResult> Handle(UpdateAttendanceCommand command, CancellationToken cancellationToken)
    {
        var result = new AttendanceResult();
        
        var attendance = await _attendance.FindAsync(x => x.Id == command.Id && x.DateDeleted == null);
        
        if (attendance == null)
        {
            Notifications.Handle("Atendimento não encontrado");
            return result;
        }
        
        attendance.Update(
            command.Description,
            command.Prescription,
            command.AgentId,
            command.AttendanceStatus
            );
        
        if (!await CommitAsync())
        {
            Notifications.Handle("Houve um probema ao salvar as informações");
            return result;
        }
        
        result.Success = true;
        result.Message = "Edição feita com sucesso";
        return result;
    }
}