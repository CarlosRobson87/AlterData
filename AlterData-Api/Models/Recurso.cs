using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AlterData_Api.Models
{
    public partial class Recurso
    {
        public Recurso()
        {
        }

        [Key]
        public int Recurso_Id { get; set; }
        public String Nome { get; set; }

        [NotMapped]
        public int Quantidade { get; set; }

        public virtual ICollection<Voto> Votos { get; set; }

    }
}
