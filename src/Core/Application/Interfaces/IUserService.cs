using Application.DTOs;

namespace Application.Interfaces
{
    public interface IUserService
    {
        string GetUserById();
        CreateUserResultDto CreateUser(CreateUserDto dto);
        string UpdateUser();
        string DeleteUser();
    }
}
