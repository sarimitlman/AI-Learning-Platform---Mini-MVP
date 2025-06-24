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

        // יצירת תת קטגוריה חדשה
        public void Create(SubCategory subCategory)
        {
            if (subCategory == null)
                throw new ArgumentNullException(nameof(subCategory));

            _subCategoryRepository.Create(subCategory);
        }

        // קבלת כל תתי הקטגוריות
        public async Task<List<SubCategory>> GetAll()
        {
            return await _subCategoryRepository.Read();
        }

        // קבלת תת קטגוריה לפי מזהה
        public async Task<SubCategory> GetSubCategoryByIdAsync(ObjectId id)
        {
            var list = await _subCategoryRepository.Read();
            var subCategory = list.FirstOrDefault(sc => sc.Id == id);

            if (subCategory == null)
                throw new Exception($"SubCategory with ID {id} not found.");

            return subCategory;
        }

        // מחיקת תת קטגוריה לפי מזהה
        public async Task DeleteSubCategory(ObjectId id)
        {
            var list = await _subCategoryRepository.Read();
            var subCategory = list.FirstOrDefault(sc => sc.Id == id);

            if (subCategory == null)
                throw new Exception($"SubCategory with ID {id} not found.");

            await _subCategoryRepository.Delete(subCategory);
        }
    }
}
