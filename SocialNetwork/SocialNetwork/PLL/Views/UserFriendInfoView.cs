using SocialNetwork.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.PLL.Views
{
    public class UserFriendInfoView
    {
        public void Show(User user)
        {
            Console.WriteLine($"...Показать здесь друзей пользователя {user.FirstName} {user.LastName}...");
        }
    }
}
