using TesteTecnicoJrMagalu.Interfaces;
using TesteTecnicoJrMagalu.Models;
using TesteTecnicoJrMagalu.Repositories;
using TesteTecnicoJrMagalu.ViewModels;

namespace TesteTecnicoJrMagalu.Services
{
    public static class CreateCTeBasedOnRequestBodyService
    {
        public async static Task<Cte> CreateCTeBasedOnRequestBody(CteViewModel cteView)
        {
            Cte cte = new Cte();
            MunicipioRepository municipioRepository = new MunicipioRepository();

            MunicipioIBGE det_MunIni = await municipioRepository.FindById(id: cteView.det_cMunIni.ToString());
            MunicipioIBGE ide_MunEnv = await municipioRepository.FindById(id: cteView.ide_cMunEnv.ToString());
            MunicipioIBGE det_MunFim = await municipioRepository.FindById(id: cteView.det_cMunFim.ToString());

            cte.det_cMunIni = cteView.det_cMunIni;

            cte.det_xMunIni = det_MunIni.nome;
            cte.ide_UFIni = det_MunIni.microrregiao.mesorregiao.uf.sigla;

            cte.ide_cMunEnv = cteView.ide_cMunEnv;
            cte.ide_xMunEnv = ide_MunEnv.nome;

            cte.det_cMunFim = cteView.det_cMunFim;
            cte.det_xMunFim = det_MunFim.nome;
            cte.ide_UFFim = det_MunFim.microrregiao.mesorregiao.uf.sigla;

            cte.ide_dhEmi = cteView.ide_dhEmi;
            cte.ide_dist_KM = cteView.ide_dist_KM;

            cte.vFretePorTonelada = cteView.vFretePorTonelada;
            cte.vOutrasDesp = cteView.vOutrasDesp;

            decimal toneladas = 0;
            InfQViewModel infQ_Peso = cteView.infCarga?.InfQ?.Where(w => w?.infCarga_infQ_cUnid == "01" || w?.infCarga_infQ_cUnid == "02").FirstOrDefault();
            if (infQ_Peso?.infCarga_infQ_cUnid == "01") //KG - precisa converter
            {
                toneladas = infQ_Peso.infCarga_infQ_qCarga / 1000;
            }
            else
            {
                toneladas = infQ_Peso.infCarga_infQ_qCarga;
            }
            cte.TOTALvFrete = cte.vOutrasDesp + (cte.vFretePorTonelada * toneladas);

            cte.ICMS_CST = cteView.imp.ICMS.CST;
            cte.ICMS_pICMS = cteView.imp.ICMS.pICMS;

            cte.ICMS_vBC = cte.TOTALvFrete / ((100 - cte.ICMS_pICMS) / 100);
            cte.ICMS_vICMS = cte.ICMS_vBC * (cte.ICMS_pICMS / 100);

            cte.TOTALvCTe = cte.TOTALvFrete + cte.ICMS_vICMS;

            return cte;
        }
    }
}
