using ManipulacaoArquivos.Models;

namespace ManipulacaoArquivos.Interfaces
{
    public interface IArquivoService
    {
        List<DadosJson> LerJson();
        DadosXml LerXml();
    }
}
