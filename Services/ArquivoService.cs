using ManipulacaoArquivos.Interfaces;
using ManipulacaoArquivos.Models;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Xml.Serialization;

namespace ManipulacaoArquivos.Services
{
    public class ArquivoService : IArquivoService
    {
        private readonly ArquivosConfig _arquivosConfig;
        private readonly ILogger<ArquivoService> _logger;

        public ArquivoService(IOptions<ArquivosConfig> arquivosConfig, ILogger<ArquivoService> logger)
        {
            _arquivosConfig = arquivosConfig.Value ?? throw new ArgumentNullException(nameof(arquivosConfig));
            _logger = logger;

            if (string.IsNullOrWhiteSpace(_arquivosConfig.CaminhoJson) || !File.Exists(_arquivosConfig.CaminhoJson))
            {
                throw new FileNotFoundException($"O arquivo JSON não foi encontrado: {_arquivosConfig.CaminhoJson}");
            }

            if (string.IsNullOrWhiteSpace(_arquivosConfig.CaminhoXml) || !File.Exists(_arquivosConfig.CaminhoXml))
            {
                throw new FileNotFoundException($"O arquivo XML não foi encontrado: {_arquivosConfig.CaminhoXml}");
            }
        }

        public List<DadosJson> LerJson()
        {
            try
            {
                string json = File.ReadAllText(_arquivosConfig.CaminhoJson);
                return JsonConvert.DeserializeObject<List<DadosJson>>(json);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro ao ler o arquivo JSON: {ex.Message}");
                throw;
            }
        }

        public DadosXml LerXml()
        {
            try
            {
                if (!File.Exists(_arquivosConfig.CaminhoXml))
                    throw new FileNotFoundException($"Arquivo XML não encontrado: {_arquivosConfig.CaminhoXml}");

                string xml = File.ReadAllText(_arquivosConfig.CaminhoXml);

                XmlSerializer serializer = new XmlSerializer(typeof(DadosXml));
                using (StringReader reader = new StringReader(xml))
                {
                    return (DadosXml)serializer.Deserialize(reader);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro ao ler o arquivo XML: {ex.Message}");
                throw;
            }
        }
    }
}
