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
   

    namespace BL.Services
    {
        public class BLCategoryService : IBLCategory
        {
            private readonly ICategory categoryRepository;

            public BLCategoryService(ICategory categoryRepository)
            {
                this.categoryRepository = categoryRepository;
            }

            // Create: יצירת קטגוריה חדשה
            public void Create(Categories category)
            {
                try
                {
                    categoryRepository.Create(category);
                }
                catch (Exception ex)
                {
                    throw new Exception($"Error creating category: {ex.Message}");
                }
            }

            // GetCategoryById: קבלת קטגוריה לפי ID
            public async Task<Categories> GetCategoryByIdAsync(ObjectId id)
            {
                var categories = await categoryRepository.Read();
                var category = categories.FirstOrDefault(c => c.Id == id);

                if (category == null)
                {
                    throw new Exception($"Category with ID {id} not found.");
                }

                return category;
            }

            // GetAll: קבלת כל הקטגוריות
            public async Task<List<Categories>> GetAll()
            {
                return await categoryRepository.Read();
            }

            // DeleteCategory: מחיקת קטגוריה לפי ID
            public async Task DeleteCategory(ObjectId id)
            {
                var categories = await categoryRepository.Read();
                var categoryToDelete = categories.FirstOrDefault(c => c.Id == id);

                if (categoryToDelete != null)
                {
                    await categoryRepository.Delete(categoryToDelete);
                }
                else
                {
                    throw new Exception($"Category with ID {id} not found.");
                }
            }

            
        }
    }

}
