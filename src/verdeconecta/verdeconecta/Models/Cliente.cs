using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace verdeconecta.Models
{
    [Table("Cliente")]
    public class Cliente
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage ="Obrigatório informar o nome!")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Obrigatório informar o E-mail!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Obrigatório informar o Data de Nascimento!")]
        public DateTime DataDeNascimento { get; set; }

        [Required(ErrorMessage = "Obrigatório informar o Peso!")]
        public float Peso { get; set; }

        [Required(ErrorMessage = "Obrigatório informar o Altura!")]
        public float Altura { get; set; }


    }
}
