using GoStore.Data.Models;
using GoStore.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }


        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Category>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetCategoriesAsync(CancellationToken cancellationToken)
        {
            try 
            {
                return Ok( await _categoryService.GetAllAsync(cancellationToken));

            } catch (Exception ex) 
            { 
                return NotFound(ex.Message + " >>> " + ex.InnerException?.Message);
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Category))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetCategoryByIdAsync(Guid id,CancellationToken cancellationToken)
        {
            try
            {
                return Ok(await _categoryService.GetOneByIdAsync(id,cancellationToken));
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message + " >>> " + ex.InnerException?.Message);
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Category))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> AddCategoryAsync(Category category, CancellationToken cancellationToken)
        {
            try
            {
                if (category == null) return BadRequest("Category data should be provided");
                if (!ModelState.IsValid) return BadRequest(ModelState);

                var result = await _categoryService.AddAsync(category, cancellationToken);
                return CreatedAtAction(nameof(GetCategoryByIdAsync),new { id = result.Id } , result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message + " >>> " + ex.InnerException?.Message);
            }
        }


        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Category))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateCategoryByIdAsync(Guid id, Category category ,CancellationToken cancellationToken)
        {
            try
            {
                if (category == null) return BadRequest("Category data should be provided");
                if (!ModelState.IsValid) return BadRequest(ModelState);

                return Ok(await _categoryService.UpdateByIdAsync(id, category, cancellationToken));
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message + " >>> " + ex.InnerException?.Message);
            }
        }


        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Category))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteCategoryByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            try
            {
                return Ok(await _categoryService.DeleteByIdAsync(id, cancellationToken));
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message + " >>> " + ex.InnerException?.Message);
            }
        }

    }
}
