namespace VetConnect.Domain.Entities;

public class ServiceHistory: BaseEntity
{
    protected ServiceHistory(){}
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
    
    public static ServiceHistory New(
        string name,
        string description,
        decimal price,
        Guid petId
    ) => new ServiceHistory
    {
        DateCreated = DateTime.UtcNow,
        Id = Guid.NewGuid(),
        Name = name,
        Description = description,
        Price = price,
        PetId = petId
    };
    
    public void Delete()
    {
        DateDeleted = DateTime.UtcNow;
    }
}