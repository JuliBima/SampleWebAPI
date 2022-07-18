using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SampleWebAPI.Data.DAL;
using SampleWebAPI.Domain;
using SampleWebAPI.DTO;

namespace SampleWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SwordsController : ControllerBase
    {
        private readonly ISword _swordDAL;
        private readonly IMapper _mapper;
        public SwordsController(ISword swordDAL, IMapper mapper)
        {
            _swordDAL = swordDAL;
            _mapper = mapper;
        }

        [HttpGet("ByWeight")]
        public async Task<IEnumerable<SwordDTO>> Get()
        {
            
            var results = await _swordDAL.GetAll();
            var swordDTO = _mapper.Map<IEnumerable<SwordDTO>>(results);

            return swordDTO;
        }
        [HttpGet("WithType")]
        public async Task<IEnumerable<SwordWithTypeDTO>> GetWithType()
        {

            var results = await _swordDAL.GetWithType();
            var swordwithtypeDTO = _mapper.Map<IEnumerable<SwordWithTypeDTO>>(results);

            return swordwithtypeDTO;
        }

        [HttpGet("Name/{name}")]
       
        public async Task<IEnumerable<SwordDTO>> GetByName(string name)
        {
           
            var results = await _swordDAL.GetByName(name);
            
            var swordDTO = _mapper.Map<IEnumerable<SwordDTO>>(results);
            return swordDTO;
        }

        [HttpPost]
        public async Task<ActionResult> Post(SwordCreateDTO swordCreateDto)
        {
            try
            {
                var newSword = _mapper.Map<Sword>(swordCreateDto);
                var result = await _swordDAL.Insert(newSword);
                var swordDto = _mapper.Map<SwordDTO>(result);

                return CreatedAtAction("Get", new { id = result.Id }, swordDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult> Put(SwordDTO swordDto)
        {
            try
            {

                var updateSword = _mapper.Map<Sword>(swordDto);
                var result = await _swordDAL.Update(updateSword);
                var swordDTO = _mapper.Map<SwordDTO>(result);
                return Ok(swordDto);
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
                await _swordDAL.Delete(id);
                return Ok($"Data samurai dengan id {id} berhasil didelete");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
