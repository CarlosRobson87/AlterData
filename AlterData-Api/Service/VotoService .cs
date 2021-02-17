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
    public class VotoService
    {
        private readonly Context _context;

        public VotoService(Context context)
        {
            _context = context;
        }

        public Boolean Votar(Voto voto)
        {
            try
            {
                _context.Votos.Add(voto);
                _context.SaveChanges();

                return true;

            }
            catch (Exception e)
            {
                return false;
            }
        }

        public List<Voto> ListarTodos()
        {
            try
            {
                return _context.Votos.ToList();
                    
            }
            catch (Exception e)
            {
                return new List<Voto>();
            }
        }

    }
}
