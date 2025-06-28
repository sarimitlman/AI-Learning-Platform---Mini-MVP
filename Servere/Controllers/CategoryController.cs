using BL.Api;
using Dal.Api;
using Dal.Models;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
namespace Servere.Controllers
{



    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IBLCategory _blCategory;

        public CategoryController(IBLCategory blCategory)
        {
            _blCategory = blCategory;
        }

        // GET api/category
        [HttpGet]
        public async Task<ActionResult<List<Categories>>> GetAllCategories()
        {
            var categories = await _blCategory.GetAll();
            return Ok(categories);
        }

        // GET api/category/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Categories>> GetCategoryById(string id)
        {
            if (!ObjectId.TryParse(id, out ObjectId objectId))
                return BadRequest("Invalid ID format.");

            var category = await _blCategory.GetCategoryByIdAsync(objectId);
            if (category == null)
                return NotFound();

            return Ok(category);
        }
    }
}



















