using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TesteTecnicoJrMagalu.Models
{
    public class CteInfCargaInfQ
    {
        [Key]
        public int id { get; set; }

        [ForeignKey(nameof(Cte))]
        public int id_cte { get; set; }
        public string? infCarga_infQ_cUnid { get; set; }

        public string? infCarga_infQ_tpMed { get; set; }

        public decimal? infCarga_infQ_qCarga { get; set; }

    }
}
