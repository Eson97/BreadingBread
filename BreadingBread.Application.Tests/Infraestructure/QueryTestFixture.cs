
using BreadingBread.Persistence;
using System;
using Xunit;

namespace BreadingBread.Application.Tests.Infraestructure
{
    public class QueryTestFixture : IDisposable
    {
        public BreadingBreadDbContext Context { get; private set; }

        public QueryTestFixture()
        {
            Context = BreadingBreadDbContextFactory.Create();
        }

        public void Dispose()
        {
            BreadingBreadDbContextFactory.Destroy(Context);
        }
    }

    [CollectionDefinition("QueryCollection")]
    public class QueryCollection : ICollectionFixture<QueryTestFixture> { }
}
