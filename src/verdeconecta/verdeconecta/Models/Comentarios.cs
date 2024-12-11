using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace verdeconecta.Models
{
    [Table("Comentarios")]
    public class Comentario
    {
        [Key]
        public int Id { get; set; } // Chave primária

        public int RefeicaoId { get; set; } // Relacionamento com a refeição
        [ForeignKey("RefeicaoId")]
        public Refeicao Refeicao { get; set; }

        public int NutricionistaId { get; set; } // Relacionamento com o nutricionista
        [ForeignKey("NutricionistaId")]
        public Usuario Nutricionista { get; set; }

        [Required]
        [StringLength(500)]
        public string NutricionistaComment { get; set; } // Comentário do nutricionista

        // Nome do nutricionista
        public string NutricionistaName { get; set; }

        public DateTime CreatedAt { get; set; } // Data de criação
    }
}