using AutoMapper;
using VetConnect.Domain.Entities;
using VetConnect.Domain.Validators.Requests;

namespace ClinicManagementSystem.API.UseCases.CreateUser;

public sealed class CreateUserMapper : Profile
{
    public CreateUserMapper()
    {
        CreateMap<CreateUserRequest, User>();
        CreateMap<User, CreateUserResponse>();
    }
}