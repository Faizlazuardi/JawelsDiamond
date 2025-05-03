<%@ Page Title="" Language="C#" MasterPageFile="~/Views/PageMaster.Master" AutoEventWireup="true" CodeBehind="MyOrdersPage.aspx.cs" Inherits="JawelsDiamond.Views.MyOrdersPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentBody" runat="server">
    <h1>My Orders</h1>
    <form runat="server">
        <div style="width: 100%; height: auto; overflow: scroll">
            <asp:GridView ID="GridViewOrders" runat="server" AutoGenerateColumns="False" GridLines="None" OnRowDataBound="GridViewOrders_RowDataBound" OnRowCommand="GridViewOrders_RowCommand" DataKeyNames="TransactionID">
                <Columns>
                    <asp:BoundField DataField="TransactionID" HeaderText="Transaction ID" />
                    <asp:BoundField DataField="TransactionDate" HeaderText="Transaction Date" />
                    <asp:BoundField DataField="PaymentMethod" HeaderText="Payment Method" />
                    <asp:BoundField DataField="TransactionStatus" HeaderText="Transaction Status" />
                    <asp:TemplateField HeaderText="View Details">
                        <ItemTemplate>
                            <asp:HyperLink ID="LinkViewDetails" runat="server" Text="View Details"></asp:HyperLink>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Actions">
                        <ItemTemplate>
                            <asp:Button ID="ConfirmButton" runat="server" Text="Confirm Package" CommandName="Confirm"
                                CommandArgument="<%# Container.DataItemIndex %>" Visible="false" />
                            <asp:Button ID="RejectButton" runat="server" Text="Reject Package" CommandName="Reject"
                                CommandArgument="<%# Container.DataItemIndex %>" Visible="false" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </form>
</asp:Content>
