using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AlterData_Api.Models
{
    public partial class Funcionario
    {
        public Funcionario()
        {
        }

        [Key]
        public int Funcionario_Id { get; set; }
        public String Nome { get; set; }
        public String Email { get; set; }
        public String Password { get; set; }

        public virtual ICollection<Voto> Votos { get; set; }
    }
}
