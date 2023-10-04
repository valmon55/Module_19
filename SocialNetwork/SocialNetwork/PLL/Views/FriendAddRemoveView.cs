using SocialNetwork.BLL.Exceptions;
using SocialNetwork.BLL.Models;
using SocialNetwork.BLL.Services;
using SocialNetwork.DAL.Entities;
using SocialNetwork.PLL.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.PLL.Views
{
    public class FriendAddRemoveView
    {
        FriendService friendService;
        public FriendAddRemoveView(FriendService friendService)
        {
            this.friendService = friendService;
        }

        public void Add(User user, string friendEmail)
        {
            try
            {
                friendService.AddFriend(user, friendEmail);
                SuccessMessage.Show($"Друг с {friendEmail} успешно добавлен.");
            }
            catch(Exception e) 
            { 
                AlertMessage.Show("Error: " + e.Message);
            }
        }
        public void Remove(User user, string friendEmail)
        {
            try
            {
                friendService.RemoveFriend(user, friendEmail);
                SuccessMessage.Show($"Друг с {friendEmail} успешно удален.");
            }
            catch (UserNotFoundException)
            {
                AlertMessage.Show("Error: " + e.Message);
            }
            catch (Exception e)
            {
                AlertMessage.Show("Error: " + e.Message);
            }
        }

    }
}
