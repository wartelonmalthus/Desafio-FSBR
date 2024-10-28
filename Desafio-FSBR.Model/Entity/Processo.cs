using System.ComponentModel.DataAnnotations;

namespace Desafio_FSBR.Model.Entity;

public class Processo : BaseEntity
{
    [Required]
    [StringLength(100)]
    public string NomeProcesso { get; set; }

    [Required]
    [RegularExpression(@"\d{7}-\d{2}.\d{4}.\d{1}.\d{2}.\d{4}", ErrorMessage = "NPU deve estar no formato 1111111-11.1111.1.11.1111")]
    public string NPU { get; set; }

    [Required]
    public DateTime DataCadastro { get; set; }

    public DateTime? DataVisualizacao { get; set; }

    [Required]
    [StringLength(2)]
    public string UF { get; set; }

    [Required]
    public string Municipio { get; set; }

    public int MunicipioCodigo { get; set; } // Código do município da API do IBGE
}
