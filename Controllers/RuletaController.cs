using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebApiRuleta.Entidades;
using WebApiRuleta.Models;

namespace WebApiRuleta.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RuletaController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            Repositorio objRepositorio = new Repositorio();
            return Ok(objRepositorio.ObtenerRuletas());
        }
        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            Repositorio objRepositorio = new Repositorio();
            Ruleta objRuleta = objRepositorio.ObtenerRuleta(id);
            if (objRuleta == null)            
                return NotFound("La Ruleta " + id.ToString() + " no existe.");            

            return Ok(objRuleta);
        }
        [HttpPost("agregarRuleta")]
        public IActionResult AgregarRuleta()
        { 
            Repositorio objRepositorio = new Repositorio();
            string id = objRepositorio.CrearRuleta();

            return CreatedAtAction(nameof(AgregarRuleta), id);
        }
        [HttpPost("agregarApuesta")]
        public IActionResult AgregarApuesta(string id , Apuesta objApuesta)
        {
            Repositorio objRepositorio = new Repositorio();
            Ruleta objRuleta = objRepositorio.ObtenerRuleta(id);
            if(objRuleta == null)
                return NotFound("La Ruleta " + id.ToString() + " no existe.");
            if(objRuleta.Estado == Estado.cerrado)
                return NotFound("La Ruleta " + id.ToString() + " esta cerrada.");
            objRepositorio.CrearApuesta(id:id, objApuesta:objApuesta);

            return Ok();
        }
        [HttpPost("iniciarRuleta")]
        public IActionResult InicarRuleta(string id)
        {
            Repositorio objRepositorio = new Repositorio();
            Ruleta objRuleta = objRepositorio.ObtenerRuleta(id);
            if (objRuleta == null)
                return NotFound("La Ruleta " + id.ToString() + " no existe.");
            if (objRuleta.Estado == Estado.abierto)
                return NotFound("La Ruleta " + id.ToString() + " ya está abierta.");
            objRepositorio.IniciarApuestas(id);

            return Ok();
        }
        [HttpPost("cerrarApuestas")]
        public IActionResult CerrarRuleta(string id)
        {
            Repositorio objRepositorio = new Repositorio();
            Ruleta objRuleta = objRepositorio.ObtenerRuleta(id);
            if (objRuleta == null)
                return NotFound("La Ruleta " + id.ToString() + " no existe.");
            if (objRuleta.Estado == Estado.cerrado)
                return NotFound("La Ruleta " + id.ToString() + " ya esta cerrada.");
            List<Apuesta> lstApuestas = objRepositorio.CerrarApuestas(id);

            return CreatedAtAction(nameof(CerrarRuleta), lstApuestas);            
        }
    }
}
