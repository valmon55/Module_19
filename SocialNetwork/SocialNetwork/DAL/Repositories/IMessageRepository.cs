using SocialNetwork.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.DAL.Repositories
{
    public interface IMessageRepository
    {
        public int Create(MessageEntity messageEntity);
        public IEnumerable<MessageEntity> FindBySenderId(int senderId);
        public IEnumerable<MessageEntity> FindByRecipientId(int recipientId);
        public int DeleteById(int messageId);
    }
}
