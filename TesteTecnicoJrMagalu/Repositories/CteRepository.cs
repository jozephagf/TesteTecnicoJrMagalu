using TesteTecnicoJrMagalu.Database;
using TesteTecnicoJrMagalu.Interfaces;
using TesteTecnicoJrMagalu.Models;

namespace TesteTecnicoJrMagalu.Repositories
{
    public class CteRepository : ICTeRepository
    {
        private readonly ConnectionContext _context;// = new ConnectionContext();

        public CteRepository(ConnectionContext context)
        {
            _context = context;
        }

        public int Add(Cte cte)
        {
            _context.Add(cte);
            _context.SaveChanges();

            return cte.ID;
        }

        public Cte FindById(int id)
        {
            return _context.Cte.Where(w => w.ID == id).FirstOrDefault();
        }

        public List<Cte> Get()
        {
            return _context.Cte.ToList();
        }

    }
}
