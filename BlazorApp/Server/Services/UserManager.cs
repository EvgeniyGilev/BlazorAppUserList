using BlazorApp.Server.Interfaces;
using BlazorApp.Server.Models;
using BlazorApp.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp.Server.Services
{
    public class UserManager : IUser
    {
        private readonly DatabaseContext _dbContext;
        public UserManager(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        // список пользователей
        public List<User> GetUserList()
        {
            return _dbContext.Users.ToList();
        }

        // список активных пользователей
        public List<User> GetUserListActive()
        {
            return _dbContext.Users.Where(u => u.IsActive == 1).ToList();
        }

        // список пользователей в архиве
        public List<User> GetUserListDeleted()
        {
            return _dbContext.Users.Where(u => u.IsActive == 0).ToList();
        }

        // Для добавления новой записи пользователя
        public void AddUser(User user)
        {
            user.IsActive = 1;
            _dbContext.Users.Add(user);
            _dbContext.SaveChanges();
        }

        // Для обновления записи конкретного пользователя
        public void UpdateUserDetails(User user)
        {
            _dbContext.Entry(user).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }

        // Для получения информации о конкретном пользователе
        public User GetUserData(int id)
        {
            User? user = _dbContext.Users.Find(id);
            if (user != null)
            {
                return user;
            }

            throw new ArgumentNullException();
        }
        //Для удаления записи конкретного пользователя
        public void DeleteUser(int id)
        {
            User? user = _dbContext.Users.Find(id);
            if (user != null)
            {
                user.IsActive = 0;
                _dbContext.Entry(user).State = EntityState.Modified;
                _dbContext.SaveChanges();
            }
            else
            {
                throw new ArgumentNullException();
            }
        }
    }
}