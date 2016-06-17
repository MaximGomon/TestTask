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
using PagedList;
using TestTask.Models;

namespace TestTask.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserRepository _repository;
        public UserController(IUserRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public ActionResult List(int pageNumber = 1, int pageSize = 5)
        {
            //var users = _repository.GetUsersPerPage(pageNumber, pageSize).ToList().ToModelList();
            //return View(users.ToPagedList(pageNumber, pageSize));
            return View(_repository.GetAllUsers().ToModelList().ToPagedList(pageNumber, pageSize));
        }

        [HttpPost]
        public ActionResult AddOrUpdate(UserModel userModel)
        {
            if (Validate(userModel) && ModelState.IsValid)
            {
                var user = userModel.ToDbEntity();
                if (!_repository.Exists(user.Id))
                {
                    _repository.AddUser(user);
                }
                else
                {
                    _repository.Update(user);
                }
                _repository.Save();
                return Content("<script>window.location.reload();</script>");
                //return RedirectToAction("List");
            }
            return Json("Form validation error");//PartialView("Add", userModel);
        }

        [HttpGet]
        public ActionResult Add()
        {
            var user = new User();
            return View(user.ToModel());
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
            _repository.Save();
            return RedirectToAction("List");
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