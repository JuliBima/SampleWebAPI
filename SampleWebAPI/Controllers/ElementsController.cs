using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SampleWebAPI.Data.DAL;
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
    }
}
