using ManipulacaoArquivos.Interfaces;
using ManipulacaoArquivos.Models;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Xml.Serialization;

namespace ManipulacaoArquivos.Repositories
{
    public class ArquivoRepository : IArquivoRepository
    {
        private readonly ArquivosConfig _arquivosConfig;

        public ArquivoRepository(IOptions<ArquivosConfig> arquivosConfig)
        {
            _arquivosConfig = arquivosConfig.Value ?? throw new ArgumentNullException(nameof(arquivosConfig));
        }

        public void SalvarDadosJson(List<DadosJson> dados)
        {
            var json = JsonConvert.SerializeObject(dados, Formatting.Indented);
            File.WriteAllText(_arquivosConfig.CaminhoJson, json);
        }

        public void SalvarDadosXml(DadosXml dados)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(DadosXml));

            using (var writer = new StreamWriter(_arquivosConfig.CaminhoXml))
            {
                serializer.Serialize(writer, dados);
            }
        }
    }
}
