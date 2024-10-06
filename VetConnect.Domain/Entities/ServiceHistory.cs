namespace VetConnect.Domain.Entities;

public class ServiceHistory: BaseEntity
{
    public string Name { get; private set; }
    public string Description { get; private set; }
    
    public decimal Price { get; private set; }

    // Relacionamento N:1 - Um ServiceHistory pertence a um único Pet
    public Guid PetId { get; private set; }
    public Pet Pet { get; private set; }

    public ServiceHistory(string description, string name, decimal price, Guid petId)
    {
        Name = name;
        Price = price;
        Description = description;
        PetId = petId;
    }
}