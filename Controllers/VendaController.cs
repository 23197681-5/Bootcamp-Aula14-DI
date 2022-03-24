using Microsoft.AspNetCore.Mvc;
using System;
using Domain;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class VendaController : ControllerBase
    {
        private IVenda _iVenda;

        public VendaController(IVenda ivenda)
        {
            _iVenda = ivenda;
        }

        //Requisicao veio do navegador
        [HttpGet]
        public IActionResult Finalizar(string idProduto)
        {
            try
            {
                _iVenda.OferecerCartaoDeCredito();
                _iVenda.Finalizar(idProduto);

                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet]
        public IActionResult Cancelar(string idProduto)
        {
            try
            {
                _iVenda.Cancelar(idProduto);

                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
