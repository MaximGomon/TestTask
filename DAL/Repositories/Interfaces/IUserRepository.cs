using System;
using System.Linq;
using DAL.Entities;

namespace DAL.Repositories.Interfaces
{
    public interface IUserRepository : IDisposable
    {
        IQueryable<User> GetUsersPerPage(int pageNumber, int pageSize);
        void Update(User user);
        User GetUserById(Guid id);
        void AddUser(User newUser);
        void Save();
        void DeleteUser(User userToDelete);
        void DeleteUserById(Guid id);
    }
}