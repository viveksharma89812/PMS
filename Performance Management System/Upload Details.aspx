<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site1.Master"  EnableEventValidation="false" MaintainScrollPositionOnPostback="true" CodeBehind="Upload Details.aspx.vb" Inherits="Performance_Management_System.WebForm3"  %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server" >
    <style type="text/css">
        .auto-style3 {
            width: 100%;         
        height: 191px;
        margin-left: 0px;
            margin-top: 0px;
            margin-bottom: 0px;
        }
        .auto-style6 {
            width: 47%;
        
    }
        .auto-style9 {
            width: 75px;
            height: 42px;
        }
        .auto-style10 {
            margin-top: 3px;
        }
        .auto-style21 {
            width: 33px;
            height: 42px;
        }
        .auto-style23 {
            width: 66px;
            height: 42px;
        }
        .auto-style24 {
            height: 42px;
            width: 24px;
        }
        .auto-style25 {
            height: 42px;
            width: 127px;
        }
        .auto-style34 {
            margin-top: 8px;
        }
        .auto-style43 {
        margin-left: 458px;
            margin-top: 0px;
        }
    .grid{
        position:absolute;
    }
    .stickyheader th{
        position:sticky;
        top:0px;
        background-color:#006699;
    }
        .auto-style46 {
            margin-left: 0px;
            margin-bottom: 0px;
        }
    </style>
    <style type="text/css">
