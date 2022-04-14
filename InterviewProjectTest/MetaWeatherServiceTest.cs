using Xunit;
using InterviewProject.Services;

namespace InterviewProjectTest
{
    public class MetaWeatherServiceTest
    {
        [Theory(DisplayName = "Get Locations")]
        [InlineData("london", 44418)]
        public async void GetLocations_One(string city, int expectedResult)
        {
            // 1. Arrange     
            MetaWeatherService metaService = new MetaWeatherService();

            // 2. Act 
            var result = await metaService.GetLocations(city);

            // 3. Assert 
            Assert.Equal(expectedResult, result[0].Woeid);
        }

        [Theory(DisplayName = "Get Locations")]
        [InlineData("san", 11)]
        public async void GetLocations_Mutiple(string city, int expectedResult)
        {
            // 1. Arrange     
            MetaWeatherService metaService = new MetaWeatherService();

            // 2. Act 
            var result = await metaService.GetLocations(city);

            // 3. Assert 
            Assert.Equal(expectedResult, result.Count);
        }

        [Theory(DisplayName = "Get Locations")]
        [InlineData("", 0)]
        [InlineData(null, 0)]
        public async void GetLocations_EmptyOrNull(string city, int expectedResult)
        {
            // 1. Arrange     
            MetaWeatherService metaService = new MetaWeatherService();

            // 2. Act 
            var result = await metaService.GetLocations(city);

            // 3. Assert 
            Assert.Equal(expectedResult, result.Count);
        }

        [Theory(DisplayName = "Get Weather")]
        [InlineData(44418, 6)]
        [InlineData(2487956, 6)]
        public async void GetWeather(int woeid, int expectedResult)
        {
            // 1. Arrange     
            MetaWeatherService metaService = new MetaWeatherService();

            // 2. Act 
            var result = await metaService.GetWeather(woeid);

            // 3. Assert 
            Assert.Equal(expectedResult, result.Count);
        }


        [Theory(DisplayName = "Get Weather")]
        [InlineData(0, 0)]
        [InlineData(-1, 0)]
        public async void GetWeather_ZeroOrMines(int woeid, int expectedResult)
        {
            // 1. Arrange     
            MetaWeatherService metaService = new MetaWeatherService();

            // 2. Act 
            var result = await metaService.GetWeather(woeid);

            // 3. Assert 
            Assert.Equal(expectedResult, result.Count);
        }

    }
}

