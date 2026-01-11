using FCG_CATALOGAPI.Interfaces.Services;
using FCG_CATALOGAPI.Models.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FCG_CATALOGAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GameController : ControllerBase
    {
        private readonly IGameService _gameService;

        public GameController(IGameService gameService)
        {
            _gameService = gameService;
        }

        [Authorize]
        [HttpGet]
        public IActionResult GetAll() => Ok(_gameService.GetAll());

        [Authorize]
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var Client = _gameService.GetById(id);
            if (Client == null)
                return NotFound();
            return Ok(Client);
        }

        [Authorize]
        [HttpPost]
        public IActionResult Create(GameDto game)
        {
            if (game == null)
                return BadRequest("Preencha as informações do jogo!");
            var retorno = _gameService.Add(game);
            if (retorno.Success)
                return Ok();
            else return BadRequest(retorno.Error);
        }
    }
}
