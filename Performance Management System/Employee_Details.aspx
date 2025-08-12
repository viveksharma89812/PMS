<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site1.Master" CodeBehind="Employee_Details.aspx.vb" Inherits="Performance_Management_System.WebForm13" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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
     <meta charset="utf-8" />  
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />  
    <link href="Content/bootstrap.cosmo.min.css" rel="stylesheet" />  
    <link href="Content/StyleSheet.css" rel="stylesheet" />  
    </asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


   <script type="text/javascript">
            function Search_Gridview(strKey) {
                var strData = strKey.value.toLowerCase().split(" ");
                var tblData = document.getElementById("<%=GridView1.ClientID %>");
                var rowData;
                for (var i = 1; i < tblData.rows.length; i++) {
                    rowData = tblData.rows[i].innerHTML;
                    var styleDisplay = 'none';
                    for (var j = 0; j < strData.length; j++) {
                        if (rowData.toLowerCase().indexOf(strData[j]) >= 0)
                            styleDisplay = '';
                        else {
                            styleDisplay = 'none';
                          
                            break;
                        }
                    }
                    tblData.rows[i].style.display = styleDisplay;
                }
            }   
        </script>
    <br />

<center>     
          <table>
             <tr>
                 <td><h2> Search :</h2></td>
                 <td> &nbsp;&nbsp;<asp:TextBox ID="txtSearch" runat="server" Font-Size="20px" onkeyup="Search_Gridview(this)"  placeholder="Search by any Columns...."></asp:TextBox>       
             </td>
          </table>
     </center>
    <br />
    <br />
     <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" width="800px"><ContentTemplate>
  
 <div class="container">
     <asp:HiddenField ID="hfScrollPosition" Value="0" runat="server" />
        
         <div id="dvScroll"  class="divcss" onscroll="setScrollPosition(this.scrollTop);" style=" overflow: auto;
          height:600px;
            width: auto;">
 <center>
        <div style="background-color:black">
          <marquee direction="left"  scrollamount="10">  <asp:Label ID="Label31" runat="server" Font-Bold="True" Font-Italic="True"  Font-Size="Large" ForeColor="Red" Text="All PMS Review Form will be available from 7th of each month and Every Department Head need to Submit it on or before 18th of Each Month."></asp:Label>  </marquee>
   
         </div>
               <br />
               <table style="border:1px solid black">
                   <tr><td>&nbsp;&nbsp;</</td>
                       <td>  Total Employee's count : <asp:Label ID="lblcount" runat="server" Font-Size="Large" Text="Label" color="white"></asp:Label> &nbsp;&nbsp;</td>
                       <td>Pending Count : <asp:Label ID="Label7" runat="server" Font-Size="Large" Text="Label" color="white" ForeColor="Red"></asp:Label> &nbsp;&nbsp;</td>
                       <td>Section head Appoved : <asp:Label ID="Label18" runat="server" Font-Size="Large" Text="Label" color="white" ForeColor="Green" title="section head Approve" ></asp:Label> &nbsp;&nbsp;</</td>
                      <td>Department head Appoved : <asp:Label ID="Label16" runat="server" Font-Size="Large" Text="Label" color="white" ForeColor="Green" title="Department head Approve" ></asp:Label> &nbsp;&nbsp;</</td>

                   </tr>
               </table>
        <br />
        <br />
<asp:GridView ID="GridView1" runat="server" Width="100%" CssClass="table table-striped table-bordered table-hover"   AutoGenerateColumns="False" DataKeyNames="EmployeeCode" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3"  ShowHeaderWhenEmpty="True" EmptyDataText="There are no data records to display." >
 <Columns>
            <asp:TemplateField HeaderText="Employee Detail">
                <ItemTemplate>          
                <asp:LinkButton ID="LinkButton1" runat="server" style="word-wrap:break-word;"
                CommandArgument='<%# Bind("EmployeeCode") %>' OnClick="Display" Font-Underline="true"  Font-Bold="true"  CommandName="Download" Text='<%# Eval("EmployeeCode") + " - " + Eval("EmployeeName") + " - " + Eval("Section") %> ' CssClass="btn btn-link" title="Onclick Employee Details show."> <i class="fa fa-external-link" style="font-size:24px" ></i></asp:LinkButton>
                </ItemTemplate>
                <ControlStyle  />
                <HeaderStyle  Wrap="False" />
                <ItemStyle Width="220px" Wrap="True" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Review Period">
                 <EditItemTemplate>
                 <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Review_Period") %>'></asp:TextBox>
                 </EditItemTemplate>
                 <ItemTemplate>
                 <asp:Label ID="Label1" runat="server" Text='<%# Bind("Review_Period") %>' Font-Bold="true"></asp:Label>
                 </ItemTemplate>
                 <ControlStyle Width="100px" />
                 <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="100px" />
                 <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="100px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Review Form">
                <ItemTemplate>
                <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Always">
                <Triggers>
                <asp:PostBackTrigger ControlID="revform" />
                </Triggers>
                <ContentTemplate>
                <asp:LinkButton ID="revform" runat="server" CommandArgument='<%# Bind("EmployeeCode") %>' OnClientClick="SetTarget()"  CommandName="Form" Text="Review Form" CssClass="btn btn-link"  Font-Underline="true"  Font-Bold="true">Review Form <i class="fa fa-external-link-square"> </i></asp:LinkButton>
                <asp:Label ID="Label3" runat="server" Text='<%# Bind("EmployeeCode") %>' visible="false" ForeColor="Red" Font-Bold="true"></asp:Label>
                </ContentTemplate></asp:UpdatePanel>  </ItemTemplate>
                <ControlStyle Width="150px" />
                <HeaderStyle Width="150px" Wrap="False" HorizontalAlign="Center" VerticalAlign="Middle"/>
                <ItemStyle Width="150px" Wrap="False"  HorizontalAlign="Center" VerticalAlign="Middle"/>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Form Status">
                <EditItemTemplate>
                <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("Form_Status") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                <asp:Label ID="Label2" runat="server"  Font-Bold="true"></asp:Label>
                </ItemTemplate>
                <ControlStyle Width="120px" />
                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="120px" />
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="120px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Section head Status">
                <EditItemTemplate>
                <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("Sect_Accept") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                <asp:Label ID="Label4" runat="server"  Font-Bold="true"></asp:Label>
                </ItemTemplate>
                <ControlStyle Width="120px" />
                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="120px" />
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="120px" />
            </asp:TemplateField>
        </Columns>
            <FooterStyle BackColor="White" ForeColor="#000066" />
            <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
            <RowStyle ForeColor="#000066" />
            <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="#007DBB" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#00547E" />
    </asp:GridView>
