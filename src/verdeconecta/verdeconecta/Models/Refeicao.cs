using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace verdeconecta.Models
{
       [Table("Refeicao")]
        public class Refeicao
        {
            [Key]

            public int Id { get; set; }         
            public TipoRefeicao TipoRefeicao { get; set; }
            
            public DateTime DataDaRefeicao { get; set; }

            public int AlimentoId { get; set; }

            [ForeignKey("AlimentoId")]
            public Alimento Alimento { get; set; }

            public int UsuarioId { get; set; }

            [ForeignKey("UsuarioId")]
            public Usuario Usuario { get; set; }
    }

            public enum TipoRefeicao
         {
            CafeDaManha,
            Almoco,
            CafeDaTarde,
            Jantar,
            Lanches
         }
}

