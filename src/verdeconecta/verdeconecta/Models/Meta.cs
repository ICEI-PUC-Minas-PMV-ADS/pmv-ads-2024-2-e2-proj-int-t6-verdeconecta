using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace verdeconecta.Models
{

    [Table("Meta")]
    public class Meta
    {
        [Key]
        public int IDMe { get; set; }

        [Display(Name ="Data de Criação")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime DaraCriacao { get; set; } = DateTime.Now;

        [Display(Name = "Duração da meta")]
        [Required(ErrorMessage = "Obrigatorio informar a duração da meta!")]
        public DateTime duracaoDaMeta { get; set;}

        [Display(Name = "Meta Calorica")]
        [Required(ErrorMessage = "Obrigatorio informar a meta calorica!")]
        public float metaCalorica { get; set; }

        [Display(Name = "Meta de Fibras")]
        [Required(ErrorMessage = "Obrigatorio informar a meta de fibras!")]
        public float MetaFibras { get; set; }

        [Display(Name = "Meta de Proteinas")]
        [Required(ErrorMessage = "Obrigatorio informar a meta de proteinas!")]
        public float metaProteinas { get; set; }

        [Display(Name = "Meta de Carboidratos")]
        [Required(ErrorMessage = "Obrigatorio informar a meta de carboidratos!")]
        public float metaCarboidratos { get; set; }

        [Display(Name = "Meta de Sodio")]
        [Required(ErrorMessage = "Obrigatorio informar a meta de sodio!")]
        public float metaSodio { get; set; }

        [Display(Name = "Meta de Gordura totais")]
        [Required(ErrorMessage = "Obrigatorio informar a meta de gordura!")]
        public float metaGorduraTotais { get; set; }

        [Display(Name = "Paciente")]
        [Required(ErrorMessage = "Obrigatorio informar o Paciente!")]
        public int idUsuario { get; set; }
        [ForeignKey(nameof(idUsuario))]
        public  Usuario Usuario { get; set; }

            
    }
}
