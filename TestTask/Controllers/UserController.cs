using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAL;
using DAL.Entities;
using DAL.Repositories.Implementations;
using DAL.Repositories.Interfaces;
using Microsoft.Ajax.Utilities;
using TestTask.Models;

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
        public ActionResult List(int pageNumber = 1, int pageSize = 5)
        {
            var users = _repository.GetUsersPerPage(pageNumber, pageSize).ToList().ToModelList();
            return View(users);
        }

        [HttpPost]
        public ActionResult Add(UserModel userModel)
        {
            if (Validate(userModel) && ModelState.IsValid)
            {
                var user = userModel.ToDbEntity();
                _repository.AddUser(user);
                return RedirectToAction("List");
            }
            return Json("Form validation error"); //Json("Form validation error"); //PartialView("Add", userModel);
        }

        [HttpGet]
        public ActionResult Add()
        {
            var user = new User();
            return View(user.ToModel());
        }

        [HttpPost]
        public ActionResult Save(UserModel userModel)
        {
            if (Validate(userModel) && ModelState.IsValid)
            {
                var user = userModel.ToDbEntity();
                _repository.Update(user);
                return RedirectToAction("List");
            }
            return PartialView("Add");
        }

        [HttpGet]
        public ActionResult Edit(Guid userId)
        {
            var user = _repository.GetUserById(userId);
            return PartialView("Add", user.ToModel());
        }

        [HttpGet]
        public ActionResult Delete(Guid userId)
        {
            _repository.DeleteUserById(userId);
            return View("List");
        }

        private bool Validate(UserModel userModel)
        {
            if (userModel.Address.IsNullOrWhiteSpace())
            {
                return false;
            }
            if (!userModel.Email.IsEmailValid())
            {
                return false;
            }
            return true;
        }
    }
}