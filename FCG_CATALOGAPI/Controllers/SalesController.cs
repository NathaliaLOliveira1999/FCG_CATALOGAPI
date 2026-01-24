using FCG_CATALOGAPI.Interfaces.Services;
using FCG_CATALOGAPI.Models.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FCG_CATALOGAPI.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class SalesController : ControllerBase
    {
        private readonly ISalesService _salesService;
        public SalesController(ISalesService salesService)
        {
            _salesService = salesService;
        }

        //[Authorize]
        //[HttpGet]
        //public IActionResult GetAll() => Ok(_salesService.GetAll());

        [Authorize]
        [HttpGet("GetByIdClient")]
        public IActionResult GetByIdClient(int idClient)
        {
            var sales = _salesService.GetByIdClient(idClient);
            if (sales == null)
                return NotFound();
            return Ok(sales);
        }

        //[Authorize]
        //[HttpGet("GetByIdGame")]
        //public IActionResult GetByIdGame(int idSale)
        //{
        //    var sales = _salesService.GetByIdSale(idSale);
        //    if (sales == null)
        //        return NotFound();
        //    return Ok(sales);
        //}

        [Authorize]
        [HttpPost]
        public IActionResult Create(SalesDto sale)
        {
            if (sale == null)
                return BadRequest("Preencha as informações da venda!");
            var retorno = _salesService.Add(sale);
            if (retorno.Success)
                return Ok(sale);
            else return BadRequest(retorno.Error);
        }
    }
}
