using System.ComponentModel.DataAnnotations;

namespace Desafio_FSBR.Model.ViewModel.Processo;

public class ProcessoUpdateRequest
{

    [StringLength(100)]
    public string? NomeProcesso { get; set; }
    public string? NPU { get; set; }
    [StringLength(2)]
    public string? UF { get; set; }
    public string? Municipio { get; set; }
}
