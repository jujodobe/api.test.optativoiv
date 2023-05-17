using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace api.test.optativoiv.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : Controller
    {
        private readonly IConfiguration _configuration;

        public AuthController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost]
        public IActionResult Authenticate([FromBody] LoginModel loginModel)
        {
            // Aquí debes implementar la lógica de autenticación utilizando el usuario y contraseña proporcionados
            var isAuthenticated = AuthenticateUser(loginModel.Username, loginModel.Password);

            if (isAuthenticated)
            {
                // Generar el token JWT
                var token = GenerateJwtToken(loginModel.Username);

                // Retornar el token en la respuesta
                return Ok(new { token });
            }

            return Unauthorized();
        }

        private bool AuthenticateUser(string username, string password)
        {
            // Aquí debes implementar tu lógica de autenticación para verificar las credenciales del usuario
            // Puedes realizar una consulta a tu base de datos o utilizar cualquier otro mecanismo de autenticación

            // Ejemplo de autenticación de prueba
            return username == "admin" && password == "admin123";
        }

        private string GenerateJwtToken(string username)
        {
            var key = Encoding.ASCII.GetBytes(_configuration["Jwt:SecretKey"]); // Cambia esto por tu propia clave secreta
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, username) // Establece el nombre de usuario como claim
                    // Puedes agregar más claims según tus necesidades
                }),
                Expires = DateTime.UtcNow.AddDays(7), // Cambia el tiempo de expiración según tus necesidades
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }

    public class LoginModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}

