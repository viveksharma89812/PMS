<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site1.Master" CodeBehind="View Details.aspx.vb" Inherits="Performance_Management_System.WebForm5" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style3 {
            width: 75%;
            margin-left: 152px;
        }
        .auto-style12 {
        width: 148px;
        height: 49px;
    }
    .auto-style13 {
        width: 291px;
        height: 49px;
    }
    .auto-style14 {
        width: 206px;
        height: 49px;
    }
    .auto-style15 {
        height: 49px;
    }
    .auto-style16 {
        width: 148px;
        height: 50px;
    }
    .auto-style17 {
            width: 291px;
            height: 50px;
        }
    .auto-style18 {
            width: 206px;
            height: 50px;
        }
    .auto-style19 {
        height: 50px;
    }
    .auto-style20 {
        width: 148px;
        height: 51px;
    }
    .auto-style21 {
        width: 291px;
        height: 51px;
    }
    .auto-style22 {
        width: 206px;
        height: 51px;
    }
    .auto-style23 {
        height: 51px;
    }
    </style>
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
    <br /><br />
    <%--   <div class="container-fluid" style=" border-style:groove"><br />--%>
        <%--<div class="col-sm-6 col-md-6 col-lg-6" style="background-color:lightpink; ">--%>
            <div class="modal fade" id="myModal" role="dialog">
                   
    <div class="modal-dialog" >
       
        <!-- Modal content-->
        <div class="modal-content" >
            <div class="modal-header">
                <button type="button" class="close" data-dismiss="modal"  >
                    &times;</button>
                <h4 class="modal-title" style="font:bold; font-size:large">
                   Your Details</h4>
            </div>
             <div class="modal-body">  
                
                <div class="col-lg-6 col-sm-6 col-md-6 col-xs-6">                                           
                    <div class="form-group">  
                         Employee Code
                <asp:Label ID="empcode" runat="server" Text="Label" CssClass="form-control"></asp:Label>
                          Employee Name
                     <asp:Label ID="empname" runat="server" Text="Label"  CssClass="form-control"></asp:Label>
                        Designation
                     <asp:Label ID="desig" runat="server" Text="Label"  CssClass="form-control"></asp:Label>
                         Department
                    <asp:Label ID="dept" runat="server" Text="Label"  CssClass="form-control"></asp:Label>
                        Section
                    <asp:Label ID="sect" runat="server" Text="Label"  CssClass="form-control"></asp:Label>
                        DOJ
                    <asp:Label ID="doj" runat="server" Text="Label"  CssClass="form-control"></asp:Label>
                        DOP
                    <asp:Label ID="dop" runat="server" Text="Label"  CssClass="form-control"></asp:Label>
                        </div>
                    </div>
                  <div class="col-lg-6 col-sm-6 col-md-6 col-xs-6">                                           
                    <div class="form-group">  
                       DOC
                    <asp:Label ID="doc" runat="server" Text="Label"  CssClass="form-control"></asp:Label>
                        DOE
                     <asp:Label ID="doe" runat="server" Text="Label"  CssClass="form-control"></asp:Label>
                        Qualification
                     <asp:Label ID="quali" runat="server" Text="Label"  CssClass="form-control"></asp:Label>
                        Previous Experience
                    <asp:Label ID="preexp" runat="server" Text="Label"  CssClass="form-control"></asp:Label>
                        Reporting Person
                    <asp:Label ID="repperson" runat="server" Text="Label"  CssClass="form-control"></asp:Label>
                        Review Period
                      <asp:Label ID="review" runat="server" Text="Label"  CssClass="form-control"></asp:Label>
                        </div>
                    </div>
           
          </div>
           
            <div class="modal-footer">
               <%-- <asp:Button ID="btnSave" OnClick="btnSave_Click"  runat="server" Text="Update"  CssClass="btn btn-primary" Font-Bold="true" Font-Size="Large"  />--%>
                <button type="button" class="btn btn-primary" data-dismiss="modal" style="font:bold; font-size:large"   >
                    Close</button>
            </div>
        </div>
            
    </div>
</div>
          <%--<div class="col-sm-6 col-md-6 col-lg-6" style="background-color:lightgray;">--%>
        <div class="container">
              <h2>Your Documents</h2><hr />

        <asp:Button ID="Button1" runat="server" Text="View Details" CssClass="btn btn-primary" />
           
                <asp:HiddenField ID="hfScrollPosition" Value="0" runat="server" />
        <br /><br />
         <div id="dvScroll"  class="divcss" onscroll="setScrollPosition(this.scrollTop);" style=" overflow: auto;
          height:500px;
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
                    
                      <asp:HyperLink ID="fname" runat="server" xmlns:asp="#unknown"  NavigateUrl='<%# "~/Images/" + Eval("fileName") %>' Text='<%# Bind("fileName") %>' Target="_blank"></asp:HyperLink>
             
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
    </asp:GridView></div>  </div>
        
              
     <script type="text/javascript">
                function SetTarget() {
                    window.document.forms[0].target = '_blank';
                    setTimeout(function () { window.document.forms[0].target = ''; }, 0);
                }
            </script>
                                             
               <br /><br />
        
   </ContentTemplate></asp:UpdatePanel>
</asp:Content>
