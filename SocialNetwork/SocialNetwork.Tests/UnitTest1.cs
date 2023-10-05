using SocialNetwork.BLL.Exceptions;
using SocialNetwork.BLL.Models;
using SocialNetwork.BLL.Services;

namespace SocialNetwork.Tests
{
    public class Tests
    {
        UserService userService = new UserService();
        FriendService friendService = new FriendService();

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
        [Test]
        public void TestFindByEmail()
        {
            string email = "fedor@mail.ru";
            var user = userService.FindByEmail(email);
            Assert.That(user.FirstName == "fedor");
        }
        [Test]
        public void AddUser()
        {
            string email = "PJ@cbi.gov";
            User? user = null;
            try
            {
                user = userService.FindByEmail(email);
            }
            catch (UserNotFoundException)
            {
                if (user is null)
                {
                    UserRegistrationData userRegistrationData = new UserRegistrationData();
                    userRegistrationData.FirstName = "Patric";
                    userRegistrationData.LastName = "Jane";
                    userRegistrationData.Email = email;
                    userRegistrationData.Password = "12341234";
                    userService.Register(userRegistrationData);
                }
                user = userService.FindByEmail(email);
            }
            Assert.That(user.FirstName == "Patric" && user.LastName == "Jane");            
        }
        [Test]
        public void AddFriend()
        {

        }
        [Test]
        public void RemoveFriend()
        {

        }
        [Test]
        public void FriendList()
        {

        }

    }
}