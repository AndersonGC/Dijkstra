namespace Dijkstra.Model {
  class Edge {
    /// <summary>
    /// O peso da aresta
    /// </summary>
    public int Value { get; private set; }

    /// <summary>
    /// O índice do nó a qual a aresta se liga
    /// </summary>
    public int NodeIndex { get; private set; }

    public Edge(int value,int nodeIndex) {
      this.Value = value;
      this.NodeIndex = nodeIndex;
    }
  }
}
