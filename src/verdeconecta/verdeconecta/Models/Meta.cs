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
        [Required(ErrorMessage = "Obrigatório informar a duração da meta!")]
        public DateTime duracaoDaMeta { get; set;}

        [Display(Name = "Meta Calórica")]
        [Required(ErrorMessage = "Obrigatório informar a meta calórica!")]
        public float metaCalorica { get; set; }

        [Display(Name = "Meta de Fibras")]
        [Required(ErrorMessage = "Obrigatório informar a meta de fibras!")]
        public float MetaFibras { get; set; }

        [Display(Name = "Meta de Proteínas")]
        [Required(ErrorMessage = "Obrigatório informar a meta de proteinas!")]
        public float metaProteinas { get; set; }

        [Display(Name = "Meta de Carboidratos")]
        [Required(ErrorMessage = "Obrigatório informar a meta de carboidratos!")]
        public float metaCarboidratos { get; set; }

        [Display(Name = "Meta de Sódio")]
        [Required(ErrorMessage = "Obrigatório informar a meta de sódio!")]
        public float metaSodio { get; set; }

        [Display(Name = "Meta de Gordura totais")]
        [Required(ErrorMessage = "Obrigatório informar a meta de gordura!")]
        public float metaGorduraTotais { get; set; }

        [Display(Name = "Paciente")]
        [Required(ErrorMessage = "Obrigatório informar o Paciente!")]
        public int idUsuario { get; set; }
        [ForeignKey(nameof(idUsuario))]
        public  Usuario Usuario { get; set; }

            
    }
}
