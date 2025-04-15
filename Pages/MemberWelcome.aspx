<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MemberWelcome.aspx.cs" Inherits="Pages.MemberWelcome" %>
<!DOCTYPE html>
<html>
<head>
    <title>Member Welcome</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <form runat="server">
        <div class="container mt-5">
            <h1 class="text-center text-primary">Welcome!</h1>
            <div class="text-center">
                <asp:Label ID="lblWelcomeMessage" runat="server" CssClass="h5 text-success"></asp:Label>
            </div>
            <div class="text-center mt-4">
                <asp:Button ID="btnBackToDefault" runat="server" CssClass="btn btn-secondary" Text="Back to Home" OnClick="btnBackToDefault_Click" />
                <asp:Button ID="btnLogout" runat="server" CssClass="btn btn-danger" Text="Logout" OnClick="btnLogout_Click" />
            </div>
        </div>
    </form>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/js/bootstrap.bundle.min.js"></script>
</body>
</html>