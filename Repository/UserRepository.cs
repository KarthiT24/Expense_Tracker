using Expense_Tracker.Helper;
using Expense_Tracker.Models;
using Microsoft.EntityFrameworkCore;

namespace Expense_Tracker.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        private User user;
        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<User> ChangeEmail(string email)
        {
            throw new NotImplementedException();
        }

        public async Task<User> ChangePassword(string password)
        {
            throw new NotImplementedException();
        }

        public async Task<User> LoginUser(UserLoginDTO userLoginDTO)
        {
            try
            {
                  user = await _context.Users.FirstAsync(u => u.UserEmail == userLoginDTO.UserEmail && u.Password == userLoginDTO.Password);  
            }
            catch (Exception e)
            {
                  Console.WriteLine(e);
            }
            return user;
        }

        public async Task<bool> SignUpUser(UserRegisterDTO userRegisterDTO)
        {
            try
            {
                var existingUser = await _context.Users.FirstOrDefaultAsync(u => u.UserEmail == userRegisterDTO.UserEmail);
                if (existingUser != null)
                {
                    return false;
                }
                user = new User
                {
                    UserName = userRegisterDTO.UserName,
                    UserEmail = userRegisterDTO.UserEmail,
                    Password = userRegisterDTO.Password
                };
                await _context.Users.AddAsync(user);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
            return true;
        }
    }
}
