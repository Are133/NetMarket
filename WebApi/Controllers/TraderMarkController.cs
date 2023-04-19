using BusinessLogic.Logic;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TraderMarkController : ControllerBase
    {
        private readonly IGenericRepository<TraderMark> _genericRepository;

        public TraderMarkController(IGenericRepository<TraderMark> genericRepository)
        {
            _genericRepository = genericRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<TraderMark>>> GetTradersMarks()
        {
            return Ok(await _genericRepository.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TraderMark>>GetTraderMark(int id)
        {
            return await _genericRepository.GetByIdAsync(id);
        }
    }
}
