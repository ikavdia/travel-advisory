// WeatherService.svc.cs
// This class implements the IWeatherService interface to provide a RESTful service
// for retrieving a 5-day weather forecast for a given ZIP code. It interacts with the
// OpenWeatherMap API to fetch data and formats it before returning the result.

using System;
using System.Net;
using System.Linq;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Text;
using System.ServiceModel.Web;
using System.IO;
using WeatherService;

namespace TravelBooking
{
    public class WeatherService : IWeatherService
    {
        // Retrieves and formats a 5-day weather forecast for the given ZIP code.
        //
        // Parameters:
        // zipcode (string): The ZIP code to get the weather forecast for.
        //
        // Returns:
        // Stream: A stream containing the formatted weather forecast.
        public Stream GetWeatherByZip(string zipcode)
        {
            try
            {   // OpenWeatherMap API configuration
                string apiKey = "f33a5637f3f73c83f0bd8d850720586e";
                string apiUrl = $"https://api.openweathermap.org/data/2.5/forecast?zip={zipcode},us&appid={apiKey}&units=metric";

                using (WebClient client = new WebClient())
                {   // Fetch and parse weather data
                    string jsonResponse = client.DownloadString(apiUrl);
                    JObject weatherData = JObject.Parse(jsonResponse);
                    JArray forecastList = (JArray)weatherData["list"];
                    // Build the result string with city info and current temperature
                    StringBuilder result = new StringBuilder();
                    result.AppendLine($"City: {weatherData["city"]["name"]}");
                    result.AppendLine($"Country: {weatherData["city"]["country"]}");
                    result.AppendLine($"Current Temperature: {forecastList[0]["main"]["temp"]}°C");
                    result.AppendLine();
                    result.AppendLine("5-Day Forecast:");
                    // Group forecast data by day and take the first 5 days
                    var groupedByDay = forecastList
                        .GroupBy(forecast => DateTime.Parse(forecast["dt_txt"].ToString()).Date)
                        .Take(5); // Ensure we only take 5 days
                    // Process and format the 5-day forecast data
                    foreach (var dayGroup in groupedByDay)
                    {   // Calculate min and max temperatures for the day
                        var minTemp = dayGroup.Min(f => (double)f["main"]["temp_min"]);
                        var maxTemp = dayGroup.Max(f => (double)f["main"]["temp_max"]);
                        var date = dayGroup.First()["dt_txt"].ToString().Substring(0, 10);
                        var weatherDescription = dayGroup.First()["weather"][0]["description"];
                        // Append daily forecast to the result
                        result.AppendLine($"Date: {date}");
                        result.AppendLine($"Min Temperature: {minTemp:F1}°C");
                        result.AppendLine($"Max Temperature: {maxTemp:F1}°C");
                        result.AppendLine($"Weather: {weatherDescription}");
                        result.AppendLine();
                    }
                    // Prepare and return the formatted output as a stream
                    string output = result.ToString();
                    WebOperationContext.Current.OutgoingResponse.ContentType = "text/plain";
                    return new MemoryStream(Encoding.UTF8.GetBytes(output));
                }
            }
            catch (Exception ex) // Handle and return any errors as a stream
            {
                string error = $"Error: {ex.Message}";
                WebOperationContext.Current.OutgoingResponse.ContentType = "text/plain";
                return new MemoryStream(Encoding.UTF8.GetBytes(error));
            }
        }
    }
}
