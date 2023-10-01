using SocialNetwork.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.PLL.Views
{
    public class FriendMenuView
    {
        public void Show(User user)
        {
            while (true)
            {
                ///Возможно лучше сразу выводить друзей
                Console.WriteLine("Мои друзья:");
                Program.friendInfoView.Show(user);
                ///Возможно лучше сразу добавлять и удалять друзей 1-й кнопкой
                Console.WriteLine("Выберите действие:");
                Console.WriteLine("* Добавить друга (нажмите 1)");
                Console.WriteLine("* Удалить из друзей (нажмите 2)");

                Console.WriteLine("Выйти из профиля (нажмите 3)");

                string keyValue = Console.ReadLine();

                if (keyValue == "3") break;

                switch (keyValue)
                {
                    case "1":
                        {
                            Console.WriteLine("Введите почтовый адрес:");
                            var friendEmail = Console.ReadLine();
                            Program.friendAddRemoveView.Add(user,friendEmail);
                            break;
                        }
                    case "2":
                        {
                            //Program.userFriendEditView.Show(user);
                            break;
                        }
                }
            }
        }
    }
}
