using BlazorApp.Shared.Models;
namespace BlazorApp.Server.Interfaces
{
    public interface IUser
    {
        public List<User> GetUserList();

        public List<User> GetUserListActive();

        public List<User> GetUserListDeleted();

        public void AddUser(User user);

        public void UpdateUserDetails(User user);

        public User GetUserData(int id);

        public void DeleteUser(int id);
    }
}