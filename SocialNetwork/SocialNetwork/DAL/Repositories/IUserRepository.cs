using SocialNetwork.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.DAL.Repositories
{
    internal interface IUserRepository
    {
        public int Create(UserEntity userEntity);
        public UserEntity FindByEmail(string email);
        public IEnumerable<UserEntity> FindAll();
        public UserEntity FindById(int id);
        public int Update(UserEntity userEntity);
        public int DeleteById(int id);
    }
}
