using System;
using System.Collections.Generic;
using System.Text;

namespace Dijkstra.Model {
  class Node {
    public enum Status {
      Undiscovered,
      Discovered,
      Visited
    }

    /// <summary>
    /// O status deste nó
    /// </summary>
    public Status NodeStatus { get; set; } = Status.Undiscovered;

    /// <summary>
    /// A distância da origem até este nó
    /// </summary>
    public int Distance { get; set; } = int.MaxValue;

    /// <summary>
    /// A lista de arestas deste nó
    /// </summary>
    public List<Edge> Edges { get; private set; }

    /// <summary>
    /// Por onde o caminho mais curto foi encontrado
    /// </summary>
    public int PathVia { get; set; } = -1;

    public Node(int distance) {
      // Define a distância inicial
      Distance = distance;

      // Inicializa o vetor de arestas
      Edges = new List<Edge>();
    }

    /// <summary>
    /// Adiciona uma aresta a lista de arestas deste nó
    /// </summary>
    /// <param name="value">O peso da aresta</param>
    /// <param name="destinationIndex">O índice do nó ao qual este se conecta</param>
    public void AddEdge(int value, int destinationIndex) {
      // Inicializa a nova aresta
      Edge newEdge = new Edge(value,destinationIndex);

      // Adiciona a aresta na lista
      Edges.Add(newEdge);
    }

    /// <summary>
    /// Adiciona uma aresta a lista de arestas deste nó
    /// </summary>
    /// <param name="edge">A aresta a ser adicionada</param>
    public void AddEdge(Edge edge) {
      // Adiciona a aresta na lista
      Edges.Add(edge);
    }

    /// <summary>
    /// Verifica se a aresta para o nó destino já existe
    /// </summary>
    /// <param name="destinationIndex">O índice do nó destino</param>
    /// <returns>True para aresta existente e false para aresta não existente</returns>
    public bool ContainsEdgeTo(int destinationIndex) {
      // Pra cada aresta deste nó
      foreach(Edge edge in Edges) {
        // Se a aresta para o destino existe, retorna verdadeiro
        if(edge.NodeIndex == destinationIndex) {
          return true;
        }
      }

      // Se chegou aqui a aresta não foi encontrada, logo retorna falso
      return false;
    }
  }
}
