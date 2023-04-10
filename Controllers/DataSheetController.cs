using AutoMapper;
using MassageApi_V1.DTOs;
using MassageApi_V1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MassageApi_V1.Controllers
{
        [ApiController]
        [Route("api/datasheet")]
        public class DataSheetController : ControllerBase
        {
            private readonly MyDBContext _context;
            private readonly IMapper _mapper;

            public DataSheetController(MyDBContext context, IMapper mapper)
            {
                this._context = context;
                _mapper = mapper;
            }
            [HttpGet("contactId")]
            public async Task<ActionResult> Getbycontactid(int contactId)
            {
                var datasheet = await _context.DataSheets.Where(ds=>ds.ContactId==contactId).FirstOrDefaultAsync();
                return Ok(datasheet);

            }
            [HttpGet("Id")]
            public async Task<ActionResult> GetbyId(int id)
            {
                var datasheet = await _context.DataSheets.FirstOrDefaultAsync(ds => ds.Id == id);
                return Ok(datasheet);
            }
            [HttpPost]
            public async Task<ActionResult> Post(DataSheetNewDTO datasheetDTO, int contactId)
            {
                var datasheet = _mapper.Map<DataSheet>(datasheetDTO);
                var contact = await _context.Contacts.Where(x => x.Id == contactId).FirstOrDefaultAsync();
                if (contact == null) 
                    return BadRequest();
                contact.DataSheet=datasheet;
                await _context.SaveChangesAsync();
                return Ok();
            }
            [HttpDelete("Id")]
            public async Task<ActionResult> Delete(int Id)
            {
                var datasheet = await _context.DataSheets.Where(x=>x.Id==Id).FirstOrDefaultAsync();
                if (datasheet == null)
                {
                return NotFound();
            }
            _context.Remove(datasheet);
            return Ok();
            
            }
            [HttpDelete("contactId")]
            public async Task<ActionResult> Deletebycontactid(int contactId)
            {
                var datasheet = await _context.DataSheets.Where(ds => ds.ContactId == contactId).FirstOrDefaultAsync();
                if(datasheet is not null)
                {
                    _context.Remove(datasheet);
                    return Ok();
                }
                return NotFound();

            }
        }
    }

