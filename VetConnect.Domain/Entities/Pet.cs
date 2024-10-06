using VetConnect.Shared.Enums;

namespace VetConnect.Domain.Entities;

public class Pet : BaseEntity
{
    public string Name { get; private set; }
    public EPetType PetType { get; private set; }
    public string Race { get; private set; }
    public DateTimeOffset BirthDate { get; private set; }

    // Relacionamento N:1 - Um Pet pertence a um único User
    public Guid UserId { get; private set; }
    public User User { get; private set; }

    // Relacionamento 1:N - Um Pet pode ter vários ServiceHistory
    public ICollection<ServiceHistory> ServiceHistories { get; private set; } = new List<ServiceHistory>();

    public Pet(string name, EPetType petType, string race, DateTimeOffset birthDate, Guid userId)
    {
        Name = name;
        PetType = petType;
        Race = race;
        BirthDate = birthDate;
        UserId = userId;
    }
}