using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using Microsoft.AspNetCore.Mvc;
using System;
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
        public async Task<ActionResult<Pagination<ProductDTO>>> GetProducts([FromQuery] ProductSpecificationParams @params)
        {
            var specification = new ProductWithCategoryAndTraderMarkSpecification(@params);
            var products = await _genericRepository.GetAllWithSpecificationAsync(specification);

            var specCount = new ProductForCountingSpecification(@params);
            var totalProducts = await _genericRepository.CountAsync(specification);

            var rounded = Math.Ceiling(Convert.ToDecimal(totalProducts / @params.PageSize));
            var totalPages = Convert.ToInt32(rounded);
            var data = _mapper.Map<IReadOnlyList<Product>, IReadOnlyList<ProductDTO>>(products);

            return Ok(new Pagination<ProductDTO>
            {
                Count = totalProducts,
                Data = data,
                PageCount = totalPages,
                PageIndex = @params.PageIndex,
                PageSize = @params.PageSize
            });
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDTO>> GetProduct(int id)
        {
            var specification = new ProductWithCategoryAndTraderMarkSpecification(id);
            var product = await _genericRepository.GetByIdWithSpecificationAsync(specification);

            if (product is null)
            {
                return NotFound(new CodeErrorResponse(404));
            }
            return _mapper.Map<Product, ProductDTO>(product);
        }
    }
}
