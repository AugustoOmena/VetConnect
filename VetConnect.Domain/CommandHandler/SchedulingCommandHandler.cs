using MediatR;
using VetConnect.Domain.Commands.Scheduling;
using VetConnect.Domain.Contracts.Repositories;
using VetConnect.Domain.Entities;
using VetConnect.Domain.Results.Scheduling;
using VetConnect.Domain.Validators;
using VetConnect.Shared.Notifications;
using VetConnect.Shared.Persistence;

namespace VetConnect.Domain.CommandHandler;

public class SchedulingCommandHandler : BaseCommandHandler,
    IRequestHandler<CreateSchedulingByUserCommand, SchedulingResult>
{
    private readonly IScheduling _scheduling;
    private readonly IAttendance _attendance;
    private readonly IServiceHistoryRepository _serviceHistory;
    
    public SchedulingCommandHandler(IUnitOfWork uow, IDomainNotification notifications, IScheduling scheduling, IAttendance attendance, IServiceHistoryRepository serviceHistory) : base(uow, notifications)
    {
        _scheduling = scheduling;
        _attendance = attendance;
        _serviceHistory = serviceHistory;
    }

    public async Task<SchedulingResult> Handle(CreateSchedulingByUserCommand request, CancellationToken cancellationToken)
    {
        var response = new SchedulingResult();
        
        var validator = new CreateSchedulingValidator();
        var validationResult = await validator.ValidateAsync(request);

        if (!validationResult.IsValid)
        {
            response.Message = validationResult.ToString();
            return response;
        }
        
        var serviceHistory = await _serviceHistory.FindAsync(x => x.Id == request.ServiceId && x.DateDeleted == null);

        
        var newScheduling = Scheduling.New(
            request.InitialDate,
            request.EndDate,
            request.Description,
            request.PetId,
            request.ServiceId,
            serviceHistory
        );
        
        var newAttendance = Attendance.New(
            newScheduling.Id
        );
        
        await _scheduling.AddSchedulingAsync(newScheduling);
        await _attendance.AddAttendanceAsync(newAttendance);
        
        if (!await CommitAsync())
        {
            Notifications.Handle("Opa, houve um problema ao salvar os dados, por favor tente novamente mais tarde");
            return response;
        }

        response.Success = true;
        return response;
    }
}