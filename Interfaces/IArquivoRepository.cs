using ManipulacaoArquivos.Models;

namespace ManipulacaoArquivos.Interfaces
{
    public interface IArquivoRepository
    {
        void SalvarDadosJson(List<DadosJson> dados);
        void SalvarDadosXml(DadosXml dados);
    }
}
