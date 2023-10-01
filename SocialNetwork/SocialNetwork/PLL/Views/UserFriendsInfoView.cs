using SocialNetwork.BLL.Models;
using SocialNetwork.BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.PLL.Views
{
    public class UserFriendsInfoView
    {
        public void Show(User user)
        {
            Console.WriteLine($"...Показать здесь друзей пользователя {user.FirstName} {user.LastName}...");
        }
    }
}
