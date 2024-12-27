namespace TesteTecnicoJrMagalu.ViewModels
{
    public class ICMSViewModel
    {
        /// <summary>
        /// Classificação tributária do serviço
        /// </summary>
        /// <example>00</example>
        public string CST { get; set; }

        /// <summary>
        /// Alíquota do ICMS
        /// </summary>
        /// <example>12</example>
        public decimal pICMS { get; set; }
    }
}
