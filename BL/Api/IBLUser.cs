using Dal.Models;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Api
{
    public interface IBLUser
    {
        public void Create(Users user);
        public Task<Users> GetUserByIdAsync(ObjectId id);
        public Task<List<Users>> GetAll();
        public Task DeleteUser(ObjectId id);
    }
}
