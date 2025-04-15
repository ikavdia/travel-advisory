<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TryItDLL.aspx.cs" Inherits="Pages.TryItDLL" %>
<!DOCTYPE html>
<html lang="en">
<head runat="server">
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>TryItDLL Page</title>
    <!-- Bootstrap CDN -->
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha1/dist/css/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container mt-5">
            <h1 class="text-center">TryItDLL Page</h1>
            <div class="card shadow p-4">
                <div class="mb-3">
                    <label for="txtInput" class="form-label">Input Text:</label>
                    <asp:TextBox ID="txtInput" CssClass="form-control" Placeholder="Enter text" runat="server" />
                </div>
                <div class="mb-3">
                    <asp:Button ID="btnHash" CssClass="btn btn-primary" Text="Generate Hash" OnClick="btnHash_Click" runat="server" />
                    <asp:Button ID="btnEncrypt" CssClass="btn btn-success" Text="Encrypt" OnClick="btnEncrypt_Click" runat="server" />
                    <asp:Button ID="btnDecrypt" CssClass="btn btn-danger" Text="Decrypt" OnClick="btnDecrypt_Click" runat="server" />
                </div>
                <asp:Label ID="lblResult" CssClass="alert alert-secondary" runat="server" />
            </div>
        </div>
    </form>
    <!-- Bootstrap JS -->
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha1/dist/js/bootstrap.bundle.min.js"></script>
</body>
</html>