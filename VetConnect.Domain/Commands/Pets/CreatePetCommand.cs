using MediatR;
using Newtonsoft.Json;
using VetConnect.Domain.Results.Pet;
using VetConnect.Shared.Enums;
using VetConnect.Shared.Security;

namespace VetConnect.Domain.Commands.Pets;

public class CreatePetCommand: IRequest<BasePetResult>
{
    public string Name { get; set; }
    
    public EPetType PetType { get; set; }
    
    public string Race { get; set; }
    
    public DateTimeOffset BirthDate { get; set; }
    
    [JsonIgnore]
    public SessionUser SessionUser { get; set; }
}