using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TesteTecnicoJrMagalu.Interfaces;
using TesteTecnicoJrMagalu.Models;

namespace TesteTecnicoJrMagalu.Controllers
{
    [Route("api/v1/municipios")]
    [ApiController]
    public class MunicipioController : ControllerBase
    {
        private readonly IMunicipioRepository _municipioRepository;

        public MunicipioController(IMunicipioRepository municipioRepository)
        {
            _municipioRepository = municipioRepository ?? throw new ArgumentNullException(nameof(municipioRepository));
        }

        //[HttpGet]
        //public async Task<IActionResult> Index()
        //{
        //    List<MunicipioIBGE> cidades = await this._municipioRepository.Get();

        //    return Ok(cidades);
        //}

        /// <summary>
        /// Obtém informações sobre um município pelo seu código IBGE.
        /// </summary>
        /// <param name="id">Código IBGE do município.</param>
        /// <returns>200 (OK): Retorna um objeto `MunicipioIBGE` com as informações do município.</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> FindById(string id)
        {
            MunicipioIBGE cidade = await this._municipioRepository.FindById(id);

            return Ok(cidade);
        }
    }
}
