using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using DAL.Entities;
using DAL.Repositories.Interfaces;

namespace DAL.Repositories.Implementations
{
    public class UserRepository : IUserRepository
    {
        private readonly UserDbContext _context;

        public UserRepository(UserDbContext context)
        {
            _context = context;
        }

        public IQueryable<User> GetUsersPerPage(int pageNumber, int pageSize)
        {
            return _context.Users.OrderBy(x => x.Id).Skip(pageNumber*pageSize).Take(pageSize);
        }

        public void Update(User user)
        {
            _context.Entry(user).State = EntityState.Modified;
        }

        public User GetUserById(Guid id)
        {
            return _context.Users.Find(id);
        }

        public void AddUser(User newUser)
        {
            _context.Users.Add(newUser);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void DeleteUser(User userToDelete)
        {
            _context.Users.Remove(userToDelete);
        }

        public void DeleteUserById(Guid id)
        {
            var user = GetUserById(id);
            _context.Users.Remove(user);
        }

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}