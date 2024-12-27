using TesteTecnicoJrMagalu.Models;

namespace TesteTecnicoJrMagalu.Interfaces
{
    public interface IMunicipioRepository
    {
        Task<List<MunicipioIBGE>> Get();

        Task<MunicipioIBGE> FindById(string id);

    }
}
