<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Search.aspx.cs" Inherits="WebApplication1.Search" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<h1>Search Courses by Course name or Instructor name</h1>
 <br />
    <h3>Keyword : <asp:TextBox runat="server" ID="keywordTBox"></asp:TextBox>
        <asp:Button runat="server" id="submitBtn" Text="Submit" onClick="submitBtn_Click"/>
    </h3>
    <br />
    <asp:GridView runat="server" ID="searchGrid" SelectMethod="searchGrid_GetData"
        width="90%" RowStyle-HorizontalAlign="Center" OnRowDataBound="searchGrid_RowDataBound"></asp:GridView>

</asp:Content>
