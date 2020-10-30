using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLibrary.Models;
using DataLibrary.DataAccess;

namespace DataLibrary.BusinessLogic
{
    public static class UsersProcessor
    {
        public static List<Object> GetScopeUserIdentity()
        {
            return SqlDataAccess.GetScopeIdentity();
        }
        public static int CreateUser(string _Username, string _Password, string _FirstName,
            string _LastName, string _EmailAddress, string _PhoneNumber, int _Role)
        {
            UsersModel data = new UsersModel
            {
                Username = _Username,
                Password = _Password,
                FirstName = _FirstName,
                LastName = _LastName,
                EmailAddress = _EmailAddress,
                PhoneNumber = _PhoneNumber,
                Role = _Role
            };
            string sql = @"insert into dbo.tbl_Users (Username, Password, FirstName, LastName, EmailAddress, PhoneNumber, Role)
                            values(@Username, @Password, @FirstName, @LastName, @EmailAddress, @PhoneNumber, @Role)";
            System.Diagnostics.Debug.WriteLine(sql);
            return SqlDataAccess.SaveData(sql, data);
        }

        public static List<UsersModel> LoadUsers()
        {
            string sql = @"select * from dbo.tbl_Users";
            System.Diagnostics.Debug.WriteLine(sql);
            return SqlDataAccess.LoadData<UsersModel>(sql);
        }

        public static UsersModel LoadOneUser(int id)
        {
            string sql = String.Format("SELECT * from dbo.tbl_Users WHERE UserID = {0}", id);
            List<UsersModel> user = SqlDataAccess.LoadData<UsersModel>(sql);

            System.Diagnostics.Debug.WriteLine(sql);

            if (user.Count > 0)
                return user[0];
            else
                return null;
        }

        public static UsersModel GetUser(string _username, string _password)
        {
            string sql = String.Format("SELECT * from dbo.tbl_Users WHERE Username = '{0}' AND Password = '{1}' ", _username, _password);
            List<UsersModel> user = SqlDataAccess.LoadData<UsersModel>(sql);

            System.Diagnostics.Debug.WriteLine(sql);

            if (user.Count > 0)
                return user[0];
            else
                return null;
        }

        public static UsersModel GetUser(string _username, string _password, int isAdmin = 1)
        {
            string sql = String.Format("SELECT * from dbo.tbl_Users WHERE Username = '{0}' AND Password = '{1}' AND Role >= {2}", _username, _password, isAdmin);
            List<UsersModel> user = SqlDataAccess.LoadData<UsersModel>(sql);

            System.Diagnostics.Debug.WriteLine(sql);

            if (user.Count > 0)
                return user[0];
            else
                return null;
        }

        public static UsersModel GetUser(string _username)
        {
            string sql = String.Format("SELECT Username, Password, FirstName, LastName, EmailAddress, PhoneNumber, Role from dbo.tbl_Users WHERE Username = '{0}' ", _username);
            List<UsersModel> user = SqlDataAccess.LoadData<UsersModel>(sql);

            System.Diagnostics.Debug.WriteLine(sql);

            if (user.Count > 0)
                return user[0];
            else
                return null;
        }
    }
}
