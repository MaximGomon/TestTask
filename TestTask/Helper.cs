using System.Collections.Generic;
using System.Linq;
using DAL.Entities;
using TestTask.Models;

namespace TestTask
{
    public static class Helper
    {
        public static List<UserModel> ToModel(this List<User> users)
        {
            return users.Select(AutoMapper.Mapper.Map<UserModel>).ToList();
        }
    }
}