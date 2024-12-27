using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TesteTecnicoJrMagalu.Database;
using TesteTecnicoJrMagalu.Interfaces;
using TesteTecnicoJrMagalu.Models;
using TesteTecnicoJrMagalu.Repositories;
using TesteTecnicoJrMagalu.Services;
using TesteTecnicoJrMagalu.ViewModels;

namespace TesteTecnicoJrMagalu.Controllers
{
    [Route("api/v1/cte")]
    [ApiController]
    public class CteController : ControllerBase
    {
        private readonly ICTeRepository _cTeRepository;
        private readonly ICteInfCargaInfQRepository _cteInfCargaInfQRepository;
        private readonly IMunicipioRepository _municipioRepository;

        private readonly ConnectionContext _context;

        public CteController(ICTeRepository cTeRepository, ICteInfCargaInfQRepository cteInfCargaInfQRepository, IMunicipioRepository municipioRepository, ConnectionContext context)
        {
            this._cTeRepository = cTeRepository ?? throw new ArgumentNullException(nameof(cTeRepository));
            this._cteInfCargaInfQRepository = cteInfCargaInfQRepository ?? throw new ArgumentNullException(nameof(cteInfCargaInfQRepository));
            this._municipioRepository = municipioRepository ?? throw new ArgumentNullException(nameof(municipioRepository)); ;
            this._context = context;
        }

        /// <summary>
        /// Obtém uma lista de todos os CTes.
        /// </summary>
        /// <returns>Uma coleção de CTes</returns>
        [HttpGet]        
        public IActionResult Index()
        {
            var cte = _cTeRepository.Get();
            return Ok(cte);
        }

        /// <summary>
        /// Obtém um CT-e específico pelo seu ID
        /// </summary>
        /// <param name="id">ID do CT-e a ser recuperado</param>
        /// <returns>O objeto Cte correspondente ao ID fornecido.</returns>
        [HttpGet("{id}")]
        public IActionResult FindById(int id)
        {
            var cte = _cTeRepository.FindById(id);

            return Ok(cte);
        }

        /// <summary>
        /// Criar novo CT-e
        /// </summary>
        /// <returns>Criação do CT-e</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     cUnid: 01 | 02 | 03 | 04 | 05 |
        ///     tpMed: 01 | 02 | 03 | 04 | 05 | 06 | 07 | 08 | 09 | 10 | 11 | 12 | 14 | 15 | 99 |
        ///     cMunIni: utilizar Código IBGE do Município de início da prestação.
        ///     cMunEnv: utilizar Código IBGE do Município de envio do CT-e.
        ///     cMunFim: utilizar Código IBGE do Município do términio da prestação.
        ///     
        ///     POST /api/v1/cte
        ///     {
        ///         "ide_dhEmi": "2024-12-24T17:50:04.483Z",
        ///         "det_cMunIni": 3516200,
        ///         "ide_cMunEnv": 3516200,
        ///         "det_cMunFim": 3112406,
        ///         "ide_dist_KM": 40,
        ///         "vFretePorTonelada": 50,
        ///         "vOutrasDesp": 18,  
        ///         "imp": {
        ///         "ICMS": {
        ///         	"CST": "00",
        ///         	"pICMS": 12
        ///         }
        ///         },  
        ///         "infCarga": {
        ///           "infQ": [
        ///             {
        ///               "infCarga_infQ_cUnid": "Verificar no campo cUnid da nota técnica do CT-e simplificado",
        ///               "infCarga_infQ_tpMed": "Verificar no campo tpMed da nota técnica do CT-e simplificado",
        ///               "infCarga_infQ_qCarga": 500
        ///             },
        ///             {
        ///               "infCarga_infQ_cUnid": "00",
        ///               "infCarga_infQ_tpMed": "00",
        ///               "infCarga_infQ_qCarga": 5
        ///             }
        ///           ]
        ///         }
        ///     }
        ///
        /// </remarks>
        /// <response code="200">Sucesso</response>
        /// <response code="400">{ type = "Add CT-e", message = "Código de munícipio de envio do CT-e não informado." }</response>
        [HttpPost]
        public async Task<IActionResult> Add(CteViewModel cteView)
        {
            try
            {
                if (cteView.det_cMunIni == 0)
                    throw new Exception("Código de município inicial da prestação não informado.");

                if (cteView.ide_cMunEnv == 0)
                    throw new Exception("Código de município de envio do CT-e não informado.");

                if (cteView.det_cMunFim == 0)
                    throw new Exception("Código de município final da prestação não informado.");

                if (cteView.ide_dist_KM == 0)
                    throw new Exception("A distância em KM não foi informada.");

                if (cteView.vFretePorTonelada <= 0)
                    throw new Exception("O valor do frete por tonelada deve ser maior que zero.");


                Cte cte = await CreateCTeBasedOnRequestBodyService.CreateCTeBasedOnRequestBody(cteView: cteView);                
                
                _cTeRepository.Add(cte);

                List<CteInfCargaInfQ> cteInfCargaInfQs = CreateCTeInfCargaInfQBasedOnRequestBodyService.CreateCTeInfCargaInfQBasedOnRequestBody(cteView: cteView, id_cte: cte.ID);
                foreach (var infQ in cteInfCargaInfQs)
                {
                    _cteInfCargaInfQRepository.Add(infQ);
                }

                return Ok();
            } catch(Exception ex)
            {
                return BadRequest(new { type = "Add CT-e", message = ex.Message });
            }
            
        }
    }
}
