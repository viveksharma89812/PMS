<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site1.Master" EnableEventValidation="false" CodeBehind="Employee_Record_Histry.aspx.vb" Inherits="Performance_Management_System.WebForm21" %>
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
    <%-- <script>
    var logoutUser = false;
    var timeoutHnd = null;
    var logouTimeInterval = 6;// Sixty Second
     function onuser_activite()
     {
        if (logoutUser)
        {
             ;
        }
        else
        {
             ResetLogOutTimer();
        }
      }
     function OnTimeoutReached()
     {
            logoutUser = true;
            alert("Your Was Session Expired");
            window.location.href = "login.aspx";

     }
     function ResetLogOutTimer()
     {
            clearTimeout(timeoutHnd);
            // set new timer
            timeoutHnd = setTimeout('OnTimeoutReached();',logouTimeInterval);
     }     
</script>
      <script>document.body.onclick = onuser_activite; timeoutHnd = setTimeout('OnTimeoutReached();',logouTimeInterval);  </script>
            <%--Prevent back--%>
<%--  <script type = "text/javascript" > 
      function preventBack() { window.history.forward(); }
      setTimeout("preventBack()", 0);
      window.onunload = function () { null };
</script>--%>
    <style>
         .stickyheader th{
        position:sticky;
        top:0px;
        background-color:#006699;
    }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container-fluid" style="font-weight:bold">
            <h3>Search Details</h3> <hr />
            <div class="col-sm-2 col-md-2 col-lg-2">
            <div class="form-group">
                Employee Code
                <asp:TextBox ID="empcode" runat="server" CssClass="form-control" AutoPostBack="true" placeholder="employee code"></asp:TextBox>
                </div>
                </div>
           <div class="col-sm-2 col-md-2 col-lg-2">
            <div class="form-group">
                Department
                 <asp:DropDownList ID="department" runat="server" AutoPostBack="True" DataTextField="section_name" DataValueField="section_name"  CssClass="form-control" AppendDataBoundItems="True" >
                     <asp:ListItem Selected="True">All</asp:ListItem>
                </asp:DropDownList>
                </div></div>
            <div class="col-sm-2 col-md-2 col-lg-2">
            <div class="form-group">
                Section
                <asp:DropDownList ID="Section" runat="server" AppendDataBoundItems="True" cssclass="form-control"  AutoPostBack="True" >
                    <asp:ListItem>All</asp:ListItem>
                </asp:DropDownList>
                </div>
                </div>
              <div class="col-sm-4 col-md-4 col-lg-4">
            <div class="form-group"><br />
                <asp:Button ID="dispall" runat="server" Text="Display All" CssClass="btn btn-primary" />
                     <asp:LinkButton ID="export" runat="server" CssClass="btn btn-danger"><i class="fa fa-file-excel-o "></i>  Export</asp:LinkButton>
                </div>
                  </div>
        </div>
      <asp:HiddenField ID="hfScrollPosition" Value="0" runat="server" />
          <div id="dvScroll"  class="divcss" onscroll="setScrollPosition(this.scrollTop);" style=" overflow: auto;
            height: 450px;
            width: auto;
            margin-left: 10px;
            margin-right: 10px;">
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"  CssClass="auto-style33" DataKeyNames="EmployeeCode"  ShowHeaderWhenEmpty="True" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" EnableViewState="False"  EmptyDataText="No record found" EnableTheming="True"  AllowPaging="True">
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
                    <asp:Label ID="Label18" runat="server" Text='<%# IIf(Eval("DOT", "{0:dd-MM-yyyy}") = "01-01-1900", "", Eval("DOT", "{0:dd-MM-yyyy}")) %>' Style="word-wrap:break-word;" ></asp:Label>
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
                    <asp:Label ID="Label19" runat="server" Text='<%# IIf(Eval("Contract_Renew", "{0:dd-MM-yyyy}") = "01-01-1900", "", Eval("Contract_Renew", "{0:dd-MM-yyyy}")) %>' Style="word-wrap:break-word;" ></asp:Label>
                </ItemTemplate>
                <ControlStyle Width="90px" />
                 <ItemStyle Width="90px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Contract Expire">
                <EditItemTemplate>
                    <asp:TextBox ID="Contract_Expire" runat="server" Text='<%# Eval("Contract_Expire", "{0:dd-MM-yyyy}") %>' ></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label20" runat="server" Text='<%# IIf(Eval("Contract_Expire", "{0:dd-MM-yyyy}") = "01-01-1900", "", Eval("Contract_Expire", "{0:dd-MM-yyyy}")) %>' Style="word-wrap:break-word;" ></asp:Label>
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
            <%-- <asp:TemplateField HeaderText="Left Date">
                  <EditItemTemplate>
                      <asp:TextBox ID="lftdate" runat="server" Text='<%# Bind("LeftDate") %>'></asp:TextBox>
                  </EditItemTemplate>
                  <ItemTemplate>
                      <asp:Label ID="lft" runat="server" Text='<%# Bind("LeftDate") %>'></asp:Label>
                  </ItemTemplate>
              </asp:TemplateField>
            --%> <asp:TemplateField HeaderText="MRI Experience">
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
                      <asp:Label ID="Label25" runat="server" Text='<%# Bind("PMS_Form_Category") %>'></asp:Label>
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
    </asp:GridView></div><br />
</asp:Content>
