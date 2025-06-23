using Dal.Api;
using Dal.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Repository
{
    public class SubCategoryRepository : ISubCatagory
    {
        private readonly IMongoCollection<SubCategory> _collection;

        public SubCategoryRepository(IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase("AiLearningDb");
            _collection = database.GetCollection<SubCategory>("SubCategory");
        }

        // Create: מוסיף תת-קטגוריה חדשה
        public async Task Create(SubCategory item)
        {
            if (item == null) throw new ArgumentNullException(nameof(item));
            await _collection.InsertOneAsync(item); // מוסיף את תת-הקטגוריה לבסיס הנתונים
        }

        // Delete: מוחק תת-קטגוריה לפי ה-Id שלה
        public async Task Delete(SubCategory item)
        {
            if (item == null) throw new ArgumentNullException(nameof(item));

            var filter = Builders<SubCategory>.Filter.Eq(sc => sc.Id, item.Id);
            var result = await _collection.DeleteOneAsync(filter);

            if (result.DeletedCount == 0)
            {
                throw new Exception($"SubCategory with ID {item.Id} not found.");
            }
        }

        // Read: מחזיר את כל תתי-הקטגוריות
        public async Task<List<SubCategory>> Read()
        {
            return await _collection.Find(_ => true).ToListAsync(); // מחזיר את כל תתי-הקטגוריות
        }

        // Update: מעדכן תת-קטגוריה לפי ה-Id שלה
        public async Task UpDate(SubCategory item)
        {
            if (item == null) throw new ArgumentNullException(nameof(item));

            var filter = Builders<SubCategory>.Filter.Eq(sc => sc.Id, item.Id);
            var update = Builders<SubCategory>.Update
                .Set(sc => sc.Name, item.Name) // עדכון שם תת-הקטגוריה
                .Set(sc => sc.CategoryId, item.CategoryId); // עדכון ה-CategoryId אם יש שינוי

            var result = await _collection.UpdateOneAsync(filter, update);

            if (result.ModifiedCount == 0)
            {
                throw new Exception($"SubCategory with ID {item.Id} not found or not updated.");
            }
        }
    }
}
