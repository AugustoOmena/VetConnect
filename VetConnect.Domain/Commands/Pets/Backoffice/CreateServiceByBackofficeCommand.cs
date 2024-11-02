using System.Text.Json.Serialization;
using MediatR;
using VetConnect.Domain.Entities;
using VetConnect.Domain.Results.ServiceVet;
using VetConnect.Shared.Security;

namespace VetConnect.Domain.Commands.Pets.Backoffice;

public class CreateServiceByBackofficeCommand: IRequest<BaseServiceHistoryResult>
{
    public string Name { get; set; }
    
    public string Description { get; set; }
    
    public decimal Price { get; set; }
    
    [JsonIgnore]
    public Guid PetId { get; set; }
    
    [JsonIgnore]
    public Pet? Pet { get; set; }
    
    [JsonIgnore]
    public SessionUser? SessionUser { get; set; }
}