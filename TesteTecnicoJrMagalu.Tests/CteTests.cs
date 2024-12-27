using TesteTecnicoJrMagalu.Models;
using TesteTecnicoJrMagalu.Repositories;
using TesteTecnicoJrMagalu.Services;
using TesteTecnicoJrMagalu.Tests.Helpers;
using TesteTecnicoJrMagalu.ViewModels;

namespace TesteTecnicoJrMagalu.Tests
{
    public class CteTests
    {
        [Fact]
        public async void CreateCteBasedOnRequestBody_ShouldMustReturnValorForRequiredFields()
        {
            //Arrange
            CteViewModel cteView  = new CteViewModel();           

            cteView.ide_dhEmi = DateTime.Now;
            cteView.det_cMunIni = 3516200;
            cteView.ide_cMunEnv = 3516200;
            cteView.det_cMunFim = 3516200;
            cteView.ide_dist_KM = 0;
            cteView.vFretePorTonelada = 50;
            cteView.vOutrasDesp = 18;

            cteView.imp = new ImpViewModel();
            cteView.imp.ICMS = new ICMSViewModel();

            cteView.imp.ICMS.CST = "00";
            cteView.imp.ICMS.pICMS = 18;

            cteView.infCarga = new InfCargaViewModel();
            cteView.infCarga.InfQ = new List<InfQViewModel>();

            cteView.infCarga.InfQ.Add(new InfQViewModel() { infCarga_infQ_cUnid = "01", infCarga_infQ_tpMed = "02", infCarga_infQ_qCarga = 500 });
            cteView.infCarga.InfQ.Add(new InfQViewModel() { infCarga_infQ_cUnid = "00", infCarga_infQ_tpMed = "00", infCarga_infQ_qCarga = 5 });

            await using var context = new MockDb().CreateDbContext();
            
            //Act
            Cte cte = await CreateCTeBasedOnRequestBodyService.CreateCTeBasedOnRequestBody(cteView: cteView);
            List<CteInfCargaInfQ> cteInfCargaInfQs = CreateCTeInfCargaInfQBasedOnRequestBodyService.CreateCTeInfCargaInfQBasedOnRequestBody(cteView: cteView, id_cte: 1);

            //Assert
            Assert.NotEqual("", cte.det_xMunIni);
            Assert.NotEqual("", cte.ide_xMunEnv);
            Assert.NotEqual("", cte.det_xMunFim);
            Assert.NotEqual("", cte.ICMS_CST);
            Assert.False(cte.vFretePorTonelada <= 0);
            Assert.False(cte.vOutrasDesp < 0);
            Assert.False(cte.ide_dist_KM < 0);
            Assert.True(cte.ICMS_pICMS > 0);
            Assert.True(cte.ICMS_vICMS > 0 && cte.ICMS_pICMS > 0);
            Assert.True(cte.TOTALvCTe > 0);
            Assert.True(cte.TOTALvFrete > 0);
            Assert.True(cteInfCargaInfQs.Count >= 2);
        }

        [Fact]
        public async void AddCte_ShouldSaveCteOnDatabase()
        {
            
            CteViewModel cteView = new CteViewModel();

            cteView.ide_dhEmi = DateTime.Now;
            cteView.det_cMunIni = 3516200;
            cteView.ide_cMunEnv = 3516200;
            cteView.det_cMunFim = 3516200;
            cteView.ide_dist_KM = 0;
            cteView.vFretePorTonelada = 50;
            cteView.vOutrasDesp = 18;

            cteView.imp = new ImpViewModel();
            cteView.imp.ICMS = new ICMSViewModel();

            cteView.imp.ICMS.CST = "00";
            cteView.imp.ICMS.pICMS = 18;

            cteView.infCarga = new InfCargaViewModel();
            cteView.infCarga.InfQ = new List<InfQViewModel>();

            cteView.infCarga.InfQ.Add(new InfQViewModel() { infCarga_infQ_cUnid = "01", infCarga_infQ_tpMed = "02", infCarga_infQ_qCarga = 500 });
            cteView.infCarga.InfQ.Add(new InfQViewModel() { infCarga_infQ_cUnid = "00", infCarga_infQ_tpMed = "00", infCarga_infQ_qCarga = 5 });

            await using var context = new MockDb().CreateDbContext();

            Cte cte = await CreateCTeBasedOnRequestBodyService.CreateCTeBasedOnRequestBody(cteView: cteView);

            CteRepository cteRepository = new CteRepository(context);
            var result = cteRepository.Add(cte);

            Assert.True(result > 0);
        }

        [Fact]
        public async void AddCteInfCargaInfQ_ShouldSaveCteOnDatabase()
        {
            CteViewModel cteView = new CteViewModel();

            cteView.ide_dhEmi = DateTime.Now;
            cteView.det_cMunIni = 3516200;
            cteView.ide_cMunEnv = 3516200;
            cteView.det_cMunFim = 3516200;
            cteView.ide_dist_KM = 0;
            cteView.vFretePorTonelada = 50;
            cteView.vOutrasDesp = 18;

            cteView.imp = new ImpViewModel();
            cteView.imp.ICMS = new ICMSViewModel();

            cteView.imp.ICMS.CST = "00";
            cteView.imp.ICMS.pICMS = 18;

            cteView.infCarga = new InfCargaViewModel();
            cteView.infCarga.InfQ = new List<InfQViewModel>();

            cteView.infCarga.InfQ.Add(new InfQViewModel() { infCarga_infQ_cUnid = "01", infCarga_infQ_tpMed = "02", infCarga_infQ_qCarga = 500 });
            cteView.infCarga.InfQ.Add(new InfQViewModel() { infCarga_infQ_cUnid = "00", infCarga_infQ_tpMed = "00", infCarga_infQ_qCarga = 5 });

            await using var context = new MockDb().CreateDbContext();

            List<CteInfCargaInfQ> infQs =  CreateCTeInfCargaInfQBasedOnRequestBodyService.CreateCTeInfCargaInfQBasedOnRequestBody(cteView: cteView, id_cte: 1);

            int numberSaveChanges = 0;
            foreach(CteInfCargaInfQ infQ in infQs)
            {
                CteInfCargaInfQRepository cteInfCargaInfQRepository = new CteInfCargaInfQRepository(context);
                cteInfCargaInfQRepository.Add(infQ);

                if (infQ.id > 0)
                    numberSaveChanges++;
            }

            Assert.True(numberSaveChanges == infQs.Count);
        }
    }
}