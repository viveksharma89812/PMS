<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site1.Master" EnableEventValidation="false" CodeBehind="Employee_Score_Histry.aspx.vb" Inherits="Performance_Management_System.WebForm22" %>
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
    <style>
        .stickyheader th{
        position:sticky;
        top:0px;
        background-color:Black;
    }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
        <link href="css/boostrap-multiselect.css" rel="stylesheet" type="text/css" />
            <script src="css/boostrap-multiselect.js" type="text/javascript"></script>
            <script type="text/javascript">
                $(function () {
                    $('#tbla').multiselect({
                        includeSelectAllOption: true,   
                         enableFiltering: true,
                        filterPlaceholder: 'Search',
            enableCaseInsensitiveFiltering: true,
            dropRight: true
                    
                    });
                });
            </script>
    <style type="text/css">
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
 </style>
        <div class="container-fluid" style="font-weight:bold">
        <div class="col-sm-2 col-lg-2 col-md-3 ">        
            <div class="form-group">Select Year <br />
                <asp:ListBox ID="tbla" runat="server" AppendDataBoundItems="true" AutoPostBack="true" CssClass="btn-group" ClientIDMode="Static"  SelectionMode="Multiple"></asp:ListBox>
                </div>
        </div>
          <div class="col-sm-2 col-lg-2 col-md-3 ">
            <div class="form-group">Review Month
                <asp:DropDownList ID="revmonth" runat="server" AutoPostBack="true" AppendDataBoundItems="true" CssClass="form-control">
                    <asp:ListItem Text="All"></asp:ListItem>
                </asp:DropDownList>
                <%--<asp:ListBox ID="revimonth" runat="server" AutoPostBack="true" AppendDataBoundItems="true" CssClass="form-control" ClientIDMode="Static" SelectionMode="Multiple">

                </asp:ListBox>--%>
                </div>
              </div>
            <%-- <div class="col-sm-2 col-lg-2 col-md-2">
            <div class="form-group">To Review Month
                <asp:DropDownList ID="revmonth2" runat="server" AutoPostBack="true" AppendDataBoundItems="true" CssClass="form-control">
                    <asp:ListItem Text="All"></asp:ListItem>
                </asp:DropDownList>
                </div>
                </div>--%>
        <div class="col-sm-2 col-lg-2 col-md-3 ">
            <div class="form-group">
                Employee Code
                <asp:TextBox ID="empcode" runat="server" AutoPostBack="true" CssClass="form-control" placeholder="employee code"></asp:TextBox>
                </div>
            </div> 
            <div class="col-sm-2 col-lg-2 col-md-3 ">
            <div class="form-group">
                Employee Name
                <asp:TextBox ID="empname" runat="server" AutoPostBack="true" CssClass="form-control" placeholder="employee name"></asp:TextBox>
                </div>
            </div>
         <div class="col-sm-2 col-lg-2 col-md-3 ">
            <div class="form-group">
                Department
                <asp:DropDownList ID="dept" runat="server" AutoPostBack="true" AppendDataBoundItems="true" CssClass="form-control"><asp:ListItem Text="All"></asp:ListItem></asp:DropDownList>
                </div>
             </div>
         <div class="col-sm-2 col-lg-2 col-md-3 ">
            <div class="form-group">Section
                <asp:DropDownList ID="sect" runat="server" AutoPostBack="true" AppendDataBoundItems="true" CssClass="form-control"><asp:ListItem Text="All"></asp:ListItem></asp:DropDownList>
                </div>
             </div>
           <div class="col-sm-2 col-lg-2 col-md-3 ">
            <div class="form-group"><br />
                <asp:Button ID="Button1" runat="server" Text="Clear" CssClass="btn btn-primary" />
                &nbsp;
                <asp:LinkButton ID="export" runat="server" CssClass="btn btn-danger"><i class="fa fa-file-excel-o "></i>  Export</asp:LinkButton>
                </div></div>
    
        
    </div>
    
    
        <h3>Employee Score Record</h3>
         <asp:HiddenField ID="hfScrollPosition" Value="0" runat="server"  />
          <div id="dvScroll" class="divcss" onscroll="setScrollPosition(this.scrollTop);" style="width:auto; height:500px; overflow:auto;  border-style:groove; font-family:Calibri; Font-Size:Small " >
        <asp:GridView ID="GridView1" runat="server" EmptyDataText="No Record Found"   ShowHeaderWhenEmpty="True" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" CellSpacing="2" ForeColor="Black" AutoGenerateColumns="False" AllowPaging="True" PageSize="18" >
          
            <Columns>
               <%--  <asp:TemplateField HeaderText="ReviewForm">
           <ItemTemplate>            
               <asp:LinkButton ID="filelink" runat="server" CommandName="Editform"   Font-Bold="true"   CommandArgument='<%# Bind("EmployeeCode") %>' OnClientClick="SetTarget()"><i class="fa fa-external-link" style="font-size:24px"></i></asp:LinkButton>         
       </ItemTemplate>
           <ItemStyle Width="20px"  HorizontalAlign="Center" VerticalAlign="Middle" /><HeaderStyle Width="40px"  HorizontalAlign="Center" VerticalAlign="Middle" />
       </asp:TemplateField>--%>
                <asp:TemplateField HeaderText="Employee Code">
                    <EditItemTemplate>
                        <asp:TextBox ID="emcode" runat="server" Text='<%# Bind("EmployeeCode") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("EmployeeCode") %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle Width="80px" HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:TemplateField>
                 <asp:TemplateField HeaderText="Employee Name">
                    <EditItemTemplate>
                        <asp:TextBox ID="emname" runat="server" Text='<%# Bind("EmployeeName") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label100" runat="server" Text='<%# Bind("EmployeeName") %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle Width="80px" HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Review Month">
                    <EditItemTemplate>
                        <asp:TextBox ID="revmon" runat="server" Text='<%# Bind("ReviewMonth") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label2" runat="server" Text='<%# Bind("ReviewMonth") %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle Width="90px" HorizontalAlign="Center" VerticalAlign="Middle"  />
                </asp:TemplateField>
                  <asp:TemplateField HeaderText="Department">
                <EditItemTemplate>
                    <asp:TextBox ID="dept" runat="server" Text='<%# Bind("Department") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="dpt" runat="server" Text='<%# Bind("Department") %>' Style="word-wrap:break-word;"></asp:Label>
                </ItemTemplate>
                <ControlStyle Width="100px"  />
                 <ItemStyle Width="100px" HorizontalAlign="Center" VerticalAlign="Middle" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Section">
                <EditItemTemplate>
                    <asp:TextBox ID="sect" runat="server" Text='<%# Bind("Section") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="sct" runat="server" Text='<%# Bind("Section") %>' Style="word-wrap:break-word;"></asp:Label>
                </ItemTemplate>
                <ControlStyle Width="100px" />
                 <ItemStyle Width="100px" HorizontalAlign="Center" VerticalAlign="Middle" />
            </asp:TemplateField>
                <asp:TemplateField HeaderText="CL">
                    <EditItemTemplate>
                        <asp:TextBox ID="cla" runat="server" Text='<%# Bind("CL") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label3" runat="server" Text='<%# Bind("CL") %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle Width="50px" HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="SL">
                    <EditItemTemplate>
                        <asp:TextBox ID="sla" runat="server" Text='<%# Bind("SL") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label4" runat="server" Text='<%# Bind("SL") %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle Width="50px" HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="PL">
                    <EditItemTemplate>
                        <asp:TextBox ID="pla" runat="server" Text='<%# Bind("PL") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label5" runat="server" Text='<%# Bind("PL") %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle Width="50px" HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="LWP">
                    <EditItemTemplate>
                        <asp:TextBox ID="lwpa" runat="server" Text='<%# Bind("LWP") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label6" runat="server" Text='<%# Bind("LWP") %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle Width="50px" HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Other Leaves">
                    <EditItemTemplate>
                        <asp:TextBox ID="other" runat="server" Text='<%# Bind("OtherLeaves") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label7" runat="server" Text='<%# Bind("OtherLeaves") %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle Width="60px" HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Actual WorkingDays">
                    <EditItemTemplate>
                        <asp:TextBox ID="actworking" runat="server" Text='<%# Bind("ActualWorkingDays") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label8" runat="server" Text='<%# Bind("ActualWorkingDays") %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle Width="90px" HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Actual PresentDays">
                    <EditItemTemplate>
                        <asp:TextBox ID="actpresent" runat="server" Text='<%# Bind("ActualPresentDays") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label9" runat="server" Text='<%# Bind("ActualPresentDays") %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle Width="90px" HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Absent Days">
                    <EditItemTemplate>
                        <asp:TextBox ID="absent" runat="server" Text='<%# Bind("AbsentDays") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label10" runat="server" Text='<%# Bind("AbsentDays") %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle Width="70px" HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Leaves Scores">
                    <EditItemTemplate>
                        <asp:TextBox ID="levscore" runat="server" Text='<%# Bind("LeavesScores") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label11" runat="server" Text='<%# Bind("LeavesScores") %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle Width="60px" HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Total Score">
                    <EditItemTemplate>
                        <asp:TextBox ID="totscor" runat="server" Text='<%# Bind("TotScore") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label12" runat="server" Text='<%# Bind("TotScore") %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle Width="50px" HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Review_Dur">
                    <EditItemTemplate>
                        <asp:TextBox ID="revduring" runat="server" Text='<%# Bind("Review_Dur") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label13" runat="server" Text='<%# Bind("Review_Dur") %>'></asp:Label>
                    </ItemTemplate>
                      <ItemStyle Width="50px" HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Review">
                    <EditItemTemplate>
                        <asp:TextBox ID="revi" runat="server" Text='<%# Bind("Review") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label14" runat="server" Text='<%# Bind("Review") %>'></asp:Label>
                    </ItemTemplate>
                      <ItemStyle Width="60px" HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Total Marks">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox15" runat="server" Text='<%# Bind("TotalMarks") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label15" runat="server" Text='<%# Bind("TotalMarks") %>'></asp:Label>
                    </ItemTemplate>
                      <ItemStyle Width="50px" HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Score1">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox16" runat="server" Text='<%# Bind("Score1") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label16" runat="server" Text='<%# Bind("Score1") %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Score2">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox17" runat="server" Text='<%# Bind("Score2") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label17" runat="server" Text='<%# Bind("Score2") %>'></asp:Label>
                    </ItemTemplate>
                     <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Score3">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox18" runat="server" Text='<%# Bind("Score3") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label18" runat="server" Text='<%# Bind("Score3") %>'></asp:Label>
                    </ItemTemplate>
                     <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Score4">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox19" runat="server" Text='<%# Bind("Score4") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label19" runat="server" Text='<%# Bind("Score4") %>'></asp:Label>
                    </ItemTemplate>
                     <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Score5">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox20" runat="server" Text='<%# Bind("Score5") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label20" runat="server" Text='<%# Bind("Score5") %>'></asp:Label>
                    </ItemTemplate>
                     <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Score6">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox21" runat="server" Text='<%# Bind("Score6") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label21" runat="server" Text='<%# Bind("Score6") %>'></asp:Label>
                    </ItemTemplate>
                     <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Score7">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox22" runat="server" Text='<%# Bind("Score7") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label22" runat="server" Text='<%# Bind("Score7") %>'></asp:Label>
                    </ItemTemplate>
                     <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Score8">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox23" runat="server" Text='<%# Bind("Score8") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label23" runat="server" Text='<%# Bind("Score8") %>'></asp:Label>
                    </ItemTemplate>
                     <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Score9">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox24" runat="server" Text='<%# Bind("Score9") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label24" runat="server" Text='<%# Bind("Score9") %>'></asp:Label>
                    </ItemTemplate>
                     <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Score10">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox25" runat="server" Text='<%# Bind("Score10") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label25" runat="server" Text='<%# Bind("Score10") %>'></asp:Label>
                    </ItemTemplate>
                     <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Score11">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox28" runat="server" Text='<%# Bind("Score11") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label34" runat="server" Text='<%# Bind("Score11") %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:TemplateField>
                  <asp:TemplateField HeaderText="Score12">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox29" runat="server" Text='<%# Bind("Score12") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label35" runat="server" Text='<%# Bind("Score12") %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:TemplateField>
                  <asp:TemplateField HeaderText="Score13">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox30" runat="server" Text='<%# Bind("Score13") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label36" runat="server" Text='<%# Bind("Score13") %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:TemplateField>
                  <asp:TemplateField HeaderText="Score14">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox31" runat="server" Text='<%# Bind("Score14") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label37" runat="server" Text='<%# Bind("Score14") %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:TemplateField>
                  <asp:TemplateField HeaderText="Score15">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox32" runat="server" Text='<%# Bind("Score15") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label38" runat="server" Text='<%# Bind("Score15") %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Status">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox26" runat="server" Text='<%# Bind("Status") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label26" runat="server" Text='<%# Bind("Status") %>'></asp:Label>
                    </ItemTemplate>
                     <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Remark">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox27" runat="server" Text='<%# Bind("Remark") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label27" runat="server" Text='<%# Bind("Remark") %>'></asp:Label>
                    </ItemTemplate> <ItemStyle Width="120px"  HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:TemplateField>
                 <asp:TemplateField HeaderText="Final PBVP Amount">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox33" runat="server" Text='<%# Bind("Famnt") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label39" runat="server" Text='<%# Bind("Famnt") %>'></asp:Label>
                    </ItemTemplate> <ItemStyle Width="120px"  HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:TemplateField>
                 <asp:TemplateField HeaderText="Fixed PBVP Amount">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox34" runat="server" Text='<%# Bind("Amnt1") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label40" runat="server" Text='<%# Bind("Amnt1") %>'></asp:Label>
                    </ItemTemplate> <ItemStyle Width="120px"  HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Department Head Sign">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox45" runat="server" Text='<%# Bind("Dept_Accept") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label390" runat="server" Text='<%# Bind("Dept_Accept") %>'></asp:Label>
                    </ItemTemplate> <ItemStyle Width="120px"  HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Section Head Sign">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox46" runat="server" Text='<%# Bind("Sect_Accept") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label385" runat="server" Text='<%# Bind("Sect_Accept") %>'></asp:Label>
                    </ItemTemplate> <ItemStyle Width="120px"  HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Plant Head Sign">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox47" runat="server" Text='<%# Bind("Plheadaccept") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label380" runat="server" Text='<%# Bind("Plheadaccept") %>'></asp:Label>
                    </ItemTemplate> <ItemStyle Width="120px"  HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:TemplateField>
                  <asp:TemplateField HeaderText="Employee Sign">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox48" runat="server" Text='<%# Bind("Emp_Accept") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label370" runat="server" Text='<%# Bind("Emp_Accept") %>'></asp:Label>
                    </ItemTemplate> <ItemStyle Width="120px"  HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:TemplateField>
                 <asp:TemplateField HeaderText="Action" ValidateRequestMode="Enabled" >  
                    <ItemTemplate>   
                         <asp:LinkButton ID="lnkBtnEdit" runat="server" Text="Edit" CssClass="btn-primary"
                            OnClick="Display"  ></asp:LinkButton>                      
                    </ItemTemplate>  
                    <EditItemTemplate>  
                        <asp:LinkButton ID="btn_Update" runat="server" Text="Update" CommandName="Update" CommandArgument='<%# Bind("EmployeeCode") %>'  EnableViewState="true" ViewStateMode="Inherit" CausesValidation="False"></asp:LinkButton>
                        <asp:LinkButton ID="btn_Cancel" runat="server" Text="Cancel" CommandName="Cancel" ></asp:LinkButton>         
                    </EditItemTemplate>
               <ItemStyle VerticalAlign="Middle" HorizontalAlign="Center" />
                </asp:TemplateField>
            </Columns>
            <FooterStyle BackColor="#CCCCCC" />
            <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" CssClass="stickyheader" />
            <PagerSettings PageButtonCount="20" Position="TopAndBottom" />
            <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" VerticalAlign="Middle"  CssClass="GridPager" />
            <RowStyle BackColor="White" />
            <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="#808080" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#383838" />
        </asp:GridView>

              <div class="modal fade" id="myModal" role="dialog">
                   
    <div class="modal-dialog">
       
        <!-- Modal content-->
        <div class="modal-content" >
            <div class="modal-header">
                <button type="button" class="close" data-dismiss="modal"  >
                    &times;</button>
                <h4 class="modal-title" style="font:bold; font-size:large">
                    Employee Details</h4>
            </div>
            <div class="modal-body">  
                
                <div class="col-lg-3 col-sm-3 col-md-3 col-xs-3">                                           
                    <div class="form-group">   
                       EmployeeCode
                        <asp:Label ID="emplocode" runat="server" Text="Label" CssClass="form-control"></asp:Label>
                         EmployeeName
                        <asp:Label ID="empn" runat="server" Text="Label" CssClass="form-control"></asp:Label>
                        Review Month
                        <asp:Label ID="revimonth" runat="server" Text="Label" CssClass="form-control"></asp:Label>
                        Department
                        <asp:Label ID="dpta" runat="server" Text="Label" CssClass="form-control"></asp:Label>
                        Section
                        <asp:Label ID="scta" runat="server" Text="Label" CssClass="form-control"></asp:Label>
                             CL
                        <asp:TextBox ID="cl" runat="server" CssClass="form-control"></asp:TextBox>
                        SL
                        <asp:TextBox ID="sl" runat="server" CssClass="form-control"></asp:TextBox>
                        PL
                        <asp:TextBox ID="pl" runat="server" CssClass="form-control"></asp:TextBox>
                       
                    </div>                  
                  </div>
                     <div class="col-lg-3 col-sm-3 col-md-3 col-xs-3">    
                <div class="form-group"> 
                     LWP
                        <asp:TextBox ID="lwp" runat="server" CssClass="form-control"></asp:TextBox>
                        other Leaves
                        <asp:TextBox ID="otherleaves" runat="server" CssClass="form-control"></asp:TextBox>
                        Actual WorkingDays
                    <asp:TextBox ID="actworking" runat="server" CssClass="form-control"></asp:TextBox>
                    Actual PresentDays
                    <asp:TextBox ID="actpresent" runat="server" CssClass="form-control"></asp:TextBox>
                    Absent Days
                    <asp:TextBox ID="absentdays" runat="server" CssClass="form-control"></asp:TextBox>
                    Leaves Score
                    <asp:TextBox ID="leavesscor" runat="server" CssClass="form-control"></asp:TextBox>
                    Review During/final
                    <asp:TextBox ID="reviduring" runat="server" CssClass="form-control"></asp:TextBox>
                    

                           </div>
                    </div>  
                 <div class="col-lg-3 col-sm-3 col-md-3 col-xs-3">    
                <div class="form-group">
                    Review 
                    <asp:TextBox ID="rev" runat="server" CssClass="form-control"></asp:TextBox>
                    Status
                    <asp:TextBox ID="stat" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                    Score1
                    <asp:TextBox ID="Scor1" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                    Score2
                    <asp:TextBox ID="Scor2" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                    Score3
                    <asp:TextBox ID="scor3" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                    Score4
                    <asp:TextBox ID="Scor4" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                    Score5
                    <asp:TextBox ID="Scor5" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>                   
                </div></div>
                       <div class="col-lg-3 col-sm-3 col-md-3 col-xs-3">    
                <div class="form-group">
                     Score6
                    <asp:TextBox ID="Scor6" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                    Score7
                    <asp:TextBox ID="Scor7" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                    Score8
                    <asp:TextBox ID="Scor8" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                    Score9
                    <asp:TextBox ID="Scor9" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                    Score10
                    <asp:TextBox ID="Scor10" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                     Score11
                    <asp:TextBox ID="Scor11" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                     Score12
                    <asp:TextBox ID="Scor12" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                     Score13
                    <asp:TextBox ID="Scor13" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                     Score14
                    <asp:TextBox ID="Scor14" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                     Score15
                    <asp:TextBox ID="Scor15" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>


                    Total Marks
                    <asp:TextBox ID="totmark" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                    Remark
                    <asp:TextBox ID="remark" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                Final PBVP Amount
                    <asp:TextBox ID="famnt" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                Fixed PBVP Amount
                    <asp:TextBox ID="amnt" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                    Department Head Sign
                    <asp:TextBox ID="Dheadsi" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                    Section Head Sign
                    <asp:TextBox ID="Sheadsi" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                    Plant Head Sign
                    <asp:TextBox ID="Plheadsi" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                    Employee Sign
                    <asp:TextBox ID="empsi" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                </div>
                     </div>

                <%--<div class="col-lg-3 col-sm-3 col-md-3 col-xs-3">    
                <div class="form-group">
                     Score6
                    <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                    Score7
                    <asp:TextBox ID="TextBox2" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                    Score8
                    <asp:TextBox ID="TextBox3" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                    Score9
                    <asp:TextBox ID="TextBox4" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                    Score10
                    <asp:TextBox ID="TextBox5" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                    Total Marks
                    <asp:TextBox ID="TextBox6" runat="server" CssClass="form-control"></asp:TextBox>
                    Remark
                    <asp:TextBox ID="TextBox7" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                    </div>
                     </div>--%>
                
            </div>
        
            <div class="modal-footer">
               
                <asp:Button ID="Button2" OnClick="btndel_Click"  runat="server" Text="Delete"  CssClass="btn btn-primary" Font-Bold="true" />
                <asp:Button ID="btnSave" OnClick="btnSave_Click"  runat="server" Text="Update"  CssClass="btn btn-primary" Font-Bold="true"   />
                <button type="button" class="btn btn-primary" data-dismiss="modal" style="font:bold; "   >
                    Cancel</button>
            </div>
        </div></div></div>
    </div><br />
 
</asp:Content>
