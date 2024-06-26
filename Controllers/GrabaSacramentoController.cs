using Api_SCI.Imp;
using Api_SCI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Api_SCI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GrabaSacramentoController : Controller
    {
        [HttpPost("AgregaSacramento")]
        public IActionResult AgregaSacramento(GrabarSacramento grabarSacramento)
        {
            GrabarSacramentoService grabar = new GrabarSacramentoService();
            Boolean result = grabar.GrabaSacramento(grabarSacramento);
            if (result)
            {
                return Ok();
            }
            else
            {
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }
    }
}
