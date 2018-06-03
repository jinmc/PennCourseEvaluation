<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Display.aspx.cs" Inherits="WebApplication1.Display" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Display Penn Courses</h1>
    <asp:Label Text="Sort by difficulty : " runat="server"></asp:Label>
    <asp:Button runat="server" Text="ASC" ID="sort1ASCBtn" OnClick="sort1ASCBtn_Click" />
    <asp:Button runat="server" Text="DESC" ID="sort1DESCBtn" OnClick="sort1DESCBtn_Click" /><br />
    <asp:Label Text="Sort by Quality : " runat="server"></asp:Label>
    <asp:Button runat="server" Text="ASC" ID="sort2ASCBtn" OnClick="sort2ASCBtn_Click" />
    <asp:Button runat="server" Text="DESC" ID="sort2DESCBtn" OnClick="sort2DESCBtn_Click" /><br />
    <br />
    <asp:GridView runat="server" ID="courseGrid" SelectMethod="courseGrid_GetData" width="90%" OnRowDataBound="courseGrid_RowDataBound"
        Visible="false" RowStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center"></asp:GridView>

    <asp:Label runat="server" ID="testLbl" Visible="false"></asp:Label>

</asp:Content>
