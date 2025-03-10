using Expense_Tracker.Models;
using Expense_Tracker.Models.DTOs;

namespace Expense_Tracker.Repository.Interfaces
{
    public interface IUserRepository
    {
        Task<bool> SignUpUser(UserRegisterDTO userRegisterDTO);
        Task<User?> LoginUser(UserLoginDTO userLoginDTO);

        Task<bool> ChangeEmail(int userId, string email);

        Task<bool> ChangePassword(int userId, string password);

    }
}
