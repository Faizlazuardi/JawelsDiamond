<%@ Page Title="" Language="C#" MasterPageFile="~/Views/PageMaster.Master" AutoEventWireup="true" CodeBehind="HandleOrdersPage.aspx.cs" Inherits="JawelsDiamond.Views.HandleOrdersPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentBody" runat="server">
    <h1>My Orders</h1>
    <form runat="server">
        <div style="width: 100%; height: auto; overflow: scroll">
            <asp:GridView ID="GridViewHandlerOrders" runat="server" AutoGenerateColumns="false" GridLines="None" OnRowDataBound="GridViewHandlerOrders_RowDataBound" DataKeyNames="TransactionID">
                <Columns>
                    <asp:BoundField DataField="TransactionID" HeaderText="Transaction ID" />
                    <asp:BoundField DataField="UserID" HeaderText="User ID" />
                    <asp:BoundField DataField="TransactionStatus" HeaderText="Status" />
                    <asp:TemplateField HeaderText="Actions">
                        <ItemTemplate>
                            <asp:Button ID="ConfirmPaymentButton" runat="server" Text="Confirm Payment" Visible="false" OnCommand="ConfirmPaymentButton_Command" CommandArgument="<%# Container.DataItemIndex %>" />
                            <asp:Button ID="ShipPackageButton" runat="server" Text="Ship Package" Visible="false" OnCommand="ShipPackageButton_Command" CommandArgument="<%# Container.DataItemIndex %>" />
                            <asp:Label ID="StatusMessageLabel" runat="server" Text=""/>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </form>
</asp:Content>
