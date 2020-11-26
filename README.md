# Dijkstra
Software que calcula o menor caminho entre dois nós de um grafo utlizando uma implementação do algoritmo de Dijkstra. Software desenvolvido para a disciplina de Redes de Computadores oferecida pelo IFMG Campus Ouro Branco no quinto período de Sistemas de Informação.

## Funcionamento
O software lê um arquivo de texto simples (.txt) contendo uma matriz de arestas e seus pesos, além de um nó de origem e um nó de destino. Com esses dados o menor caminho é calculado e exibido.

## Instruções de Uso
1. Insira na pasta do executável um arquivo de texto simples (.txt) contendo a matriz a ser lida, separando colunas com um espaço e linhas por uma quebra de linha. Observação: O maior valor encontrado na matriz será considerado o valor do infinito, logo, a matriz do exemplo abaixo represta o valor do infinito com o número 125.
2. Em uma sessão do shell, navegue até a pasta do software e execute o seguinte comando: 'dijkstra.exe *NomeDoArquivoDeTexto* *NóOrigem* *NóDestino*', substituindo *NomeDoArquivoDeTexto* pelo nome do arquivo de texto criado no passo 1, *NóOrigem* pelo número do nó de origem e *NóDestino* pelo número do nó de destino.

## Exemplo

Um arquivo nomeado 'Matriz.txt' com o conteúdo a seguir:
<pre>
125 100 125
100 125 13
125 13 125
</pre>

E a seguinte linha de comando

<code>
dijkstra.exe Matriz.txt 0 2
</code>