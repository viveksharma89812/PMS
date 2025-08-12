<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site1.Master" Culture="en-GB"  EnableEventValidation="false" MaintainScrollPositionOnPostback="true" CodeBehind="Upload_Details.aspx.vb" Inherits="Performance_Management_System.WebForm3"  %>

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
        .GridPager a, .GridPager span {
    display: block;
    height: 20px;
    /*width: 15px;*/
    font-weight: bold;
    text-align: center;
    text-decoration: none;
    padding-left: 6px;
    padding-right: 6px;
}

.GridPager a {
    background-color: #336666;
    color: black;
    border: 1px solid #969696;
}

.GridPager span {
    background-color: #A1DCF2;
    color: black;
    /*border: 1px solid #3AC0F2;*/
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
                  dateFormat: 'dd/mm/yy',
                 changeMonth: true,
                        changeYear: true,
             });
         }
    });
</script>
         <script>
         $(document).ready(function () {
             Sys.WebForms.PageRequestManager.getInstance().add_endRequest(EndRequestHandler);
             Sys.WebForms.PageRequestManager.getInstance().beginAsyncPostBack();
             function EndRequestHandler(sender, args) {
             $('#dot').datepicker({
                  dateFormat: 'dd/mm/yy',
                 changeMonth: true,
                        changeYear: true,
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
                 dateFormat: 'dd/mm/yy',
                 changeMonth: true,
                        changeYear: true,
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
                  dateFormat: 'dd/mm/yy',
                 changeMonth: true,
                        changeYear: true,
             });
         }
    });
</script>
         <script>
         $(document).ready(function () {
             Sys.WebForms.PageRequestManager.getInstance().add_endRequest(EndRequestHandler);
             Sys.WebForms.PageRequestManager.getInstance().beginAsyncPostBack();
             function EndRequestHandler(sender, args) {
             $('#Contract_Renew').datepicker({
                  dateFormat: 'dd/mm/yy',
                 changeMonth: true,
                        changeYear: true,
             });
         }
    });
</script>
     <script>
         $(document).ready(function () {
             Sys.WebForms.PageRequestManager.getInstance().add_endRequest(EndRequestHandler);
             Sys.WebForms.PageRequestManager.getInstance().beginAsyncPostBack();
             function EndRequestHandler(sender, args) {
             $('#Contract_Expire').datepicker({
                  dateFormat: 'dd/mm/yy',
                 changeMonth: true,
                        changeYear: true,
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
                
                  dateFormat: 'dd/mm/yy',
                 changeMonth: true,
                        changeYear: true,
             });
         }
    });
