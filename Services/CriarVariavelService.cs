using CriarVariavel.Entities;
using System.Text.Json;

namespace CriarVariavel.Services
{
    public class CriarVariavelService
    {
        public string CriarVariavel(Variavel valoresVariavel)
        {
            Dictionary<string, string> variavel = new()
            {
                { valoresVariavel.NomeVariavel, valoresVariavel.ValorVariavel }
            };

            return JsonSerializer.Serialize(variavel, new JsonSerializerOptions { WriteIndented = true });

        }
    }
}
