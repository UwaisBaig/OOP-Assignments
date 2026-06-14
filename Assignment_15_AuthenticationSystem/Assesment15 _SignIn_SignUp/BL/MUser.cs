using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assesment_15_SignUp_Classes.BL
{
    public class MUser
    {
        public string userName;
        public string userPassword;
        public string userRole;
        public static List<MUser> usersList = new List<MUser>();
        public MUser(string userName, string userPassword, string userRole)
        {
            this.userName = userName;
            this.userPassword = userPassword;
            this.userRole = userRole;
        }

        public bool isAdmin()
        {
            if (userRole == "Admin")
            {
                return true;
            }
            return false;
        }

        public static bool addUserIntoList(MUser user)
        {
            foreach (MUser storedUser in usersList)
            {
                if (storedUser.userName.ToLower() == user.userName.ToLower())
                {
                    return false;
                }
            }
            usersList.Add(user);
            return true;
        }
        public static MUser isValid(MUser user)
        {
            foreach (MUser storedUser in usersList)
            {
                if (storedUser.userName == user.userName && storedUser.userPassword == user.userPassword)
                {
                    return storedUser;
                }
            }
            return null;
        }
    }
}