</center>
           
<script type="text/javascript">
 function SetTarget() {
window.document.forms[0].target = '_blank';
setTimeout(function () { window.document.forms[0].target = ''; }, 0);
 </script>

<div class="modal fade" id="myModal" role="dialog">
    <div class="modal-dialog">
        <!-- Modal content-->
        <div class="modal-content" <%--style="background-color:lightsteelblue" --%>>
            <div class="modal-header">
                <button type="button" class="close" data-dismiss="modal"  >
                    &times;</button>
                <h4 class="modal-title" style="font:bold; font-size:large">
                    Employee Details</h4>
            </div>              
            <div class="modal-body"> 
                <div class="col-lg-6 col-sm-6 col-md-6 col-xs-6">                                           
                    <div class="form-group">   
                       <asp:Label ID="Label1" runat="server" Text="Employee Code"></asp:Label>
                         <asp:Label ID="empcode" runat="server" Text="Label" CssClass="form-control"></asp:Label>
                         <asp:Label ID="Label30" runat="server" Text="Employee Name"></asp:Label>
                        <asp:Label ID="empname" runat="server" Text="Label" CssClass="form-control"></asp:Label>
                        <asp:Label ID="Label14" runat="server" Text="Designation"></asp:Label>
                        <asp:Label ID="desig" runat="server" Text="Label" CssClass="form-control"></asp:Label>
                        Grad
                        <asp:Label ID="grd" runat="server" Text="Label" CssClass="form-control"></asp:Label>
                        <asp:Label ID="Label2" runat="server" Text="Department"></asp:Label>                       
                      <asp:Label ID="dept" runat="server" Text="Label" CssClass="form-control"></asp:Label>                  
                       <asp:Label ID="Label4" runat="server" Text="Section"></asp:Label>                      
                       <asp:Label ID="sect" runat="server" Text="Label" CssClass="form-control"></asp:Label>                 
                          <asp:Label ID="Label5" runat="server" Text="DOJ"></asp:Label>
                   <asp:Label ID="doj" runat="server" Text="Label" CssClass="form-control"></asp:Label>
                    </div>                  
                  </div>
                  <div class="col-lg-6 col-sm-6 col-md-6 col-xs-6"> 
                <div class="form-group"> 
                    <asp:Label ID="Label8" runat="server" Text="DOP"></asp:Label>
                        <asp:Label ID="dop" runat="server" Text="Label" CssClass="form-control"></asp:Label>
                     <asp:Label ID="Label9" runat="server" Text="DOC"></asp:Label>
                        <asp:Label ID="doc" runat="server" Text="Label" CssClass="form-control"></asp:Label>
                          <asp:Label ID="Label10" runat="server" Text="DOE"></asp:Label>
                        <asp:Label ID="doe" runat="server" Text="Label" CssClass="form-control"></asp:Label>
                         <asp:Label ID="Label11" runat="server" Text="Qualification"></asp:Label>
                         <asp:Label ID="quali" runat="server" Text="Label" CssClass="form-control"></asp:Label>      
                          <asp:Label ID="Label12" runat="server" Text="Previous Experience"></asp:Label>
                 <asp:Label ID="preexp" runat="server" Text="Label" CssClass="form-control"></asp:Label>
                         <asp:Label ID="Label13" runat="server" Text="Reporting Person" ></asp:Label>
                       <asp:Label ID="reporting" runat="server" Text="Label" CssClass="form-control"></asp:Label>
                         <asp:Label ID="Label15" runat="server" Text="Review Period" ></asp:Label>
                    <asp:Label ID="review" runat="server" Text="Label" CssClass="form-control"></asp:Label>
                    <asp:Label ID="Label6" runat="server" Text="PMS_Form_Category" ></asp:Label>
                    <asp:Label ID="PMS_Form_Category" runat="server" Text="Label" CssClass="form-control"></asp:Label>
                           </div>
                    </div>                     
            </div>
            <div class="modal-footer">
                <button type="button" class="btn btn-primary" data-dismiss="modal" style="font:bold; font-size:large"  title="Close Popup"  >
                    Close</button>
            </div>
        </div>
    </div>
 </div>
</div>




   </div></ContentTemplate></asp:UpdatePanel>
</asp:Content>


