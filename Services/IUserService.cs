using Expense_Tracker.Models;

namespace Expense_Tracker.Services
{
    public interface IUserService
    {
        Task SignUpUser(UserRegisterDTO userRegisterDTO);

        Task LoginUser(UserLoginDTO userLoginDTO);

        
    }
}
