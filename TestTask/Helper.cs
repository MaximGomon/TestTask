using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using DAL.Entities;
using TestTask.Models;
using AutoMapper;

namespace TestTask
{
    public static class Helper
    {
        public static IQueryable<UserModel> ToModelList(this IQueryable<User> users)
        {
            Mapper.Initialize(cfg => {
                cfg.CreateMap<User, UserModel>();
            });
            return users.Select(Mapper.Map<UserModel>).AsQueryable();
        }

        public static UserModel ToModel(this User user)
        {
            Mapper.Initialize(cfg => {
                cfg.CreateMap<User, UserModel>();
            });
            return Mapper.Map<UserModel>(user);
        }

        public static User ToDbEntity(this UserModel userModel)
        {
            Mapper.Initialize(cfg => {
                cfg.CreateMap<UserModel, User>();
            });
            return AutoMapper.Mapper.Map<User>(userModel);
        }
        public static bool IsEmailValid(this string emailaddress)
        {
            try
            {
                MailAddress m = new MailAddress(emailaddress);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }
    }
}