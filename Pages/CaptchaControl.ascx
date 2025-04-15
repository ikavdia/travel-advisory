<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CaptchaControl.ascx.cs" Inherits="Pages.CaptchaControl" %>

<div class="captcha-container p-3 border rounded bg-light">
    <!-- Captcha Label -->
    <div class="mb-3">
        <asp:Label ID="lblCaptcha" runat="server" CssClass="form-label text-dark fw-bold" Text="Enter the Captcha:"></asp:Label>
    </div>

    <!-- Captcha Image -->
    <div class="mb-3 text-center">
        <asp:Image ID="captchaImage" runat="server" CssClass="border" />
    </div>

    <!-- Captcha Input -->
    <div class="mb-3">
        <asp:TextBox ID="txtCaptcha" runat="server" CssClass="form-control" Placeholder="Enter Captcha" />
    </div>

    <!-- Buttons -->
    <div class="d-flex justify-content-between">
        <asp:Button ID="btnRefresh" runat="server" CssClass="btn btn-secondary" Text="Refresh Captcha" OnClick="btnRefresh_Click" />
        <!-- Removed btnSubmit -->
    </div>

    <!-- Message Label -->
    <div class="mt-3">
        <asp:Label ID="lblMessage" runat="server" CssClass="form-text"></asp:Label>
    </div>
</div>