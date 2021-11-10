using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TIMAN.Api.Repositories;
using TIMAN.Model;

namespace TIMAN.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductsController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        [HttpGet]
        public async Task<ActionResult> GetProducts(string timkiem=null)
        {
            try
            {
                var result = await _productRepository.GetProducts(timkiem);
                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }
        [HttpPost]
        public async Task<ActionResult> Create([FromBody] Product request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            request.DateCreated = DateTime.Now;
            var product = await _productRepository.AddProduct(request);
            return CreatedAtAction(nameof(GetProductById), new { id = product.Id }, product);
        }
        [Route("GetById")]
        [HttpGet]
        public async Task<ActionResult<Product>> GetProductById(int id)
        {
            try
            {
                var result = await _productRepository.GetProduct(id);

                if (result == null) return NotFound();

                return result;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteProduct(int id)
        {
            try
            {
                var product = await _productRepository.GetProduct(id);

                if (product == null)
                {
                    return NotFound($"{id} not found");
                }
                var result = await _productRepository.DeleteProduct(id);

                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error deleting data");
            }
        }
        [HttpPut]
        [Route("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] Product request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var ProductFromDb = await _productRepository.GetProduct(id);

            if (ProductFromDb == null)
            {
                return NotFound($"{id} is not found");
            }


            var Result = await _productRepository.UpdateProduct(request);

            return Ok(Result);
        }
        [HttpGet]
        [Route("GetByCategoryId")]
        public async Task<ActionResult> GetByCategoryId(int categoryId)
        {
            try
            {
                var result = await _productRepository.GetProductByCategoryId(categoryId);
                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }
    }
}
