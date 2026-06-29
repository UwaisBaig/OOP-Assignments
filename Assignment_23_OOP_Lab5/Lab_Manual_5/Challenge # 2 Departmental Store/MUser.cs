using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge___2_Departmental_Store
{
    // --- BUSINESS LOGIC ---
    public class MUser
    {
        public string username;
        public string password;
        public string role; // "Admin" or "Customer"

        public MUser(string username, string password, string role)
        {
            this.username = username;
            this.password = password;
            this.role = role;
        }
    }

    // --- DATA LAYER ---
    public class MUserDL
    {
        public static List<MUser> users = new List<MUser>();

        public static void addUser(MUser u)
        {
            users.Add(u);
        }

        public static MUser signIn(string username, string password)
        {
            foreach (MUser u in users)
            {
                if (u.username == username && u.password == password)
                    return u;
            }
            return null;
        }
    }

    // --- USER INTERFACE ---
    public class MUserUI
    {
        public static MUser takeInput()
        {
            Console.Write("Enter Username: ");
            string username = Console.ReadLine();
            Console.Write("Enter Password: ");
            string password = Console.ReadLine();
            Console.Write("Enter Role (Admin/Customer): ");
            string role = Console.ReadLine();

            return new MUser(username, password, role);
        }

        public static MUser takeLoginInput()
        {
            Console.Write("Enter Username: ");
            string username = Console.ReadLine();
            Console.Write("Enter Password: ");
            string password = Console.ReadLine();

            return new MUser(username, password, ""); // Role isn't needed for search
        }
    }
}