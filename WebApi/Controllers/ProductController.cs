using BusinessLogic.Logic;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IGenericRepository<Product> _genericRepository;

        public ProductController(IGenericRepository<Product> genericProductRepository)
        {
            _genericRepository = genericProductRepository; 
        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProducts()
        {
            var specification = new ProductWithCategoryAndTraderMarkSpecification();
            var products = await _genericRepository.GetAllWithSpecificationAsync(specification);
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var specification = new ProductWithCategoryAndTraderMarkSpecification(id);

            return await _genericRepository.GetByIdWithSpecificationAsync(specification);
        }
    }
}
