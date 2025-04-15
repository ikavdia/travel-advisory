// ICurrencyExchangeService.cs
// This interface defines the contract for a RESTful service that provides currency exchange rates.
// It includes operations to retrieve exchange rates between two currencies and to list available currencies.

using System.ServiceModel;
using System.ServiceModel.Web;

namespace CurrencyExchangeService
{
    // This interface defines the contract for the Currency Exchange RESTful service.
    [ServiceContract]
    public interface ICurrencyExchangeService
    {
        // Retrieves the exchange rate between two currencies.
        //
        // Parameters:
        // fromCurrency (string): The currency to convert from.
        // toCurrency (string): The currency to convert to.
        //
        // Returns:
        // string: The exchange rate as a JSON string.
        [OperationContract]
        [WebGet(UriTemplate = "/exchange/{fromCurrency}/{toCurrency}", ResponseFormat = WebMessageFormat.Json)]
        string GetExchangeRate(string fromCurrency, string toCurrency);

        // Retrieves a list of all available currencies.
        //
        // Returns:
        // string: A JSON string containing all available currencies.
        [OperationContract]
        [WebGet(UriTemplate = "/currencies", ResponseFormat = WebMessageFormat.Json)]
        string GetAvailableCurrencies();
    }
}
