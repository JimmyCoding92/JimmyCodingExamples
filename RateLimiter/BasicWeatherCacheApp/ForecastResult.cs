namespace BasicWeatherCacheApp
{
    public class ForecastResult
    {
        public long ElapsedTime { get; }
        public IEnumerable<WeatherForecast> Forecasts { get; }

        public ForecastResult(IEnumerable<WeatherForecast> forecasts, long elapsedTime)
        {
            Forecasts = forecasts;
            ElapsedTime = elapsedTime;
        }
    }
}
