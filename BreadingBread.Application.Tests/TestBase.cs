using BreadingBread.Application.Tests.Infraestructure;
using System;

namespace BreadingBread.Application.Tests
{
    public class TestBase : IDisposable
    {
        protected readonly Persistence.BreadingBreadDbContext context;
        public TestBase()
        {
            context = BreadingBreadDbContextFactory.Create();
        }

        public void Dispose()
        {
            BreadingBreadDbContextFactory.Destroy(context);
        }
    }
}
