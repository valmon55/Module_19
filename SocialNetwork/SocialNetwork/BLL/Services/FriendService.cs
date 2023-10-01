using SocialNetwork.BLL.Exceptions;
using SocialNetwork.BLL.Models;
using SocialNetwork.DAL.Entities;
using SocialNetwork.DAL.Repositories;
using SocialNetwork.PLL.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.BLL.Services
{
    public class FriendService : UserService
    {
        IFriendRepository friendRepository;
        public FriendService()
        {
            friendRepository = new FriendRepository();
        }
        /// <summary>
        /// Получить всех друзей пользователя
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public IEnumerable<Friend> ShowFriends(User user)
        {
            List<Friend> friends = new List<Friend>();
            foreach(FriendEntity friendEntity in friendRepository.FindAllByUserId(user.Id))
            {
                friends.Add(ConstructFriendModel(friendEntity));
            }
            return friends;
        }
        /// <summary>
        /// Пользователю user добавляем друга по friendEmail
        /// </summary>
        /// <param name="user"></param>
        /// <param name="friendEmail"></param>
        /// <exception cref="UserNotFoundException"></exception>
        public void AddFriend(User user, string friendEmail)
        {
            if (!new EmailAddressAttribute().IsValid(friendEmail))
                throw new ArgumentNullException();

            User friend = FindByEmail(friendEmail);
            if (user is null)
                throw new UserNotFoundException();

            var friendEntity = new FriendEntity()
            {
                user_id = user.Id,
                friend_id = friend.Id,
            };
            if (user.Id == friend.Id)
            {
                AlertMessage.Show("Добавление себя к себе в друзья не разрешено!");
            }
            else
            {
                if (friendRepository.Create(friendEntity) == 0)
                    throw new Exception();
            }
        }
        public void RemoveFriend(User user, string friendEmail)
        {
            if (!new EmailAddressAttribute().IsValid(friendEmail))
                throw new ArgumentNullException();

            User friendUser = FindByEmail(friendEmail);
            if (user is null)
                throw new UserNotFoundException();
            List<FriendEntity> friendEntities = friendRepository.FindAllByUserId(friendUser.Id)
            ///чтобы найти Friend.ID необходимо
            ///1. найти User.ID
            ///2. FriendRepository.FindAllByUserId.Where(friend_id = User.ID(из п.1)) .ID
            //if (friendRepository.Delete(userRepository.FindByEmail(friendEmail).id) == 0)
            if (friendRepository.Delete(fr) == 0)
                throw new Exception();

        }
        private Friend ConstructFriendModel(FriendEntity friendEntity)
        {
            return new Friend(friendEntity.id,
                              friendEntity.user_id,
                              friendEntity.friend_id
                             );
        }
    }
}
