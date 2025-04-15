// IWeatherService.cs
// This interface defines the contract for a RESTful service that provides a 5-day weather forecast
// based on the provided ZIP code. The service fetches data from an external weather API.

using System.IO;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace WeatherService
{
    [ServiceContract]
    public interface IWeatherService
    {
        // Gets a 5-day weather forecast for a given ZIP code.
        //
        // Parameters:
        // zipcode (string): The ZIP code to get the weather forecast for.
        //
        // Returns:
        // Stream: A stream containing the weather forecast data.
        [OperationContract]
        [WebGet(UriTemplate = "/weather/zip/{zipcode}")]
        Stream GetWeatherByZip(string zipcode); // Method to fetch weather forecast by ZIP code
    }
}
