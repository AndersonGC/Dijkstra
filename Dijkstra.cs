using Dijkstra.Model;

namespace Dijkstra {
  class Dijkstra {
    /// <summary>
    /// Valor que representa o infinito
    /// </summary>
    private int infiniteValue = -1;

    /// <summary>
    /// A quantidade total de nós
    /// </summary>
    private int nodesAmount;

    /// <summary>
    /// A lista de nós
    /// </summary>
    private Node[] nodes;

    public Dijkstra (int[,] matrix) {
      // Calcula o valor do infinito
      CalculateInfinity(matrix);

      // Obtem a quantidade de nós no grafo
      this.nodesAmount = matrix.GetLength(0);

      // Inicializa os nós
      InitializeNodes();

      // Transforma a matriz de pesos em grafo
      FromMatrixToGraph(matrix);
    }

    /// <summary>
    /// Calcula o valor do infinito obtendo o maior peso na matriz
    /// </summary>
    /// <param name="matrix">A matriz contendo os valores</param>
    private void CalculateInfinity(int[,] matrix) {
      // Para cada número na matriz
      foreach(int numero in matrix) {
        // Se o número é maior que o atual infinito...
        if(numero > this.infiniteValue) {
          // Ajusta o valor do infinito
          this.infiniteValue = numero;
        }
      }
    }

    /// <summary>
    /// Inicializa os nós
    /// </summary>
    private void InitializeNodes() {
      // Inicializa o vetor de nós
      this.nodes = new Node[this.nodesAmount];

      // Para cada nó no grafo
      for(int index = 0; index < this.nodesAmount; index++) {
        // Instancia um novo nó com distância igual a infinito e o armazena
        this.nodes[index] = new Node(infiniteValue);
      }
    }

    /// <summary>
    /// Transforma uma matriz de inteiro em um vetor de nós (grafo)
    /// </summary>
    /// <param name="matrix">A matriz contendo os pesos das arestas</param>
    private void FromMatrixToGraph(int[,] matrix) {
      // Para cada linha da matriz
      for(int rowIndex = 0; rowIndex < this.nodesAmount; rowIndex++) {
        // Para cada coluna da matriz
        for(int colIndex = 0; colIndex < this.nodesAmount; colIndex++) {
          // Se o indice da linha e coluna forem iguais, significa que estamos
          //  falando de uma aresta do nó a si mesmo, logo é ignorado
          if(rowIndex == colIndex) {
            continue;
          }

          // Se a aresta já existe, ignoramos
          if(nodes[rowIndex].ContainsEdgeTo(colIndex)) {
            continue;
          }

          // Se o valor for menor que o valor do infinito existe uma aresta
          if(matrix[rowIndex,colIndex] < this.infiniteValue) {
            // Cria a aresta
            Edge edge = new Edge(matrix[rowIndex,colIndex],colIndex);

            // Adiciona a aresta ij no nó i
            this.nodes[rowIndex].AddEdge(edge);
          }
        }
      }
    }

    /// <summary>
    /// Calcula o menor caminho da origem até o destino
    /// </summary>
    /// <param name="origin">O índice do nó origem</param>
    /// <param name="destination">O índice do nó destino</param>
    /// <returns>Uma string contendo 'N' pra não há caminho ou o caminho caso encontre</returns>
    public string CalculatePath(int origin, int destination) {
      // Cria a flag de busca encerrada com caminho encontrado
      bool pathFound = false;

      // Define a distância do nó de origem como 0
      this.nodes[origin].Distance = 0;

      // Define o nó de origem como descoberto
      this.nodes[origin].NodeStatus = Node.Status.Discovered;

      // Define o nó inicial para começarmos
      int currentNode = origin;

      // Enquanto ainda houver nós a serem explorados
      while(currentNode != -1) {
        // Obtém uma cópia da instância
        Node node = this.nodes[currentNode];

        // Varre todos os nós que tem arestas com o nó atual
        foreach(Edge edge in node.Edges) {
          // Define o nó como descoberto se necessário
          if(this.nodes[edge.NodeIndex].NodeStatus == Node.Status.Undiscovered) {
            this.nodes[edge.NodeIndex].NodeStatus = Node.Status.Discovered;
          }

          // Calcula a distância do nó atual até o seu vizinho
          int distance = node.Distance + edge.Value;

          // Se a distância calculada for menor que a atual, substitui
          if(distance < this.nodes[edge.NodeIndex].Distance) {
            this.nodes[edge.NodeIndex].Distance = node.Distance + edge.Value;
            this.nodes[edge.NodeIndex].PathVia = currentNode;
          }

          // Se eu cheguei no destino, encerra a busca
          if(edge.NodeIndex == destination) {
            // Define a flag de busca encerrada, caminho encontrado
            pathFound = true;
            break;
          }
        }

        // Se o caminho já foi encontrado, encerra
        if(pathFound) {
          break;
        }

        // Define o nó de origem como visitado
        this.nodes[currentNode].NodeStatus = Node.Status.Visited;

        // Obtém o índice do próximo nó com a menor distância que ainda não foi visitado 
        currentNode = GetShortestNodeIndex();
      }

      // Se não encontramos um caminho, retornamos como rota um status negativo
      if(!pathFound) {
        return "N";
      } else {
        // Se encontramos o caminho, retorna a string com cada nó que foi visitado. 
        // Definimos a string que vai armazenar o caminho
        string path = "";

        // Definimos o nó atual como o destion (já que iremos varrer de trás para frente)
        currentNode = destination;

        // Enquanto não chegar na origem...
        while(currentNode != origin) {
          // Concatenamos o caminho (de trás para frente)
          path = string.Concat(currentNode, ' ', path);

          // Ajustamos o nó atual como o anterior
          currentNode = this.nodes[currentNode].PathVia;
        }

        // Adicionamos a origem no inicio da fila
        path = string.Concat(origin,' ',path);

        // Retorna o caminho
        return path;
      }
    }

    /// <summary>
    /// Obtém o índice do nó mais próximo
    /// </summary>
    /// <returns>O índice do nó mais próximo</returns>
    private int GetShortestNodeIndex() {
      int closerIndex = -1;
      int smallestDistance = this.infiniteValue;

      // Varre todos os nós
      for(int index = 0; index < this.nodes.Length; index++) {
        // Ignora nó se ele já foi visitado
        if(this.nodes[index].NodeStatus == Node.Status.Visited) {
          continue;
        }

        // Verifica se a distância do nó é a menor atual
        if(this.nodes[index].Distance < smallestDistance) {
          // Se for substitui a menor distância e atualiza o indice do mais próximo
          smallestDistance = this.nodes[index].Distance;
          closerIndex = index;
        }
      }

      // Retorna o índice do mais próximo
      return closerIndex;
    }
  }
}
