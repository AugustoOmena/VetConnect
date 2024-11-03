using System.Text.Json.Serialization;

namespace VetConnect.Domain.Commands.Pets.Backoffice;

public class UpdateServiceCommand : CreateServiceByBackofficeCommand
{
    [JsonIgnore]
    public Guid? Id { get; set; }
}