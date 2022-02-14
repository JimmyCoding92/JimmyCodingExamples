namespace BasicWeatherCacheApp
{
    public static class SlidingWindowRateLimiterExtensions
    {
        public static void UseSlidingWindowRateLimiter(this IApplicationBuilder builder)
        {
            builder.UseMiddleware<SlidingWindowRateLimiter>();
        }
    }
}
