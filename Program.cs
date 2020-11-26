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
      Regex rx = new Regex(@"(.{1,})(\.txt)",RegexOptions.IgnoreCase);
      if(!rx.IsMatch(fileName)) {
        // Encerra a aplicação com código 110
        ExitWithErrorCode(110);
      }

      // Abre o arquivo e carrega a matriz de arestas
      int[,] matrix;
      int status = FileReader.ReadMatrixFile(fileName,out matrix);
      if(status != 0) {
        // Encerra a aplicação com o código do erro
        ExitWithErrorCode(status);
      }

      // Obtém o nó de origem
      int origin;
      // Se falha ao realizar o parse do argumento na variável de origem
      if(!int.TryParse(args[1],out origin)) {
        // Encerra a aplicação com código 120
        ExitWithErrorCode(120);
      }

      // Se o nó de origem não existir no grafo
      if(origin < 0 || origin > matrix.GetLength(0)) {
        // Encerra a aplicação com código 122
        ExitWithErrorCode(122);
      }

      // Obtém o nó de destino
      int destination;
      // Se falha ao realizar o parse do argumento na variável de destino
      if(!int.TryParse(args[2],out destination)) {
        // Encerra a aplicação com código 121
        ExitWithErrorCode(121);
      }

      // Se o nó de destino não existir no grafo
      if(destination < 0 || destination > matrix.GetLength(0)) {
        // Encerra a aplicação com código 123
        ExitWithErrorCode(123);
      }

      // Calcula o caminho pelo algoritmo de Djikstra
      Dijkstra dijkstra = new Dijkstra(matrix);
      string path = dijkstra.CalculatePath(origin, destination);

      // Se o caminho não foi encontrado...
      if(path.Equals("N")) {
        // Encerra a aplicação com código 300
        ExitWithErrorCode(300);
      } else {
        // Imprime o resultado na tela
        Console.WriteLine(path);

        // Encerra a aplicação com código 0 (Sucesso)
        Environment.Exit(0);
      }

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
