# Travel Advisory & Booking Web App  

A web-based travel advisory and booking platform, built using **C#, ASP.NET, HTML, and CSS**. This application enables users to explore travel destinations, book accommodations, and access personalized travel recommendations.  

---

## Features  

1. **Secure Authentication & Session Management**  
- User registration & login with encrypted credentials  
- Secure session handling using cookies and state management  

2. **Travel Booking System**  
- Browse and book flights, hotels, and activities  
- Integration with external APIs for real-time availability  

3. **Personalized Advisory Services**  
- User-specific travel recommendations  
- Secure data storage with XML-based persistence  

4. **Staff & Admin Access Control**  
- Role-based access: Members vs. Staff  
- Administrative panel for managing bookings and user access  

---

## Technologies Used  

- **Backend:** C#, ASP.NET Web Forms  
- **Frontend:** HTML, CSS  
- **Security:** Session State, Cookies, XML-based User Authentication  
- **Architecture:** Microservices, RESTful API Integration  

---

## 🏗️ Project Structure  

```bash
📂 TravelBooking/
 ┣ 📂 App_Code/        # Backend business logic
 ┣ 📂 WebServices/     # RESTful services integration
 ┣ 📂 Pages/           # Web pages (Default, Member, Staff)
 ┣ 📂 Components/      # User authentication & security features
 ┣ 📂 Data/            # XML-based data storage
 ┣ 📂 Styles/          # CSS for UI styling
 ┣ 📄 Global.asax      # Global event handlers
 ┣ 📄 Web.config       # Application configuration
 ┗ 📜 README.md        # Project Documentation
```

## Getting Started  

### Prerequisites  
- .NET Framework  
- Visual Studio (or any C# IDE)  

### Installation  
1. Clone the repository:  
   ```sh
   git clone https://github.com/yourusername/TravelBooking.git
   cd TravelBooking
   ```
2. Open the project in Visual Studio and restore dependencies.
3. Run the application and access it via http://localhost:PORT/.

## Security & Data Management

Encrypted Passwords: All user credentials are securely encrypted before storage.
Session Management: Utilizes ASP.NET Session State & Cookies for user authentication.
Role-Based Access Control: Only authorized users can access restricted areas.

## License
This project is open-source and available under the MIT License.
