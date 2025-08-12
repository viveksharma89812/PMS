<%--<%@ Page Title="" Language="vb"   AutoEventWireup="false" Culture="en-GB" MasterPageFile="~/Site1.Master" CodeBehind="Import_excel.aspx.vb" Inherits="Performance_Management_System.WebForm4" %>
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
                 
             <div class="form-group" ><br />
                  <asp:CheckBox ID="linechecked" runat="server" text=" Line Send" BackColor="Green" Style="display:none;" /> <asp:Button ID="Button1" runat="server" Text="Import" ValidationGroup="insert" cssclass="btn btn-primary" />    <asp:LinkButton ID="send" runat="server" CssClass="btn btn-success" OnClientClick="return confirm('Are you sure you want to send the mail?');">Send Mail <i class="fa fa-send"></i>  </asp:LinkButton>    
                 </div>
              </div>
         <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Please select file" ControlToValidate="FileUpload1" Display="None" ForeColor="Red" ValidationGroup="insert"></asp:RequiredFieldValidator>
     <asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="auto-style1" ForeColor="Red" Width="308px" ShowMessageBox="True" ShowSummary="False" ValidationGroup="insert" />
     </div>

       
         <asp:HiddenField ID="hfScrollPosition" Value="0" runat="server"  />
          <div id="dvScroll" class="divcss" onscroll="setScrollPosition(this.scrollTop);" style="width:730px; height:auto;  grid-column-gap:inherit;  border-style:groove; font-family:Calibri; Font-Size:Small " >
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
</asp:Content>--%>


<%@ Page Title="" Language="vb" AutoEventWireup="false" Culture="en-GB" MasterPageFile="~/Site1.Master" CodeBehind="Import_excel.aspx.vb" Inherits="Performance_Management_System.WebForm4" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style4 {
            margin-left: 276px;
        }

         .reopen-button {
        padding: 8px 20px;
        border: none;
        border-radius: 4px;
        font-weight: bold;
        color: white;
        transition: background-color 0.3s ease, cursor 0.3s ease;
    }

    .reopen-button:disabled {
        background-color: #cccccc;
        cursor: not-allowed;
    }

    .reopen-button:not(:disabled) {
        background-color: #006699;
        cursor: pointer;
    }
    </style>
    <script src="https://code.jquery.com/jquery-1.11.3.min.js" type="text/javascript"></script>
    <script type="text/javascript">   
        $(document).ready(function () {
            maintainScrollPosition();
            disableReopenButton();
        });
        function pageLoad() {
            maintainScrollPosition();
            disableReopenButton();
        }
        function maintainScrollPosition() {
            $("#dvScroll").scrollTop($('#<%=hfScrollPosition.ClientID%>').val());
        }   
        function setScrollPosition(scrollValue) {
            $('#<%=hfScrollPosition.ClientID%>').val(scrollValue);
        }




        var clickCount = 0;
        var clickTimeout;

        function handleSecretClick() {
            clickCount++;

            if (clickTimeout) clearTimeout(clickTimeout);

            clickTimeout = setTimeout(() => {
                clickCount = 0;
            }, 3000);

            if (clickCount === 3) {
                enableReopenButton();
                clickCount = 0;
            }
        }


        function disableReopenButton() {
            var btn = document.getElementById("<%= reopenBtn.ClientID %>");
    btn.disabled = true;
    btn.style.backgroundColor = "#cccccc";
    btn.style.cursor = "not-allowed";
}

