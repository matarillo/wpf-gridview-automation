using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    public class MainWindowViewModel
    {
        public UserCollection Users { get; set; }

        public static MainWindowViewModel CreateDummyData()
        {
            return new MainWindowViewModel
            {
                Users = new UserCollection
                {
                    new User
                    {
                        FirstName = "Nikki",
                        LastName = "Murphy",
                        Email = "Freda.McDermott@hotmail.com",
                        Password = "UOF3jC8S_E5sevn",
                        DisplayName = "Karine.Murazik"
                    },
                    new User
                    {
                        FirstName = "Hayley",
                        LastName = "Reichel-Watsica",
                        Email = "Aaliyah23@hotmail.com",
                        Password = "F2EAFyTqHbR4Kt6",
                        DisplayName = "Alek.Osinski45"
                    },
                    new User
                    {
                        FirstName = "Keegan",
                        LastName = "Connelly",
                        Email = "Trey_Satterfield80@hotmail.com",
                        Password = "bRtsuoo1tYIHS3b",
                        DisplayName = "Edythe_Conroy83"
                    }
                }
            };
        }
    }
}
