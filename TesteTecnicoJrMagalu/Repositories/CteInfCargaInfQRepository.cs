using TesteTecnicoJrMagalu.Database;
using TesteTecnicoJrMagalu.Interfaces;
using TesteTecnicoJrMagalu.Models;

namespace TesteTecnicoJrMagalu.Repositories
{
    public class CteInfCargaInfQRepository : ICteInfCargaInfQRepository
    {

        private readonly ConnectionContext _context;

        public CteInfCargaInfQRepository(ConnectionContext context)
        {
            _context = context;
        }

        public int Add(CteInfCargaInfQ cargaInfCargaInfQ)
        {
            _context.Add(cargaInfCargaInfQ);
            _context.SaveChanges();

            return cargaInfCargaInfQ.id;
        }
    }
}
