using Model.Dto;

namespace Interface.User
{
    public interface IUserService
    {
        Task<UserInfo> UserLogin(LoginInput input);
        bool DeleteUser(long id);
        Task<bool> AddUser(UserAddInput input);
        Task<int> UpdateUser(long id,UserInfo info);
    }
}