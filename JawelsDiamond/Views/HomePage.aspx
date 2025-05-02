<%@ Page Title="" Language="C#" MasterPageFile="~/Views/PageMaster.Master" AutoEventWireup="true" CodeBehind="HomePage.aspx.cs" Inherits="JawelsDiamond.Views.HomePage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentBody" runat="server">
    <h1>Homepage</h1>
    <form runat="server">
        <asp:GridView ID="GridViewJewel" runat="server" AutoGenerateColumns="False" GridLines="None">
            <Columns>
                <asp:BoundField DataField="JewelID" HeaderText="Jewel ID" />
                <asp:BoundField DataField="JewelName" HeaderText="Jewel Name" />
                <asp:BoundField DataField="JewelPrice" HeaderText="Jewel Price" />
                
                <asp:HyperLinkField DataNavigateUrlFields="JewelID" DataNavigateUrlFormatString="JewelDetails.aspx?id={0}" Text="Details" HeaderText="Show Details" />
                
            </Columns>
        </asp:GridView>
    </form>
</asp:Content>
