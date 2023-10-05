using SocialNetwork.BLL.Models;
using SocialNetwork.BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.PLL.Views
{
    public class FriendsInfoView
    {
        FriendService friendService;
        internal FriendsInfoView(FriendService friendService) 
        { 
            this.friendService = friendService;
        }
        public void Show(User user)
        {
            var friends = friendService.ShowFriends(user);
            User friendUser;
            if (friends.Count() == 0)
                Console.WriteLine($"{user.FirstName}, у вас нет друзей.");
            else
            {
                Console.WriteLine($"{user.FirstName}, ваши друзья:");
                foreach (Friend friend in friends)
                {
                    friendUser = friendService.FindById(friend.Friend_id);
                    //Console.WriteLine($"ID = {friend.Id} USER_ID = {friend.User_id} FRIEND_ID = {friend.Friend_id}");
                    Console.WriteLine($"FirstName = {friendUser.FirstName} LastName = {friendUser.LastName}");
                }
            }
        }
    }
}
