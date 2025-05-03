<%@ Page Title="" Language="C#" MasterPageFile="~/Views/PageMaster.Master" AutoEventWireup="true" CodeBehind="ProfilePage.aspx.cs" Inherits="JawelsDiamond.Views.ProfilePage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentBody" runat="server">
    <article>
        <hgroup style="text-align: center;">
            <h2>Change Password</h2>
            <p>Change your password</p>
        </hgroup>

        <form id="FormChangePassword" runat="server">

            <asp:Label ID="OldPasswordLabel" runat="server" Text="Old Password"></asp:Label>
            <asp:TextBox ID="OldPasswordInput" runat="server"></asp:TextBox>

            <asp:Label ID="NewPasswordLabel" runat="server" Text="New Password"></asp:Label>
            <asp:TextBox ID="NewPasswordInput" runat="server"></asp:TextBox>

            <asp:Label ID="ConfirmPasswordLabel" runat="server" Text="Confirm Password"></asp:Label>
            <asp:TextBox ID="ConfirmPasswordInput" runat="server"></asp:TextBox>

            <br />
            <br />

            <asp:Button ID="SubmitButton" runat="server" Text="Change Password" OnClick="SubmitButton_Click"/>
            <asp:Label ID="StatusMessage" runat="server" Text="" CssClass="pico-color-red-500"></asp:Label>
        </form>
    </article>
</asp:Content>
