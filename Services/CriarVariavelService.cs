using CriarVariavel.Entities;
using CriarVariavel.Interfaces;
using System.Text.Json;

namespace CriarVariavel.Services
{
    public class CriarVariavelService : ICriarVariavelService
    {
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

        private static bool ValidaDuplicidadeVariavel(List<Variavel> variaveis)
        {
            HashSet<string> _variaveisUnicas = [];
            foreach (Variavel _variavel in variaveis)
            {
                if (!_variaveisUnicas.Add(_variavel.NomeVariavel)) return false; // Encontrado variáveis duplicadas 
            }
            return true;
        }

        private static void RenomearVariavel(List<Variavel> variaveis)
        {
            HashSet<string> _nomesUsados = [];
            Dictionary<string, int> contadorPorNome = [];

            foreach (var variavel in variaveis)
            {
                string _nomeOriginal = variavel.NomeVariavel;

                // se o nome da variável já foi usado, gera um novo nome com o contador
                if (!_nomesUsados.Add(_nomeOriginal))
                {
                    if (!contadorPorNome.ContainsKey(_nomeOriginal)) contadorPorNome[_nomeOriginal] = 1;

                    string _novoNome;
                    // gera nome novo e verifica se já foi usado
                    do
                    {
                        _novoNome = _nomeOriginal + contadorPorNome[_nomeOriginal];
                        contadorPorNome[_nomeOriginal]++;
                    }
                    while (!_nomesUsados.Add(_novoNome));

                    variavel.NomeVariavel = _novoNome;
                }
                // se nome de variável não existe, adiciona ao conjunto de nomes usados e inica o contador da variável
                else contadorPorNome[_nomeOriginal] = 1;
            }
        }
    }
}