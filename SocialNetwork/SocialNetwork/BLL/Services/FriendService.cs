using SocialNetwork.BLL.Exceptions;
using SocialNetwork.BLL.Models;
using SocialNetwork.DAL.Entities;
using SocialNetwork.DAL.Repositories;
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
            if(friendRepository.Create(friendEntity) == 0)
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
