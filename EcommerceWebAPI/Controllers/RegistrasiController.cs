using AutoMapper;
using EcommerceWebAPI.Data.DAL;
using EcommerceWebAPI.Domain;
using EcommerceWebAPI.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrasiController : ControllerBase
    {
        private readonly IRegistrasi _registerDAl;
        private readonly IMapper _mapper;
        public RegistrasiController(IRegistrasi registerDAl, IMapper mapper)
        {
            _registerDAl = registerDAl;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<UserReadDTO>> Get()
        {

            var results = await _registerDAl.GetAll();
            var DTO = _mapper.Map<IEnumerable<UserReadDTO>>(results);

            return DTO;
        }

        [HttpPost]
        public async Task<ActionResult> Post(UserCreateDTO Obj)
        {
            try
            {
                var newuser = _mapper.Map<User>(Obj);
                var result = await _registerDAl.Insert(newuser);
                var Dto = _mapper.Map<UserCreateDTO>(result);

                return CreatedAtAction("Get", new { id = result.Id }, Dto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult> Put(UserUpdeteDTO Obj)
        {
            try
            {

                var update = _mapper.Map<User>(Obj);
                var result = await _registerDAl.Update(update);
                var DTO = _mapper.Map<UserUpdeteDTO>(result);
                return Ok(DTO);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                await _registerDAl.Delete(id);
                return Ok($"Data dengan id {id} berhasil didelete");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
