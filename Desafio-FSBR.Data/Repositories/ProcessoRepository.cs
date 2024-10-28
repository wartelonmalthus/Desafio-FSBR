using Desafio_FSBR.Data.Context;
using Desafio_FSBR.Data.Interfaces;
using Desafio_FSBR.Model.Entity;

namespace Desafio_FSBR.Data.Repositories;

public class ProcessoRepository(ApplicationDbContext context) : BaseRepository<Processo>(context), IProcessoRepository
{
}
