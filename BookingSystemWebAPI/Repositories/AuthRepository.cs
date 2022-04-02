using BookingSystemWebAPI.Data;
using BookingSystemWebAPI.Models.Entities;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace BookingSystemWebAPI.Repositories
{
    public class AuthRepository : IAuthRepository
    {
        private readonly DataContext _dataContext;


        public AuthRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public ServiceResponse<string> Login(string username, string password)
        {
            var serviceResponse = new ServiceResponse<string>();
            var user = _dataContext.Users.FirstOrDefault(x => x.UserName.ToLower() == username.ToLower());

            if (user == null)
            {
                serviceResponse.Success = false;
                serviceResponse.ErrorMessage = "User not found";
            }
            else if (!VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
            {
                serviceResponse.Success = false;
                serviceResponse.ErrorMessage = "Wrong password";
            }
            else
            {
                serviceResponse.Data = user.Id.ToString();
            }

            return serviceResponse;

        }

        public async Task<ServiceResponse<int>> Register(User user, string password)
        {
            var response = new ServiceResponse<int>();

            if (UserExists(user.UserName))
            {
                response.Success = false;
                response.ErrorMessage = "User already exists";
                return response;
            }

            CreatePasswordHash(password, out byte[] passwordHash, out byte[] passwordSalt);

            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            await _dataContext.Users.AddAsync(user);
            await _dataContext.SaveChangesAsync();

            
            response.Data = user.Id;
            response.Success = true;

            return response;
        }

        public bool UserExists(string username)
        {
            if (_dataContext.Users.Any(x => x.UserName.ToLower() == username.ToLower()))
            {
                return true;
            }
            return false;
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using(var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != passwordHash[i])
                        return false;
                }
                return true;
            }
        }
    }
}
