using API.AutoMapper;
using Xunit;

namespace Tests.Unit.API.AutoMapper
{
    public class AutoMapperConfigTests
    {
        [Fact]
        public void should_assert_configuration_as_valid()
        {
            var config = AutoMapperConfig.RegisterMappings();

            config.AssertConfigurationIsValid();
        }
    }
}