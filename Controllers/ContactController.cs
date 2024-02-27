using AutoMapper;
using MassageApi_V1.DTOs;
using MassageApi_V1.Models;
using MassageApi_V1.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MassageApi_V1.Controllers
{
    [ApiController]
    [Route("api/contact")]
    [Authorize(Roles ="Admin")]
    public class ContactController : ControllerBase
    {
        private readonly IContactRepository _repository;
        private readonly IMapper _mapper;

        public ContactController(IContactRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        [HttpGet("GetAll")]
        public async Task<ActionResult> GetAll()
        {
            var result = await _repository.GetAll();
            if (result == null)
                return NotFound();
            return Ok(result);
        }
        
        [HttpGet("Id")]
        public async Task<ActionResult>GetbyId(int id)
        {
            var result = await _repository.GetbyId(id);
            if (result == null)
                return NotFound();
            return Ok(result);
        }
        [HttpPost]
        public async Task<ActionResult> Post(ContactNewDTO contactDTO)
        {
             var contact = _mapper.Map<Contact>(contactDTO);
             return Ok(await _repository.Post(contact));
          
           
        }
        [HttpPut("Contact")]
        public async Task<ActionResult> Put(ContactNewDTO contactDTO)
        {
            var contact = _mapper.Map<Contact>(contactDTO);
            var entity = await _repository.Update(contact);
            return Ok(entity);

        }
        [HttpDelete("Id")]
        public async Task<ActionResult> Delete(int id)
        {
            var result = await _repository.Delete(id);
            var resultClean = _mapper.Map<List<ContactNewDTO>>(result);
            if (result == null)
                return NotFound();
            return Ok(resultClean);
        }
    }
}
