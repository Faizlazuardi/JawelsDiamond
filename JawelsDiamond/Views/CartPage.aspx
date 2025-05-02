<%@ Page Title="" Language="C#" MasterPageFile="~/Views/PageMaster.Master" AutoEventWireup="true" CodeBehind="CartPage.aspx.cs" Inherits="JawelsDiamond.Views.CartPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentBody" runat="server">
    <form runat="server">
        <div style="width: 100%; height: auto; overflow: scroll">
            <asp:GridView ID="GridViewCart" runat="server" AutoGenerateColumns="false" GridLines="None" DataKeyNames="JewelID" AutoGenerateEditButton="false">
                <Columns>
                    <asp:BoundField DataField="JewelID" HeaderText="Jewel ID" />
                    <asp:BoundField DataField="MsJewel.JewelName" HeaderText="Jewel Name" />
                    <asp:BoundField DataField="MsJewel.JewelPrice" HeaderText="Jewel Price" DataFormatString="{0:C}" HtmlEncode="false" />
                    <asp:BoundField DataField="MsJewel.MsBrand.BrandName" HeaderText="Brand Name" />
                    <asp:TemplateField HeaderText="Subtotal">
                        <ItemTemplate>
                            <%# Eval("MsJewel.JewelPrice", "{0:C}") != null && Eval("Quantity") != null ? 
            (Convert.ToDecimal(Eval("MsJewel.JewelPrice")) * Convert.ToInt32(Eval("Quantity"))).ToString("C") : "N/A" %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Quantity">
                        <ItemTemplate>
                            <asp:TextBox ID="TextBoxQuantity" TextMode="SingleLine" runat="server" Text='<%# Bind("Quantity") %>'></asp:TextBox>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Actions">
                        <ItemTemplate>
                            <asp:Button ID="UpdateButton" runat="server" Text="Update" CommandArgument='<%# Eval("JewelID") %>' OnClick="UpdateButton_Click" />
                            <asp:Button ID="RemoveButton" runat="server" Text="Remove" CommandArgument='<%# Eval("JewelID") %>' OnClick="RemoveButton_Click" CssClass="pico-background-red-500" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
        <br />
        <br />
        <asp:Label ID="TotalPriceLabel" runat="server" Text="Total Price: "></asp:Label>
        <br />
        <br />
        <asp:DropDownList ID="PaymentList" runat="server">
            <asp:ListItem Text="Credit Card" Value="1"></asp:ListItem>
            <asp:ListItem Text="PayPal" Value="2"></asp:ListItem>
            <asp:ListItem Text="Bank Transfer" Value="3"></asp:ListItem>
        </asp:DropDownList>
        <br />
        <br />
        <br />
        <asp:Button ID="CheckoutButton" runat="server" Text="Checkout" OnClick="CheckoutButton_Click" />
        <asp:Button ID="ClearCartButton" runat="server" Text="Clear Cart" CssClass="pico-background-red-500" />
    </form>
</asp:Content>
