using VetConnect.Domain.Entities;
using VetConnect.Domain.ViewModels.Users;

namespace VetConnect.Domain.Projections;

public static class UserProjections
{
    public static UserVm ToVm(this User user) => new UserVm
    {
        Id = user.Id,
        FirstName = user.FirstName,
        LastName = user.LastName,
        UserType = user.UserType,
        Email = user.Email,
        Phone = user.Phone,
        Pets = user.Pets
    };
    
    public static IEnumerable<UserVm> ToVm(this IEnumerable<User> users) => 
        users.Select(user => user.ToVm());
}