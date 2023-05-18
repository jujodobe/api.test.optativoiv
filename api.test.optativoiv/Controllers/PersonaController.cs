using api.test.optativoiv.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Services;

namespace api.test.optativoiv.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonaController : Controller
    {
        private PersonaService personaService;
        private IConfiguration configuration;

        public PersonaController(IConfiguration configuration)
        {
            this.configuration = configuration;
            this.personaService = new PersonaService(configuration.GetConnectionString("postgresDB"));    
        }
        [Authorize]
        [HttpGet("ListarPersona")]
        public ActionResult<List<PersonaModel>> ListarPersonas()
        {   
            var resultado = personaService.listarPersona();
            return Ok(resultado);
        }

        [Authorize]
        [HttpGet("ConsultarPersona/{id}")]
        public ActionResult<PersonaModel> ConsultarPersona(int id)
        {
            var resultado = this.personaService.consultarPersona(id);
            return Ok(resultado);
        }

        [HttpPost("InsertarPersona")]
        public ActionResult<string> insertarPersona(PersonaModel modelo)
        {
            var resultado = this.personaService.insertarPersona(new infraestructure.Models.PersonaModel {
                Nombre = modelo.Nombre,
                Apellido = modelo.Apellido,
                Email = modelo.Email,
                Telefono = modelo.Telefono,
                Edad = modelo.Edad
            });
            return Ok(resultado);
        }

        [HttpPut("modificarPersona/{id}")]
        public ActionResult<string> modificarPersona(PersonaModel modelo, int id)
        {
            var resultado = this.personaService.modificarPersona(new infraestructure.Models.PersonaModel
            {
                Nombre = modelo.Nombre,
                Apellido = modelo.Apellido,
                Email = modelo.Email,
                Telefono = modelo.Telefono,
                Edad = modelo.Edad
            }, id);
            return Ok(resultado);
        }

        [HttpDelete("eliminarPersona/{id}")]
        public ActionResult<string> eliminarPersona(int id)
        {
            var resultado = this.personaService.eliminarPersona(id);
            return Ok(resultado);
        }
    }
}
