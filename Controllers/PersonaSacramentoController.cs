using Api_SCI.Imp;
using Api_SCI.Models;
using Microsoft.AspNetCore.Mvc;

namespace Api_SCI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonaSacramentoController : Controller
    {
        [HttpPost]
        public IActionResult grabarPersonaSacramento([FromBody]PersonaSacramento personaSacramento)
        {
           
            PersonaSacramentoService grabar = new PersonaSacramentoService();
            Response result = grabar.GrabaPersonaSacramento(personaSacramento);
            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return StatusCode(500);
            }
        }

    }
}
