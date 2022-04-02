using BookingSystemWebAPI.Models.Entities;
using System.Threading.Tasks;

namespace BookingSystemWebAPI.Repositories
{
    public interface IAuthRepository
    {
        Task<ServiceResponse<int>> Register(User user, string password);

        ServiceResponse<string> Login(string username, string password);

        bool UserExists(string username);
    }
}