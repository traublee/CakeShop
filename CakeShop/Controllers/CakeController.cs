using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using CakeShop.Models;
using CakeShop.Models.Requests;
using CakeShop.BL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using CakeShop.Models.Models;

namespace CakeShop.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CakeController : ControllerBase
    {
        private readonly ICakeService _cakeService;
        private readonly IMapper _mapper;

        public CakeController(ICakeService cakeService, IMapper mapper)
        {
            _cakeService = cakeService;
            _mapper = mapper;
        }

        [HttpGet("GetAllCakes")]
        public async Task<IActionResult> GetAll()
        {
            var cakes = await _cakeService.GetAllCakes();
            return Ok(cakes);
        }

        [HttpGet("GetCakeById")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var cake = await _cakeService.GetCakeById(id);
            if (cake != null)
                return Ok(cake);
            return NotFound();
        }

        [HttpPost("AddCake")]
        public async Task<IActionResult> Add([FromBody] CakeRequest cakeRequest)
        {
            var cake = _mapper.Map<Cake>(cakeRequest);
            await _cakeService.AddCake(cake);
            return Ok();
        }

        [HttpPost("UpdateCake")]
        public async Task<IActionResult> Update([FromBody] CakeRequest cakeRequest)
        {
            var cake = _mapper.Map<Cake>(cakeRequest);
            await _cakeService.UpdateCake(cake);
            return Ok();
        }

        [HttpDelete("DeleteCake")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _cakeService.DeleteCake(id);
            return Ok();
        }
    }
}