<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site1.Master" CodeBehind="View Documents.aspx.vb" Inherits="Performance_Management_System.WebForm7" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
    .auto-style3 {
        margin-left: 363px;
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
       <script type='text/javascript'>
        function openModal() {
            $('[id*=myModal]').modal('show');
        }  
</script>
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server"><ContentTemplate>
    <br />
  <asp:HiddenField ID="hfScrollPosition" Value="0" runat="server" />
        <div class="container">
         <div id="dvScroll"  class="divcss" onscroll="setScrollPosition(this.scrollTop);" style=" overflow: auto;
            height: 420px;
            width: auto;
            ">
    <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="False"  EmptyDataText="No record found" ShowHeaderWhenEmpty="True" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3">
         <Columns>
            <asp:BoundField DataField="EmployeeCode" HeaderText="Employee Code"   >
             <HeaderStyle HorizontalAlign="Center" />
             <ItemStyle HorizontalAlign="Center" Width="150px"  />
             </asp:BoundField>
           <%-- <asp:BoundField DataField="FileName" HeaderText="File" >
             <HeaderStyle HorizontalAlign="Center" />
             <ItemStyle HorizontalAlign="Center" />
             </asp:BoundField>--%>
            <asp:BoundField DataField="Date" HeaderText="Date" DataFormatString="{0:dd-MM-yyyy hh:mm tt}" >
             <HeaderStyle HorizontalAlign="Center"  />
             <ItemStyle HorizontalAlign="Center" Width="170px" />
             </asp:BoundField>
            <asp:TemplateField HeaderText="File">
                  <ItemTemplate>
                    
                      <asp:HyperLink ID="fname" runat="server" xmlns:asp="#unknown" NavigateUrl='<%# "~/Images/" + Eval("fileName") %>' Text='<%# Bind("fileName") %>' Target="_blank"></asp:HyperLink>
             
                    </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="180px" />
                <HeaderStyle HorizontalAlign="Center" />
             </asp:TemplateField>
        </Columns>
         <FooterStyle BackColor="White" ForeColor="#000066" />
         <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
         <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
         <RowStyle ForeColor="#000066" />
         <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
         <SortedAscendingCellStyle BackColor="#F1F1F1" />
         <SortedAscendingHeaderStyle BackColor="#007DBB" />
         <SortedDescendingCellStyle BackColor="#CAC9C9" />
         <SortedDescendingHeaderStyle BackColor="#00547E" />
    </asp:GridView></div>
     <script type="text/javascript">
                function SetTarget() {
                    window.document.forms[0].target = '_blank';
                    setTimeout(function () { window.document.forms[0].target = ''; }, 0);
                }
            </script>
<br />
        </div>
    <br /></ContentTemplate></asp:UpdatePanel>
</asp:Content>
