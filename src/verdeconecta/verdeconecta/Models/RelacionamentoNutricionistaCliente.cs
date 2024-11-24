using Microsoft.AspNetCore.Authorization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace verdeconecta.Models
{
    [Table("RelacionamentoNutricionistaCliente")]
    public class RelacionamentoNutricionistaCliente
    {
        [ForeignKey("Nutricionista")]
        public int IdNutricionista { get; set; }
        public Usuario Nutricionista { get; set; }

        [ForeignKey("Cliente")]
        public int IdCliente { get; set; }
        public Usuario Cliente { get; set; }
    }
}
