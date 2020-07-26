using Microsoft.AspNetCore.Mvc;
using WebApiRuleta.Entidades;
using WebApiRuleta.Negocio;

namespace WebApiRuleta.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RuletaController : ControllerBase
    {        
        [HttpGet]
        public IActionResult Get()
        {            
            return Ok(new BLRuleta().ObtenerRuletas());
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {            
            Ruleta objRuleta = new BLRuleta().ObtenerRuletaID(id);
            if (objRuleta == null)            
                return NotFound("La Ruleta " + id.ToString() + " no existe.");            

            return Ok(objRuleta);
        }
        [HttpPost("agregarRuleta")]
        public IActionResult AgregarRuleta()
        {
            return CreatedAtAction(nameof(AgregarRuleta), new BLRuleta().CrearRuleta());
        }
        [HttpPost("agregarApuesta")]
        public IActionResult AgregarApuesta(Apuesta objApuesta)
        {
            bool rta = new BLRuleta().CrearApuesta(objApuesta);            
            if(!rta)
                return NotFound("La Ruleta " + objApuesta.IdRuleta.ToString() + " no esta Abierta.");

            return Ok();
        }
        [HttpPost("iniciarRuleta")]
        public IActionResult InicarRuleta(int id)
        {
            bool rta = new BLRuleta().IniciarRuleta(id);
            if (!rta)
                return NotFound("La Ruleta " + id.ToString() + " no existe.");

            return Ok();
        }
        [HttpPost("cerrarApuestas")]
        public IActionResult CerrarRuleta(int id)
        {            
            return CreatedAtAction(nameof(CerrarRuleta), new BLRuleta().CerrarRuleta(id));            
        }
    }
}
