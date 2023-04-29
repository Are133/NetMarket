using AutoMapper;
using BusinessLogic.Logic;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApi.DTOs;
using WebApi.Errors;

namespace WebApi.Controllers
{
    public class ProductController : BaseAPIController
    {
        private readonly IGenericRepository<Product> _genericRepository;

        private readonly IMapper _mapper;
        public ProductController(IGenericRepository<Product> genericProductRepository,
            IMapper mapper)
        {
            _genericRepository = genericProductRepository; 
            _mapper = mapper;   
        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProducts()
        {
            var specification = new ProductWithCategoryAndTraderMarkSpecification();
            var products = await _genericRepository.GetAllWithSpecificationAsync(specification);
            return Ok(_mapper.Map<IReadOnlyList<Product>, IReadOnlyList<ProductDTO>>(products));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDTO>> GetProduct(int id)
        {
            var specification = new ProductWithCategoryAndTraderMarkSpecification(id);
            var product = await _genericRepository.GetByIdWithSpecificationAsync(specification);

            if(product is null)
            {
                return NotFound(new CodeErrorResponse(404));
            }
            return _mapper.Map<Product, ProductDTO>(product);
        }
    }
}
