using BL.Api;
using Dal.Api;
using Dal.Models;
using Dal.Repository;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BL.Services
{
    public class BLPromptService : IBLPrompt
    {
        private readonly IPrompt _promptRepo;
        private readonly IBLAI _aiService;


        public BLPromptService(IPrompt promptRepo, IBLAI aiService)
        {
            _promptRepo = promptRepo;
            _aiService = aiService;
        }
        public async Task<List<Prompts>> GetAll()
        {
            return await _promptRepo.Read();
        }

        public async Task<Prompts> GetById(ObjectId id)
        {
            var all = await _promptRepo.Read();
            return all.FirstOrDefault(p => p.Id == id.ToString());
        }

        public async Task Delete(ObjectId id)
        {
            var all = await _promptRepo.Read();
            var promptToDelete = all.FirstOrDefault(p => p.Id == id.ToString());
            if (promptToDelete != null)
                await _promptRepo.Delete(promptToDelete);
        }

        public async Task Update(Prompts prompt)
        {
            await _promptRepo.UpDate(prompt);
        }
        public async Task CreateResponse(PromptRequest promptRequest)
        {
            // שולחים ל-AI
            string response = await _aiService.GetResponseFromAI(promptRequest.Prompt);

            // בונים אובייקט Prompts עם ה-Response שהתקבל מה-AI
            var prompt = new Prompts
            {
                UserId = promptRequest.UserId,
                SubCategoryId = promptRequest.SubCategoryId,
                Prompt = promptRequest.Prompt,
                Response = response,  // ה-response שחזר מה-AI
                CreatedAt = DateTime.UtcNow
            };

            // שומרים את התשובה בבסיס הנתונים
            await _promptRepo.Create(prompt);
        }


    }
}

