<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Staff.aspx.cs" Inherits="Pages.Staff" %>

<!DOCTYPE html>
<html>
<head>
    <title>Staff Management</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <div class="container mt-5">
        <h1 class="text-center text-primary">Staff Management</h1>
        <div class="mb-4">
            <asp:Label ID="lblStaffMessage" runat="server" CssClass="h5 text-success"></asp:Label>
        </div>
        <form runat="server">
            <div class="mb-3">
                <label for="txtStaffUsername" class="form-label">Staff Username:</label>
                <asp:TextBox ID="txtStaffUsername" runat="server" CssClass="form-control" />
            </div>
            <div class="mb-3">
                <label for="txtStaffPassword" class="form-label">Staff Password:</label>
                <asp:TextBox ID="txtStaffPassword" runat="server" TextMode="Password" CssClass="form-control" />
            </div>
            <div class="mb-3">
                <asp:Button ID="btnAddStaff" runat="server" Text="Add Staff" CssClass="btn btn-success" OnClick="btnAddStaff_Click" />
            </div>
            <asp:Label ID="lblStaffErrorMessage" runat="server" CssClass="text-danger"></asp:Label>
            <div class="mb-3">
                <asp:Button ID="btnLogout" runat="server" Text="Logout" CssClass="btn btn-danger" OnClick="btnLogout_Click" />
            </div>
            <div class="mb-3">
                <asp:Button ID="btnBackToHome" runat="server" Text="Back to Home" CssClass="btn btn-secondary" OnClick="btnBackToHome_Click" />
            </div>
        </form>
    </div>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/js/bootstrap.bundle.min.js"></script>
</body>
</html>
