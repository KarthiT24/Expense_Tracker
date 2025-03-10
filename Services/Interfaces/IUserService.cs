using Expense_Tracker.Models.DTOs;

namespace Expense_Tracker.Services.Interfaces
{
    public interface IUserService
    {
        Task<bool> SignUpUser(UserRegisterDTO userRegisterDTO);

        Task<string?> LoginUser(UserLoginDTO userLoginDTO);

        Task<bool> ChangeEmail(int id, string email);

        Task<bool> ChangePassword(int id, string password);


    }
}
