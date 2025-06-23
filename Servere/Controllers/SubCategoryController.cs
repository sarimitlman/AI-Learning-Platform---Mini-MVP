using BL.Api;
using Dal.Models;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Servere.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubCategoryController : ControllerBase
    {
        private readonly IBLSubCategory _blSubCategory;

        public SubCategoryController(IBLSubCategory blSubCategory)
        {
            _blSubCategory = blSubCategory;
        }

        // GET: api/SubCategory
        [HttpGet]
        public async Task<ActionResult<List<SubCategory>>> GetAllSubCategories()
        {
            var list = await _blSubCategory.GetAll();
            return Ok(list);
        }

        // GET: api/SubCategory/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<SubCategory>> GetSubCategoryById(string id)
        {
            if (!ObjectId.TryParse(id, out ObjectId objectId))
                return BadRequest("Invalid ID format.");

            var subCategory = await _blSubCategory.GetSubCategoryByIdAsync(objectId);
            if (subCategory == null)
                return NotFound();

            return Ok(subCategory);
        }

        // POST: api/SubCategory
        [HttpPost]
        public ActionResult CreateSubCategory([FromBody] SubCategory subCategory)
        {
            if (subCategory == null)
                return BadRequest("SubCategory is null.");

            _blSubCategory.Create(subCategory);
            return Ok();
        }

        // DELETE: api/SubCategory/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteSubCategory(string id)
        {
            if (!ObjectId.TryParse(id, out ObjectId objectId))
                return BadRequest("Invalid ID format.");

            await _blSubCategory.DeleteSubCategory(objectId);
            return NoContent(); // 204
        }
    }
}

