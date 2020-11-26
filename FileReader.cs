using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace Dijkstra {
  class FileReader {
    /// <summary>
    /// Lê um arquivo de texto contendo os valores e retorna um estado de erro além da matriz
    /// </summary>
    /// <param name="fileName">Nome do arquivo a ser lido</param>
    /// <param name="matrix">A matriz que será preenchida com os valores lidos</param>
    /// <returns>O status de erro. 0 Significa sucesso e qualquer outro número um erro</returns>
    public static int ReadMatrixFile(string fileName,out int[,] matrix) {
      string path = string.Concat("./",fileName);

      // Transforma a matriz em nula até a inicialização
      matrix = null;

      int i = 0, j = 0;

      // Se o arquivo existe
      if(File.Exists(path)) {
        // Lê o conteúdo do arquivo
        string fileContents = File.ReadAllText(path);

        // Se o arquivo está vazio retorna o erro 201
        if(fileContents == null || fileContents == "") {
          return 201;
        }

        // Separa o arquivo linha por linha
        string[] rows = fileContents.Split('\n');

        // Inicializa a matrix
        matrix = new int[rows.Length,rows.Length];

        // Para cada linha do arquivo...
        foreach(string row in rows) {
          // Separa cada çoluna na linha
          string[] columns = row.Split(' ');

          // Verifica se a linha possui o número correto de colunas
          if(columns.Length != rows.Length) {
            // Se o número de colunas e linhas é diferente retorna o erro 210
            return 210;
          }

          // Para cada coluna na linha...
          foreach(string item in columns) {
            // Obtém o valor e se não é possível transforma-lo em inteiro retorna o erro 220
            int value;
            if(!int.TryParse(item,out value)) {
              return 220;
            }

            // Se o número é negativo retorna o erro 221
            if(value < 0) {
              return 221;
            }

            // Atribui o número na posição correta da matriz
            matrix[i,j] = value;

            // Incrementa o índice da coluna
            j++;
          }

          // Incrementa o índice da linha e zera o índice da coluna
          i++;
          j = 0;
        }

      } else {
        // Se o arquivo não existe, retorna o erro 200
        return 200;
      }

      // Se chegou até aqui a matriz foi carregada corretamente, logo retorna status de sucesso
      return 0;
    }
  }
}
