using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TesteTecnicoJrMagalu.Interfaces;
using TesteTecnicoJrMagalu.Models;
using TesteTecnicoJrMagalu.Repositories;

namespace TesteTecnicoJrMagalu.Controllers
{
    [Route("api/v1/uf")]
    [ApiController]
    public class UFController : ControllerBase
    {

        private readonly IUFRepository _ufRepository;

        public UFController(IUFRepository ufRepository)
        {
            _ufRepository = ufRepository ?? throw new ArgumentNullException(nameof(ufRepository));
        }

        /// <summary>
        /// Obtém uma lista de todas as unidades federativas brasileiras.
        /// </summary>
        /// <returns>Uma lista de objetos UFIBGE representando os estados.</returns>
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<UFIBGE> estados = await this._ufRepository.Get();

            return Ok(estados);
        }
        
    }
}
