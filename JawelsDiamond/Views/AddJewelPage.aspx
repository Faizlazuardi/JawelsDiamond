<%@ Page Title="" Language="C#" MasterPageFile="~/Views/PageMaster.Master" AutoEventWireup="true" CodeBehind="AddJewelPage.aspx.cs" Inherits="JawelsDiamond.Views.AddJewelPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentBody" runat="server">
    <article>
        <h1>Add New Jewel</h1>
        <form runat="server">
            <asp:Label ID="JewelNameLabel" runat="server" Text="Jewel Name"></asp:Label>
            <asp:TextBox ID="JewelNameInput" runat="server"></asp:TextBox>

            <asp:Label ID="CategoryLabel" runat="server" Text="Category"></asp:Label>
            <asp:DropDownList ID="CategoryDropDownList" runat="server">
            </asp:DropDownList>

            <asp:Label ID="BrandLabel" runat="server" Text="Brand"></asp:Label>
            <asp:DropDownList ID="BrandDropDownList" runat="server">
            </asp:DropDownList>

            <asp:Label ID="PriceLabel" runat="server" Text="Price"></asp:Label>
            <asp:TextBox ID="PriceInput" runat="server"></asp:TextBox>

            <asp:Label ID="ReleaseLabel" runat="server" Text="Release Year"></asp:Label>
            <asp:TextBox ID="ReleaseInput" runat="server"></asp:TextBox>

            <br />
            <br />

            <asp:Button ID="SubmitButton" runat="server" Text="Submit Update" OnClick="SubmitButton_Click" />
            <asp:Label ID="StatusMessage" runat="server" Text="" CssClass="pico-color-red-500"></asp:Label>

        </form>
    </article>
</asp:Content>
