using api.test.optativoiv.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api.test.optativoiv.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonaController : Controller
    {
        private List<PersonaModel> personaModel;

        public PersonaController()
        {
            personaModel = new List<PersonaModel>()
            {
                new PersonaModel { Id = 1, Nombre = "Juan", Apellido = "Perez", Edad = 30, Email = "jp@example.com", Telefono = "09812341564" },
                new PersonaModel { Id = 2, Nombre = "Mario", Apellido = "Gomez", Edad = 25, Email = "mg@example.com", Telefono = "09812341545"},
                new PersonaModel { Id = 3, Nombre = "Antonio", Apellido = "Mazacote", Edad = 25, Email = "am@example.com", Telefono = "09915674654"},
            };
        }

        [HttpGet("ListarPersona")]
        public ActionResult<List<PersonaModel>> ListarPersonas()
        {
            return Ok(personaModel);
        }

        [HttpGet("ConsultarPersona/{id}")]
        public ActionResult<PersonaModel> ConsultarPersona(int id, string documento)
        {
            PersonaModel resultadoPersona = new PersonaModel();
            var peronaItem=personaModel[id+1];
            resultadoPersona = (PersonaModel)peronaItem;
            return Ok(resultadoPersona);
        }
    }
}
