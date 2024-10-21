namespace VetConnect.Domain.Contracts.Repositories;

public interface IPetRepository
{
    Task<T> AddPetAsync<T>(T pet);
}