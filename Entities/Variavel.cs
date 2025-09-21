using System.ComponentModel.DataAnnotations;

namespace CriarVariavel.Entities
{
    public class Variavel
    {
        [Required(ErrorMessage = "O campo NomeVariavel é obrigatório.")]
        public string NomeVariavel { get; set; } = "NomeVariavel";

        [Required(ErrorMessage = "O campo ValorVariavel é obrigatório.")]
        public string ValorVariavel { get; set; } = "ValorVariavel";
    }
}
