using TesteTecnicoJrMagalu.Models;

namespace TesteTecnicoJrMagalu.Interfaces
{
    public interface ICTeRepository
    {
        public int Add(Cte cte);

        public List<Cte> Get();

        public Cte FindById(int id);
    }
}
