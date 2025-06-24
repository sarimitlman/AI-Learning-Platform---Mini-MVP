using Dal.Models;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Api
{
    public interface IBLCategory
    {
        public void Create(Categories category);
        public Task<Categories> GetCategoryByIdAsync(ObjectId id);
        public Task<List<Categories>> GetAll();
        public Task DeleteCategory(ObjectId id);
    }
}
