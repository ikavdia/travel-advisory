﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Pages.Login" %>
<!-- Removed CaptchaControl registration -->

<!DOCTYPE html>
<html>
<head>
    <title>Login Page</title>
    <!-- Add Bootstrap -->
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <div class="container mt-5">
        <h1 class="text-center text-primary">Login</h1>
        <form runat="server" class="mt-4">
            <div class="mb-3">
                <label for="txtUsername" class="form-label">Username:</label>
                <asp:TextBox ID="txtUsername" runat="server" CssClass="form-control" Placeholder="Enter your username" />
            </div>
            <div class="mb-3">
                <label for="txtPassword" class="form-label">Password:</label>
                <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" TextMode="Password" Placeholder="Enter your password" />
            </div>
            
            <div class="mb-3 text-center">
                <asp:Button ID="btnLogin" runat="server" Text="Login" CssClass="btn btn-primary" OnClick="btnLogin_Click" />
            </div>
            <div class="mb-3">
                <asp:Button ID="btnBackToHome" runat="server" Text="Back to Home" CssClass="btn btn-secondary" OnClick="btnBackToHome_Click" />
            </div>
            <asp:Label ID="lblMessage" runat="server" CssClass="text-danger" />
        </form>
    </div>
    <!-- Bootstrap JS -->
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/js/bootstrap.bundle.min.js"></script>
</body>
</html>
