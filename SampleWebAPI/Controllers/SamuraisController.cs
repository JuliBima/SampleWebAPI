﻿using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SampleWebAPI.Data.DAL;
using SampleWebAPI.Domain;
using SampleWebAPI.DTO;
using SampleWebAPI.Helpers;
using SampleWebAPI.Models;

namespace SampleWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SamuraisController : ControllerBase
    {
        private readonly ISamurai _samuraiDAL;
        private readonly IMapper _mapper;
        public SamuraisController(ISamurai samuraiDAL,IMapper mapper)
        {
            _samuraiDAL = samuraiDAL;
            _mapper = mapper;
        }

        [Authorize]
        [HttpGet]
        public async Task<IEnumerable<SamuraiReadDTO>> Get()
        {
            //List<SamuraiReadDTO> samuraiDTO = new List<SamuraiReadDTO>();
            /*foreach (var result in results)
           {
               samuraiDTO.Add(new SamuraiReadDTO
               {
                   Id = result.Id,
                   Name = result.Name
               });
           }*/
            var results = await _samuraiDAL.GetAll();
            var samuraiDTO = _mapper.Map<IEnumerable<SamuraiReadDTO>>(results);
           
            return samuraiDTO;
        }

        [Authorize]
        [HttpGet("{id}")]
        public async Task<SamuraiReadDTO> Get(int id)
        {
            /*SamuraiReadDTO samuraiDTO = new SamuraiReadDTO();
            samuraiDTO.Id = result.Id;
            samuraiDTO.Name = result.Name;*/
            var result = await _samuraiDAL.GetById(id);
            if (result == null) throw new Exception($"data {id} tidak ditemukan");
            var samuraiDTO = _mapper.Map<SamuraiReadDTO>(result);
           
            return samuraiDTO;
        }

        [Authorize]
        [HttpGet("ByName")]
        public async Task<IEnumerable<SamuraiReadDTO>> GetByName(string name)
        {
            List<SamuraiReadDTO> samuraiDtos = new List<SamuraiReadDTO>();
            var results = await _samuraiDAL.GetByName(name);
            foreach(var result in results)
            {
                samuraiDtos.Add(new SamuraiReadDTO
                {
                    Id = result.Id,
                    Name = result.Name
                });
            }
            return samuraiDtos;
        }

        [Authorize]
        [HttpGet("WithQuotes")]
        public async Task<IEnumerable<SamuraiWithQuotesDTO>> GetSamuraiWithQuote()
        {
            var results = await _samuraiDAL.GetSamuraiWithQuotes();
            var samuraiWithQuoteDtos = _mapper.Map<IEnumerable<SamuraiWithQuotesDTO>>(results);  
            return samuraiWithQuoteDtos;
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult> Post(SamuraiCreateDTO samuraiCreateDto)
        {
            try
            {
                var newSamurai = _mapper.Map<Samurai>(samuraiCreateDto);
                var result = await _samuraiDAL.Insert(newSamurai);
                var samuraiReadDto = _mapper.Map<SamuraiReadDTO>(result);
                
                return CreatedAtAction("Get", new { id = result.Id }, samuraiReadDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize]
        [HttpPut]
        public async Task<ActionResult> Put(SamuraiReadDTO samuraiDto)
        {
            try
            {
                var updateSamurai = new Samurai
                {
                    Id = samuraiDto.Id,
                    Name = samuraiDto.Name
                };
                var result = await _samuraiDAL.Update(updateSamurai);
                return Ok(samuraiDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                await _samuraiDAL.Delete(id);
                return Ok($"Data samurai dengan id {id} berhasil didelete");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
