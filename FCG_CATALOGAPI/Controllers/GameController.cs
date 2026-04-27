using FCG_CATALOGAPI.Interfaces.Services;
using FCG_CATALOGAPI.Models.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FCG_CATALOGAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class GameController : ControllerBase
    {
        private readonly IGameService _gameService;

        public GameController(IGameService gameService)
        {
            _gameService = gameService;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll() => Ok(_gameService.GetAll());

        [HttpGet("GetById")]
        public IActionResult GetById(int id)
        {
            var Client = _gameService.GetById(id);
            if (Client == null)
                return NotFound();
            return Ok(Client);
        }

        [HttpPost]
        public IActionResult Create(GameDto game)
        {
            if (game == null)
                return BadRequest("Preencha as informações do jogo!");
            var retorno = _gameService.Add(game);
            if (retorno.Success)
                return Ok(game);
            else return BadRequest(retorno.Error);
        }
    }
}
