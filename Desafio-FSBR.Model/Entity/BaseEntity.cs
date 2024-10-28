namespace Desafio_FSBR.Model.Entity;


public abstract class BaseEntity
{
    protected BaseEntity()
    {
        DataCadastro = DateTime.Now;
        DelecaoLogica = false;
    }
    public int Id { get; set; }
    public DateTime DataCadastro { get; set; }
    public DateTime? DataAlteracao { get; set; }
    public bool DelecaoLogica { get; set; }
}


