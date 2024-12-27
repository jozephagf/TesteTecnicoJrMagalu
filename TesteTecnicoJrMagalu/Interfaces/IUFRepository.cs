using TesteTecnicoJrMagalu.Models;

namespace TesteTecnicoJrMagalu.Interfaces
{
    public interface IUFRepository
    {
        Task<List<UFIBGE?>> Get();
    }
}
