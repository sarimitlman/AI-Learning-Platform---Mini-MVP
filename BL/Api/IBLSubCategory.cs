using Dal.Models;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Api
{
    public interface IBLSubCategory
    {
        public void Create(SubCategory subCategory);
        public Task<SubCategory> GetSubCategoryByIdAsync(ObjectId id);
        public Task<List<SubCategory>> GetAll();
        public Task DeleteSubCategory(ObjectId id);
    }
}
