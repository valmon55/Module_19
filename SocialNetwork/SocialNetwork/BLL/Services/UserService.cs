﻿using SocialNetwork.BLL.Exceptions;
using SocialNetwork.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using SocialNetwork.DAL.Repositories;
using System.Net.Http.Headers;
using SocialNetwork.DAL.Entities;

namespace SocialNetwork.BLL.Services
{
    public class UserService
    {
        IUserRepository userRepository;
        public UserService() 
        { 
            userRepository = new UserRepository();
        }
        public void Register(UserRegistratiionData userRegistratiionData)
        {
            if (String.IsNullOrEmpty(userRegistratiionData.FirstName))
                throw new ArgumentNullException();
            if (String.IsNullOrEmpty(userRegistratiionData.LastName))
                throw new ArgumentNullException();
            if (String.IsNullOrEmpty(userRegistratiionData.Password))
                throw new ArgumentNullException();
            if (String.IsNullOrEmpty(userRegistratiionData.Email))
                throw new ArgumentNullException();

            if(userRegistratiionData.Password.Length < 8)
                throw new ArgumentNullException();
            if (!new EmailAddressAttribute().IsValid(userRegistratiionData.Email))
                throw new ArgumentNullException();
            if(userRepository.FindByEmail(userRegistratiionData.Email) != null)
                throw new ArgumentNullException();

            var userEntity = new UserEntity()
            {
                firstname = userRegistratiionData.FirstName,
                lastname = userRegistratiionData.LastName,
                password = userRegistratiionData.Password,
                email = userRegistratiionData.Email
            };
            if( this.userRepository.Create(userEntity) == 0)
                throw new Exception();
        }
    }
}
