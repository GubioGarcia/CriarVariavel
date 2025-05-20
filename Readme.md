# 🧩 CriarVariavel API

API ASP.NET Core que recebe uma lista de variáveis (nome e valor) via JSON, valida duplicidade de nomes e retorna um objeto JSON com as variáveis nomeadas corretamente. Caso haja duplicidade de nomes, o serviço renomeia automaticamente as variáveis para garantir unicidade.

## ✅ Funcionalidades

- Receber uma lista de variáveis via `POST` em JSON.
- Verificar duplicidade de nomes de variáveis.
- Renomear variáveis duplicadas automaticamente (ex: `variavel`, `variavel1`, `variavel2`, etc.).
- Retornar as variáveis como um objeto JSON formatado.

## 🚀 Como Executar

1. Clone o repositório:
   ```bash
   git clone https://github.com/seu-usuario/CriarVariavel.git
   cd CriarVariavel

2. Restaure os pacotes e execute a aplicação:
dotnet restore
dotnet run

3. Acesse a interface Swagger para testar a API:
https://localhost:{PORTA}/swagger

## 📌 Endpoint Disponível
POST /api/CriarVariavel/CriarVariavel
Recebe uma lista de variáveis e retorna o JSON com nomes únicos.

Exemplo de Requisição:
[
  {
    "nomeVariavel": "variavel",
    "valorVariavel": "valor1"
  },
  {
    "nomeVariavel": "teste",
    "valorVariavel": "valor2"
  },
  {
    "nomeVariavel": "variavel",
    "valorVariavel": "valor3"
  }
]

Exemplo de Resposta:
{
  "variavel": "valor1",
  "teste": "valor2",
  "variavel1": "valor3"
}

## 👨‍💻 Autor
Desenvolvido por Gubio Garcia dos Santos.
Contato: [gubiogarcia@gmail.com] | GitHub: [https://github.com/gubiogarcia]