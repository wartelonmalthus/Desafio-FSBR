namespace Desafio_FSBR.Model.ViewModel.Processo;

public class ProcessoDetailsViewModel
{
    public ProcessoDetailsViewModel()
    {
        DataVisualizacao = DateTime.Now;
    }
    public int Id { get; set; }
    public string NomeProcesso { get; set; }
    public string NPU { get; set; }
    public string UF { get; set; }
    public string Municipio { get; set; }
    public DateTime DataCadastro { get; set; }
    public DateTime? DataVisualizacao { get; set; }
    public DateTime? DataAlteracao { get; set; }
}
