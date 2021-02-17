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
    public class FuncionarioService
    {
        private readonly Context _context;

        public FuncionarioService(Context context)
        {
            _context = context;
        }

        public async Task<string> SalvarAsync(Funcionario funcionario)
        {
            try
            {
                _context.Funcionarios.Add(funcionario);
                await _context.SaveChangesAsync();
                return null;
            }
            catch (Exception e)
            {
                if (e.InnerException.Message.Contains("duplicate key") && e.InnerException.Message.Contains("funcionario_email_key"))
                    return "Email já cadastrado";
                return e.Message;
            }
        }

        public List<Funcionario> ListarTodos()
        {
            try
            {
                return _context.Funcionarios.ToList();
                    
            }
            catch (Exception e)
            {
                return new List<Funcionario>();
            }
        }

        public Funcionario GetFuncionario(String email)
        {
            try
            {
                return _context.Funcionarios.Include(f => f.Votos).Where(f => f.Email.ToLower().Equals(email.ToLower())).FirstOrDefault();

            }
            catch (Exception e)
            {
                return new Funcionario();
            }
        }

    }
}
