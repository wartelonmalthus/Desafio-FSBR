namespace Desafio_FSBR.Model.Entity;


public abstract class BaseEntity
{
    protected BaseEntity()
    {
        CreateAt = DateTime.Now;
        SoftDelete = false;
    }
    public int Id { get; set; }
    public DateTime CreateAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public bool SoftDelete { get; set; }
}


