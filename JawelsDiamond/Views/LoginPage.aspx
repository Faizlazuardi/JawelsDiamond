<%@ Page Title="" Language="C#" MasterPageFile="~/Views/PageMaster.Master" AutoEventWireup="true" CodeBehind="LoginPage.aspx.cs" Inherits="JawelsDiamond.Views.LoginPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentBody" runat="server">
    <article>
        <hgroup style="text-align: center;">
            <h2>Login</h2>
            <p>Login into your account</p>
        </hgroup>

        <form id="FormLogin" runat="server">
            <asp:Label ID="EmailLabel" runat="server" Text="Email"></asp:Label>
            <asp:TextBox ID="EmailInput" runat="server"></asp:TextBox>

            <asp:Label ID="PasswordLabel" runat="server" Text="Password"></asp:Label>
            <asp:TextBox ID="PasswordInput" runat="server"></asp:TextBox>

            <asp:CheckBox ID="RememberMeCheckbox" runat="server" />
            <asp:Label ID="RememberMeLabel" runat="server" Text="Remember Me"></asp:Label>

            <br />
            <br />

            <asp:Button ID="SubmitButton" runat="server" Text="Login" OnClick="SubmitButton_Click" />
            <asp:Label ID="StatusMessage" runat="server" Text="" CssClass="pico-color-red-500"></asp:Label>
        </form>
    </article>
</asp:Content>
