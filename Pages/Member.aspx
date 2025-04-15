<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Member.aspx.cs" Inherits="Pages.Member" %>
<%@ Register Src="CaptchaControl.ascx" TagName="CaptchaControl" TagPrefix="uc" %>

<!DOCTYPE html>
<html>
<head>
    <title>Member Page</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <form id="mainForm" runat="server">
        <div class="container mt-5">
            <h1 class="text-center text-primary">Welcome to the Member Page</h1>
            
            <!-- Display User Info -->
            <div class="mb-3">
                <asp:Label ID="lblWelcomeMessage" runat="server" CssClass="h5 text-success"></asp:Label>
            </div>

            <!-- Logout Button -->
            <asp:Button ID="btnLogout" runat="server" CssClass="btn btn-danger" Text="Logout" OnClick="btnLogout_Click" />

            <hr />

            <!-- Registration Form -->
            <h2 class="text-center text-info">Register a New User</h2>
            <div id="signupForm">
                <div class="mb-3">
                    <label for="txtUsername" class="form-label">Username</label>
                    <asp:TextBox ID="txtUsername" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="mb-3">
                    <label for="txtPassword" class="form-label">Password</label>
                    <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="mb-3">
                    <label for="txtConfirmPassword" class="form-label">Confirm Password</label>
                    <asp:TextBox ID="txtConfirmPassword" runat="server" TextMode="Password" CssClass="form-control"></asp:TextBox>
                </div>
                
                <!-- Captcha Control -->
                <div class="mb-3">
                    <uc:CaptchaControl ID="CaptchaControl" runat="server" />
                </div>

                <div class="mb-3">
                    <asp:Label ID="lblSignupMessage" runat="server" CssClass="form-text"></asp:Label>
                </div>
                <asp:Button ID="btnSignup" runat="server" CssClass="btn btn-primary" Text="Sign Up" OnClick="btnSignup_Click" />
                <div class="mb-3 text-center">
                    <asp:Button ID="btnBackToDefault" runat="server" CssClass="btn btn-secondary" Text="Back to Home" OnClick="btnBackToDefault_Click" />
                </div>
            </div>
        </div>
    </form>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/js/bootstrap.bundle.min.js"></script>
</body>
</html>
