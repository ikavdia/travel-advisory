<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TryIt.aspx.cs" Inherits="Pages.TryIt" Async="true" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>TryIt Page</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" rel="stylesheet" />
    <style>
        body { margin: 20px; background-color: #f8f9fa; font-family: Arial, sans-serif; }
        .service-section { margin-bottom: 20px; padding: 20px; background-color: #fff; border-radius: 8px; }
        .output { margin-top: 15px; padding: 15px; background-color: #e9ecef; border-radius: 5px; }
        .output pre { margin: 0; }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <h1 class="text-center">TryIt Page for Services</h1>

            <!-- Flight Search Service -->
            <div class="service-section">
                <h2>Flight Search Service</h2>
                <p class="text-muted">Search for flights using origin, destination, travel date, and number of passengers.</p>
                <div class="row g-3 align-items-center">
                    <div class="col-md-3">
                        <label for="txtOrigin" class="form-label">Origin (IATA Code):</label>
                        <asp:TextBox ID="txtOrigin" runat="server" CssClass="form-control" Placeholder="e.g., PHX"></asp:TextBox>
                    </div>
                    <div class="col-md-3">
                        <label for="txtDestination" class="form-label">Destination (IATA Code):</label>
                        <asp:TextBox ID="txtDestination" runat="server" CssClass="form-control" Placeholder="e.g., LAX"></asp:TextBox>
                    </div>
                    <div class="col-md-3">
                        <label for="txtTravelDate" class="form-label">Travel Date (YYYY-MM-DD):</label>
                        <asp:TextBox ID="txtTravelDate" runat="server" CssClass="form-control" Placeholder="e.g., 2024-12-01"></asp:TextBox>
                    </div>
                    <div class="col-md-3">
                        <label for="txtPassengers" class="form-label">Number of Passengers:</label>
                        <asp:TextBox ID="txtPassengers" runat="server" CssClass="form-control" Placeholder="e.g., 1"></asp:TextBox>
                    </div>
                    <div class="col-md-12 mt-3">
                        <asp:Button ID="btnGetFlights" runat="server" Text="Search Flights" CssClass="btn btn-primary w-100" OnClick="btnGetFlights_Click" />
                    </div>
                </div>
                <div class="output">
                    <asp:Label ID="lblFlightResults" runat="server" CssClass="text-dark"></asp:Label>
                </div>
            </div>

            <!-- Currency Exchange Service -->
            <div class="service-section">
                <h2>Currency Exchange Service</h2>
                <p class="text-muted">Get current exchange rates between two currencies.</p>
                <div class="row g-3 align-items-center">
                    <div class="col-md-4">
                        <label for="txtFromCurrency" class="form-label">From Currency:</label>
                        <asp:TextBox ID="txtFromCurrency" runat="server" CssClass="form-control" Placeholder="e.g., USD"></asp:TextBox>
                    </div>
                    <div class="col-md-4">
                        <label for="txtToCurrency" class="form-label">To Currency:</label>
                        <asp:TextBox ID="txtToCurrency" runat="server" CssClass="form-control" Placeholder="e.g., EUR"></asp:TextBox>
                    </div>
                    <div class="col-md-4 align-self-end">
                        <asp:Button ID="btnGetExchangeRate" runat="server" Text="Get Exchange Rate" CssClass="btn btn-primary w-100" OnClick="btnGetExchangeRate_Click" />
                    </div>
                </div>
                <div class="output">
                    <asp:Label ID="lblExchangeRateResult" runat="server" CssClass="text-dark"></asp:Label>
                </div>
            </div>

            <!-- Weather Service -->
            <div class="service-section">
                <h2>Weather Service</h2>
                <p class="text-muted">Get a 5-day weather forecast for a given ZIP code.</p>
                <div class="row g-3 align-items-center">
                    <div class="col-md-6">
                        <label for="txtZipCode" class="form-label">ZIP Code:</label>
                        <asp:TextBox ID="txtZipCode" runat="server" CssClass="form-control" Placeholder="e.g., 10001"></asp:TextBox>
                    </div>
                    <div class="col-md-6 align-self-end">
                        <asp:Button ID="btnGetWeather" runat="server" Text="Get Weather Forecast" CssClass="btn btn-primary w-100" OnClick="btnGetWeather_Click" />
                    </div>
                </div>
                <div class="output">
                    <asp:Label ID="lblWeatherResult" runat="server" CssClass="text-dark"></asp:Label>
                </div>
            </div>

            <!-- Hotel Search Service -->
            <div class="service-section">
                <h2>Hotel Search Service</h2>
                <p class="text-muted">Search for hotels by city code.</p>
                <div class="row g-3 align-items-center">
                    <div class="col-md-6">
                        <label for="txtCityCode" class="form-label">City Code:</label>
                        <asp:TextBox ID="txtCityCode" runat="server" CssClass="form-control" Placeholder="e.g., NYC"></asp:TextBox>
                    </div>
                    <div class="col-md-6 align-self-end">
                        <asp:Button ID="btnGetHotels" runat="server" Text="Search Hotels" CssClass="btn btn-primary w-100" OnClick="btnGetHotels_Click" />
                    </div>
                </div>
                <div class="output">
                    <asp:Label ID="lblHotelResults" runat="server" CssClass="text-dark"></asp:Label>
                </div>
            </div>

        </div>
    </form>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/js/bootstrap.bundle.min.js"></script>
</body>
</html>
