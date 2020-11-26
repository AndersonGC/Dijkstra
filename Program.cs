using System;
using System.Text.RegularExpressions;

namespace Dijkstra {
  class Program {
    static void Main(string[] args) {
      // Se possui menos de 3 argumentos, significa que está faltando algum argumento
      if(args.Length < 3) {
        // Encerra a aplicação com código 100
        ExitWithErrorCode(100);
      }

      // Obtém o nome do arquivo contendo a matriz de pesos
      string fileName = args[0];

      // Se o nome não segue o formato correto (*.txt)
      Regex rx = new Regex(@"(.{1,})(\.txt)", RegexOptions.IgnoreCase);
      if(!rx.IsMatch(fileName)) {
        // Encerra a aplicação com código 110
        ExitWithErrorCode(110);
      }

      // TODO: Abre o arquivo e carrega a matriz de arestas

      // Obtém o nó de origem
      int origin;
      // Se falha ao realizar o parse do argumento na variável de origem
      if(!int.TryParse(args[1], out origin)) {
        // Encerra a aplicação com código 120
        ExitWithErrorCode(120);
      }

      // Obtém o nó de destino
      int destination;
      // Se falha ao realizar o parse do argumento na variável de destino
      if(!int.TryParse(args[2],out destination)) {
        // Encerra a aplicação com código 121
        ExitWithErrorCode(121);
      }

      // TODO: Calcula o caminho pelo algoritmo de Djikstra
      string path = "6 5 2 0 ";

      // Imprime o resultado na tela
      Console.WriteLine(path);
    }

    /// <summary>
    /// Encerra a aplicação com o código de erro especificado
    /// </summary>
    /// <param name="errorCode">O código de erro a ser exibido</param>
    private static void ExitWithErrorCode(int errorCode) {
      // Imprime uma mensagem de erro
      Console.WriteLine("Erro " + errorCode + " - Confira o Readme para mais informações");

      // Encerra a execução
      Environment.Exit(errorCode);
    }
  }
}
