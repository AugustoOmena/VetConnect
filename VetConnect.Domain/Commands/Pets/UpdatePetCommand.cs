using System.Text.Json.Serialization;

namespace VetConnect.Domain.Commands.Pets;

public class UpdatePetCommand : CreatePetCommand
{
    [JsonIgnore]
    public Guid? Id { get; set; }
}