<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Average.aspx.cs" Inherits="WebApplication1.Average" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Sort by averages of instructor qualities or course qualities</h1>
    <h3>
    <asp:Label runat="server" Text="Sort by average instructor quality :"></asp:Label>
    <asp:Button runat="server" ID="instAverBtn" Text="Instructor Average" onclick="instAverBtn_Click"/> <br />
    <asp:Label runat="server" Text="Sort by average course quality : "></asp:Label>
    <asp:Button runat="server" ID="courseAverBtn" Text="Course Average" onclick="courseAverBtn_Click"/> <br />
    </h3>
    <br /> 
    <asp:GridView runat="server" Visible="false" ID="instructorGrid"
        SelectMethod="instructorGrid_GetData" RowStyle-HorizontalAlign="Center"
        width="60%" AutoGenerateColumns="false"
        >
        <Columns>
            <asp:HyperLinkField HeaderText="Instructor" DataTextField="Instructor" DataNavigateUrlFields="Instructor" DataNavigateUrlFormatString="~/Search?keyword={0}" />
            <asp:BoundField HeaderText="Instructor Quality Average" DataField="Average" DataFormatString="{0:n2}" />
            <asp:BoundField HeaderText="Course Numbers" DataField="CourseNumber" />
        </Columns>
    </asp:GridView>

    <asp:GridView runat="server" Visible="false" ID="courseGrid"
        SelectMethod="courseGrid_GetData" RowStyle-HorizontalAlign="Center"
        width="60%" AutoGenerateColumns="false"
        >
            <Columns>
            <asp:HyperLinkField HeaderText="Course" DataTextField="Course" DataNavigateUrlFormatString="~/Search?keyword={0}" DataNavigateUrlFields="Course"  />
            <asp:BoundField HeaderText="Course Quality Average" DataField="Average" DataFormatString="{0:n2}" />
            <asp:BoundField HeaderText="Course Numbers" DataField="CourseNumber" />
            <asp:BoundField HeaderText="Average Student Numbers" DataField="AverageSNum" DataFormatString="{0:n2}"/>
            </Columns>
    </asp:GridView>
</asp:Content>
