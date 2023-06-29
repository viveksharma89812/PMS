<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site1.Master" CodeBehind="Dashboard.aspx.vb" Inherits="Performance_Management_System.WebForm18" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style2 {
            width: 86%;
            margin-left: 104px;
            height: 273px;
        }
        .auto-style3 {
            height: 163px;
        }
        .auto-style4 {
            height: 163px;
            width: 415px;
        }
        .auto-style5 {
            width: 415px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server"><ContentTemplate>
    <br />

    <table class="auto-style2" id="1" >
        <tr>
            <td class="auto-style3">
               <center> <asp:Image ID="Image3" runat="server" ImageUrl="~/Images/download.jpg" Width="140px" /></center>
            </td>
            <td class="auto-style4">
                <center><asp:Image ID="Image4" runat="server" ImageUrl="~/Images/review.jpg" Height="159px" Width="212px" /></center>
            </td>
            <td class="auto-style3">
                <center><asp:Image ID="Image5" runat="server" ImageUrl="~/Images/download (1).jpg" CssClass="auto-style1" Height="158px" Width="140px" /></center>
            </td>
        </tr>
        <tr >
            <td>
               <center><asp:LinkButton ID="updetail" runat="server" PostBackUrl="~/Upload Details.aspx">Upload Details</asp:LinkButton> </center>
            </td>
            <td class="auto-style5">
               <center> <asp:LinkButton ID="empreview" runat="server" PostBackUrl="~/Employee Review Cycle.aspx">Employee Review Cycle</asp:LinkButton></center>
            </td>
            <td>
              <center><asp:LinkButton ID="updocu" runat="server" PostBackUrl="~/Upload Document.aspx">Upload Documents</asp:LinkButton>  </center>
            </td>
        </tr>
      <%--  <tr >
            <td class="auto-style3">
               <center> <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/download.jpg" Width="140px" /></center>
            </td>
            <td class="auto-style4">
                <center><asp:Image ID="Image2" runat="server" ImageUrl="~/Images/review.jpg" Height="159px" Width="212px" /></center>
            </td>
            <td class="auto-style3">
                <center><asp:Image ID="Image6" runat="server" ImageUrl="~/Images/download (1).jpg" CssClass="auto-style1" Height="158px" Width="140px" /></center>
            </td>
        </tr>
        <tr >
            <td>
               <center><asp:LinkButton ID="empdetails" runat="server" PostBackUrl="~/View Details.aspx">Employee Details</asp:LinkButton> </center>
            </td>
            <td class="auto-style5">
               <center> <asp:LinkButton ID="empre" runat="server" PostBackUrl="~/Employee Review Cycle.aspx">Employee Review Cycle</asp:LinkButton></center>
            </td>
            <td>
              <center><asp:LinkButton ID="empdocu" runat="server" PostBackUrl="~/View Documents.aspx">Employee Documents</asp:LinkButton>  </center>
            </td>
        </tr>--%>
    </table><br></ContentTemplate></asp:UpdatePanel>
</asp:Content>
