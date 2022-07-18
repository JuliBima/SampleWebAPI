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
    public class ElementsController : ControllerBase
    {
        private readonly IElement _elementDAl;
        private readonly IMapper _mapper;
        public ElementsController(IElement elementDAl, IMapper mapper)
        {
            _elementDAl = elementDAl;
            _mapper = mapper;
        }


        [HttpGet("BerdasarkanNama")]
        public async Task<IEnumerable<ElementDTO>> Get()
        {

            var results = await _elementDAl.GetAll();
            var elementDTO = _mapper.Map<IEnumerable<ElementDTO>>(results);

            return elementDTO;
        }

        [HttpGet("Name/{name}")]
        public async Task<IEnumerable<ElementDTO>> GetByName(string name)
        {

            var results = await _elementDAl.GetByName(name);

            var elementDTO = _mapper.Map<IEnumerable<ElementDTO>>(results);
            return elementDTO;
        }

        [HttpPost]
        public async Task<ActionResult> Post(ElementCreateDTO elementCreateDto)
        {
            try
            {
                var newElement = _mapper.Map<Element>(elementCreateDto);
                var result = await _elementDAl.Insert(newElement);
                var elementDto = _mapper.Map<ElementDTO>(result);

                return CreatedAtAction("Get", new { id = result.ElementId }, elementDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult> Put(ElementDTO elementDto)
        {
            try
            {

                var updateElement = _mapper.Map<Element>(elementDto);
                var result = await _elementDAl.Update(updateElement);
                var elementDTO = _mapper.Map<ElementDTO>(result);
                return Ok(elementDTO);
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
                await _elementDAl.Delete(id);
                return Ok($"Data Element dengan id {id} berhasil didelete");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
