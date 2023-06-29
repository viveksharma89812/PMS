<%@ Page Title="" Language="vb" AutoEventWireup="false" EnableEventValidation="false" MaintainScrollPositionOnPostback="true" MasterPageFile="~/Site1.Master" CodeBehind="Upload_Document.aspx.vb" Inherits="Performance_Management_System.WebForm6" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <style type="text/css">
         .auto-style43 {
             width: 83%;
             margin-left: 0px;
        height: 106px;
    }
         .auto-style44 {
             width: 159px;
         }
         .auto-style46 {
             margin-left: 497px;
         }
         .auto-style49 {
             height: 400px;
             width: 820px;
             overflow: auto;
             margin-left: 153px;
         }
         .auto-style53 {
             height: 50px;
         }
         .auto-style54 {
             margin-top: 11px;
         }
         .stickyheader th{
        position:sticky;
        top:0px;
        background-color:#006699;
    }
         .auto-style58 {
             width: 198px;
         }
         .auto-style61 {
             width: 133px;
         }
         .auto-style65 {
             width: 149px;
         }
         .auto-style66 {
             width: 184px;
         }
         .auto-style67 {
             width: 137px;
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
     <%--<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional"><Triggers><asp:PostBackTrigger ControlID="empid" /><asp:PostBackTrigger ControlID="export" /><asp:PostBackTrigger ControlID="upload" /></Triggers><ContentTemplate>--%>
    <br />
        <div class="container-fluid" style="font-weight:bold"  >
            <div class="col-sm-6 col-lg-6 col-md-6">
            <h3>Upload Documents of Employee</h3><hr />
             <div class="col-sm-5 col-lg-5 col-md-5">
            <div class="form-group">
                Employee ID
                  <asp:TextBox ID="empid" runat="server" TabIndex="1" AutoPostBack="True"  CssClass="form-control" placeholder="EmployeeCode"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="empid" Display="None" ErrorMessage="Please enter employeeID" ForeColor="Red" ValidationGroup="insert"></asp:RequiredFieldValidator>
                </div>
                 </div>
              <div class="col-sm-5 col-lg-5 col-md-5">
            <div class="form-group">
                Employee Name
                 <asp:TextBox ID="empname" runat="server" AutoPostBack="True" TabIndex="2"  CssClass="form-control" placeholder="EmployeeName"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="empname" Display="None" ErrorMessage="Please enter employee name" ForeColor="Red" ValidationGroup="insert"></asp:RequiredFieldValidator>
                </div>
                  </div>
              <div class="col-sm-6 col-lg-6 col-md-6">
            <div class="form-group">
                File Upload
                 <asp:FileUpload ID="FileUpload1" runat="server" ForeColor="Red" CssClass="form-control" TabIndex="3" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="FileUpload1" Display="None" ErrorMessage="PLease select file" ForeColor="Red" ValidationGroup="insert"></asp:RequiredFieldValidator>
                </div>
                  </div>
              <div class="col-sm-2 col-lg-2 col-md-2">
            <div class="form-group"><br />
                 <asp:Button ID="upload" runat="server" CssClass="btn btn-primary"  TabIndex="4" Text="Upload" ValidationGroup="insert" Width="100px" />
                </div>
                  </div>
                <div class="col-sm-2 col-lg-2 col-md-2">
            <div class="form-group">
                <br />
                <asp:LinkButton ID="export" runat="server" CssClass="btn btn-danger"><i class="fa fa-file-excel-o "></i>  Export</asp:LinkButton>

                </div>
                    </div>
        </div>
   
      
    <asp:Label ID="Label3" runat="server" Text="Label" Visible="False" Font-Size="Large" ForeColor="Red"></asp:Label>
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="auto-style46" Font-Size="Larger" ForeColor="Red" ShowMessageBox="True" ShowSummary="False" ValidationGroup="insert" Width="738px" />
    <div class="col-sm-6 col-md-6 col-lg-6"><h3>Search Details</h3><hr />
        <div class="col-sm-3 col-md-3 col-lg-3"> <div class="form-group">
       <asp:Label ID="Label6" runat="server" Text="Employee Code"></asp:Label>
<asp:TextBox ID="emplid" runat="server" AutoPostBack="True" placeholder="Search EmployeeCode" CssClass="form-control"></asp:TextBox>
        </div></div>
         <div class="col-sm-3 col-md-3 col-lg-3"> <div class="form-group">Department
             <asp:DropDownList ID="department" runat="server" AutoPostBack="True"   CssClass="form-control" AppendDataBoundItems="True" >
                     <asp:ListItem Selected="True">All</asp:ListItem>
                </asp:DropDownList>
             </div>
             </div>
          <div class="col-sm-4 col-md-4 col-lg-4"> <div class="form-group">Section
         <asp:DropDownList ID="Section" runat="server" AppendDataBoundItems="True" cssclass="form-control"  AutoPostBack="True" >
                    <asp:ListItem>All</asp:ListItem>
                </asp:DropDownList>
              </div></div>
      <div class="col-sm-2 col-md-2 col-lg-2"> <div class="form-group">   <br />      
          <asp:Button ID="Button1" runat="server" Text="Display All"  CssClass="btn btn-primary"/>

          </div>
          </div>
        </div></div>
    <asp:Label ID="Label4" runat="server" ForeColor="Red" Text="Label" Visible="False"></asp:Label>
   
     
   <asp:HiddenField ID="hfScrollPosition" Value="0" runat="server" />
        
          <div id="dvScroll"  class="divcss" onscroll="setScrollPosition(this.scrollTop);" style=" overflow: auto;
            height: 420px;
            width: auto;
            margin-left: 10px;
            margin-right: 10px;">
              <div class="container">
    <asp:GridView ID="GridView1" runat="server"  AutoGenerateColumns="False"  DataKeyNames="FileName" EmptyDataText="No record found" ShowHeaderWhenEmpty="True" Width="800px" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" >
        <Columns>
            
             <asp:TemplateField HeaderText="Sr No">
                           
                            <ItemTemplate>
                                <%#Container.DataItemIndex + 1 %>
                            </ItemTemplate>
                            <ControlStyle Width="70px" />
                            <HeaderStyle  Width="50px"  />
                            <ItemStyle  Width="50px" HorizontalAlign="Center" />
                        </asp:TemplateField>
             <asp:TemplateField HeaderText="Employee Code">
                 <EditItemTemplate>
                     <asp:TextBox ID="txtempcode" runat="server" Text='<%# Bind("EmployeeCode") %>' ReadOnly="true"></asp:TextBox>
                 </EditItemTemplate>
                 <ItemTemplate>
                     <asp:Label ID="Label2" runat="server" Text='<%# Bind("EmployeeCode") %>' Style="word-wrap:break-word;"></asp:Label>
                 </ItemTemplate>
                 <ItemStyle HorizontalAlign="Center" Width="120px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Employee Name">
                <EditItemTemplate>
                    <asp:TextBox ID="txtempname" runat="server" Text='<%# Bind("EmployeeName") %>' ReadOnly="true"></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label3" runat="server" Text='<%# Bind("EmployeeName") %>' Style="word-wrap:break-word;"></asp:Label>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="150px" />
            </asp:TemplateField>
            <%-- <asp:TemplateField HeaderText="FilePath">
                 <EditItemTemplate>
                     <asp:TextBox ID="txtfpath" runat="server" Text='<%# Bind("filePath") %>' ReadOnly="true"></asp:TextBox>
                 </EditItemTemplate>
                 <ItemTemplate>
                     <asp:Label ID="Label1" runat="server" Text='<%# Bind("filePath") %>'></asp:Label>
                 </ItemTemplate>
                
                
                 <HeaderStyle HorizontalAlign="Center" />
                
                 <ItemStyle Width="300px" />
                
             </asp:TemplateField>--%>
             <asp:TemplateField HeaderText="Date">
                 <EditItemTemplate>
                     <asp:TextBox ID="txtdate" runat="server" Text='<%# Eval("Date", "{0:dd-MM-yyyy hh:mm:tt}") %>'  ReadOnly="true"></asp:TextBox>
                 </EditItemTemplate>
                 <ItemTemplate>
                     <asp:Label ID="Label5" runat="server" Text='<%# Eval("Date", "{0:dd-MM-yyyy hh:mm:tt}") %>' Style="word-wrap:break-word;"></asp:Label>
                 </ItemTemplate>
                 <ControlStyle Width="180px" />
                 <HeaderStyle Width="180px" />
                 <ItemStyle HorizontalAlign="Center" Width="180px" />
            </asp:TemplateField>
             <asp:TemplateField HeaderText="Doc File">
                  <ItemTemplate>
                      <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# "~/Emp_File/" + Eval("FileName") %>' Text='<%# Bind("FileName") %>' Target="_blank"></asp:HyperLink>
               <%--  <asp:LinkButton ID="LinkButton1" runat="server" CommandArgument='<%# Bind("FileName") %>' CommandName="Download" Text='<%# Bind("FileName") %>'  OnClientClick="SetTarget()"></asp:LinkButton>--%>
                     </ItemTemplate>
                 
                  <ItemStyle HorizontalAlign="Center" Width="250px" />
                 <EditItemTemplate>
                                <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl='<%# "~/Emp_File/" + Eval("FileName") %>' Text='<%# Bind("FileName") %>' Target="_blank" CssClass="hyper" Style="word-wrap:break-word;" ></asp:HyperLink>
                                <asp:FileUpload ID="FileUpload2" runat="server" Width="100px" />
                            </EditItemTemplate>
             </asp:TemplateField>
               <asp:TemplateField HeaderText="Edit" ValidateRequestMode="Enabled">
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkBtnEdit" runat="server" Text="Edit" CssClass="btn-primary"
                            OnClick="Display"  ></asp:LinkButton>
                               <%-- <asp:linkbutton id="btn_Edit" runat="server" commandname="Edit" commandargument='<%# Bind("EmployeeCode") %>' text="Edit" enableviewstate="true" viewstatemode="Inherit"  xmlns:asp="#unknown"></asp:linkbutton>--%>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:LinkButton ID="btn_Update" runat="server" Text="Update" CommandName="Update" CommandArgument='<%# Bind("EmployeeCode") %>' EnableViewState="true" ViewStateMode="Inherit"  ></asp:LinkButton>
                                <asp:linkbutton id="btn_Cancel" runat="server" text="Cancel" commandname="Cancel" xmlns:asp="#unknown"></asp:linkbutton>
                            </EditItemTemplate>
                            <HeaderStyle  Width="70px" />
                            <ItemStyle  Width="70px" HorizontalAlign="Center"  />
                        </asp:TemplateField>
            <asp:TemplateField HeaderText="Delete">
                            <ItemTemplate>
                               <asp:LinkButton ID="Delete" runat="server" cssclass="btn-primary" CommandName="Delete" Text="Delete" OnClientClick="return confirm('Are you sure you want to delete this  Record?');" ></asp:LinkButton> 
                                </ItemTemplate>
                
                              <HeaderStyle  Width="70px" />
                            <ItemStyle  Width="70px" HorizontalAlign="Center"  />
                
                        </asp:TemplateField>
         </Columns>
         <FooterStyle BackColor="White" ForeColor="#000066" />
         <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White"  CssClass="stickyheader"/>
         <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
         <RowStyle ForeColor="#000066" />
         <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
         <SortedAscendingCellStyle BackColor="#F1F1F1" />
         <SortedAscendingHeaderStyle BackColor="#007DBB" />
         <SortedDescendingCellStyle BackColor="#CAC9C9" />
         <SortedDescendingHeaderStyle BackColor="#00547E" />
    </asp:GridView>

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
            <%--  <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                 <ContentTemplate>--%>
            <div class="modal-body">  
                
                <div class="col-lg-12 col-sm-12 col-md-12 col-xs-12">                                           
                    <div class="form-group">   
                       
                       <asp:Label ID="Label1" runat="server" Text="Employee Code"></asp:Label>
                         <asp:Label ID="emplcode" runat="server"  CssClass="form-control"></asp:Label>
                         <asp:Label ID="Label30" runat="server" Text="Employee Name"></asp:Label>
                         <asp:TextBox ID="emplnm" runat="server" CssClass="form-control" ></asp:TextBox>
                        <asp:Label ID="Label14" runat="server" Text="Date"></asp:Label>
                        <asp:TextBox ID="dat" runat="server" CssClass="form-control" ReadOnly="true" ></asp:TextBox>
                        <asp:Label ID="Label7" runat="server" Text="Document File"></asp:Label>                                                                
                         <asp:HyperLink ID="flname" runat="server" cssclass="hyper" ></asp:HyperLink><asp:FileUpload ID="docfile" runat="server" CssClass="form-control"/>
                                                             
                    </div>                  
                  </div>
                     
            </div>
          <%-- </ContentTemplate>
                  <Triggers>
               <asp:PostBackTrigger ControlID="btnSave" />
                 
            </Triggers>
             </asp:UpdatePanel>--%>
            <div class="modal-footer">
                <asp:Button ID="btnSave" OnClick="btnSave_Click"  runat="server" Text="Update"  CssClass="btn btn-primary" Font-Bold="true" Font-Size="Large"  />
                <button type="button" class="btn btn-primary" data-dismiss="modal" style="font:bold; font-size:large"   >
                    Cancel</button>
            </div>
        </div>
            
    </div>
              </div>

          </div></div>
   <%--  <script type="text/javascript">
                function SetTarget() {
                    window.document.forms[0].target = '_blank';
                    setTimeout(function () { window.document.forms[0].target = ''; }, 0);
                }
            </script>--%>
  
    <br />
        <%--</ContentTemplate></asp:UpdatePanel>--%>
</asp:Content>
