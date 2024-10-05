namespace ClinicManagementSystem.Shared.Persistence;

public interface IUnitOfWork
{
    Task<int> SaveChangesAsync();
}