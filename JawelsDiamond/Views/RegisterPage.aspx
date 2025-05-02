<%@ Page Title="" Language="C#" MasterPageFile="~/Views/PageMaster.Master" AutoEventWireup="true" CodeBehind="RegisterPage.aspx.cs" Inherits="JawelsDiamond.Views.RegisterPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentBody" runat="server">
    <article>
        <hgroup style="text-align: center;">
            <h2>Register</h2>
            <p>Create an account</p>
        </hgroup>

        <form id="FormRegister" runat="server">
            <asp:Label ID="UsernameLabel" runat="server" Text="Username"></asp:Label>
            <asp:TextBox ID="UsernameInput" runat="server"></asp:TextBox>

            <asp:Label ID="PasswordLabel" runat="server" Text="Password"></asp:Label>
            <asp:TextBox ID="PasswordInput" runat="server"></asp:TextBox>

            <asp:Label ID="ConfirmPasswordLabel" runat="server" Text="Confirm Password"></asp:Label>
            <asp:TextBox ID="ConfirmPasswordInput" runat="server"></asp:TextBox>

            <asp:Label ID="EmailLabel" runat="server" Text="Email"></asp:Label>
            <asp:TextBox ID="EmailInput" runat="server"></asp:TextBox>

            <asp:Label ID="DOBLabel" runat="server" Text="DOB"></asp:Label>
            <asp:TextBox ID="DateInput" runat="server" TextMode="Date"></asp:TextBox>

            <asp:Label ID="GenderLabel" runat="server" Text="Gender"></asp:Label>
            
            <asp:RadioButtonList ID="GenderList" runat="server" BorderStyle="None">
                <asp:ListItem Text="Male" Value="Male" Selected></asp:ListItem>
                <asp:ListItem Text="Female" Value="Female"></asp:ListItem>
            </asp:RadioButtonList>

            <br />
            <br />

            <asp:Button ID="SubmitButton" runat="server" Text="Register" OnClick="SubmitButton_Click" />
            <asp:Label ID="StatusMessage" runat="server" Text="" CssClass="pico-color-red-500" ></asp:Label>
        </form>
    </article>
</asp:Content>
