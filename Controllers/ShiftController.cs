using AutoMapper;
using MassageApi_V1.DTOs;
using MassageApi_V1.Models;
using MassageApi_V1.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace MassageApi_V1.Controllers
{
    [ApiController]
    [Route("api/shift")]
    
    
    public class ShiftController : ControllerBase
    {
        private readonly IShiftRepository _repository;
        private readonly IMapper _mapper;

        public ShiftController(IShiftRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        [HttpGet]
        [Authorize(Roles = "CommonUser,Admin" )]

        public async Task<ActionResult> GetAll()
        {
            var shifts = await _repository.GetAll();
            if (shifts == null)
            {
                return BadRequest();
            }
            return Ok(shifts);

        }
        [HttpGet("Relations")]
        [Authorize(Roles = "Admin")]

        public async Task<ActionResult> GetAllWhitRelations()
        {
            var shifts = await _repository.GetAllWhitRelations();
            if (shifts == null)
            {
                return BadRequest();
            }
            return Ok(shifts);

        }
        [HttpGet("Id")]
        [Authorize(Roles = "Admin")]

        public async Task<ActionResult> GetbyId(int id)
        {
            
            var shift = await _repository.GetbyId(id);

            if (shift == null)
            {
                return BadRequest();
            }
            return Ok(shift);
        }
        [HttpPost]
        [Authorize(Roles ="CommonUser,Admin")]

        public async Task<ActionResult> Post(ShiftNewDTO shiftDTO)
        {
            var shift = _mapper.Map<Shift>(shiftDTO);
            var result= await _repository.Post(shift);
            if (result == null)
            {
                return BadRequest();
            }
            return Ok(result);
        }

        [HttpPut("Shift")]
        [Authorize(Roles = "Admin")]

        public async Task<ActionResult> Put(ShiftNewDTO shiftDTO)
        {
            var shift = _mapper.Map<Shift>(shiftDTO);
            var entity = await _repository.Update(shift);
            return Ok(entity);

        }
        [HttpDelete("Id")]
        [Authorize(Roles = "Admin")]

        public async Task<ActionResult> Delete(int Id)
        {
            var shift = await _repository.Delete(Id);
            if (shift != null)
              return Ok();
            
            return BadRequest();
        }
    }
}
