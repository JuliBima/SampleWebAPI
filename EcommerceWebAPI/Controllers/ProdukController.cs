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
    public class ProdukController : ControllerBase
    {
        private readonly IProduk _produkDAl;
        private readonly IMapper _mapper;
        public ProdukController(IProduk produkDAl, IMapper mapper)
        {
            _produkDAl = produkDAl;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<ProdukReadDTO>> Get()
        {

            var results = await _produkDAl.GetAll();
            var produkDTO = _mapper.Map<IEnumerable<ProdukReadDTO>>(results);

            return produkDTO;
        }

        [HttpGet("WithTypeKatalog")]
        public async Task<IEnumerable<ProdukTypeKatalogReadDTO>> GetProdukTypeKatalog()
        {
            var results = await _produkDAl.GetProdukTypeKatalog();
            var samuraiWithQuoteDtos = _mapper.Map<IEnumerable<ProdukTypeKatalogReadDTO>>(results);
            return samuraiWithQuoteDtos;
        }

        [HttpGet("WithTypeKatalogPaging")]
        public async Task<IEnumerable<ProdukTypeKatalogReadDTO>> GetProdukTypeKatalogPaging(int skip, int take)
        {
            var results = await _produkDAl.GetProdukTypeKatalogPaging(skip,take);
            var samuraiWithQuoteDtos = _mapper.Map<IEnumerable<ProdukTypeKatalogReadDTO>>(results);
            return samuraiWithQuoteDtos;
        }

        [HttpGet("Name/{name}")]

        public async Task<IEnumerable<ProdukTypeKatalogReadDTO>> GetProdukByName(string name)
        {

            var results = await _produkDAl.GetProdukByName(name);

            var DTO = _mapper.Map<IEnumerable<ProdukTypeKatalogReadDTO>>(results);
            return DTO;
        }

        [HttpGet("Harga/{harga}")]

        public async Task<IEnumerable<ProdukTypeKatalogReadDTO>> GetProdukByHarga(int harga)
        {

            var results = await _produkDAl.GetProdukByHarga(harga);

            var DTO = _mapper.Map<IEnumerable<ProdukTypeKatalogReadDTO>>(results);
            return DTO;
        }

        [HttpGet("Type/{type}")]

        public async Task<IEnumerable<ProdukTypeKatalogReadDTO>> GetProdukByType(string type)
        {

            var results = await _produkDAl.GetProdukByType(type);

            var DTO = _mapper.Map<IEnumerable<ProdukTypeKatalogReadDTO>>(results);
            return DTO;
        }

        [HttpPost("WithType")]
        public async Task<ActionResult> Post(ProdukWithTypeDTO typekatalog)
        {
            try
            {
                var newproduk = _mapper.Map<Produk>(typekatalog);
                var result = await _produkDAl.InsertWithType(newproduk);
                var produkDto = _mapper.Map<ProdukWithTypeDTO>(result);

                return CreatedAtAction("Get", new { id = result.Id }, produkDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



        [HttpPut]
        public async Task<ActionResult> Put(ProdukReadDTO elementDto)
        {
            try
            {

                var updateElement = _mapper.Map<Produk>(elementDto);
                var result = await _produkDAl.Update(updateElement);
                var elementDTO = _mapper.Map<ProdukReadDTO>(result);
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
                await _produkDAl.Delete(id);
                return Ok($"Data dengan id {id} berhasil didelete");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("addExistingKatalog")]
        public async Task<ActionResult> Post(int produkID, int katalogID)
        {
            try
            {
                //var newElement = _mapper.Map<Element>(elementCreateDto);
                await _produkDAl.AddProdukToExistingKatalog(produkID, katalogID);
                //var elementDto = _mapper.Map<ElementToExistingSwordDTO>(result);

                return Ok("Sukses ditambahkan");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //[HttpPost("AddKeranjang")]
        //public async Task<ActionResult> Post(int produkId, int userId, KeranjangDTO jumlahItem)
        //{
        //    try
        //    {
        //        var newElement = _mapper.Map<Keranjang>(jumlahItem);
        //        var a = await _produkDAl.AddKeranjang(produkId, userId, newElement);
        //        var elementDto = _mapper.Map<KeranjangDTO>(a);

        //        return Ok("Sukses ditambahkan");
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }
        //}

        [HttpPost("AddKeranjang2")]
        public async Task<ActionResult> Post(KeranjangDTO obj)
        {
            try
            {
                var newproduk = _mapper.Map<Keranjang>(obj);
                var result = await _produkDAl.AddKeranjang2(newproduk);
                var produkDto = _mapper.Map<KeranjangDTO>(result);

                return CreatedAtAction("Get", new { id = result.Id }, produkDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
    
}
