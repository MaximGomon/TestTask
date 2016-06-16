using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAL;
using DAL.Repositories.Implementations;
using DAL.Repositories.Interfaces;

namespace TestTask.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserRepository _repository;
        public UserController()
        {
            _repository = new UserRepository(new UserDbContext());
        }

        [HttpGet]
        public ActionResult List(int pageNumber, int pageSize)
        {
            var users = _repository.GetUsersPerPage(pageNumber, pageSize).ToList().ToModel();
            return View(users);
        }

        [HttpGet]
        public ActionResult List(int pageNumber = 1)
        {
            var users = _repository.GetUsersPerPage(pageNumber).ToList().ToModel();
            return View(users);
        }
    }
}