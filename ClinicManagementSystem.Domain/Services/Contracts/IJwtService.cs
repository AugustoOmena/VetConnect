using ClinicManagementSystem.Domain.Entities;

namespace ClinicManagementSystem.Domain.Services.Contracts;

public interface IJwtService
{
    string GenerateToken(User usuario);
}