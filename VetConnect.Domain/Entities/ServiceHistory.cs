using VetConnect.Shared.Enums;

namespace VetConnect.Domain.Entities;

public class ServiceHistory: BaseEntity
{
    protected ServiceHistory(){}
    public string Name { get; private set; }
    public string Description { get; private set; }
    
    public decimal Price { get; private set; }

    public EServiceType ServiceType { get; private set; }

    public ServiceHistory(string description, string name, decimal price,  EServiceType serviceType)
    {
        Name = name;
        Price = price;
        Description = description;
        ServiceType = serviceType;
    }
    
    public static ServiceHistory New(
        string name,
        string description,
        decimal price,
        EServiceType serviceType
    ) => new ServiceHistory
    {
        DateCreated = DateTime.UtcNow,
        Id = Guid.NewGuid(),
        Name = name,
        Description = description,
        Price = price,
        ServiceType = serviceType
    };
    
    public void Update(
        string name,
        string description,
        decimal price
    )
    {
        DateUppdated = DateTime.UtcNow;
        Name = name;
        Description = description;
        Price = price;
    }
    
    public void Delete()
    {
        DateDeleted = DateTime.UtcNow;
    }
}