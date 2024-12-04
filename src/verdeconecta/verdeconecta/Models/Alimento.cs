using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace verdeconecta.Models
{
    [Table("Alimento")]
    public class Alimento
    {
        [Key]

        public int Id { get; set; }
   
        [Required(ErrorMessage = "Obrigatório informar o nome do alimento!")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Obrigatório informar a quantidade!")]
        public float Fibras { get; set; }
        public float Proteinas { get; set; }
        [Display(Name = "Proteínas")]
        public float Carboidratos { get; set; }
        public float Gorduras { get; set; }
        public float Calorias { get; set; }
        public ICollection<Refeicao> Refeicoes { get; set; }
    }
}
