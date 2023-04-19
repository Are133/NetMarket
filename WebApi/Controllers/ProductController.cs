using BusinessLogic.Logic;
using Core.Entities;
using Core.Interfaces;
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
            var products = await _genericRepository.GetAllAsync();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            return await _genericRepository.GetByIdAsync(id);
        }
    }
}
