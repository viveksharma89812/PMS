<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site1.Master" CodeBehind="Employee Review Cycle.aspx.vb" Inherits="Performance_Management_System.WebForm19" %><%@ Register assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI.DataVisualization.Charting" tagprefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <div>
    <asp:Chart ID="Chart1" runat="server">
        <Legends>
<asp:Legend Alignment="Center" Docking="Bottom" Name="Dotnet Chart Example" />
</Legends>
    <series>
        <asp:Series Name="Series1">
           <EmptyPointStyle />
        </asp:Series>
    </series>
    <chartareas>
        <asp:ChartArea Name="ChartArea1">
        </asp:ChartArea>
    </chartareas>
</asp:Chart></div>
</asp:Content>
