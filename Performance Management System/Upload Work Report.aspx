<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site1.Master" CodeBehind="Upload Work Report.aspx.vb" Inherits="Performance_Management_System.WebForm18" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style3 {
            margin-left: 164px;
        }
        .auto-style4 {
            margin-left: 203px;
        }
        .auto-style5 {
            margin-left: 335px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br /><br />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:DropDownList ID="department" runat="server" AutoPostBack="true" CssClass="auto-style4">
         <asp:ListItem Selected="True">---Select---</asp:ListItem>
                            <asp:ListItem>Administration</asp:ListItem>
                            <asp:ListItem>Finance</asp:ListItem>
                            <asp:ListItem>HR</asp:ListItem>
                            <asp:ListItem>Institutional Sales</asp:ListItem>
                            <asp:ListItem>IT</asp:ListItem>
                            <asp:ListItem>Marketing</asp:ListItem>
                            <asp:ListItem>Planning</asp:ListItem>
                            <asp:ListItem>Production</asp:ListItem>
                            <asp:ListItem>Service</asp:ListItem>
                            <asp:ListItem>QA</asp:ListItem>
                            <asp:ListItem>RD1</asp:ListItem>
                            <asp:ListItem>RD2</asp:ListItem>
                            <asp:ListItem>Retail Sales</asp:ListItem>
                            <asp:ListItem>Civil</asp:ListItem>
                            <asp:ListItem>EHS</asp:ListItem>
    </asp:DropDownList>
    <asp:DropDownList ID="section" runat="server" CssClass="auto-style3" AutoPostBack="True">
        <asp:ListItem>---Select---</asp:ListItem>
    </asp:DropDownList>
    <br />
&nbsp;&nbsp;
    <asp:GridView ID="GridView1" runat="server" CssClass="auto-style5">
    </asp:GridView>
    <br />
    <br />
</asp:Content>
