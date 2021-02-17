
using AlterData_Api.Data;
using AlterData_Api.Models;
using AlterData_Api.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AlterData_Api.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class FuncionarioController : ControllerBase
    {
        private readonly Context _context;
        private Utils utils = new Utils();
        private FuncionarioService funcionarioService;

        public FuncionarioController(Context context)
        {
            _context = context;
            funcionarioService = new FuncionarioService(_context);
        }


        [HttpPost]
        [Route("Cadastrar")]
        public async Task<ActionResult<Funcionario>> POST([FromBody] Funcionario funcionario)
        {

            if (!utils.ValidarEmail(funcionario.Email))
            {
                return BadRequest("Email não valido");
            }

            utils.CriptografarSenha(funcionario);

            String request = await funcionarioService.SalvarAsync(funcionario);
            if (request != null)
            {
                return BadRequest(request);
            }

            return Ok("Sucesso");
        }

        [HttpGet]
        [Route("ListarTodos")]
        public List<Funcionario> ListarTodos()
        {

            return funcionarioService.ListarTodos();
        }

        [HttpGet]
        [Route("getFuncionario")]
        public Funcionario GetFuncionario(Funcionario funcionario)
        {

            return funcionarioService.GetFuncionario(funcionario.Email);
        }

    }
}