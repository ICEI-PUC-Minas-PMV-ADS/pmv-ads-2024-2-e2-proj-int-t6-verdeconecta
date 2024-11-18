using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace verdeconecta.Models
{
    [Table("DicasNutricionais")]
    public class DicasNutricionais
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Obrigatório informar o titulo!")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "Obrigatório informar a dica nutricional!")]
        public string Dica { get; set; }

        [Required(ErrorMessage = "Obrigatório informar o Data de postagem da dica!")]
        public DateTime DataDica { get; set; }

        public int Likes { get; set; } = 0;
        public int Dislikes { get; set; } = 0;
    }

}
