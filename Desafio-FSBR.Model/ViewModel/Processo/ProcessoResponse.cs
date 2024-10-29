namespace Desafio_FSBR.Model.ViewModel.Processo;

public class ProcessoResponse
{
    public int Id { get; set; }
    public string NomeProcesso { get; set; }
    public string NPU { get; set; }
    public string UF { get; set; }
    public string Municipio { get; set; }
    public int MunicipioCodigo { get; set; }
    public DateTime DataCadastro { get; set; }
}
