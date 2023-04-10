using AutoMapper;
using MassageApi_V1.DTOs;
using MassageApi_V1.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MassageApi_V1.Controllers
{
    [Authorize(Roles ="Admin")]
    [ApiController]
    [Route("api/shift")]
    
    public class ShiftController : ControllerBase
    {
        private readonly MyDBContext _context;
        private readonly IMapper _mapper;

        public ShiftController(MyDBContext context, IMapper mapper)
        {
            this._context = context;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var shifts = await _context.Shifts.Select(x=>
                new {
                        date=x.Date,
                        contact=x.contact.Name,
                        contactLastName=x.contact.LastName,
                        massageType=x.massageType.Name,
                    }).ToListAsync();
            if (shifts == null)
            {
                return BadRequest();
            }
            return Ok(shifts);

        }
        [HttpGet("Id")]
        public async Task<ActionResult> GetbyId(int id)
        {
            
            var shift = await _context.Shifts.Where(x=>x.Id==id).Select(x => new {
                date = x.Date,
                contact = x.contact.Name,
                contactLastName = x.contact.LastName,
                massageType = x.massageType.Name,
            }).FirstOrDefaultAsync();

            if (shift == null)
            {
                return BadRequest();
            }
            return Ok(shift);
        }
        [HttpPost]
        public async Task<ActionResult> Post(ShiftNewDTO shiftDTO, int? contactId, int massage)
        {
            var shift = _mapper.Map<Shift>(shiftDTO);
            shift.MassageTypeId =massage;
            if(contactId==null)
            {
                _context.Add(shift);
            }            
            else
            {
                var contact = await _context.Contacts.FirstOrDefaultAsync(s => s.Id == contactId);
                if (contact != null)
                {
                    contact.Shift = shift;

                }
                else { return BadRequest("El contacto no existe"); }

            }
            await _context.SaveChangesAsync();
            return Ok();
        }
        [HttpDelete("Id")]
        public async Task<ActionResult> Delete(int Id)
        {
            var shift = await _context.Shifts.FirstOrDefaultAsync(s => s.Id == Id);
            if (shift != null)
            {
                _context.Remove(shift);
                return Ok();
            }
            return BadRequest();
        }
    }
}
