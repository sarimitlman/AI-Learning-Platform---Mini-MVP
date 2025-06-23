using BL.Api;
using Dal.Api;
using Dal.Models;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Services
{
    public class BLUserService : IBLUser
    {
        private readonly IUsers userRepository;

        public BLUserService(IUsers userRepository)
        {
            this.userRepository = userRepository;
        }

        // Create: יצירת משתמש חדש
        public void Create(Users user)
        {
            try
            {
                userRepository.Create(user);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error creating user: {ex.Message}");
            }
        }

        // GetUserById: קבלת משתמש לפי ID
        public async Task<Users> GetUserByIdAsync(ObjectId id)
        {
            var users = await userRepository.Read();
            var user = users.FirstOrDefault(u => u.Id == id);

            if (user == null)
            {
                throw new Exception($"User with ID {id} not found.");
            }

            return user;
        }

        // GetAll: קבלת כל המשתמשים
        public async Task<List<Users>> GetAll()
        {
            return await userRepository.Read();
        }

        // DeleteUser: מחיקת משתמש
        public async Task DeleteUser(ObjectId id)
        {
            var users = await userRepository.Read();
            var userToDelete = users.FirstOrDefault(u => u.Id == id);

            if (userToDelete != null)
            {
                await userRepository.Delete(userToDelete);
            }
            else
            {
                throw new Exception($"User with ID {id} not found.");
            }
        }




    }
}


