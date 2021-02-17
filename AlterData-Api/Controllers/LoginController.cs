
using AlterData_Api.Data;
using AlterData_Api.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AlterData_Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly Context _context;
        private Utils utils = new Utils();

        public LoginController(Context context)
        {
            _context = context;
        }
      

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] Funcionario funcionarioLogin)
        {
            try
            {
                if(!utils.ValidarEmail(funcionarioLogin.Email))
                {
                    return BadRequest("Email não valido");
                }

                utils.CriptografarSenha(funcionarioLogin);

                Funcionario funcionario = _context.Funcionarios.Where(f => f.Email.Equals(funcionarioLogin.Email) && f.Password.Equals(funcionarioLogin.Password)).FirstOrDefault();

                if(funcionario != null)
                {
                    return Ok(funcionario);
                } else
                {
                return BadRequest("email ou senha invalidos");
                    
                }
            } catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            
        }

    }
}