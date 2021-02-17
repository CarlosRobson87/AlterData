using AlterData_Api.Data;
using AlterData_Api.Models;
using AlterData_Api.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AlterData_Api.Service
{
    public class RecursoService
    {
        private readonly Context _context;

        public RecursoService(Context context)
        {
            _context = context;
        }

        public async Task<string> SalvarAsync(Recurso recurso)
        {
            try
            {
                _context.Recursos.Add(recurso);
                await _context.SaveChangesAsync();
                return null;
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        public List<Recurso> ListarTodos()
        {
            try
            {
                return _context.Recursos.ToList();
                    
            }
            catch (Exception e)
            {
                return new List<Recurso>();
            }
        }

        public Recurso GetRecurso(String nome)
        {
            try
            {
                return _context.Recursos.Where(f => f.Nome.ToLower().Equals(nome.ToLower())).FirstOrDefault();

            }
            catch (Exception e)
            {
                return new Recurso();
            }
        }


        public List<Recurso> ListarParaVoto(Funcionario funcionario)
        {
            try
            {
                List<Recurso> recursos = _context.Recursos.Include(r => r.Votos).ThenInclude(v => v.Funcionario).ToList();
                foreach (Recurso recurso in recursos.ToList())
                {
                    if (recurso.Votos.Where(v => v.Funcionario.Email.Equals(funcionario.Email)).Any())
                    {
                        recursos.Remove(recurso);
                    }
                }
                return recursos;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public List<Recurso> ListarOrdemMaisVotadas()
        {
            try
            {
                //Realiza left join entre Recursos e Votos
                //Agrupa por Recurso e quando a variavel Recurso_id em Votos não existir, adiciona 0 na quantidade
                List<Recurso> recursos = (from r in _context.Recursos
                                          join v in _context.Votos on r.Recurso_Id equals v.Recurso_Id into rv
                                          from c in rv.DefaultIfEmpty()
                                          group c by new { r.Nome, c.Recurso_Id } into gr
                                          select new Recurso
                                          {
                                              Nome = gr.Key.Nome,
                                              Quantidade = gr.Key.Recurso_Id == null ? 0 : gr.Count()

                                          }).OrderByDescending(o => o.Quantidade).ToList();



                return recursos;
            }
            catch (Exception e)
            {
                return null;
            }
        }

    }
}
