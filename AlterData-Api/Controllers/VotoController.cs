using AlterData_Api.Data;
using AlterData_Api.Models;
using AlterData_Api.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlterData_Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VotoController : Controller
    {
        private readonly Context _context;
        private VotoService votoService;

        public VotoController(Context context)
        {
            _context = context;
            votoService = new VotoService(_context);
        }

        [HttpGet]
        [Route("ListarTodos")]
        public async Task<ActionResult> ListarTodos()
        {
            try
            {
                List<Voto> recursos = votoService.ListarTodos();
                return Ok(recursos);
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        [Route("Votar")]
        public async Task<ActionResult<Recurso>> Votar(Voto voto)
        {
            if(votoService.Votar(voto))
                return Ok(true);
            else
                return BadRequest();
        }
    }
}
