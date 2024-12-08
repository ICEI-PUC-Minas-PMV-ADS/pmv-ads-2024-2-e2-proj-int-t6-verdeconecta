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
        public double Fibras { get; set; }
        public double Proteinas { get; set; }
        public double Carboidratos { get; set; }
        public double Gorduras { get; set; }
        public double Calorias { get; set; }
        public ICollection<Refeicao> Refeicoes { get; set; }
    }
}
