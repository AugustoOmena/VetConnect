using VetConnect.Domain.Entities;

namespace VetConnect.Domain.Services.Contracts;

public interface IJwtService
{
    string GenerateToken(User usuario);
}