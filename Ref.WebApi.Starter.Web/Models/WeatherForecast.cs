using System;

namespace Ref.WebApi.Starter.Web.Models
{
    [Obsolete("Serves only as an example")]
    public record WeatherForecast(DateTime Date, int TemperatureC, string Summary)
    {
        public int TemperatureF => 32 + (int) (TemperatureC / 0.5556);
    }
}