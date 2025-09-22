using CriarVariavel.Entities;
using CriarVariavel.Interfaces;
using System.Text.Json;

namespace CriarVariavel.Services
{
    public class CriarVariavelService : ICriarVariavelService
    {
        public Dictionary<string, string> CriarVariavel(List<Variavel> variaveis)
        {
            if (variaveis is null) throw new Exception("A lista de variáveis não pode estar vazia. O corpo da requisição não foi enviado ou está inválido.");

            foreach (var (_variavel, index) in variaveis.Select((v, i) => (v, i)))
            {
                if (string.IsNullOrWhiteSpace(_variavel.NomeVariavel))
                    throw new ArgumentException($"NomeVariavel é obrigatório e não pode estar vazio ou conter apenas espaços. Erro no item {index + 1}.");

                if (string.IsNullOrWhiteSpace(_variavel.ValorVariavel))
                    throw new ArgumentException($"ValorVariavel é obrigatório e não pode estar vazio ou conter apenas espaços. Erro no item {index + 1}.");
            }

            if (!ValidaDuplicidadeVariavel(variaveis)) RenomearVariavel(variaveis);

            Dictionary<string, string> variavel = [];
            foreach (var _valoresVariavel in variaveis)
            {
                variavel[_valoresVariavel.NomeVariavel.Trim()] = _valoresVariavel.ValorVariavel.Trim();
            }

            return variavel;
        }

        private static bool ValidaDuplicidadeVariavel(List<Variavel> variaveis)
        {
            return variaveis.Select(v => v.NomeVariavel).Distinct().Count() == variaveis.Count;
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