using System;
using System.IO;
using System.Net;
using System.Text;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.ServiceModel.Web;
using FlightService;

namespace TravelBooking
{
    public class FlightService : IFlightService
    {
        private string GetAmadeusAccessToken()
        {
            try
            {
                string tokenUrl = "https://test.api.amadeus.com/v1/security/oauth2/token";
                string apiKey = "POCiVeNAx4Y8LQskLFevtHPc0JfWDNSw"; // Replace with your actual API key
                string apiSecret = "8ZDTsXQ4nczi76Rx"; // Replace with your actual API secret

                using (var client = new WebClient())
                {
                    client.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
                    var requestBody = $"grant_type=client_credentials&client_id={apiKey}&client_secret={apiSecret}";
                    var response = client.UploadString(tokenUrl, requestBody);

                    var tokenData = JObject.Parse(response);
                    return tokenData["access_token"]?.ToString() ?? throw new Exception("Access token missing in response.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error fetching Amadeus access token: {ex.Message}");
            }
        }

        public Stream GetFlights(string origin, string destination, string travelDate)
        {
            try
            {
                // Get the access token for Amadeus API
                string accessToken = GetAmadeusAccessToken();
                string apiUrl = "https://test.api.amadeus.com/v2/shopping/flight-offers";

                using (var client = new WebClient())
                {
                    // Set headers
                    client.Headers.Add("Authorization", $"Bearer {accessToken}");
                    client.Headers.Add(HttpRequestHeader.ContentType, "application/json");
                    client.Headers.Add("X-HTTP-Method-Override", "GET");

                    // Create the JSON request body
                    var requestBody = new
                    {
                        currencyCode = "USD",
                        originDestinations = new[]
                        {
                            new
                            {
                                id = "1",
                                originLocationCode = origin,
                                destinationLocationCode = destination,
                                departureDateTimeRange = new
                                {
                                    date = travelDate
                                }
                            }
                        },
                        travelers = new[]
                        {
                            new
                            {
                                id = "1",
                                travelerType = "ADULT"
                            }
                        },
                        sources = new[] { "GDS" },
                        searchCriteria = new
                        {
                            maxFlightOffers = 10
                        }
                    };

                    // Serialize the body to JSON
                    string jsonRequestBody = JsonConvert.SerializeObject(requestBody);

                    // Make the POST request
                    string jsonResponse = client.UploadString(apiUrl, jsonRequestBody);
                    JObject flightData = JObject.Parse(jsonResponse);

                    // Prepare response string
                    StringBuilder result = new StringBuilder();
                    result.AppendLine("Flight Offers:");
                    var flightOffers = flightData["data"];
                    if (flightOffers == null)
                    {
                        result.AppendLine("No flights found.");
                    }
                    else
                    {
                        foreach (var offer in flightOffers)
                        {
                            string price = offer["price"]["total"]?.ToString();
                            var segment = offer["itineraries"][0]["segments"][0];

                            string departure = segment["departure"]["iataCode"]?.ToString();
                            string arrival = segment["arrival"]["iataCode"]?.ToString();
                            string departureTime = segment["departure"]["at"]?.ToString();
                            string arrivalTime = segment["arrival"]["at"]?.ToString();
                            string airline = segment["carrierCode"]?.ToString();
                            string flightNumber = segment["number"]?.ToString();

                            // Ensure we only include flights that match the requested route
                            if (departure == origin && arrival == destination)
                            {
                                result.AppendLine($"Price: {price} USD");
                                result.AppendLine($"Airline: {airline}");
                                result.AppendLine($"Flight Number: {flightNumber}");
                                result.AppendLine($"From: {departure} to {arrival}");
                                result.AppendLine($"Departure Time: {departureTime}");
                                result.AppendLine($"Arrival Time: {arrivalTime}");
                                result.AppendLine();
                            }
                        }
                    }

                    WebOperationContext.Current.OutgoingResponse.ContentType = "text/plain";
                    return new MemoryStream(Encoding.UTF8.GetBytes(result.ToString()));
                }
            }
            catch (Exception ex)
            {
                string error = $"Error: {ex.Message}";
                WebOperationContext.Current.OutgoingResponse.ContentType = "text/plain";
                return new MemoryStream(Encoding.UTF8.GetBytes(error));
            }
        }
    }
}
