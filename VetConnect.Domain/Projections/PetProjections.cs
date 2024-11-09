using VetConnect.Domain.Entities;
using VetConnect.Domain.ViewModels.Pets;

namespace VetConnect.Domain.Projections;

public static class PetProjections
{
    public static PetVm ToVm(this Pet pet) => new PetVm
    {
        Id = pet.Id,
        Name = pet.Name,
        PetType = pet.PetType,
        Race = pet.Race,
        BirthDate = pet.BirthDate,
        UserName = (pet.User.FirstName + " " + pet.User.LastName),
        UserId = pet.UserId
    };
    
    public static IEnumerable<PetVm> ToVm(this IEnumerable<Pet> pets) => 
        pets.Select(pet => pet.ToVm());
}