using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Pages
{
    public partial class TryIt : Page
    {
        // Flight Search Service Button Click Handler
        protected async void btnGetFlights_Click(object sender, EventArgs e)
        {
            // Validate input
            if (string.IsNullOrWhiteSpace(txtOrigin.Text) ||
                string.IsNullOrWhiteSpace(txtDestination.Text) ||
                string.IsNullOrWhiteSpace(txtTravelDate.Text) ||
                string.IsNullOrWhiteSpace(txtPassengers.Text))
            {
                lblFlightResults.Text = "<span class='text-danger'>Please fill in all fields for flight search.</span>";
                return;
            }

            if (!int.TryParse(txtPassengers.Text, out int passengerCount) || passengerCount <= 0)
            {
                lblFlightResults.Text = "<span class='text-danger'>Number of passengers must be a valid positive number.</span>";
                return;
            }

            // Construct the API URL
            string url = $"http://webstrar21.fulton.asu.edu/Page1/FlightService.svc/flights?origin={HttpUtility.UrlEncode(txtOrigin.Text)}&destination={HttpUtility.UrlEncode(txtDestination.Text)}&travelDate={HttpUtility.UrlEncode(txtTravelDate.Text)}&adults={passengerCount}";

            // Call the API
            await CallApiAsync(url, lblFlightResults);
        }

        // Currency Exchange Service Button Click Handler
        protected async void btnGetExchangeRate_Click(object sender, EventArgs e)
        {
            // Validate input
            if (string.IsNullOrWhiteSpace(txtFromCurrency.Text) || string.IsNullOrWhiteSpace(txtToCurrency.Text))
            {
                lblExchangeRateResult.Text = "<span class='text-danger'>Please provide both 'From' and 'To' currency codes.</span>";
                return;
            }

            // Convert currencies to lowercase for the API request
            string fromCurrency = txtFromCurrency.Text.Trim().ToLower();
            string toCurrency = txtToCurrency.Text.Trim().ToLower();

            // Construct the API URL
            string url = $"http://webstrar21.fulton.asu.edu/Page1/CurrencyExchangeService.svc/exchange/{HttpUtility.UrlEncode(fromCurrency)}/{HttpUtility.UrlEncode(toCurrency)}";

            // Call the API
            await CallApiAsync(url, lblExchangeRateResult);
        }

        // Weather Service Button Click Handler
        protected async void btnGetWeather_Click(object sender, EventArgs e)
        {
            // Validate input
            if (string.IsNullOrWhiteSpace(txtZipCode.Text))
            {
                lblWeatherResult.Text = "<span class='text-danger'>Please provide a valid ZIP code.</span>";
                return;
            }

            string zipCode = txtZipCode.Text.Trim();

            // Construct the API URL
            string url = $"http://webstrar21.fulton.asu.edu/Page1/WeatherService.svc/weather/zip/{HttpUtility.UrlEncode(zipCode)}";

            // Call the API
            await CallApiAsync(url, lblWeatherResult);
        }

        // Hotel Search Service Button Click Handler
        protected async void btnGetHotels_Click(object sender, EventArgs e)
        {
            // Validate input
            if (string.IsNullOrWhiteSpace(txtCityCode.Text))
            {
                lblHotelResults.Text = "<span class='text-danger'>Please provide a valid City Code.</span>";
                return;
            }

            // Construct the API URL for hotel service
            string cityCode = txtCityCode.Text.Trim();
            string url = $"http://webstrar21.fulton.asu.edu/Page1/HotelService.svc/hotels?cityCode={HttpUtility.UrlEncode(cityCode)}";

            // Call the API
            await CallApiAsync(url, lblHotelResults);
        }

        // Generic API Call Method
        private async Task CallApiAsync(string url, Label outputLabel)
        {
            try
            {
                // Log the API URL (for debugging purposes)
                outputLabel.Text = $"<span class='text-info'>Calling URL: {HttpUtility.HtmlEncode(url)}</span><br />";

                using (HttpClient client = new HttpClient())
                {
                    HttpResponseMessage response = await client.GetAsync(url);

                    if (response.IsSuccessStatusCode)
                    {
                        string result = await response.Content.ReadAsStringAsync();
                        outputLabel.Text += $"<pre>{HttpUtility.HtmlEncode(result)}</pre>";
                    }
                    else
                    {
                        outputLabel.Text += $"<span class='text-danger'>Error: {response.StatusCode} - {response.ReasonPhrase}</span>";
                    }
                }
            }
            catch (Exception ex)
            {
                outputLabel.Text += $"<span class='text-danger'>Error: {HttpUtility.HtmlEncode(ex.Message)}</span>";
            }
        }
    }
}
