<%@ Page Title="" Language="vb"   AutoEventWireup="false" Culture="en-GB" MasterPageFile="~/Site1.Master" CodeBehind="Import_excel.aspx.vb" Inherits="Performance_Management_System.WebForm4" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        
        .auto-style4 {
            margin-left: 276px;
        }
    </style>
     <script src="http://code.jquery.com/jquery-1.11.3.js" type="text/javascript"></script>
    <script type="text/javascript">   
        $(document).ready(function () {
            maintainScrollPosition();
        });
        function pageLoad() {
            maintainScrollPosition();
        }
        function maintainScrollPosition() {
            $("#dvScroll").scrollTop($('#<%=hfScrollPosition.ClientID%>').val());
        }   
        function setScrollPosition(scrollValue) {
            $('#<%=hfScrollPosition.ClientID%>').val(scrollValue);
        }               
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server"><Triggers><asp:PostBackTrigger ControlID="Button1" /></Triggers><ContentTemplate><br />
       <div class="container" style="font-weight:bold">
         <h2>Upload Attendance Excel File</h2><hr />
         <div class="col-sm-4 col-md-4 col-lg-4">
             <div class="form-group">
                 Select File
                  <asp:FileUpload ID="FileUpload1" runat="server" CssClass="form-control" />
             </div>
         </div>
          <div class="col-sm-4 col-md-4 col-lg-4">
             <div class="form-group"><br />
                   <asp:Button ID="Button1" runat="server" Text="Import" ValidationGroup="insert" cssclass="btn btn-primary" />  <asp:LinkButton ID="send" runat="server" CssClass="btn btn-success">Send Mail <i class="fa fa-send"></i>  </asp:LinkButton>    
                 </div>
              </div>
         <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Please select file" ControlToValidate="FileUpload1" Display="None" ForeColor="Red" ValidationGroup="insert"></asp:RequiredFieldValidator>
     <asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="auto-style1" ForeColor="Red" Width="308px" ShowMessageBox="True" ShowSummary="False" ValidationGroup="insert" />
     </div>
         <asp:HiddenField ID="hfScrollPosition" Value="0" runat="server"  />
          <div id="dvScroll" class="divcss" onscroll="setScrollPosition(this.scrollTop);" style="width:730px; height:auto; grid-column-gap:inherit;  border-style:groove; font-family:Calibri; Font-Size:Small " >
             <asp:GridView ID="GridView1" runat="server" PageSize="50" CssClass="auto-style3" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" EmptyDataText="No Record Found" ShowHeaderWhenEmpty="True">
        <FooterStyle BackColor="White" ForeColor="#000066" />
        <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
        <RowStyle ForeColor="#000066" />
        <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#F1F1F1" />
        <SortedAscendingHeaderStyle BackColor="#007DBB" />
        <SortedDescendingCellStyle BackColor="#CAC9C9" />
        <SortedDescendingHeaderStyle BackColor="#00547E" />
    </asp:GridView>
        </div>
    <br /></ContentTemplate></asp:UpdatePanel>
</asp:Content>
