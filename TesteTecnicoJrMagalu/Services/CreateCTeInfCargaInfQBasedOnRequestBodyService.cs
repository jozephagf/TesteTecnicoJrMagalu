using TesteTecnicoJrMagalu.Models;
using TesteTecnicoJrMagalu.ViewModels;

namespace TesteTecnicoJrMagalu.Services
{
    public static class CreateCTeInfCargaInfQBasedOnRequestBodyService
    {
        public static List<CteInfCargaInfQ> CreateCTeInfCargaInfQBasedOnRequestBody(CteViewModel cteView, int id_cte)
        {
            List<CteInfCargaInfQ> cteInfCargaInfQs = new List<CteInfCargaInfQ>();

            foreach(var infQ in cteView.infCarga.InfQ)
            {
                CteInfCargaInfQ infCargaInfQ = new CteInfCargaInfQ();
                infCargaInfQ.infCarga_infQ_tpMed = infQ.infCarga_infQ_tpMed;
                infCargaInfQ.infCarga_infQ_qCarga = infQ.infCarga_infQ_qCarga;
                infCargaInfQ.infCarga_infQ_cUnid = infQ.infCarga_infQ_cUnid;
                infCargaInfQ.id_cte = id_cte;

                cteInfCargaInfQs.Add(infCargaInfQ);
            }

            return cteInfCargaInfQs;
        }
    }
}
