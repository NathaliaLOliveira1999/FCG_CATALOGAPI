using FCG_CATALOGAPI.Interfaces.Services;
using FCG_CATALOGAPI.Models.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FCG_CATALOGAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class LibraryController : ControllerBase
    {
        private readonly ILibraryService _libraryService;

        public LibraryController(ILibraryService libraryService)
        {
            _libraryService = libraryService;
        }

        [HttpGet("GetByIdClient")]
        public IActionResult GetByIdClient(int idClient)
        {
            var listaCliente = _libraryService.GetByIdClient(idClient);
            if (listaCliente == null)
                return NotFound();
            return Ok(listaCliente);
        }

        [HttpGet("GetByIdGame")]
        public IActionResult GetByIdGame(int idGame)
        {
            var listaGame = _libraryService.GetByIdGame(idGame);
            if (listaGame == null)
                return NotFound();
            return Ok(listaGame);
        }

        [HttpPost]
        public IActionResult Create(LibraryDto games)
        {
            if (games == null)
                return BadRequest("Preencha as informações dos jogos!");
            var retorno = _libraryService.Add(games);
            if (retorno.Success)
                return Ok(games);
            else return BadRequest(retorno.Error);
        }
    }
}