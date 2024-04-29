using Application.Common.Mappings;
using AutoMapper;
using Xunit;

namespace Application.UnitTests.Core
{
    public class QueryTestFixture
    {        
        public IMapper Mapper { get; private set; }

        public QueryTestFixture()
        {            

            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            Mapper = configurationProvider.CreateMapper();
        }
    }

    [CollectionDefinition(nameof(QueryCollection))]
    public class QueryCollection : ICollectionFixture<QueryTestFixture> { }
}
