using Domain.Entities;
using Service.Services;
using Service.Services.Intefaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace EFProject.Controllers
{
    public class UserController
    {
        private readonly IUserService _userService;
        public UserController()
        {
            _userService = new UserService();
        }

        public async Task StartAsync()
        {
            Start: Console.WriteLine("Welcome! Please select option:");
            Console.WriteLine("1: Register");
            Console.WriteLine("2: Login");
            string choice = Console.ReadLine();

            if (choice == "1")
            {
                await RegisterAsync();
                await LoginAsync();
            }
            else if (choice == "2")
            {
                await LoginAsync();
            }
            else
            {
                Console.WriteLine("Invalid choice. Please try again:");
                goto Start;
            }
        }

        private async Task RegisterAsync()
        {
            RegisterFullName: Console.WriteLine("Enter Full Name:");
            string fullName;
            while (true)
            {
                fullName = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(fullName))
                {
                    Console.WriteLine("FullName empty. Please try again:");
                    goto RegisterFullName;
                }
                else
                {
                    break;
                }
            }

            RegisterUserName: Console.WriteLine("Enter Username:");
            string username;
            while (true)
            {
                username = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(username))
                {
                    Console.WriteLine("Username empty. Please try again:");
                    goto RegisterUserName;
                }
                else if (username == null)
                {
                    Console.WriteLine("Username already exists. Please try again:");
                    goto RegisterUserName;
                }
                else
                {
                    break;
                }
            }

            RegisterEmail: Console.WriteLine("Enter Email:");
            string email;
            while (true)
            {
                email = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(email))
                {
                    Console.WriteLine("Invalid email format. Please try again:");
                    goto RegisterEmail;
                }
                else
                {
                    break;
                }
            }
            RegisterPassword: Console.WriteLine("Enter Password:");
            string password;
            while (true)
            {
                password = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(password) || password.Length < 8)
                {
                    Console.WriteLine("Password max 8 simbol enter. Please try again:");
                    goto RegisterPassword;
                }
                else
                {
                    break;
                }
            }

            var newUser = new User
            {
                FullName = fullName,
                UserName = username,
                Email = email,
                Password = password
            };

            await _userService.RegisterAsync(newUser);
            Console.WriteLine("Registration successful.");
        }
        private async Task LoginAsync()
        {
            Console.WriteLine("Login:");

            Login: Console.WriteLine("Enter Username:");
            string username = Console.ReadLine();

            Console.WriteLine("Enter Password:");
            string password = Console.ReadLine();

            var user = await _userService.CheckAsync(username, password);

            if (user != null)
            {
                Console.WriteLine("Login successful!");
                
            }
            else
            {
                Console.WriteLine("Invalid username or password.");
                goto Login;
            }
        }
    }
}
