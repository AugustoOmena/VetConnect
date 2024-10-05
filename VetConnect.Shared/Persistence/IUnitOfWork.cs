namespace VetConnect.Shared.Persistence;

public interface IUnitOfWork
{
    Task<int> SaveChangesAsync();
}