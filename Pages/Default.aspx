<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Pages.Default" %>

<!DOCTYPE html>
<html>
<head>
    <title>Service-Oriented Web Application</title>
    <!-- Add Bootstrap -->
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
        <div class="container mt-5">
            <h1 class="text-center text-primary">Welcome to the Travel Application</h1>
            <p class="text-muted text-center">
                This application offers flight search, currency exchange, weather services, and more.
            </p>

            <h2>How to Use This Application</h2>
            <p>To use this application:</p>
            <ul>
                <li><strong>Sign Up:</strong> Users can sign up by navigating to the <a href="Login.aspx">Login Page</a>. Enter your username and password.</li>
                <li><strong>Test Features:</strong> TAs/graders can test individual components using the links in the Service Directory below.</li>
                <li><strong>Example Inputs:</strong> Use the following inputs to test:
                    <ul>
                        <li><strong>Flight Search:</strong> Origin = "LAX", Destination = "JFK", Date = "2024-11-20".</li>
                        <li><strong>Weather Service:</strong> ZIP Code = "90210".</li>
                        <li><strong>Currency Exchange:</strong> From = "USD", To = "EUR".</li>
                    </ul>
                </li>
            </ul>

                    <!-- Session Counters -->
            <div class="text-center my-4">
                <asp:Label ID="lblActiveCounter" runat="server" Text="Active Sessions: "></asp:Label><br />
                <asp:Label ID="lblTotalCounter" runat="server" Text="Total Sessions: "></asp:Label>

            </div>

            <!-- Navigation Buttons -->
            <div class="d-flex justify-content-center gap-3 my-4">
                <button class="btn btn-primary" onclick="window.location.href='Member.aspx'">Go to Member Registration</button>
                <button class="btn btn-secondary" onclick="window.location.href='Login.aspx'">Go to Staff Page</button>
                <button class="btn btn-secondary" onclick="window.location.href='MemberLogin.aspx'">Go to Member Login</button>
            </div>

            <!-- Service Directory -->
            <h2 class="text-center text-success">Service Directory</h2>
            <table class="table table-bordered table-striped">
                <thead class="table-dark">
                    <tr>
                        <th>Provider Name</th>
                        <th>Component Type</th>
                        <th>Operation Name</th>
                        <th>Parameters</th>
                        <th>Return Type</th>
                        <th>Description</th>
                        <th>TryIt Page</th>
                    </tr>
                </thead>
                <tbody>
                    <!-- Flight Search Service -->
                    <tr>
                        <td>Prabhat Krishna Kommineni</td>
                        <td>RESTful Service</td>
                        <td>GetFlights</td>
                        <td>Origin (string), Destination (string), Travel Date (string)</td>
                        <td>Stream (text/plain)</td>
                        <td>Searches for available flights using the Amadeus API based on origin, destination, and travel date.</td>
                        <td><a href="TryIt.aspx">Try Flight Search</a></td>
                    </tr>
                    <!-- Hotel Service -->
                        <tr>
                        <th>Kaitlyn McCain</th>
                        <th>RESTful Service</th>
                        <th>\GetHotelsByCity</th>
                        <th>City IAIA Code (string)</th>
                        <th>String (Hotel List)</th>
                        <th>Searches and fetches for a list of hotels for a given city, using the Amadeus API.</th>
                        <td><a href="TryIt.aspx">Try Hotel Service</a></td>
                    </tr>
                    <!-- Weather Service -->
                    <tr>
                        <td>Ishan Kavdia</td>
                        <td>RESTful Service</td>
                        <td>GetWeatherByZip</td>
                        <td>Zip Code (string)</td>
                        <td>Stream (text/plain)</td>
                        <td>Fetches a 5-day weather forecast for a given ZIP code using the OpenWeatherMap API.</td>
                        <td><a href="TryIt.aspx">Try Weather Service</a></td>
                    </tr>
                    <!-- Currency Exchange Service -->
                    <tr>
                        <td>Ishan Kavdia</td>
                        <td>RESTful Service</td>
                        <td>GetExchangeRate</td>
                        <td>From Currency (string), To Currency (string)</td>
                        <td>String (Exchange Rate)</td>
                        <td>Fetches the exchange rate between two currencies using the Currency API.</td>
                        <td><a href="TryIt.aspx">Try Currency Exchange</a></td>
                    </tr>
                    <!-- DLL Component -->
                    <tr>
                        <td>Ishan Kavdia</td>
                        <td>DLL Function</td>
                        <td>Encrypt, Decrypt, ComputeHash</td>
                        <td>Encrypt/Decrypt: Text (string), ComputeHash: Text (string)</td>
                        <td>Encrypt/Decrypt: String (encrypted or decrypted text), ComputeHash: String (hash value)</td>
                        <td>Provides encryption, decryption, and hashing functions as a local DLL component.</td>
                        <td><a href="TryItDLL.aspx">Try DLL Component</a></td>
                    </tr>
                    <!-- Captcha Component -->
                    <tr>
                        <td>Ishan Kavdia, Prabhat Krishna Kommineni</td>
                        <td>User Control</td>
                        <td>GenerateCaptcha, ValidateCaptcha</td>
                        <td>GenerateCaptcha: None, ValidateCaptcha: Input (string)</td>
                        <td>GenerateCaptcha: Captcha image, ValidateCaptcha: Boolean</td>
                        <td>Provides a captcha image and validates user input for improved security.</td>
                        <td><a href="Login.aspx">Try Captcha</a></td>
                    </tr>
                    <!-- Cookie Component -->
                    <tr>
                        <td>Prabhat Krishna Kommineni</td>
                        <td>Cookie</td>
                        <td>SetCookie, GetCookie</td>
                        <td>SetCookie: Name (string), Value (string), GetCookie: Name (string)</td>
                        <td>SetCookie: Void, GetCookie: String (cookie value)</td>
                        <td>Handles setting and retrieving cookies for session or persistent storage.</td>
                        <td><a href="TryItCookie.aspx">Try Cookie Component</a></td>
                    </tr>
                    <!-- Global Component -->
                        <tr>
                        <th>Kaitlyn McCain</th>
                        <th>Global</th>
                        <th>ActiveCount, TotalCount</th>
                        <th>object sender, Event Args e</th>
                        <th>voide</th>
                        <th>Keeps track of accesses to the application, has both Active and total. Also handles exceptions in the application</th>
                        <th>TryIt Page</th>
                    </tr>
                </tbody>
            </table>
        </div>
    <!-- Bootstrap JS -->
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/js/bootstrap.bundle.min.js"></script>
</body>
</html>