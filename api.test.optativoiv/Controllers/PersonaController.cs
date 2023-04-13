using api.test.optativoiv.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Services;

namespace api.test.optativoiv.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonaController : Controller
    {
        private string ConnectionString = "Server=127.0.0.1;Port=5433;Database=postgres;User Id=postgres;Password=123456;";
        private PersonaService personaService;

        public PersonaController()
        {
            this.personaService = new PersonaService(ConnectionString);    
        }

        [HttpGet("ListarPersona")]
        public ActionResult<List<PersonaModel>> ListarPersonas()
        {   
            var resultado = personaService.listarPersona();
            return Ok(resultado);
        }

        [HttpGet("ConsultarPersona/{id}")]
        public ActionResult<PersonaModel> ConsultarPersona(int id, string documento)
        {
            return Ok(null);
        }

        [HttpPost("InsertarPersona")]
        public ActionResult<string> insertarPersona(PersonaModel modelo)
        {
            return Ok("Ok");
        }
    }
}
