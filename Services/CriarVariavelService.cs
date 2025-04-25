using CriarVariavel.Entities;
using System.Text.Json;

namespace CriarVariavel.Services
{
    public class CriarVariavelService
    {
        private int contadorVariavel = 0;

        public string CriarVariavel(List<Variavel> variaveis)
        {
            if (variaveis == null || variaveis.Count == 0) throw new Exception("Nenhuma variável foi informada.");

            if (!ValidaDuplicidadeVariavel(variaveis)) RenomearVariavel(variaveis);

            Dictionary<string, string> variavel = [];
            foreach (var _valoresVariavel in variaveis)
            {
                variavel[_valoresVariavel.NomeVariavel] = _valoresVariavel.ValorVariavel;
            }

            return JsonSerializer.Serialize(variavel, new JsonSerializerOptions { WriteIndented = true });
        }

        private bool ValidaDuplicidadeVariavel(List<Variavel> variaveis)
        {
            HashSet<string> _variaveisUnicas = [];
            foreach (Variavel _variavel in variaveis)
            {
                if (!_variaveisUnicas.Add(_variavel.NomeVariavel)) return false; // Encontrado variáveis duplicadas 
            }
            return true;
        }

        private void RenomearVariavel(List<Variavel> variaveis)
        {
            HashSet<string> _variaveisAux = [];
            foreach (Variavel _variavel in variaveis)
            {
                if (!_variaveisAux.Add(_variavel.NomeVariavel))
                {
                    _variavel.NomeVariavel += contadorVariavel;
                    contadorVariavel++;
                }
            }
        }
    }
}