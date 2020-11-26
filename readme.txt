## Instruções de Uso ##
1. Insira na pasta do executável um arquivo de texto simples (.txt) contendo a matriz a ser lida, separando colunas com um espaço e linhas por uma quebra de linha. Observação: O maior valor encontrado na matriz será considerado o valor do infinito, logo, a matriz do exemplo abaixo represta o valor do infinito com o número 125.
2. Em uma sessão do shell, navegue até a pasta do software e execute o seguinte comando: 'dijkstra.exe _NomeDoArquivoDeTexto_ _NóOrigem_ _NóDestino_', substituindo _NomeDoArquivoDeTexto_ pelo nome do arquivo de texto criado no passo 1, _NóOrigem_ pelo número do nó de origem e _NóDestino_ pelo número do nó de destino.

## Exemplo ##

Um arquivo nomeado 'Matriz.txt' com o conteúdo a seguir:

125 100 125
100 125 13
125 13 125

E a seguinte linha de comando

dijkstra.exe Matriz.txt 0 2
