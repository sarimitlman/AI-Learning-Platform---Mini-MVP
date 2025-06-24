using BL.Api;
using Dal.Api;
using Dal.Models;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BL.Services
{
    public class BLSubCategoryService : IBLSubCategory
    {
        private readonly ISubCategory _subCategoryRepository;

        public BLSubCategoryService(ISubCategory subCategoryRepository)
        {
            _subCategoryRepository = subCategoryRepository;
        }

        public async Task<List<SubCategory>> GetSubCategoriesByCategoryIdAsync(ObjectId categoryId)
        {
            var allSubCategories = await _subCategoryRepository.Read();
            return allSubCategories.Where(sc => sc.CategoryId == categoryId.ToString()).ToList();
        }
    }
}
