using SocialNetwork.BLL.Models;
using SocialNetwork.BLL.Services;

namespace SocialNetwork
{
    internal class Program
    {
        public static UserService userService = new UserService();
        static void Main(string[] args)
        {
            Console.WriteLine("Добро пожаловать в социальную сеть!");

            while (true)
            {
                Console.WriteLine("Для регистрации пользователя введите имя пользователя:");
                string firstName = Console.ReadLine();
                Console.Write("фамилия:");
                string lastName = Console.ReadLine();
                Console.Write("пароль:");
                string password = Console.ReadLine();
                Console.Write("почтовый адрес:");
                string email = Console.ReadLine();

                UserRegistratiionData userRegistratiionData = new UserRegistratiionData()
                {
                    FirstName = firstName,
                    LastName = lastName,
                    Password = password,
                    Email = email
                };
                try
                {
                    userService.Register(userRegistratiionData);
                    Console.WriteLine("Регистрация прошла успешно.");
                }
                catch (ArgumentNullException e)
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine("Введите корректое значение!");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine("Произошла ошибка при регистрации!");
                }


                Console.ReadKey();
            }
        }
    }
}