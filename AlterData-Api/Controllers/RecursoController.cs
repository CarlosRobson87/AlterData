using AlterData_Api.Data;
using AlterData_Api.Models;
using AlterData_Api.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlterData_Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RecursoController : Controller
    {
        private readonly Context _context;
        private RecursoService recursoService;

        public RecursoController(Context context)
        {
            _context = context;
            recursoService = new RecursoService(_context);
        }


        [HttpPost]
        [Route("Cadastrar")]
        public async Task<ActionResult<Recurso>> POST(Recurso recurso)
        {
            String request = await recursoService.SalvarAsync(recurso);
            if (request != null)
            {
                return BadRequest(request);
            }

            return Ok();
        }

        [HttpGet]
        [Route("ListarTodos")]
        public List<Recurso> ListarTodos()
        {
            try
            {
                return recursoService.ListarTodos();
            }catch (Exception e)
            {
                return new List<Recurso>();
            }
        }

        [HttpGet]
        [Route("getRecurso")]
        public Recurso GetRecurso(Recurso recurso)
        {

            return recursoService.GetRecurso(recurso.Nome);
        }

        [HttpPost]
        [Route("ListarParaVoto")]
        public async Task<ActionResult> ListarParaVoto(Funcionario funcionario)
        {
            List<Recurso> request = recursoService.ListarParaVoto(funcionario);
            if (request != null)
            {
                return Ok(request); 
            }

            return BadRequest("Erro interno");
        }

        [HttpGet]
        [Route("ListarOrdemMaisVotadas")]
        public async Task<ActionResult> ListarOrdemMaisVotadas()
        {
            List<Recurso> request = recursoService.ListarOrdemMaisVotadas();
            if (request != null)
            {
                return Ok(request);
            }

            return BadRequest("Erro interno");

        }

    }
}
