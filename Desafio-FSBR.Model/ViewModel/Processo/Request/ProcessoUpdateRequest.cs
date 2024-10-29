using System.ComponentModel.DataAnnotations;

namespace Desafio_FSBR.Model.ViewModel.Processo.Request;

public class ProcessoUpdateRequest
{
    [Required]
    [StringLength(100)]
    public string NomeProcesso { get; set; }
    [Required]
    [RegularExpression(@"\d{7}-\d{2}.\d{4}.\d{1}.\d{2}.\d{4}", ErrorMessage = "NPU deve estar no formato 1111111-11.1111.1.11.1111")]
    public string NPU { get; set; }
    [Required]
    [StringLength(2)]
    public string UF { get; set; }
    [Required]
    public string Municipio { get; set; }
}
