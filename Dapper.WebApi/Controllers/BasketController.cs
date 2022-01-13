using System.Threading.Tasks;
using AutoMapper;
using Dapper.Application.Interfaces;
using Dapper.Core.Entities;
using Dapper.Core.Models;
using Dapper.Core.Models.Commands;
using Microsoft.AspNetCore.Mvc;

namespace Dapper.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public BasketController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var data = await _unitOfWork.Baskets.GetAllAsync();
            return Ok(data);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var data = await _unitOfWork.Baskets.GetByIdAsync(id);
            if (data == null) return Ok();
            return Ok(data);
        }
        [HttpPost]
        public async Task<IActionResult> Add(BasketInsertDTO basketDTO)
        {
            var basket = _mapper.Map<Basket>(basketDTO);
            var data = await _unitOfWork.Baskets.AddAsync(basket);
            return Ok(data);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var data = await _unitOfWork.Baskets.DeleteAsync(id);
            return Ok(data);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateLight(BasketUpdateDTO basketDTO)
        {
            var basket = _mapper.Map<Basket>(basketDTO);
            var data = await _unitOfWork.Baskets.UpdateAsync(basket);
            return Ok(data);
        }
    }
}