.modalBackground
{
background-color: Gray;
filter: alpha(opacity=80);
opacity: 0.8;
z-index: 10000;
}
        .auto-style69 {
            width: 471px;
            height: 18px;
        }
        </style>
     <style type="text/css">
        .divcss {
            overflow:auto;
            height: 200px;
            width: 400px;
        }
           .auto-style70 {
             margin-top: 8px;
         }
         .auto-style77 {
             width: 444px;
             height: 18px;
         }
         .auto-style82 {
             width: 444px;
             height: 24px;
         }
         .auto-style83 {
             width: 447px;
             height: 24px;
         }
         .auto-style84 {
             width: 463px;
             height: 24px;
         }
         .auto-style85 {
             width: 412px;
             height: 24px;
         }
         .auto-style86 {
             width: 447px;
             height: 18px;
         }
         .auto-style87 {
             width: 463px;
             height: 18px;
         }
         .auto-style88 {
             width: 412px;
             height: 18px;
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

       <link rel="stylesheet" href="https://code.jquery.com/ui/1.12.0/themes/base/jquery-ui.css">
<script src="https://code.jquery.com/jquery-1.12.4.js"></script>
<script src="https://code.jquery.com/ui/1.12.0/jquery-ui.js"></script>
     <script>
         $(document).ready(function () {
             Sys.WebForms.PageRequestManager.getInstance().add_endRequest(EndRequestHandler);
             Sys.WebForms.PageRequestManager.getInstance().beginAsyncPostBack();
             function EndRequestHandler(sender, args) {
             $('#doj').datepicker({
                 dateFormat: 'dd-mm-yy'
             });
         }
    });
</script>
              <script>
         $(document).ready(function () {
             Sys.WebForms.PageRequestManager.getInstance().add_endRequest(EndRequestHandler);
             Sys.WebForms.PageRequestManager.getInstance().beginAsyncPostBack();
             function EndRequestHandler(sender, args) {
             $('#dop').datepicker({
                 dateFormat: 'dd-mm-yy'
             });
         }
    });
</script>
               <script>
         $(document).ready(function () {
             Sys.WebForms.PageRequestManager.getInstance().add_endRequest(EndRequestHandler);
             Sys.WebForms.PageRequestManager.getInstance().beginAsyncPostBack();
             function EndRequestHandler(sender, args) {
             $('#doc').datepicker({
                 dateFormat: 'dd-mm-yy'
             });
         }
    });
</script>
               <script>
         $(document).ready(function () {
             Sys.WebForms.PageRequestManager.getInstance().add_endRequest(EndRequestHandler);
             Sys.WebForms.PageRequestManager.getInstance().beginAsyncPostBack();
             function EndRequestHandler(sender, args) {
             $('#doe').datepicker({
                 dateFormat: 'dd-mm-yy'
             });
         }
    });
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server" >
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager> <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional"><Triggers><asp:PostBackTrigger ControlID="import" /><asp:PostBackTrigger ControlID="Button1" /><%--<asp:PostBackTrigger ControlID="Dept" /><asp:PostBackTrigger ControlID="sect" />--%></Triggers><ContentTemplate>
     <link rel="stylesheet" href="//code.jquery.com/ui/1.12.0/themes/base/jquery-ui.css"> 
    <script src="https://code.jquery.com/ui/1.12.0/jquery-ui.js"></script> 
    <script>
        $(function () {
              $('[id*=doj]').datepicker({
            dateFormat:'dd-mm-yy'
        });          
        });
    </script>
        <script>
        $(function () {
              $('[id*=dop]').datepicker({
            dateFormat:'dd-mm-yy'
        });          
        });
    </script>
        <script>
        $(function () {
              $('[id*=doe]').datepicker({
            dateFormat:'dd-mm-yy'
        });          
        });
    </script>
        <script>
        $(function () {
              $('[id*=doc]').datepicker({
            dateFormat:'dd-mm-yy'
        });          
        });
    </script>
    <asp:Label ID="Label2" runat="server" Font-Size="Larger" ForeColor="Red" Text="Label" style="margin-left:40px;"></asp:Label>
  <div class="container-fluid">
      <div class="col-sm-6 col-md-6 col-lg-6">
       <h3>Upload Employee Details</h3>  <hr />  
         <div class="col-sm-6 col-md-6 col-lg-6">
            <div class="form-group">
                  Select File
                  <asp:FileUpload ID="uploadfile" runat="server" CssClass="form-control" />
                </div>
             </div>
       <div class="col-sm-2 col-md-2 col-lg-2">
             <div class="form-group"><br />
                   <asp:Button ID="import" runat="server" Text="Import" ValidationGroup="insert" cssclass="btn btn-primary" />    
                 </div>
              </div>
       <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Please select file" ControlToValidate="uploadfile" Display="None" ForeColor="Red" ValidationGroup="insert"></asp:RequiredFieldValidator>
     <asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="auto-style1" ForeColor="Red" Width="308px" ShowMessageBox="True" ShowSummary="False" ValidationGroup="insert" />
  </div>
       <div class="col-sm-6 col-md-6 col-lg-6">
            <h3>Search Details</h3> <hr />
           <div class="col-sm-3 col-md-3 col-lg-3">
            <div class="form-group">
                Department
                 <asp:DropDownList ID="department" runat="server" AutoPostBack="True" DataTextField="section_name" DataValueField="section_name"  CssClass="form-control" AppendDataBoundItems="True" >
                     <asp:ListItem Selected="True">All</asp:ListItem>
                </asp:DropDownList>
                </div></div>
            <div class="col-sm-3 col-md-3 col-lg-3">
            <div class="form-group">
                Section
                <asp:DropDownList ID="Section" runat="server" AppendDataBoundItems="True" cssclass="form-control"  AutoPostBack="True" >
                    <asp:ListItem>All</asp:ListItem>
                </asp:DropDownList>
                </div>
                </div>
              <div class="col-sm-6 col-md-6 col-lg-6">
            <div class="form-group"><br />
                <asp:Button ID="dispall" runat="server" Text="Display All" CssClass="btn btn-primary" />
                      <asp:Button ID="Button1" runat="server" Text="Export Into Excel" cssclass="btn btn-primary" />
                </div>
                  </div>
           </div>
  </div>
       <%-- <div class="container-fluid" >
            <h2>Fill Employee Details</h2><hr />
         

            <div class="col-sm-2 col-md-2 col-lg-2">
            <div class="form-group">
                Employee Code
                 <asp:TextBox ID="empcode" runat="server" AutoPostBack="True"  TabIndex="1" cssclass="form-control" placeholder="EmployeeCode"></asp:TextBox>
                </div>  </div>
               <div class="col-sm-2 col-md-2 col-lg-2">
            <div class="form-group">
                Employee Name
                  <asp:TextBox ID="emplname" runat="server" TabIndex="2" AutoCompleteType="Enabled" placeholder="EmployeeName" CssClass="form-control"></asp:TextBox>
                </div>
                   </div>
            <div class="col-sm-2 col-md-2 col-lg-2">
            <div class="form-group">Designation
                <asp:TextBox ID="desi" runat="server" cssclass="form-control" TabIndex="3"  placeholder="Designation"></asp:TextBox>
                </div>
                   </div>
            <div class="col-sm-2 col-md-2 col-lg-2">
            <div class="form-group">
                Department
                 <asp:DropDownList ID="Dept" runat="server" AutoPostBack="True" BackColor="White" ForeColor="Black" cssclass="form-control" TabIndex="4" >
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
                </div>
                   </div>
          <div class="col-sm-2 col-md-2 col-lg-2">
            <div class="form-group">
                Section
                  <asp:DropDownList ID="sect" runat="server" AppendDataBoundItems="True" AutoPostBack="True"  CssClass="form-control" TabIndex="5" >
                    <asp:ListItem>---Select---</asp:ListItem>
                </asp:DropDownList>
                </div>
                   </div>
            <div class="col-sm-2 col-md-2 col-lg-2">
            <div class="form-group">
                DOJ
                  <asp:TextBox ID="doj" runat="server" cssclass="form-control" TabIndex="6" placeholder="dd-mm-yyyy"  ></asp:TextBox>
                </div>
                   </div>
             <div class="col-sm-2 col-md-2 col-lg-2">
            <div class="form-group">
                DOP
                <asp:TextBox ID="dop" runat="server" cssclass="form-control" TabIndex="7"  placeholder="dd-mm-yyyy"  ></asp:TextBox>
                </div>
                   </div>
             <div class="col-sm-2 col-md-2 col-lg-2">
            <div class="form-group">
                DOC
                 <asp:TextBox ID="doc" runat="server"  CssClass="form-control" TabIndex="8"  placeholder="dd-mm-yyyy"  ></asp:TextBox>
                </div>
                   </div>
             <div class="col-sm-2 col-md-2 col-lg-2">
            <div class="form-group">
                DOE
                  <asp:TextBox ID="doe" runat="server"  CssClass="form-control" TabIndex="9"  placeholder="dd-mm-yyyy"  ></asp:TextBox>
                </div>
                   </div>
             <div class="col-sm-2 col-md-2 col-lg-2">
            <div class="form-group">
                Qualification
                <asp:TextBox ID="qualification" runat="server" CssClass="form-control"  TabIndex="10"  placeholder="Qualification"></asp:TextBox>
                </div>
                   </div>
             <div class="col-sm-2 col-md-2 col-lg-2">
            <div class="form-group">Previous Experience
                <asp:TextBox ID="preexp" runat="server" CssClass="form-control"  TabIndex="11"  placeholder="Previous Experience"></asp:TextBox>
                </div>
                   </div>
             <div class="col-sm-2 col-md-2 col-lg-2">
            <div class="form-group">Reporting Person Name
                 <asp:TextBox ID="reporpersonname" runat="server" CssClass="form-control"  TabIndex="12"  placeholder="Reporting PersonName"></asp:TextBox>
                </div>
                   </div>
              <div class="col-sm-2 col-md-2 col-lg-2">
            <div class="form-group">
                Review Period
            <asp:DropDownList ID="Review" runat="server" CssClass="form-control"  TabIndex="13" >
                    <asp:ListItem>---Select---</asp:ListItem>
                    <asp:ListItem>Training Period</asp:ListItem>
                    <asp:ListItem>Probation Period</asp:ListItem>
                    <asp:ListItem>Permanent Review Period</asp:ListItem>
                    <asp:ListItem>FTE Period</asp:ListItem>
                    <asp:ListItem>Contract Worker Period</asp:ListItem>
                </asp:DropDownList></div></div>
       
          <div class="col-sm-2 col-md-2 col-lg-2">
            <div class="form-group">

        <br />
                <asp:Button ID="submit" runat="server" CssClass="btn btn-primary"  TabIndex="14" Text="Submit" ValidationGroup="insert"  />
           </div></div> </div>
   
<asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="auto-style43" ForeColor="Red" Width="256px" ValidationGroup="insert" Font-Size="Larger" ShowMessageBox="True" ShowSummary="False" Height="16px" />
  <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="empcode" Display="None" ErrorMessage="Please enter employeecode" ForeColor="Red" ValidationGroup="insert"></asp:RequiredFieldValidator>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="emplname" Display="None" ErrorMessage="Please enter employee name" ForeColor="Red" ValidationGroup="insert"></asp:RequiredFieldValidator>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="desi" Display="None" ErrorMessage="Please enter designation" ForeColor="Red" ValidationGroup="insert"></asp:RequiredFieldValidator>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="Dept" Display="None" ErrorMessage="Please select department" ForeColor="Red" InitialValue="---Select---" ValidationGroup="insert"></asp:RequiredFieldValidator>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="doj" Display="None" ErrorMessage="Please select date of joining" ForeColor="Red" ValidationGroup="insert"></asp:RequiredFieldValidator>
   <%-- <asp:CompareValidator ID="CompareValidator3" runat="server" ControlToCompare="doj" ControlToValidate="dop" ErrorMessage="Incorrect date of probation" ForeColor="Red" Operator="GreaterThanEqual" ValidationGroup="insert" Display="None"></asp:CompareValidator>
    <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="doj" ControlToValidate="doc" ErrorMessage="Incorrect date of confirm" ForeColor="Red" Operator="GreaterThan" ValidationGroup="insert" Display="None"></asp:CompareValidator>--%>
    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="preexp" Display="None" ErrorMessage="Please enter previous experience" ForeColor="Red" ValidationGroup="insert"></asp:RequiredFieldValidator>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="qualification" Display="None" ErrorMessage="Please enter qualification" ForeColor="Red" ValidationGroup="insert"></asp:RequiredFieldValidator>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="Review" Display="None" ErrorMessage="Please select Review period" ForeColor="Red" InitialValue="---Select---" ValidationGroup="insert"></asp:RequiredFieldValidator>

        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="sect" Display="None" ErrorMessage="Please select section" ForeColor="Red" InitialValue="---Select---" ValidationGroup="insert"></asp:RequiredFieldValidator>--%>
        <%--<asp:CompareValidator ID="CompareValidator2" runat="server" ControlToCompare="doj" ControlToValidate="doe" ErrorMessage="Incorrect date of extend" ForeColor="Red" Operator="GreaterThan" ValidationGroup="insert" Display="None"></asp:CompareValidator>--%>
       
        <div class="container-fluid">
            <asp:GridView ID="GridView2" runat="server" Visible="false"></asp:GridView>
        </div>
          <asp:HiddenField ID="hfScrollPosition" Value="0" runat="server" />
          <div id="dvScroll"  class="divcss" onscroll="setScrollPosition(this.scrollTop);" style=" overflow: auto;
            height: 420px;
            width: auto;
            margin-left: 10px;
            margin-right: 10px;">
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"  CssClass="auto-style33" DataKeyNames="EmployeeCode"  OnRowDeleting="GridView1_RowDeleting" ShowHeaderWhenEmpty="True" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" EnableViewState="False" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowUpdating="GridView1_RowUpdating" OnRowEditing="GridView1_RowEditing" EmptyDataText="No record found" EnableTheming="True"  AllowPaging="True">
        <Columns>
              <asp:TemplateField HeaderText="Sr No">                          
                            <ItemTemplate>
                                <%#Container.DataItemIndex + 1 %>
                            </ItemTemplate>
                            <ControlStyle Width="70px" />
                            <HeaderStyle  Width="50px"  />
                            <ItemStyle  Width="50px"  />
                        </asp:TemplateField>
            <asp:TemplateField HeaderText="Emp.Code">
                <EditItemTemplate>
                   <asp:TextBox ID="empcode" runat="server" Text='<%# Bind("EmployeeCode") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("EmployeeCode") %>' Style="word-wrap:break-word;"></asp:Label>
                </ItemTemplate>
                <ControlStyle Width="100px" />
                <ItemStyle Width="100px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Emp. Name">
                <EditItemTemplate>
                    <asp:TextBox ID="empname" runat="server" Text='<%# Bind("EmployeeName") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("EmployeeName") %>' Style="word-wrap:break-word;"></asp:Label>
                </ItemTemplate>
                <ControlStyle Width="100px" />
                 <ItemStyle Width="100px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Designation">
                <EditItemTemplate>
                    <asp:TextBox ID="desc" runat="server" Text='<%# Bind("Designation") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label3" runat="server" Text='<%# Bind("Designation") %>' Style="word-wrap:break-word;"></asp:Label>
                </ItemTemplate>
                <ControlStyle Width="100px" />
                 <ItemStyle Width="100px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Department">
                <EditItemTemplate>
                    <asp:TextBox ID="dept" runat="server" Text='<%# Bind("Department") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label4" runat="server" Text='<%# Bind("Department") %>' Style="word-wrap:break-word;"></asp:Label>
                </ItemTemplate>
                <ControlStyle Width="100px" />
                 <ItemStyle Width="100px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Section">
                <EditItemTemplate>
                    <asp:TextBox ID="sect" runat="server" Text='<%# Bind("Section") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label5" runat="server" Text='<%# Bind("Section") %>' Style="word-wrap:break-word;"></asp:Label>
                </ItemTemplate>
                <ControlStyle Width="100px" />
                 <ItemStyle Width="100px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="DOJ">
                <EditItemTemplate>
                    <asp:TextBox ID="doj" runat="server" Text='<%# Eval("DOJ", "{0:dd-MM-yyyy}") %>' ></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label6" runat="server" Text='<%# IIf(Eval("DOJ", "{0:dd-MM-yyyy}") = "01-01-1900", "", Eval("DOJ", "{0:dd-MM-yyyy}")) %>' Style="word-wrap:break-word;" ></asp:Label>
                </ItemTemplate>
                <ControlStyle Width="90px" />
                 <ItemStyle Width="90px" />
            </asp:TemplateField>
            
            <asp:TemplateField HeaderText="DOP">
                <EditItemTemplate>
                    <asp:TextBox ID="dop" runat="server" Text='<%# Eval("DOP", "{0:dd-MM-yyyy}") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label7" runat="server" Text='<%# IIf(Eval("DOP", "{0:dd-MM-yyyy}") = "01-01-1900", "", Eval("DOP", "{0:dd-MM-yyyy}")) %>' Style="word-wrap:break-word;"  ></asp:Label>
                </ItemTemplate>
                <ControlStyle Width="90px" />
                 <ItemStyle Width="90px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="DOC">
                <EditItemTemplate>
                    <asp:TextBox ID="doc" runat="server" Text='<%# Eval("DOC", "{0:dd-MM-yyyy}") %>'  ></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label8" runat="server" Text='<%# IIf(Eval("DOC", "{0:dd-MM-yyyy}") = "01-01-1900", "", Eval("DOC", "{0:dd-MM-yyyy}")) %>' Style="word-wrap:break-word;" ></asp:Label>
                </ItemTemplate>
                <ControlStyle Width="90px" />
                 <ItemStyle Width="90px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="DOE">
                <EditItemTemplate>
                    <asp:TextBox ID="doe" runat="server" Text='<%# Eval("DOE", "{0:dd-MM-yyyy}") %>'  ></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label9" runat="server" Text='<%# IIf(Eval("DOE", "{0:dd-MM-yyyy}") = "01-01-1900", "", Eval("DOE", "{0:dd-MM-yyyy}")) %>' ></asp:Label>
                </ItemTemplate>
                <ControlStyle Width="90px" />
                 <ItemStyle Width="90px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Qualification">
                <EditItemTemplate>
                    <asp:TextBox ID="quali" runat="server" Text='<%# Bind("Qualification") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label10" runat="server" Text='<%# Bind("Qualification") %>' Style="word-wrap:break-word;"></asp:Label>
                </ItemTemplate>
                <ControlStyle Width="90px" />
                 <ItemStyle Width="100px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Previous Experience">
                <EditItemTemplate>
                    <asp:TextBox ID="preexp" runat="server" Text='<%# Bind("PreviousExperience") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label11" runat="server" Text='<%# Bind("PreviousExperience") %>' Style="word-wrap:break-word;"></asp:Label>
                </ItemTemplate>
                <ControlStyle Width="100px" />
                 <ItemStyle Width="100px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Reporting Person">
                <EditItemTemplate>
                    <asp:TextBox ID="reppersonname" runat="server" Text='<%# Bind("ReportingPersonName") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label12" runat="server" Text='<%# Bind("ReportingPersonName") %>' Style="word-wrap:break-word;"></asp:Label>
                </ItemTemplate>
                <ControlStyle Width="100px" />
                 <ItemStyle Width="100px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Review Period">
                <EditItemTemplate>
                  
                    <asp:DropDownList ID="review" runat="server" AutoPostBack="true" selectedvalue='<%# Bind("Review_Period") %>'>
                        <asp:ListItem>Training Period</asp:ListItem>
                    <asp:ListItem>Probation Period</asp:ListItem>
                    <asp:ListItem>Permanent Review Period</asp:ListItem>
                    <asp:ListItem>FTE Period</asp:ListItem>
                    <asp:ListItem>Contract Worker Period</asp:ListItem>
                    </asp:DropDownList>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label13" runat="server" Text='<%# Bind("Review_Period") %>' Style="word-wrap:break-word;"></asp:Label>
                </ItemTemplate>
                <ControlStyle Width="110px" />
                 <ItemStyle Width="110px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Action" ValidateRequestMode="Enabled">  
                    <ItemTemplate>   
                         <asp:LinkButton ID="lnkBtnEdit" runat="server" Text="Edit" CssClass="btn-primary"
                            OnClick="Display"  ></asp:LinkButton>
                      <%--  <asp:LinkButton ID="btn_Edit" runat="server" CommandName="Edit" CommandArgument='<%# Bind("EmployeeCode") %>'   Text="Edit"   EnableViewState="true" ViewStateMode="Inherit" CausesValidation="False"></asp:LinkButton>--%>
                    </ItemTemplate>  
                    <EditItemTemplate>  
                        <asp:LinkButton ID="btn_Update" runat="server" Text="Update" CommandName="Update" CommandArgument='<%# Bind("EmployeeCode") %>'  EnableViewState="true" ViewStateMode="Inherit" CausesValidation="False"></asp:LinkButton>
                        <asp:LinkButton ID="btn_Cancel" runat="server" Text="Cancel" CommandName="Cancel" ></asp:LinkButton>         
                    </EditItemTemplate>  
                </asp:TemplateField>
            <asp:TemplateField HeaderText="Action">
                            <ItemTemplate>
                               <asp:LinkButton ID="Delete" runat="server" CssClass="btn-primary" CommandName="Delete" Text="Delete" OnClientClick="return confirm('Are you sure you want to delete this  Record?');"></asp:LinkButton>
                                </ItemTemplate>      
                        </asp:TemplateField>
        </Columns>
        <FooterStyle BackColor="White" ForeColor="#000066" />
        <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" CssClass="stickyheader" HorizontalAlign="Center" VerticalAlign="Middle"  />
        <PagerSettings Position="TopAndBottom" />
        <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
        <RowStyle ForeColor="#000066" HorizontalAlign="Center" VerticalAlign="Middle" />
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
              <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional" ><Triggers>
               <asp:PostBackTrigger ControlID="btnSave" /> 
                 
            </Triggers>
                 <ContentTemplate>
    <link rel="stylesheet" href="//code.jquery.com/ui/1.12.0/themes/base/jquery-ui.css"> 
    <script src="https://code.jquery.com/ui/1.12.0/jquery-ui.js"></script> 
    <script>
        $(function () {
            $('[id*=doja]').datepicker({
                dateFormat: 'dd-mm-yy' 
                
                
        });          
        });
    </script>
              <script>
        $(function () {
            $('[id*=dopa]').datepicker({
                dateFormat: 'dd-mm-yy' 
                
                
        });          
        });
    </script>
              <script>
        $(function () {
            $('[id*=doca]').datepicker({
                dateFormat: 'dd-mm-yy' 
                
                
        });          
        });
    </script>
              <script>
        $(function () {
            $('[id*=doea]').datepicker({
                dateFormat: 'dd-mm-yy' 
                
                
        });          
        });
    </script>
                                  
            <div class="modal-body">  
                
                <div class="col-lg-6 col-sm-6 col-md-6 col-xs-6">                                           
                    <div class="form-group">   
                       
                       <asp:Label ID="Label1" runat="server" Text="Employee Code"></asp:Label>
                         <asp:Label ID="emplcode" runat="server"  CssClass="form-control"></asp:Label>
                         <asp:Label ID="Label30" runat="server" Text="Employee Name"></asp:Label>
                         <asp:TextBox ID="emplnm" runat="server" CssClass="form-control" ></asp:TextBox>
                        <asp:Label ID="Label14" runat="server" Text="Designation"></asp:Label>
                        <asp:TextBox ID="designation" runat="server" CssClass="form-control" ></asp:TextBox>
                        <asp:Label ID="Label3" runat="server" Text="Department"></asp:Label>
                        <asp:DropDownList ID="deptb" runat="server" AutoPostBack="true" AppendDataBoundItems="true" CssClass="form-control">
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
                       <%-- <asp:TextBox ID="depta" runat="server" CssClass="form-control" ></asp:TextBox> --%>                      
                       <asp:Label ID="Label4" runat="server" Text="Section"></asp:Label>                      
                       <%-- <asp:TextBox ID="secta" runat="server" CssClass="form-control">  </asp:TextBox> --%> 
                        <asp:DropDownList ID="sectb" runat="server" CssClass="form-control" AppendDataBoundItems="true"></asp:DropDownList>                  
                          <asp:Label ID="Label5" runat="server" Text="DOJ"></asp:Label><%--<div class="input-group">--%>
                        <asp:TextBox ID="doja" runat="server" CssClass="form-control" ></asp:TextBox><%--<span class="input-group-addon">
                        <asp:DropDownList ID="machno" runat="server" AutoPostBack="true" AppendDataBoundItems="true"><asp:ListItem Text="All"></asp:ListItem></asp:DropDownList></span></div>--%>
                          <asp:Label ID="Label8" runat="server" Text="DOP"></asp:Label>
                        <asp:TextBox ID="dopa" runat="server" CssClass="form-control"  ></asp:TextBox>
                                                             
                    </div>                  
                  </div>
                  <div class="col-lg-6 col-sm-6 col-md-6 col-xs-6"> 
                <div class="form-group"> 
                     <asp:Label ID="Label9" runat="server" Text="DOC"></asp:Label>
                        <asp:TextBox ID="doca" runat="server" CssClass="form-control"  ></asp:TextBox>
                          <asp:Label ID="Label10" runat="server" Text="DOE"></asp:Label>
                        <asp:TextBox ID="doea" runat="server" CssClass="form-control" ></asp:TextBox>
                         <asp:Label ID="Label11" runat="server" Text="Qualification"></asp:Label>
                         <asp:TextBox ID="qualific" runat="server" CssClass="form-control"  ></asp:TextBox>         
                          <asp:Label ID="Label12" runat="server" Text="Previous Experience"></asp:Label>
                   <%-- <asp:DropDownList ID="fltlocation" runat="server" AutoPostBack="true" CssClass="form-control"></asp:DropDownList> --%>  
                     <asp:TextBox ID="preexpa" runat="server" CssClass="form-control" ></asp:TextBox>
                         <asp:Label ID="Label13" runat="server" Text="Reporting Person"></asp:Label>
                        <asp:TextBox ID="reportingperson" runat="server"  CssClass="form-control" ></asp:TextBox>
                   <%-- <asp:DropDownList ID="faltitem" runat="server" AutoPostBack="true" CssClass="form-control"></asp:DropDownList>--%>
                         <asp:Label ID="Label15" runat="server" Text="Review Period"></asp:Label>
                      <%--  <asp:TextBox ID="reviewper" runat="server"  CssClass="form-control" ></asp:TextBox>--%>
                       <asp:DropDownList ID="reviewper1" runat="server" CssClass="form-control">
                   
                    <asp:ListItem>Training Period</asp:ListItem>
                    <asp:ListItem>Probation Period</asp:ListItem>
                    <asp:ListItem>Permanent Review Period</asp:ListItem>
                    <asp:ListItem>FTE Period</asp:ListItem>
                    <asp:ListItem>Contract Worker Period</asp:ListItem>
                </asp:DropDownList>
                           </div>
                    </div>                     
            </div>
           </ContentTemplate> </asp:UpdatePanel>
            <div class="modal-footer">
                <asp:Button ID="btnSave" OnClick="btnSave_Click"  runat="server" Text="Update"  CssClass="btn btn-primary" Font-Bold="true" Font-Size="Large"  />
                <button type="button" class="btn btn-primary" data-dismiss="modal" style="font:bold; font-size:large"   >
                    Cancel</button>
            </div>
        </div>
            
    </div>

              </div></div>
   <%-- <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="auto-style47" EmptyDataText="No Record Found" ShowHeaderWhenEmpty="True"  BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" style="margin-left: 19px" Width="1282px">
        <Columns>
            <asp:BoundField DataField="EmployeeCode" HeaderText="Employee Code" >
            <ControlStyle Width="70px" />
            </asp:BoundField>
            <asp:BoundField DataField="EmployeeName" HeaderText="EmployeeName" >
             <ControlStyle Width="70px" />
            </asp:BoundField>
             <asp:BoundField DataField="Department" HeaderText="Dept" >
            <ControlStyle Width="70px" />
            </asp:BoundField>
            <asp:BoundField DataField="Section" HeaderText="Sect" >
            <ControlStyle Width="70px" />
            </asp:BoundField>
            <asp:BoundField DataField="Designation" HeaderText="Designation" >
             <ControlStyle Width="70px" />
            </asp:BoundField>
            <asp:BoundField DataField="DOJ" HeaderText="Date of Joining">
            <ControlStyle Width="70px" />
            </asp:BoundField>
            <asp:BoundField DataField="DOP" HeaderText="Date of Probation">
            <ControlStyle Width="70px" />
            </asp:BoundField>
            <asp:BoundField DataField="DOC" HeaderText="Date of Confirm">
            <ControlStyle Width="70px" />
            </asp:BoundField>
            <asp:BoundField DataField="DOE" HeaderText="Date of Extend">
            <ControlStyle Width="70px" />
            </asp:BoundField>
            <asp:BoundField DataField="Qualification" HeaderText="Qualification">
            <ControlStyle Width="70px" />
            </asp:BoundField>
            <asp:BoundField DataField="PreviousExperience" HeaderText="Previous Experience">
            <ControlStyle Width="60px" />
            </asp:BoundField>
            <asp:BoundField DataField="ReportingPersonName" HeaderText="Reporting Person Name">
            <ControlStyle Width="70px" />
            </asp:BoundField>
            <asp:BoundField DataField="Review_Period" HeaderText="Review Period">
            <ControlStyle Width="70px" />
            </asp:BoundField>
             <asp:TemplateField HeaderText="Edit" ValidateRequestMode="Enabled">  
                    <ItemTemplate>   
                        <asp:LinkButton ID="btn_Edit" runat="server" CommandName="Edit" CommandArgument='<%# Bind("EmployeeCode") %>'   Text="Edit"   EnableViewState="true" ViewStateMode="Inherit" CausesValidation="False" OnClick="btn_Edit_Click"></asp:LinkButton>
                    </ItemTemplate>  
                 </asp:TemplateField>
             <asp:TemplateField HeaderText="Delete">
                            <ItemTemplate>
                               <asp:LinkButton ID="Delete" runat="server"  CommandName="Delete" Text="Delete" ></asp:LinkButton>
                                </ItemTemplate>      
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
    </asp:GridView>--%>
        
        
<%--<asp:Button ID="btnShowPopup" runat="server" style="display:none" />
        <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtender1"  runat="server" TargetControlID="btnShowPopup" PopupControlID="pnlpopup"
CancelControlID="btnCancel" ></ajaxToolkit:ModalPopupExtender>
       
        <asp:Panel ID="pnlpopup" runat="server" BackColor="White" Height="350px" Width="400px" style="display:none">
<table width="100%" style="border:Solid 3px #D55500; width:100%; height:100%" cellpadding="0" cellspacing="0">
<tr style="background-color:#D55500">
<td colspan="2" style=" height:10%; color:White; font-weight:bold; font-size:larger" align="center">User Details</td>
</tr>
<tr>
<td align="right" style=" width:45%">
EmployeeCode:
</td>
<td>
<asp:Label ID="lblID" runat="server"></asp:Label>
</td>
</tr>

<tr>
<td align="right">
EmployeeName:
</td>
<td>
<asp:TextBox ID="txtempname" runat="server"/>
</td>
</tr>
<tr>
<td align="right">
Dept:
</td>
<td>
<asp:TextBox ID="txtdept" runat="server"/>
</td>
</tr>
<tr>
<td align="right">
Sect:
</td>
<td>
<asp:TextBox ID="txtsect" runat="server"/>
</td>
</tr>
<tr>
<td align="right">
Designation:
</td>
<td>
<asp:TextBox ID="txtDesg" runat="server"/>
</td>
</tr>
    <tr>
<td align="right">
Date Of Joining:
</td>
<td>
<asp:TextBox ID="txtdoj" runat="server"/>
</td>
</tr>
    <tr>
<td align="right">
Date Of Probation:
</td>
<td>
<asp:TextBox ID="txtdop" runat="server"/>
</td>
</tr>
    <tr>
<td align="right">
Date of confirm:
</td>
<td>
<asp:TextBox ID="txtdoc" runat="server"/>
</td>
</tr>
    <tr>
<td align="right">
Date of Extend:
</td>
<td>
<asp:TextBox ID="txtdoe" runat="server"/>
</td>
</tr>
    <tr>
<td align="right">
Qualification:
</td>
<td>
<asp:TextBox ID="txtquali" runat="server"/>
</td>
</tr>
    <tr>
<td align="right">
Previous Experience:
</td>
<td>
<asp:TextBox ID="txtpreexp" runat="server"/>
</td>
</tr>
    <tr>
<td align="right">
Reporting Person Name:
</td>
<td>
<asp:TextBox ID="txtrepperson" runat="server"/>
</td>
</tr>
    <tr>
<td align="right">
Review Period:
</td>
<td>
<asp:TextBox ID="txtreview" runat="server"/>
</td>
</tr>
<tr>
<td>
</td>
<td>
<asp:Button ID="btnUpdate" CommandName="Update" runat="server" Text="Update" onclick="btnUpdate_Click"/>
<%-- <asp:Button ID="btnCancel" runat="server" Text="Cancel"  />--%>
    
<%--</td>
</tr>
</table>
</asp:Panel>
    <br />
    <asp:Label ID="lblresult" runat="server"/>--%>
    <br /></ContentTemplate></asp:UpdatePanel>
</asp:Content>
