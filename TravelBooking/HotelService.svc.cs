using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.IO;
using System.Net;
using Newtonsoft.Json.Linq;
using System.ServiceModel.Web;

namespace TravelBooking
{
    public class HotelService : IHotelService
    {
        private string GetAmadeusAccessToken()
        {
            try
            {
                string tokenUrl = "https://test.api.amadeus.com/v1/security/oauth2/token";
                string apiKey = "PZWxSlcL66qhKxBgJRax9EWhzBIFKkIL"; 
                string apiSecret = "oic4O09XjxOh6ghh"; 

                using (var client = new WebClient())
                {
                    client.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
                    var requestBody = $"grant_type=client_credentials&client_id={apiKey}&client_secret={apiSecret}";
                    var response = client.UploadString(tokenUrl, requestBody);

                    var tokenData = JObject.Parse(response);
                    return tokenData["access_token"].ToString();
                }
            }
            catch (Exception ex)
            {
                throw new WebFaultException<string>($"Error obtaining access token: {ex.Message}", HttpStatusCode.InternalServerError);
            }
        }

        public string GetHotelsByCity(string cityCode)
        {
            try
            {
                string accessToken = GetAmadeusAccessToken();
                string apiUrl = $"https://test.api.amadeus.com/v1/reference-data/locations/hotels/by-city?cityCode={cityCode}";

                using (var client = new WebClient())
                {
                    client.Headers[HttpRequestHeader.Authorization] = $"Bearer {accessToken}";
                    string jsonResponse = client.DownloadString(apiUrl);
                    JObject hotelData = JObject.Parse(jsonResponse);

                    // Prepare response string
                    StringBuilder result = new StringBuilder();
                    result.AppendLine("Hotel List:");

                    var hotels = hotelData["data"];
                    if (hotels == null)
                    {
                        result.AppendLine("No hotels found.");
                    }
                    else
                    {
                        foreach (var hotel in hotels)
                        {
                            string name = hotel["name"]?.ToString() ?? "N/A";
                            string address = hotel["address"]?["countryCode"]?.ToString() ?? "N/A";
                            string latitude = hotel["geoCode"]?["latitude"]?.ToString() ?? "N/A";
                            string longitude = hotel["geoCode"]?["longitude"]?.ToString() ?? "N/A";

                            result.AppendLine($"Name: {name}");
                            result.AppendLine($"Address: {address}");
                            result.AppendLine($"Location: {latitude}, {longitude}");
                            result.AppendLine();
                        }
                    }

                    return result.ToString();
                }
            }
            catch (Exception ex)
            {
                throw new WebFaultException<string>($"Error fetching hotels: {ex.Message}", HttpStatusCode.InternalServerError);
            }
        }

    }
}