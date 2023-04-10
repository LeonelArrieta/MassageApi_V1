using AutoMapper;
using MassageApi_V1.DTOs;
using MassageApi_V1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MassageApi_V1.Controllers
{
    [ApiController]
    [Route("api/contact")]
    public class ContactController : ControllerBase
    {
        private readonly MyDBContext _context;
        private readonly IMapper _mapper;

        public ContactController(MyDBContext context, IMapper mapper)
        {
            this._context = context;
            _mapper = mapper;
        }
        [HttpGet("GetAll")]
        public async Task<ActionResult> GetAll()
        {
            var Contacts = await _context.Contacts.ToListAsync();
            return Ok(Contacts);

        }
        [HttpGet("Id")]
        public async Task<ActionResult>GetbyId(int id)
        {
            var contact = await _context.Contacts.FirstOrDefaultAsync(c=>c.Id==id);
            return Ok(contact);
        }
        [HttpPost]
        public async Task<ActionResult> Post(ContactNewDTO contactDTO)
        {
            var contact = _mapper.Map<Contact>(contactDTO);
            _context.Add(contact);
            await _context.SaveChangesAsync();
            return Ok();
        }
        [HttpDelete("Id")]
        public async Task<ActionResult> Delete(int Id)
        {
            var contact = await _context.Contacts.FirstOrDefaultAsync(c => c.Id == Id);
            if (contact != null)
            {
                _context.Remove(contact);
                return Ok();
            }
            return BadRequest();
        }
    }
}
