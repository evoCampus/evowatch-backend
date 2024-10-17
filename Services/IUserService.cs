using evoWatch.Models;
using evoWatch.Models.DTO;

namespace evoWatch.Services
{
    public interface IUserService
    {
        void addUser(UserDTO user);
        List<User> getUsers();
    }
}