function enableReopenButton() {
            var btn = document.getElementById("<%= reopenBtn.ClientID %>");
            btn.disabled = false;
            btn.style.backgroundColor = "#006699";
            btn.style.cursor = "pointer";
        }

    </script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:ScriptManager ID="ScriptManager1" runat="server" />

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <Triggers>
            <asp:PostBackTrigger ControlID="ReSalesImportbtn" />
            <asp:PostBackTrigger ControlID="Button1" />
              <asp:PostBackTrigger ControlID="DownloadSampleBtn" />
        </Triggers>
        <ContentTemplate>
            <br />
            <div class="container" style="font-weight:bold">
                <div style="display: flex; justify-content: space-between; align-items: center;">
                     <div style="display: flex; align-items: center; gap: 10px;">
      <%--  <button id="secretTriggerBtn" type="button" onclick="handleSecretClick()" 
            ">
            
        </button>--%>
        <h2>  <span style="cursor:pointer;" onclick="handleSecretClick()">Upload</span> Attendance Excel File</h2>
    </div>
                    <h2>Upload ReSales Excel File</h2>
                </div>
                <hr />

                <div class="row">
                    <!-- Attendance Section -->
                    <div class="col-sm-6">
                        <div class="form-group">
                            <label>Select Attendance File</label>
                            <asp:FileUpload ID="FileUpload1" runat="server" CssClass="form-control" />
                        </div>
                        <div class="form-group">
                            <asp:CheckBox ID="linechecked" runat="server" Text=" Line Send" BackColor="Green" Style="display:none;" />
                            <asp:Button ID="Button1" runat="server" Text="Import Attendance" ValidationGroup="insert" CssClass="btn btn-primary" />
                            <asp:LinkButton ID="send" runat="server" CssClass="btn btn-success" OnClientClick="return confirm('Are you sure you want to send the mail?');">
                                Send Mail <i class="fa fa-send"></i>
                            </asp:LinkButton>
                        </div>
                    </div>

                    <!-- ReSales Section -->
                    <div class="col-sm-6">
                        <div class="form-group">
                            <label>Select ReSales File</label>
                            <asp:FileUpload ID="FileUpload2" runat="server" CssClass="form-control" />
                        </div>
                        <div class="form-group">
                            <asp:Button ID="ReSalesImportbtn" runat="server" Text="Import" CssClass="btn btn-primary" OnClick="ReSalesImportbtn_Click" />
                             <%--<asp:Button ID="RefreshBtn" runat="server" Text="Refresh" CssClass="btn btn-danger ml-2" OnClick="RefreshBtn_Click" />--%>
                             <asp:Button ID="DownloadSampleBtn" runat="server" Text="Download Sample" CssClass="btn btn-success ml-2" OnClick="DownloadSampleBtn_Click" />
                           
                        </div>
                    </div>
                </div>

                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                    ErrorMessage="Please select file" ControlToValidate="FileUpload1"
                    Display="None" ForeColor="Red" ValidationGroup="insert" />

                <asp:ValidationSummary ID="ValidationSummary1" runat="server"
                    CssClass="auto-style1" ForeColor="Red" Width="308px"
                    ShowMessageBox="True" ShowSummary="False" ValidationGroup="insert" />
            </div>

            <!-- Scroll-Aware GridView -->
            <asp:HiddenField ID="hfScrollPosition" Value="0" runat="server" />
            <div style="display: flex; gap: 20px; align-items: flex-start;">
                <div id="dvScroll" class="divcss" onscroll="setScrollPosition(this.scrollTop);"
                     style="width:730px; height:auto; border-style:groove; font-family:Calibri; font-size:small;"> 
                    <asp:GridView ID="GridView1" runat="server" PageSize="50" CssClass="auto-style3"
                        AutoGenerateColumns="true" BackColor="White" BorderColor="#CCCCCC"
                        BorderStyle="None" BorderWidth="1px" CellPadding="3" 
                        EmptyDataText="No Record Found" ShowHeaderWhenEmpty="True">
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
                 <!-- ReOpen form -->
                <br />
                <!-- ReOpen form -->
                   <!-- ReOpen form in single row -->
                 <!-- ReOpen form -->
<div style="font-family: Calibri; font-size: small; border: 1px solid #ccc; padding: 20px; border-radius: 8px; box-shadow: 0 0 10px rgba(0,0,0,0.1); width: 600px;">
    <form id="reopenForm" onsubmit="return handleReopen(event)" style="display: flex; justify-content: space-between; align-items: flex-end; gap: 20px;">
        <div style="flex: 1;">
            <label for="employeeId" style="display: block; font-weight: bold;">Employee ID</label>
            <input type="text" id="employeeId" name="employeeId" required 
                style="width: 100%; padding: 6px; border: 1px solid #ccc; border-radius: 4px;">
        </div>
        <br />
        <!-- ReOpen button and note in the same row -->
        <div style="display: flex; justify-content: flex-start; align-items: center; gap: 15px;">
           <asp:Button ID="reopenBtn" runat="server" Text="ReOpen"
    CssClass="reopen-button" OnClick="reopenBtn_Click" />


            <p style="margin: 0; color: #555; font-size: 13px;">
                <strong>Note:</strong> ReOpen will be for the current month only.
            </p>
             <asp:Label ID="lblStatus" runat="server" Font-Bold="true" ForeColor="Green" />
        </div>
    </form>
</div>




            </div>

           

        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
