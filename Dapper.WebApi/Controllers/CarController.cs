using System.Threading.Tasks;
using AutoMapper;
using Dapper.Application.Interfaces;
using Dapper.Core.Entities;
using Dapper.Core.Models.Commands;
using Microsoft.AspNetCore.Mvc;

namespace Dapper.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CarController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var data = await _unitOfWork.Cars.GetAllAsync();
            return Ok(data);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var data = await _unitOfWork.Cars.GetByIdAsync(id);
            if (data == null) return Ok();
            return Ok(data);
        }
        [HttpPost]
        public async Task<IActionResult> Add(CarInsertDTO carDTO)
        {
            var car = _mapper.Map<Car>(carDTO);
            var data = await _unitOfWork.Cars.AddAsync(car);
            return Ok(data);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var data = await _unitOfWork.Cars.DeleteAsync(id);
            return Ok(data);
        }
        [HttpPut]
        public async Task<IActionResult> Update(CarUpdateDTO carDTO)
        {
            var car = _mapper.Map<Car>(carDTO);
            var data = await _unitOfWork.Cars.UpdateAsync(car);
            return Ok(data);
        }
    }
}