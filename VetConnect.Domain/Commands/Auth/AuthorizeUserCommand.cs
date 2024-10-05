using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using MediatR;
using VetConnect.Domain.Results.Auth;

namespace VetConnect.Domain.Commands.Auth;

public class AuthorizeUserCommand: IRequest<AuthorizeUserResult>
{
    [Required(ErrorMessage = "O campo Email é obrigatório.")]
    [EmailAddress(ErrorMessage = "O campo Email deve ser um endereço de e-mail válido.")]
    public string Email { get; set; }

    [Required(ErrorMessage = "O campo Senha é obrigatório.")]
    public string Password { get; set; }

    [JsonIgnore]
    [Required]
    [StringLength(50)]
    public string UserType { get; set; }
    
    //[JsonIgnore] public int? ExpirationTimeDefault { get; set; }
}