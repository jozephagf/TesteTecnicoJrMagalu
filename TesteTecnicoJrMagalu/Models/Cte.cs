using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TesteTecnicoJrMagalu.Models
{    public class Cte
    {
        [Key]
        public int ID { get; set; }

        public int? det_cMunIni { get; set; }

        public string? det_xMunIni { get; set; }

        public  string? ide_UFIni { get; set; }

        public int ide_cMunEnv { get; set; }

        public string? ide_xMunEnv { get; set; }

        public int det_cMunFim { get; set; }

        public string? det_xMunFim { get; set; }

        public string? ide_UFFim { get; set; }

        public DateTime ide_dhEmi { get; set; }

        public decimal ide_dist_KM { get; set; }
              
        public decimal vFretePorTonelada {  get; set; }

        public decimal vOutrasDesp { get; set; }

        public decimal TOTALvFrete { get; set; }

        public string ICMS_CST { get; set; }

        public decimal ICMS_vBC {  get; set; }

        public decimal ICMS_pICMS { get; set; }

        public decimal ICMS_vICMS {  get; set; }

        public decimal TOTALvCTe {  get; set; }

    }
}
