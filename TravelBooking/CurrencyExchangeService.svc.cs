// CurrencyExchangeService.svc.cs
// This class implements the ICurrencyExchangeService interface to provide a RESTful service
// for retrieving currency exchange rates and listing available currencies. It fetches data
// from external APIs and returns results in JSON format.

using System;
using System.IO;
using System.Net;
using Newtonsoft.Json.Linq;
using CurrencyExchangeService;

namespace TravelBooking
{
    // This class implements the ICurrencyExchangeService interface to provide
    // currency exchange rates and available currencies information.
    public class CurrencyExchangeService : ICurrencyExchangeService
    {
        private string primaryApiUrl = "https://cdn.jsdelivr.net/npm/@fawazahmed0/currency-api@latest/v1/currencies";
        private string fallbackApiUrl = "https://latest.currency-api.pages.dev/v1/currencies";
        // Retrieves the exchange rate between two currencies.
        public string GetExchangeRate(string fromCurrency, string toCurrency)
        {
            try
            {
                // Attempt to fetch data from primary API
                string apiUrl = $"{primaryApiUrl}/{fromCurrency}.json";
                string jsonResponse = FetchApiResponse(apiUrl);

                // If the response is valid, extract the specific rate from the JSON data
                if (!string.IsNullOrEmpty(jsonResponse))
                {
                    // Parse the JSON response
                    JObject data = JObject.Parse(jsonResponse);

                    // Check if the target currency exists in the response
                    if (data[fromCurrency] != null && data[fromCurrency][toCurrency] != null)
                    {
                        // Extract and return the exchange rate
                        return data[fromCurrency][toCurrency].ToString();
                    }
                    else
                    {
                        return $"Error: Exchange rate from {fromCurrency} to {toCurrency} not found.";
                    }
                }

                // If the primary API fails, attempt the fallback
                apiUrl = $"{fallbackApiUrl}/{fromCurrency}.json";
                jsonResponse = FetchApiResponse(apiUrl);

                if (!string.IsNullOrEmpty(jsonResponse))
                {
                    // Parse the JSON response and extract the exchange rate
                    JObject data = JObject.Parse(jsonResponse);
                    if (data[fromCurrency] != null && data[fromCurrency][toCurrency] != null)
                    {
                        return data[fromCurrency][toCurrency].ToString();
                    }
                    else
                    {
                        return $"Error: Exchange rate from {fromCurrency} to {toCurrency} not found.";
                    }
                }

                return "Error: Unable to retrieve exchange rates from both primary and fallback APIs.";
            }
            catch (Exception ex)
            {
                return $"Error: {ex.Message}";
            }
        }
        // Retrieves a list of all available currencies.
        public string GetAvailableCurrencies()
        {
            try
            {
                // Fetch list of currencies from primary API
                string apiUrl = $"{primaryApiUrl}.json";
                string jsonResponse = FetchApiResponse(apiUrl);

                // If primary fails, use the fallback URL
                if (string.IsNullOrEmpty(jsonResponse))
                {
                    apiUrl = $"{fallbackApiUrl}.json";
                    return FetchApiResponse(apiUrl);
                }

                return jsonResponse;
            }
            catch (Exception ex)
            {
                return $"Error: {ex.Message}";
            }
        }
        // Helper method to fetch API response
        private string FetchApiResponse(string url)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "GET";

                using (WebResponse response = request.GetResponse())
                {
                    using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                    {
                        return reader.ReadToEnd();
                    }
                }
            }
            catch
            {
                // Return null if the API call fails
                return null;
            }
        }
    }
}
