using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace TravelTourConsole.Services
{
    public partial class RegistrationService
    {
        List<User> users = new List<User>();
        private int nextid = 1;
        public RegistrationService() { }
        





        public void Run()
        {
            Console.Clear();
            Console.WriteLine("******* SubMenu *******");
            Console.WriteLine("11_Registeration");
            Console.WriteLine("12_ShowUser");
            Console.WriteLine("13_Login");
            Console.WriteLine("-11 Back to main menu");

            string choice = Console.ReadLine();
            switch (choice) {
                case "11": Registeration();
                    break;
                case "12": ShowUser();
                    break;
                case "13": Login();
                    break;
                case "-11":
                    return;
            }
        }
        public void Registeration() {
            Console.WriteLine("New User Registration:");
            string username = "";
            Console.WriteLine("Enter username");
            username = Console.ReadLine();
            if (username == "")
            {
                Console.WriteLine("Username cannot empty!");

            }
            else if (UsernameExisist(username) == true) {
                Console.WriteLine("This username is already Registed.");
                username = "";
            }
            string Password = "";
            while (Password == "") {
                Console.WriteLine("Password");
                Password = Console.ReadLine();
                if (Password == "") {

                    Console.WriteLine("Password cannot empty!");
                }


            }
            string Fullname = "";
            while (Fullname == "") {
                Console.WriteLine("FullName:");
                Fullname = Console.ReadLine();
                if (Fullname == "") {
                    Console.WriteLine("FullName cannot empty!");
                }
            }
            string Phoneinput = "";
            int Phonenumber = 1;
            while (Phoneinput == "") {
                Console.WriteLine("Phone number:");
                Phoneinput = Console.ReadLine();
                if (Phoneinput == "")
                {
                    Console.WriteLine("Phone number cannot empty!");
                }
                else {
                    Phonenumber = int.Parse(Phoneinput);
                    Console.WriteLine("Registration completed successfully");
                }

            }
            var u = new User();
            u.id = nextid;
            u.Username = username;
            u.Password = Password;
            u.Fullname = Fullname;
            u.phoneNumber = Phonenumber;

            users.Add(u);
            nextid++;

        }
        private bool UsernameExisist(string namee) {
            for (int i = 0; i < users.Count; i++) {
                if (users[i].Username == namee)
                {
                    return true;
                }


            }
            return false;
        }
        public void ShowUser() {
            if (users.Count == 0) {
                Console.WriteLine("No user Registed!");
            }
            foreach (var u in users) {
                Console.WriteLine(u.id + "|" + u.Username + "|" + u.Fullname + "|" + u.phoneNumber);
            }

        }
        public bool Login()
        {
            Console.WriteLine("User Login:");
            string userName = Console.ReadLine();
            Console.WriteLine("PasswordL");
            string password = Console.ReadLine();
            for (int i = 0; i < users.Count; i++) {
                if (users[i].Username == userName && users[i].Password == password) {
                    Console.WriteLine("Login successful");
                    return true;
                }
            }
            Console.WriteLine("Username or Password incorrect!");
            return false;
        }
    }
}










            