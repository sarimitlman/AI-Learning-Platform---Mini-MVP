using Dal.Models;
using MongoDB.Bson;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BL.Api
{
    public interface IBLPrompt
    {
        Task CreateResponse(PromptRequest promptRequest);
        Task<List<Prompts>> GetAll();
        Task<Prompts> GetById(ObjectId id);
        Task Delete(ObjectId id);
        Task Update(Prompts prompt);
    }
}

