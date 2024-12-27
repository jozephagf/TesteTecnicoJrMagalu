using Microsoft.AspNetCore.Connections;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteTecnicoJrMagalu.Tests.Helpers
{
    class MockDb : IDbContextFactory<TesteTecnicoJrMagalu.Database.ConnectionContext>
    {
        public TesteTecnicoJrMagalu.Database.ConnectionContext CreateDbContext()
        {
            var options = new DbContextOptionsBuilder<TesteTecnicoJrMagalu.Database.ConnectionContext>()
                .UseInMemoryDatabase($"InMemoryTestDb-{DateTime.Now.ToFileTimeUtc()}")
                .Options;

            return new TesteTecnicoJrMagalu.Database.ConnectionContext(options);
        }

    }
}
