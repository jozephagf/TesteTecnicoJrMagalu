using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteTecnicoJrMagalu.Controllers;
using TesteTecnicoJrMagalu.Models;
using TesteTecnicoJrMagalu.Repositories;

namespace TesteTecnicoJrMagalu.Tests
{
    public class UFTests
    {
        [Fact]
        public async void IndexUF_ReturnAllUFs()
        {
            UFRepository repository = new UFRepository();

            var controller = new UFController(repository);
            var result = await controller.Index();

            Assert.NotNull(result);
            Assert.IsType<OkObjectResult>(result);
        }
    }
}
