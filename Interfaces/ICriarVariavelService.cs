using CriarVariavel.Entities;

namespace CriarVariavel.Interfaces
{
    public interface ICriarVariavelService
    {
        public Dictionary<string, string> CriarVariavel(List<Variavel> variaveis);
    }
}
