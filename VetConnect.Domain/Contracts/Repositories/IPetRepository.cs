using System.Linq.Expressions;
using VetConnect.Domain.Entities;
using VetConnect.Domain.Queries.Backoffice;
using VetConnect.Domain.Queries.Users;
using VetConnect.Shared.Persistence;

namespace VetConnect.Domain.Contracts.Repositories;

public interface IPetRepository : IRepository<Pet>
{
    Task<T> AddPetAsync<T>(T pet);
    
    Expression<Func<Pet, bool>> Where(PetsByUserQuery query);
    
    Expression<Func<Pet, bool>> Where(ListPetsByUserIdQuery query);


}