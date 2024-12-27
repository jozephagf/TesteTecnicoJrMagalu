using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteTecnicoJrMagalu.Controllers;
using TesteTecnicoJrMagalu.Repositories;

namespace TesteTecnicoJrMagalu.Tests
{
    public class MunicipioTests
    {
        [Fact]
        public async void FindById_ShouldReturnCityWithSameId()
        {
            MunicipioRepository municipioRepository = new MunicipioRepository();
         
            //Instancia a função de consultar municipio por ID que criamos na nossa API, para isso como parametro, é necessário informar o repository com a função de consulta
            var controller = new MunicipioController(municipioRepository);

            //Informamos um ID válido do IBGE
            string id = "3516200";

            //Consultamos na nossa API
            var result = await controller.FindById(id);

            //Deverá retornar algum valor diferente de nulo com o Http 200
            Assert.NotNull(result);
            Assert.IsType<OkObjectResult>(result);
        }
    }
}
