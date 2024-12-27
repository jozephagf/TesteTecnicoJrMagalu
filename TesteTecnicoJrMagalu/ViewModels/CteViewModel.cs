using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel;

namespace TesteTecnicoJrMagalu.ViewModels
{
    public class CteViewModel
    {
        /// <summary>
        /// Data início da operação
        /// </summary>
        /// <example>2024-12-24T20:19:32.453Z</example>
        public DateTime ide_dhEmi { get; set; }

        /// <summary>
        /// Código IBGE do Município de início da prestação
        /// </summary>
        /// <example>3516200</example>
        /// 
        [SwaggerSchema(Description = "Código IBGE do Munícipio de início da prestação", Title = "det_cMunIni")]
        public int det_cMunIni { get; set; }

        /// <summary>
        /// Código IBGE do Município de envio do CT-e
        /// </summary>
        /// <example>3516200</example>
        public int ide_cMunEnv { get; set; }

        /// <summary>
        /// Código IBGE do Município de término da prestação
        /// </summary>
        /// <example>3112406</example>
        [SwaggerSchema(Description = "My super duper data")]
        public int det_cMunFim { get; set; }

        /// <summary>
        /// Distância entre origem e destino em km
        /// </summary>
        /// <example>40</example>
        public decimal ide_dist_KM { get; set; }

        /// <summary>
        /// Informações da Carga do CT-e
        /// </summary>
        public InfCargaViewModel infCarga { get; set; }

        /// <summary>
        /// Valor do frete por tonelada
        /// </summary>
        /// <example>10</example>
        public decimal vFretePorTonelada {  get; set; }

        /// <summary>
        /// Valor das despesas adicionais, pedágios, custos de carregamento, descarregamento ou qualquer outra taxa extra que seja cobrada durante a operação
        /// </summary>
        /// <example>50</example>
        public decimal vOutrasDesp {  get; set; }

        /// <summary>
        /// Informações relativas aos impostos
        /// </summary>
        public ImpViewModel imp { get; set; }
    }
}
