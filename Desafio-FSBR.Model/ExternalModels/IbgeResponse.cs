namespace Desafio_FSBR.Model.ExternalModels;

public class UfResponse
{
    public int id { get; set; }
    public string nome { get; set; }
    public string sigla { get; set; }
    public Regiao regiao { get; set; }

}
public class Regiao
{
    public int id { get; set; }
    public string nome { get; set; }
    public string sigla { get; set; }
}
