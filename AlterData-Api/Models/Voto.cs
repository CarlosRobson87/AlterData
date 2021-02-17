using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AlterData_Api.Models
{
    public partial class Voto
    {
        public Voto()
        {

        }
        [Key]
        public int Funcionario_Id { get; set; }
        [Key]
        public int Recurso_Id { get; set; }
        public DateTime Data_Votacao { get; set; }
        public String Comentario { get; set; }

        [NotMapped]
        public int Quantidade { get; set; }

        public virtual Funcionario Funcionario { get; set; }
        public virtual Recurso Recurso { get; set; }
    }
}
