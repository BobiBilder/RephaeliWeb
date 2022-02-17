using MasterProject.DAL;
using MasterProject.Models;
using MasterProject.ViewModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
namespace MasterProject.BLL
{
    public class UserBLL
    {
        UserDB userDB = new UserDB();

        public LoginUser UsersLogin(string IDnum, string userPass, bool isWorker)
        {
            DataTable dt = userDB.UserLogin(IDnum, userPass, isWorker);
            if(dt != null && dt.Rows.Count > 0)
            {

                LoginUser user = new LoginUser();
                user.FirstName = dt.Rows[0]["FirstName"].ToString();
                user.LastName = dt.Rows[0]["LastName"].ToString();
                user.IDnum = dt.Rows[0]["IDnum"].ToString();
                user.IsWorker = isWorker;
                if (isWorker)
                {
                    user.id = int.Parse(dt.Rows[0]["EmployeeID"].ToString()); 
                    user.IsManager = bool.Parse(dt.Rows[0]["IsManager"].ToString());
                }
                else
                {
                    user.id = int.Parse(dt.Rows[0]["ClientID"].ToString());
                }
                return user;
            }
            return null;
        }
    }
}