</script>
     <meta charset="utf-8" />  
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />  
    <link href="Content/bootstrap.cosmo.min.css" rel="stylesheet" />  
    <link href="Content/StyleSheet.css" rel="stylesheet" /> 
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server" >

     <link rel="stylesheet" href="//code.jquery.com/ui/1.12.0/themes/base/jquery-ui.css"> 
    <script src="https://code.jquery.com/ui/1.12.0/jquery-ui.js"></script> 
    <script>
        $(function () {
              $('[id*=doj]').datepicker({
             dateFormat: 'dd/mm/yy',
                 changeMonth: true,
                        changeYear: true,
        });          
        });
    </script>
     <script>
        $(function () {
              $('[id*=dot]').datepicker({
             dateFormat: 'dd/mm/yy',
                 changeMonth: true,
                        changeYear: true,
        });          
        });
    </script>
   
        <script>
        $(function () {
              $('[id*=dop]').datepicker({
            dateFormat: 'dd/mm/yy',
                 changeMonth: true,
                        changeYear: true,
        });          
        });
    </script>
        <script>
        $(function () {
              $('[id*=doe]').datepicker({
           dateFormat: 'dd/mm/yy',
                 changeMonth: true,
                        changeYear: true,
        });          
        });
    </script>
        <script>
        $(function () {
              $('[id*=doc]').datepicker({
             dateFormat: 'dd/mm/yy',
                 changeMonth: true,
                        changeYear: true,
        });          
            });
    </script>
      <script>
        $(function () {
              $('[id*=Contract_Renew]').datepicker({
             dateFormat: 'dd/mm/yy',
                 changeMonth: true,
                        changeYear: true,
        });          
        });
    </script>
    <script>
        $(function () {
              $('[id*=Contract_Expire]').datepicker({
             dateFormat: 'dd/mm/yy',
                 changeMonth: true,
                        changeYear: true,
        });          
        });
    </script>
    <asp:Label ID="Label2" runat="server" Font-Size="Larger" ForeColor="Red" Text="Label" style="margin-left:40px;"></asp:Label>
  <div class="container-fluid" style="font-weight:bold">
      <div class="col-sm-5 col-md-5 col-lg-5">
       <h3>Upload Employee Details</h3>  <hr />  
         <div class="col-sm-8 col-md-8 col-lg-8">
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
             <div class="col-sm-4 col-md-4 col-lg-4">
            <div class="form-group">
                Employee Code
                <asp:TextBox ID="empcode" runat="server" CssClass="form-control"  AutoPostBack="true" placeholder="Emp Code"></asp:TextBox>
                </div>
                 </div>
           <div class="col-sm-4 col-md-4 col-lg-4">
            <div class="form-group">
                Department
                 <asp:DropDownList ID="department" runat="server" AutoPostBack="True" DataTextField="section_name" DataValueField="section_name"  CssClass="form-control" AppendDataBoundItems="True" >
                     <asp:ListItem Selected="True">All</asp:ListItem>
                </asp:DropDownList>
                </div></div>
            <div class="col-sm-4 col-md-4 col-lg-4">
            <div class="form-group">
                Section
                <asp:DropDownList ID="Section" runat="server" AppendDataBoundItems="True" cssclass="form-control"  AutoPostBack="True" >
                    <asp:ListItem>All</asp:ListItem>
                </asp:DropDownList>
                </div>
                </div>
              <div class="col-sm-6 col-md-6 col-lg-6">
            <div class="form-group">
                <asp:Button ID="dispall" runat="server" Text="Display All" CssClass="btn btn-primary" />
                <asp:LinkButton ID="export" runat="server" CssClass="btn btn-danger"><i class="fa fa-file-excel-o "></i>  Export</asp:LinkButton>
                     
                </div>
                  </div>
           </div>
  </div>
    
        <div class="container-fluid">
            
            <asp:GridView ID="GridView2" runat="server" Visible="false" CssClass="table table-striped table-bordered table-hover"></asp:GridView>
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
              <asp:TemplateField HeaderText="Grade">
                  <EditItemTemplate>
                      <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("Grade") %>'></asp:TextBox>
                  </EditItemTemplate>
                  <ItemTemplate>
                      <asp:Label ID="Label18" runat="server" Text='<%# Bind("Grade") %>'></asp:Label>
                  </ItemTemplate>
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
             <asp:TemplateField HeaderText="DOT">
                <EditItemTemplate>
                    <asp:TextBox ID="dot" runat="server" Text='<%# Eval("DOT", "{0:dd-MM-yyyy}") %>' ></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label22" runat="server" Text='<%# IIf(Eval("DOT", "{0:dd-MM-yyyy}") = "01-01-1900", "", Eval("DOT", "{0:dd-MM-yyyy}")) %>' Style="word-wrap:break-word;" ></asp:Label>
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
                 <asp:TemplateField HeaderText="Contract Renew">
                <EditItemTemplate>
                    <asp:TextBox ID="Contract_Renew" runat="server" Text='<%# Eval("Contract_Renew", "{0:dd-MM-yyyy}") %>' ></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label23" runat="server" Text='<%# IIf(Eval("Contract_Renew", "{0:dd-MM-yyyy}") = "01-01-1900", "", Eval("Contract_Renew", "{0:dd-MM-yyyy}")) %>' Style="word-wrap:break-word;" ></asp:Label>
                </ItemTemplate>
                <ControlStyle Width="90px" />
                 <ItemStyle Width="90px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Contract Expire">
                <EditItemTemplate>
                    <asp:TextBox ID="Contract_Expire" runat="server" Text='<%# Eval("Contract_Expire", "{0:dd-MM-yyyy}") %>' ></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label24" runat="server" Text='<%# IIf(Eval("Contract_Expire", "{0:dd-MM-yyyy}") = "01-01-1900", "", Eval("Contract_Expire", "{0:dd-MM-yyyy}")) %>' Style="word-wrap:break-word;" ></asp:Label>
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
              <asp:TemplateField HeaderText="Increment Paid/Unpaid">
                  <EditItemTemplate>
                      <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("IncrementDetail") %>'></asp:TextBox>
                  </EditItemTemplate>
                  <ItemTemplate>
                      <asp:Label ID="Label14" runat="server" Text='<%# Bind("IncrementDetail") %>'></asp:Label>
                  </ItemTemplate>
              </asp:TemplateField>
              <asp:TemplateField HeaderText="Percentage of Getting">
                  <EditItemTemplate>
                      <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("PercentOfGet") %>'></asp:TextBox>
                  </EditItemTemplate>
                  <ItemTemplate>
                      <asp:Label ID="Label15" runat="server" Text='<%# Bind("PercentOfGet") %>'></asp:Label>
                  </ItemTemplate>
              </asp:TemplateField>
              <asp:TemplateField HeaderText="Increment EffectiveDate">
                  <EditItemTemplate>
                      <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("Increment_EffectiveDate") %>'></asp:TextBox>
                  </EditItemTemplate>
                  <ItemTemplate>
                      <asp:Label ID="Label16" runat="server" Text='<%# Bind("Increment_EffectiveDate") %>'></asp:Label>
                  </ItemTemplate>
              </asp:TemplateField>
              <asp:TemplateField HeaderText="No of Extension">
                  <EditItemTemplate>
                      <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("NoOfExtension") %>'></asp:TextBox>
                  </EditItemTemplate>
                  <ItemTemplate>
                      <asp:Label ID="Label17" runat="server" Text='<%# Bind("NoOfExtension") %>'></asp:Label>
                  </ItemTemplate>
              </asp:TemplateField>

             <asp:TemplateField HeaderText="MRI Experience">
                  <EditItemTemplate>
                      <asp:TextBox ID="mriexp" runat="server" Text='<%# Bind("MRIExperience") %>'></asp:TextBox>
                  </EditItemTemplate>
                  <ItemTemplate>
                      <asp:Label ID="mriep" runat="server" Text='<%# Bind("MRIExperience") %>'></asp:Label>
                  </ItemTemplate>
              </asp:TemplateField>
              <asp:TemplateField HeaderText="PMS Form Category">
                  <EditItemTemplate>
                      <asp:TextBox ID="PMS_Form_Category" runat="server" Text='<%# Bind("PMS_Form_Category") %>'></asp:TextBox>
                  </EditItemTemplate>
                  <ItemTemplate>
                      <asp:Label ID="Label31" runat="server" Text='<%# Bind("PMS_Form_Category") %>'></asp:Label>
                  </ItemTemplate>
              </asp:TemplateField>
            <asp:TemplateField HeaderText="Action" ValidateRequestMode="Enabled">  
                    <ItemTemplate>   
                         <asp:LinkButton ID="lnkBtnEdit" runat="server" Text="Edit" CssClass="btn-primary"
                            OnClick="Display"  ></asp:LinkButton>
               
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
        <EmptyDataRowStyle Font-Bold="True" Font-Size="Large" HorizontalAlign="Center" VerticalAlign="Middle" />
        <FooterStyle BackColor="White" ForeColor="#000066" />
        <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" CssClass="stickyheader" HorizontalAlign="Center" VerticalAlign="Middle"  />

        <PagerSettings Position="TopAndBottom" />
         <PagerSettings PageButtonCount="20" />
        <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" VerticalAlign="Middle"  CssClass="GridPager" />
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
        <div class="modal-content">
            <div class="modal-header">
                <button type="button" class="close" data-dismiss="modal">
                    </button>
                <h4 class="modal-title" style="font:bold; font-size:large">
                    Employee Details</h4>
            </div>
           
    <link rel="stylesheet" href="//code.jquery.com/ui/1.12.0/themes/base/jquery-ui.css"> 
    <script src="https://code.jquery.com/ui/1.12.0/jquery-ui.js"></script> 
    <script>
        $(function () {
            $('[id*=doja]').datepicker({
                 dateFormat: 'dd/mm/yy',
                 changeMonth: true,
                        changeYear: true,
                
                
        });          
        });
    </script>
             <script>
        $(function () {
              $('[id*=dota]').datepicker({
             dateFormat: 'dd/mm/yy',
                 changeMonth: true,
                        changeYear: true,
        });          
        });
    </script>
              <script>
        $(function () {
            $('[id*=dopa]').datepicker({
                dateFormat: 'dd/mm/yy',
                 changeMonth: true,
                        changeYear: true,
                
                
        });          
        });
    </script>
              <script>
        $(function () {
            $('[id*=doca]').datepicker({
                dateFormat: 'dd/mm/yy',
                 changeMonth: true,
                        changeYear: true,
                
                
        });          
        });
    </script>
             <script>
        $(function () {
              $('[id*=Contract_Renew]').datepicker({
             dateFormat: 'dd/mm/yy',
                 changeMonth: true,
                        changeYear: true,
        });          
        });
    </script>
    <script>
        $(function () {
              $('[id*=Contract_Expire]').datepicker({
             dateFormat: 'dd/mm/yy',
                 changeMonth: true,
                        changeYear: true,
        });          
        });
    </script>
              <script>
        $(function () {
            $('[id*=doea]').datepicker({
                dateFormat: 'dd/mm/yy',
                 changeMonth: true,
                        changeYear: true,
                
                
        });          
        });
    </script>
                      <script>
        $(function () {
            $('[id*=incredate]').datepicker({
                dateFormat: 'dd/mm/yy',
                 changeMonth: true,
                        changeYear: true,
                
                
        });          
        });
    </script>
 
                                  
            <div class="modal-body">  
                
                <div class="col-lg-4 col-sm-4 col-md-4 col-xs-4">                                           
                    <div class="form-group">   
                       
                       <asp:Label ID="Label1" runat="server" Text="Employee Code"></asp:Label>
                         <asp:Label ID="emplcode" runat="server"  CssClass="form-control"></asp:Label>
                         <asp:Label ID="Label30" runat="server" Text="Employee Name"></asp:Label>
                         <asp:TextBox ID="emplnm" runat="server" CssClass="form-control" ></asp:TextBox>
                        <asp:Label ID="Label14" runat="server" Text="Designation"></asp:Label>
                        <asp:TextBox ID="designation" runat="server" CssClass="form-control" ></asp:TextBox>
                        <asp:Label ID="gra" runat="server" Text="Grade"></asp:Label>
                        <asp:TextBox ID="grad" runat="server" CssClass="form-control"></asp:TextBox>
                        <asp:Label ID="Label3" runat="server" Text="Department"></asp:Label>
                        <asp:TextBox ID="depta" runat="server" CssClass="form-control"></asp:TextBox>                                                         
                       <asp:Label ID="Label4" runat="server" Text="Section"></asp:Label>                      
                        <asp:TextBox ID="secta" runat="server" CssClass="form-control"></asp:TextBox>                                    
                          <asp:Label ID="Label5" runat="server" Text="DOJ"></asp:Label>
                        <asp:TextBox ID="doja" runat="server" CssClass="form-control" ></asp:TextBox>
                      
                                                                              
                    </div>                  
                  </div>
                <div class="col-lg-4 col-sm-4 col-md-4 col-xs-4"> 
                <div class="form-group">
                      <asp:Label ID="Label29" runat="server" Text="DOT"></asp:Label>
                         <asp:TextBox ID="dota" runat="server" CssClass="form-control" ></asp:TextBox>
                     <asp:Label ID="Label8" runat="server" Text="DOP"></asp:Label>
                        <asp:TextBox ID="dopa" runat="server" CssClass="form-control"  ></asp:TextBox>
                              <asp:Label ID="Label9" runat="server" Text="DOC"></asp:Label>
                        <asp:TextBox ID="doca" runat="server" CssClass="form-control"  ></asp:TextBox>
                      <asp:Label ID="Label33" runat="server" Text="Contract Renew"></asp:Label>
                         <asp:TextBox ID="Contract_Renew" runat="server" CssClass="form-control" ></asp:TextBox>
                        <asp:Label ID="Label34" runat="server" Text="Contract Expire"></asp:Label>
                        <asp:TextBox ID="Contract_Expire" runat="server" CssClass="form-control" ></asp:TextBox>   
                  
                      <asp:Label ID="Label10" runat="server" Text="DOE"></asp:Label>
                    <asp:TextBox ID="doea" runat="server" CssClass="form-control" ></asp:TextBox>  
                         <asp:Label ID="Label11" runat="server" Text="Qualification"></asp:Label>
                         <asp:TextBox ID="qualific" runat="server" CssClass="form-control"  ></asp:TextBox>         
                          <asp:Label ID="Label12" runat="server" Text="Previous Experience"></asp:Label>
                  
                     <asp:TextBox ID="preexpa" runat="server" CssClass="form-control" ></asp:TextBox>
                         <asp:Label ID="Label13" runat="server" Text="Reporting Person"></asp:Label>
                        <asp:TextBox ID="reportingperson" runat="server"  CssClass="form-control" ></asp:TextBox>
                 
                         <asp:Label ID="Label15" runat="server" Text="Review Period"></asp:Label>
                    <asp:TextBox ID="reviewperioda" runat="server" CssClass="form-control"></asp:TextBox>
               
                   
                           </div>
                    </div>    
                 <div class="col-lg-4 col-sm-4 col-md-4 col-xs-4"> 
                <div class="form-group"> 
                     <asp:Label ID="Label18" runat="server" Text="Increment Detail"></asp:Label>
                    <asp:TextBox ID="incredetail" runat="server" CssClass="form-control"></asp:TextBox>
                    <asp:Label ID="Label19" runat="server" Text="Percent Of Get"></asp:Label>
                    <asp:TextBox ID="perget" runat="server" CssClass="form-control"></asp:TextBox>
                    <asp:Label ID="Label20" runat="server" Text="Increment EffectiveDate"></asp:Label>
                    <asp:TextBox ID="incredate" runat="server" CssClass="form-control"></asp:TextBox>
                    <asp:Label ID="Label21" runat="server" Text="NO of Extension"></asp:Label>
                    <asp:TextBox ID="noofextend" runat="server" CssClass="form-control"></asp:TextBox>
                    MRI Experience
                    <asp:TextBox ID="mriexperience" runat="server" CssClass="form-control"></asp:TextBox>
                        <asp:Label ID="Label38" runat="server" Text="PMS Form Category"></asp:Label>
                        <asp:TextBox ID="PMS_Form_Category" runat="server" CssClass="form-control" ></asp:TextBox>

                    </div>
                     </div>
            </div>
        
            <div class="modal-footer">
                <asp:Button ID="btnSave" OnClick="btnSave_Click"  runat="server" Text="Update"  CssClass="btn btn-primary" Font-Bold="true" Font-Size="Large"  />
                <button type="button" class="btn btn-primary" data-dismiss="modal" style="font:bold; font-size:large"   >
                    Cancel</button>
            </div>
        </div>
            
    </div>

              </div></div>
  
    <br />
</asp:Content>
