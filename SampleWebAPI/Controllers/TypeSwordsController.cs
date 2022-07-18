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
    public class TypeSwordsController : ControllerBase
    {
        private readonly ITypeSword _typeswordDAL;
        private readonly IMapper _mapper;
        public TypeSwordsController(ITypeSword typeswordDAL, IMapper mapper)
        {
            _typeswordDAL = typeswordDAL;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<TypeSwordDTO>> Get()
        {

            var results = await _typeswordDAL.GetAll();
            var typeswordDTO = _mapper.Map<IEnumerable<TypeSwordDTO>>(results);

            return typeswordDTO;
        }

        [HttpPost]
        public async Task<ActionResult> Post(TypeSwordCreateDTO typeswordCreateDto)
        {
            try
            {
                var newType = _mapper.Map<TypeSword>(typeswordCreateDto);
                var result = await _typeswordDAL.Insert(newType);
                var typeDto = _mapper.Map<TypeSwordDTO>(result);

                return CreatedAtAction("Get", new { id = result.Id }, typeDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult> Put(TypeSwordDTO typeswordDTo)
        {
            try
            {

                var updateTypeSword = _mapper.Map<TypeSword>(typeswordDTo);
                var result = await _typeswordDAL.Update(updateTypeSword);
                var typeswordDTO = _mapper.Map<TypeSwordDTO>(result);
                return Ok(typeswordDTO);
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
                await _typeswordDAL.Delete(id);
                return Ok($"Data TypeSword dengan id {id} berhasil didelete");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
