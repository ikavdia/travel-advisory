<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TryItCookie.aspx.cs" Inherits="Pages.TryItCookie" %>
<!DOCTYPE html>
<html>
<head>
    <title>TryIt Cookie</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container mt-5">
            <h1 class="text-center">TryIt Cookie Page</h1>
            <div class="card p-4 shadow">
                <asp:Label ID="lblCookieResult" runat="server" CssClass="alert alert-info d-block" Text="Cookie Information will appear here."></asp:Label>
                <div class="d-flex gap-2">
                    <asp:Button ID="btnGetCookie" runat="server" CssClass="btn btn-primary" Text="Get Cookie" OnClick="btnGetCookie_Click" />
                    <asp:Button ID="btnClearCookie" runat="server" CssClass="btn btn-danger" Text="Clear Cookie" OnClick="btnClearCookie_Click" />
                </div>
            </div>
        </div>
    </form>
</body>
</html>
