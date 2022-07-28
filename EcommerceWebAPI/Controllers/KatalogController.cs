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
    public class KatalogController : ControllerBase
    {
        private readonly IKatalog _katalogDAl;
        private readonly IMapper _mapper;
        public KatalogController(IKatalog katalogDAl, IMapper mapper)
        {
            _katalogDAl = katalogDAl;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<KatalogReadDTO>> Get()
        {

            var results = await _katalogDAl.GetAll();
            var katalogDTO = _mapper.Map<IEnumerable<KatalogReadDTO>>(results);

            return katalogDTO;
        }


        [HttpPost]
        public async Task<ActionResult> Post(KatalogCreateDTO typekatalog)
        {
            try
            {
                var newproduk = _mapper.Map<Katalog>(typekatalog);
                var result = await _katalogDAl.Insert(newproduk);
                var produkDto = _mapper.Map<KatalogCreateDTO>(result);

                return CreatedAtAction("Get", new { id = result.KatalogId }, produkDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult> Put(KatalogReadDTO katalogDto)
        {
            try
            {

                var update= _mapper.Map<Katalog>(katalogDto);
                var result = await _katalogDAl.Update(update);
                var DTO = _mapper.Map<KatalogReadDTO>(result);
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
                await _katalogDAl.Delete(id);
                return Ok($"Data dengan id {id} berhasil didelete");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("KatalogFromProduk/{id}")]
        public async Task<ActionResult> DeleteKatalogProduk(int id)
        {
            try
            {
                await _katalogDAl.DeleteKatalogProduk(id);
                return Ok($"Data dengan id {id} berhasil didelete");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("addExistingProduk")]
        public async Task<ActionResult> Post(int katalogID, int produkID)
        {
            try
            {

                await _katalogDAl.AddKatalogExisting(katalogID, produkID);

                return Ok("Sukses ditambahkan");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
