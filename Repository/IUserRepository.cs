using Expense_Tracker.Models;

namespace Expense_Tracker.Repository
{
    public interface IUserRepository
    {
            Task<bool> SignUpUser(UserRegisterDTO userRegisterDTO);
            Task<User> LoginUser(UserLoginDTO userLoginDTO);

            Task<User> ChangeEmail(string email);

            Task<User> ChangePassword(string password);

    }
}
