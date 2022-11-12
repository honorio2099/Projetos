using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FluentResults;
using Microsoft.AspNetCore.Mvc;
using TesteRestful_API.Data;
using TesteRestful_API.Data.DTO_S;
using TesteRestful_API.Models;
using TesteRestful_API.Services;

namespace TesteRestful_API.Controllers
{
    [ApiController]
    [Route("[controller]")] // basicamente - exemplo: http://localhost:1234/brinquedinhos
    public class BrinquedosController : ControllerBase
    {
        private readonly BrinquedoService _brinquedoService;

        public BrinquedosController(BrinquedoService brinquedoService)
        {
            _brinquedoService = brinquedoService;
        }

        [HttpPost]
        public IActionResult adicionar([FromBody] CreateBrinquedoDTO brinquedoDTO)
        {
            ReadBrinquedoDTO brinqDTO = _brinquedoService.adicionar(brinquedoDTO);
            return CreatedAtAction(nameof(RecuperarBrinquedoPorID), new { Id = brinqDTO.IDBrinquedo }, brinqDTO);
        }

        [HttpGet]
        public IActionResult RecuperarBrinquedo()
        {
            List<ReadBrinquedoDTO> listabrinqDTO = _brinquedoService.RecuperarBrinquedo();
            return Ok(listabrinqDTO);
        }

        [HttpGet("{id}")]
        public IActionResult RecuperarBrinquedoPorID(int id)
        {
            ReadBrinquedoDTO readBrinquedoDTO = _brinquedoService.RecuperarBrinquedoPorID(id);
            if (readBrinquedoDTO == null)
                return NotFound();

            return Ok(readBrinquedoDTO);
        }

        [HttpDelete("{id}")]
        public IActionResult DeletaBrinquedo(int id)
        {
                Result respExcluir = _brinquedoService.DeletaBrinquedo(id);

                // igual o AtualizaCinema aqui, mas ao contrário
                if (respExcluir.IsSuccess)
                    return NoContent();

                return NotFound();
            
        }

        [HttpPut("{id}")]
        public IActionResult AtualizaBrinquedo(int id, [FromBody] UpdateBrinquedoDTO UpdatenovoBrinqDTO)
        {
            Result respAtualizar = _brinquedoService.AtualizaBrinquedo(id, UpdatenovoBrinqDTO);

            // igual o AtualizaCinema aqui, mas ao contrário
            if (respAtualizar.IsSuccess)
                return NoContent();

            return NotFound();
        }
    }
}
