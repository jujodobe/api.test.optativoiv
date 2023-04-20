using System.ComponentModel.DataAnnotations;

namespace api.test.optativoiv.Models
{
    public class PersonaModel
    {
        public int Id { get; set; }

        [Required]
        [MinLength(3)]
        public string Nombre { get; set; }

        [Required]
        public string Apellido { get; set; }

        [Required]
        public int Edad { get; set; }

        public string Email { get; set; }

        public string Telefono { get; set; }

    }
}
