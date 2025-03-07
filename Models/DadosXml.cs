using System.Xml.Serialization;

namespace ManipulacaoArquivos.Models
{
    
    [XmlRoot(ElementName = "Dados")]
    public class DadosXml
    {
        [XmlElement(ElementName = "row")]
        public List<Row> Row { get; set; }
    }

    [XmlRoot(ElementName = "row")]
    public class Row
    {
        [XmlElement(ElementName = "dia")]
        public int Dia { get; set; }

        [XmlElement(ElementName = "valor")]
        public double Valor { get; set; }
    }
 
}
