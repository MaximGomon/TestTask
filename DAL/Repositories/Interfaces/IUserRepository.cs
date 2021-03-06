﻿using System;
using System.Linq;
using DAL.Entities;

namespace DAL.Repositories.Interfaces
{
    public interface IUserRepository : IDisposable
    {
        IQueryable<User> GetUsersPerPage(int pageNumber, int pageSize = 5);
        IQueryable<User> GetAllUsers();
        bool Exists(Guid userId);
        void Update(User user);
        User GetUserById(Guid id);
        void AddUser(User newUser);
        void Save();
        void DeleteUser(User userToDelete);
        void DeleteUserById(Guid id);
    }
}