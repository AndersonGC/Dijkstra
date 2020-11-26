using System.Linq;
using System.Xml;
using System.Xml.Linq;

namespace Dijkstra.Utils {
  class XMLReader {
    /// <summary>
    /// Obtém as informações do erro baseado no seu código e retorna se encontrou o erro especificado
    /// </summary>
    /// <param name="errorCode">O código do erro a ser procurado</param>
    /// <param name="description">A descrição obtida do xml de erros</param>
    /// <returns>true para erro encontrado e false para erro não encontrado</returns>
    public static bool LoadErrorData(int errorCode, out string description) {
      // Carrega o xml contendo os erros
      XDocument errorsDocument = XDocument.Load("./Resources/errors.xml");

      // Obtem a descrição e a solução
      var query = from error in errorsDocument.Root.Descendants("error")
                  where (int)error.Attribute("id") == errorCode
                  select error.Element("description").Value + " " + error.Element("fix").Value;

      // Se não achou nenhum erro com esse código
      if(query.Count() == 0) {
        // Define os valores de erro como erro desconhecido
        description = "Erro desconhecido. Favor entrar em contato com o desenvolvedor.";
        return false;
      }

      // Define o valor da descrição e retorna positivo
      description = query.First();
      return true;
    }
  }
}
