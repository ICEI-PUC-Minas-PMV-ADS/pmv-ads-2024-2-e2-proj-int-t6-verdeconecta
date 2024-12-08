using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace verdeconecta.Models
{
    [Table("Questionarios")]
    public class Questionario
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Tipo de dieta vegetariana")]
        public TipoDieta? TipoDieta { get; set; }

        [Display(Name = "Restrições alimentares")]
        public string TemRestricaoAlimentar { get; set; }
        
        [Display(Name = "Descreva mais sobre suas restrições alimentares")]
        public string RestricaoDetalhes { get; set; }
        
        [Display(Name = "Nível de atividade física")]
        public NivelAtividadeFisica NivelAtividadeFisica { get; set; }

        [Display(Name = "Objetivo principal")]
        public ObjetivoPrincipal ObjetivoPrincipal { get; set; }

        [Display(Name = "Número de refeições por dia")]
        public int RefeicoesPorDia { get; set; }

        [Display(Name = "Horário das Refeições")]
        public int HorarioRefeicoes { get; set; }

        [Display(Name = "Consumo de frutas e vegetais")]
        public ConsumoFrutasVegetais ConsumoFrutasVegetais { get; set; }

        [Display(Name = "Usuário")]
        public int UsuarioId { get; set; }
        [Display(Name = "Usuário")]

        [ForeignKey("UsuarioId")]
        public Usuario Usuario { get; set; }
    }

    // Enumeradores para opções:
    public enum TipoDieta
    {
        [Display(Name = "Ovo-lacto-vegetariano")]
        OvoLactoVegetariano,

        [Display(Name = "Lacto-vegetariano")]
        LactoVegetariano,

        [Display(Name = "Ovo-vegetariano")]
        OvoVegetariano,

        [Display(Name = "Vegano")]
        Vegano,

        [Display(Name = "Pretendo, mas ainda não sou vegetariano")]
        Pretendo
    }

    public enum NivelAtividadeFisica
    {
        Sedentario,
        Leve,
        Moderado,
        Intenso
    }

    public enum ObjetivoPrincipal
    {
        [Display(Name = "Manter peso")]
        ManterPeso,

        [Display(Name = "Perder peso")]
        PerderPeso,

        [Display(Name = "Ganhar massa muscular")]
        GanharMassaMuscular,

        [Display(Name = "Melhorar a performance física")]
        MelhorarPerformance,

        [Display(Name = "Melhorar a saúde geral")]
        MelhorarSaudeGeral
    }

    public enum ConsumoFrutasVegetais
    {
        Baixo,
        Moderado,
        Alto
    }
}
