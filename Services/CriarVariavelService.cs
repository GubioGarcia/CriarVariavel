using CriarVariavel.Entities;
using System.Text.Json;

namespace CriarVariavel.Services
{
    public class CriarVariavelService
    {
        public string CriarVariavel(List<Variavel> variaveis)
        {
            List<Dictionary<string, string>> variavel = [];
            foreach (var valoresVariavel in variaveis)
            {
                Dictionary<string, string> variavelItem = new()
                {
                    { valoresVariavel.NomeVariavel, valoresVariavel.ValorVariavel }
                };
                variavel.Add(variavelItem);
            }

            return JsonSerializer.Serialize(variavel, new JsonSerializerOptions { WriteIndented = true });
        }
    }
}