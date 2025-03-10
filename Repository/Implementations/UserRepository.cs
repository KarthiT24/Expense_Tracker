using Expense_Tracker.Helper;
using Expense_Tracker.Models;
using Expense_Tracker.Models.DTOs;
using Expense_Tracker.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Expense_Tracker.Repository.Implementations
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;
        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<bool> ChangeEmail(int userId, string email)
        {
            try
            {
                var user = await _context.Users.FirstAsync(u => u.UserEmail == email);
                if (user == null)
                {
                    user = await _context.Users.FirstAsync(u => u.UserId == userId);
                    user.UserEmail = email;
                    _context.Users.Update(user);
                    await _context.SaveChangesAsync();
                    return true;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return false;
        }

        public async Task<bool> ChangePassword(int userId, string password)
        {
            var user = await _context.Users.FirstAsync(u => u.UserId == userId);
            try
            {
                user.Password = BCrypt.Net.BCrypt.HashPassword(password);
                _context.Users.Update(user);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return false;
        }

        public async Task<User?> LoginUser(UserLoginDTO userLoginDTO)
        {
            User? user = null;
            try
            {
                user = await _context.Users.FirstAsync(u => u.UserEmail == userLoginDTO.UserEmail);

                if (user != null)
                {
                    bool res = BCrypt.Net.BCrypt.Verify(userLoginDTO.Password, user.Password);
                    if (res)
                    {
                        return user;
                    }
                }
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
                var user = new User
                {
                    UserName = userRegisterDTO.UserName,
                    UserEmail = userRegisterDTO.UserEmail,
                    Password = BCrypt.Net.BCrypt.HashPassword(userRegisterDTO.Password)
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
