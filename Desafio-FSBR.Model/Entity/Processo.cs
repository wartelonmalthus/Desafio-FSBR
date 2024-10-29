namespace Desafio_FSBR.Model.Entity;

public class Processo : BaseEntity
{
    public string NomeProcesso { get; set; }
    public string NPU { get; set; }
    public string UF { get; set; }
    public string Municipio { get; set; }
    public DateTime? DataVisualizacao{ get; set; }
}
