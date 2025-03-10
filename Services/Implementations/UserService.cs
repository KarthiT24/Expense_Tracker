using Expense_Tracker.Helper;
using Expense_Tracker.Models;
using Expense_Tracker.Models.DTOs;
using Expense_Tracker.Repository.Interfaces;
using Expense_Tracker.Services.Interfaces;

namespace Expense_Tracker.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _configuration;
        private User? user;

        public UserService(IUserRepository userRepository, IConfiguration configuration)
        {
            _userRepository = userRepository;
            _configuration = configuration;
        }
        public async Task<string?> LoginUser(UserLoginDTO userLoginDTO)
        {
            try
            {
                user = await _userRepository.LoginUser(userLoginDTO);
                if (user != null)
                {
                    var token = JwtTokenGenerator.GenerateToken(user.UserId,
                        user.UserEmail,
                        _configuration["Jwt:Key"],
                        _configuration["Jwt:Issuer"],
                        _configuration["Jwt:Audience"]
                        );
                    return token;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }

        public async Task<bool> SignUpUser(UserRegisterDTO userRegisterDTO)
        {
            var result = false;
            try
            {
                result = await _userRepository.SignUpUser(userRegisterDTO);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return result;
        }

        public async Task<bool> ChangeEmail(int id, string email)
        {
            bool result = false;
            try
            {
                result = await _userRepository.ChangeEmail(id, email);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return result;
        }

        public async Task<bool> ChangePassword(int id, string password)
        {
            bool result = false;
            try
            {
                result = await _userRepository.ChangePassword(id, password);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return result;
        }
    }
}
