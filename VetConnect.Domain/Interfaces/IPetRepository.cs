using VetConnect.Domain.Entities;

namespace VetConnect.Domain.Interfaces;

public interface IPetRepository: IBaseRepository<Pet>
{
    Task<Pet> GetByName(string email, CancellationToken cancellationToken);
}