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
    public class RegistrasiController : ControllerBase
    {
        private readonly IRegistrasi _registrasiDAl;
        private readonly IMapper _mapper;
        public RegistrasiController(IRegistrasi registrasiDAl, IMapper mapper)
        {
            _registrasiDAl = registrasiDAl;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<RegistrasiDTO>> Get()
        {
            
            var results = await _registrasiDAl.GetAll();
            var registrasiDTO = _mapper.Map<IEnumerable<RegistrasiDTO>>(results);

            return registrasiDTO;
        }

        [HttpPost]
        public async Task<ActionResult> Post(RegistrasiDTO registrasiDto)
        {
            try
            {
                var newregister = _mapper.Map<User>(registrasiDto);
                var result = await _registrasiDAl.Insert(newregister);
                var registrasiiReadDto = _mapper.Map<RegistrasiDTO>(result);

                return CreatedAtAction("Get", new { id = result.Id }, registrasiiReadDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
