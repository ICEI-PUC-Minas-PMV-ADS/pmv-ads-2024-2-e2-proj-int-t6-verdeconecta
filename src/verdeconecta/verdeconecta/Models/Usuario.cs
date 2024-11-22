
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace verdeconecta.Models
{
    [Table("Usuario")]
    public class Usuario
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

        [Required(ErrorMessage = "Obrigório informar a Senha!")]
        [DataType(DataType.Password)]
        public string Senha { get; set; }

        public Perfil Perfil { get; set; }
        public ICollection<Refeicao> Refeicoes { get; set; }
        public ICollection<Meta> Metas { get; set; }
#nullable enable
        public string? TokenRedefinicaoSenha { get; set; }
        public DateTime? TokenValidade { get; set; }   
        

    }

    public enum Perfil
    {
        Cliente,
        Nutricionista
    }
}
