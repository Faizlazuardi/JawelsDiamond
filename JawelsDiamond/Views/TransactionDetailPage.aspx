<%@ Page Title="" Language="C#" MasterPageFile="~/Views/PageMaster.Master" AutoEventWireup="true" CodeBehind="TransactionDetailPage.aspx.cs" Inherits="JawelsDiamond.Views.TransactionDetailPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentBody" runat="server">
    <h1>Transaction Details</h1>
    <form runat="server">
        <asp:GridView ID="GridViewTransactionDetails" runat="server" AutoGenerateColumns="False" GridLines="None">
            <Columns>
                <asp:BoundField DataField="TransactionHeader.TransactionID" HeaderText="Transaction ID" />

                <asp:BoundField DataField="MsJewel.JewelName" HeaderText="Jewel Name" />

                <asp:BoundField DataField="Quantity" HeaderText="Quantity" />
            </Columns>
        </asp:GridView>
    </form>
</asp:Content>
