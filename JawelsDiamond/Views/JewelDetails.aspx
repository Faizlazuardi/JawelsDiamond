<%@ Page Title="" Language="C#" MasterPageFile="~/Views/PageMaster.Master" AutoEventWireup="true" CodeBehind="JewelDetails.aspx.cs" Inherits="JawelsDiamond.Views.JewelDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentBody" runat="server">
    <form runat="server">
        <article>
            <header id="HeaderItems">
                <h3>
                <asp:Label ID="JewelNameLabel" runat="server" Text="N/A"></asp:Label>
                </h3>
            </header>
            <hgroup>
                <h6>Jewel Category</h6>
                <asp:Label ID="JewelCategoryLabel" runat="server" Text="N/A"></asp:Label>
            </hgroup>
            <hgroup>
                <h6>Jewel Brand</h6>
                <asp:Label ID="JewelBrandLabel" runat="server" Text="N/A"></asp:Label>
            </hgroup>
            <hgroup>
                <h6>Country Of Origin</h6>
                <asp:Label ID="OriginLabel" runat="server" Text="N/A"></asp:Label>
            </hgroup>
            <hgroup>
                <h6>Class</h6>
                <asp:Label ID="ClassLabel" runat="server" Text="N/A"></asp:Label>
            </hgroup>
            <hgroup>
                <h6>Price</h6>
                <asp:Label ID="PriceLabel" runat="server" Text="N/A"></asp:Label>
            </hgroup>
            <hgroup>
                <h6>Release Year</h6>
                <asp:Label ID="ReleaseLabel" runat="server" Text="N/A"></asp:Label>
            </hgroup>
            <footer>
                <asp:Button ID="AddToCartButton" runat="server" Text="Add to cart" OnClick="AddToCartButton_Click"/>
                <asp:Button ID="DeleteButton" runat="server" Text="Delete" CssClass="pico-background-red-500" OnClick="DeleteButton_Click" Visible="false"/>
                <asp:Button ID="EditButton" runat="server" Text="Edit" CssClass="pico-background-green-400" OnClick="EditButton_Click" Visible="false" />
            </footer>
        </article>
    </form>
</asp:Content>
