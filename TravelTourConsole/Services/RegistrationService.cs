using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelTourConsole.Services
{
    public class RegistrationService
    {
       
        

      private  List<User>users1=new List<User>();
      private  int nextid = 1;
        

        public void Run()
        {
            Console.Clear();
            Console.WriteLine("******* SubMenu *******");
            Console.WriteLine("11.Registeration");
            Console.WriteLine("12.show users");
            Console.WriteLine("13.login");
            Console.WriteLine("-11.Back to Main menu");
            Console.Write(" enter your choice:");
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "11":
                    Registeration();
                    break;
                case "12":
                    showusers();
                    break;
                case "13":
                    Login();
                    break;
                case "-11":
                    return;

            }

            
            
        }

        class User
        {
            public string Fullname;
            public string Username;
            public int id;
            public string Password;
            public int phoneNumber;


        }
        public void Registeration()
        {
            Console.WriteLine("New user registration :");
            
           string Username= Console.ReadLine();
            if (Username == " ")
            {
                Console.WriteLine("Username cannot empty!");
                Console.ReadLine();

                if (UsernameExisist(Username))
                {
                    Console.WriteLine("This userename is already registered :");
                    Console.ReadLine();
                    return;
                }
            }
            return;
            Console.Write("Password :");
            string Password = Console.ReadLine();
            if (Password == " ")
            {
                Console.WriteLine("Pssword cannot empty!");
            }
            Console.Write("Fullname :");
            string Fullname = Console.ReadLine();

            Console.Write(" Phone Number :");
            int PhoneNumber = int.Parse(Console.ReadLine());

            var u = new User();
            u.id = nextid;
            u.Username = Username;
            u.Password = Password;
            u.Fullname = Fullname;
            u.phoneNumber = PhoneNumber;
            nextid = nextid + 1;
            users1.Add(u);

            Console.WriteLine("Registration is Succesful");
        }




        private bool UsernameExisist(string username)
        {
            foreach (var u in users1)
            {
                if (u.Username == username)
                {
                    return true;
                   
                }
            } return false;

        }

        public void showusers()
        {
            if (users1.Count == 0)
            {
                Console.WriteLine("No user registed!");
                return;
                foreach (var u in users1)
                {
                    Console.WriteLine(u.id + "|" + u.Username + "|" + u.Fullname + "|" + u.phoneNumber);
                }
                return;


            }



        }

        private void Login()
        {
            Console.Write("username :");
            string userName = Console.ReadLine();
            User user = null;
            foreach (var x in users1)
            {
                if (x.Username == userName)
                {
                    user = x;
                    break;
                    if (user == null)
                    
                        Console.WriteLine("user not found");

                    
                }


            }
            string pass = Console.ReadLine();
            if (pass == user.Password)
            {
                Console.WriteLine("Login Succsessful");

            }
            else
            {
                Console.WriteLine("Password is wrong");
            }


        }
    }
}





