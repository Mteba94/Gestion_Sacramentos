using Api_SCI.Imp;
using Api_SCI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Api_SCI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SacramentoController : Controller
    {
        //[HttpPost("AgregaSacramento")]
        [HttpPost]
        public IActionResult AgregaSacramento([FromBody]Sacramento grabarSacramento)
        {
            SacramentoService grabar = new SacramentoService();
            Boolean result = grabar.GrabaSacramento(grabarSacramento);
            if (result)
            {
                return Ok("Guardado Correctamente");
            }
            else
            {
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }

        [HttpGet]
        public IActionResult GetSacramento()
        {
            List<Sacramento> result = new List<Sacramento>();

            SacramentoService verSacramento = new SacramentoService();
            result = verSacramento.getSacramentos();
            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }
    }
}
