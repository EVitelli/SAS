using Senai.Sas.Infra.Data.Domains;

namespace Senai.Sas.Infra.Core.Persistence.Repositories
{
    public abstract class BaseRepository
    {
        protected readonly SasContext _context;

        public BaseRepository(SasContext context)
        {
            _context = context;
        }
    }
}
