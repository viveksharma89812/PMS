<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Variablepay.aspx.vb"  Inherits="Performance_Management_System.Variablepay" EnableEventValidation="false"  %>

<!DOCTYPE html>

<script src="https://code.jquery.com/jquery-3.3.1.min.js"></script>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
      
    /* Style for GridView */
    .gridview-style {
        width: 100%;
        border-collapse: collapse;
        margin: 20px 0;
        font-family: Arial, sans-serif;
    }

    .gridview-style th, .gridview-style td {
        padding: 10px;
        text-align: left;
        border: 1px solid #ddd;
    }

    /* Add a background color for the header */
    .gridview-style th {
        background-color: #4CAF50;
        color: white;
    }

    /* Add alternating row colors */
    .gridview-style tr:nth-child(even) {
        background-color: #f2f2f2;
    }

    .gridview-style tr:hover {
        background-color: #ddd;
    }

    /* Style for page numbers or footer if needed */
    .gridview-style .pager {
        padding: 10px;
        text-align: center;
    }
    h1 {
      font-family: 'Arial', sans-serif;
      font-size: 3em;
      text-align: center;
      color: #4CAF50; /* Green color */
      text-shadow: 2px 2px 4px rgba(0, 0, 0, 1);
      margin-top: 10px;
      padding: 10px;
      background-color: whitesmoke;
      border-radius: 8px;
    }
      .marquee {
            display: inline-block;
            white-space: nowrap;
            animation: marquee 5s linear infinite;
        }
       .flipped-image {
      transform: scaleX(-1); /* Flips the image horizontally */
    }
    /* Custom styling for dropdown lists */
    .dropdown-list {
        padding: 8px 12px;
        border: 1px solid #ccc;
        border-radius: 4px;
        font-size: 14px;
        background-color: #f9f9f9;
        color: #333;
        box-shadow: 0 2px 5px rgba(0, 0, 0, 0.1);
        transition: border-color 0.3s ease, background-color 0.3s ease;
    }

    /* Hover effect for dropdown list */
    .dropdown-list:hover {
        border-color: #007bff;
        background-color: #e9f4ff;
    }

    /* Focus effect for dropdown list */
    .dropdown-list:focus {
        border-color: #0056b3;
        background-color: #e1efff;
        outline: none;
    }

    /* Optional: Styling for the options */
    .dropdown-list option {
        padding: 8px;
        font-size: 14px;
    }
    /* Custom styling for dropdown lists */
    .dropdown-list {
        padding: 8px 12px;
        border: 1px solid #ccc;
        border-radius: 4px;
        font-size: 14px;
        background-color: #f9f9f9;
        color: #333;
        box-shadow: 0 2px 5px rgba(0, 0, 0, 0.1);
        transition: border-color 0.3s ease, background-color 0.3s ease;
    }

    .dropdown-list:hover {
        border-color: #007bff;
        background-color: #e9f4ff;
    }

    .dropdown-list:focus {
        border-color: #0056b3;
        background-color: #e1efff;
        outline: none;
    }

    /* Custom styling for Find button */
    .btn-find {
        background-color: #007bff;
        color: white;
        border: none;
        font-size: 14px;
        padding: 10px 20px;
        border-radius: 5px;
        cursor: pointer;
        transition: background-color 0.3s ease;
    }

     .btn-clear {
        background-color: #a04a4a;
        color: white;
        border: none;
        font-size: 14px;
        padding: 10px 20px;
        border-radius: 5px;
        cursor: pointer;
        transition: background-color 0.3s ease;
    }

    .btn-find:hover {
        background-color: #0056b3;
    }

    .btn-find, .btn-clear, .btn-success {
    margin-left: 2em; /* Adds a two-tab gap between all buttons */
}
    /* Custom styling for PDF and Export buttons */
    .btn {
        font-size: 16px;
        font-weight: bold;
        border-radius: 5px;
        cursor: pointer;
        display: inline-flex;
        align-items: center;
        justify-content: center;
        padding: 10px 20px;
        transition: background-color 0.3s ease;
    }

    .btn-success {
        background-color: #28a745;
        color: white;
    }

    .btn-success:hover {
        background-color: #218838;
    }

    .btn-danger {
        background-color: #dc3545;
        color: white;
    }

    .btn-danger:hover {
        background-color: #c82333;
    }

    /* Icons in buttons */
    .fa {
        font-size: 20px;
    }
    #editPopup {
        display: none;
        position: fixed;
        top: 10%;
        left: 20%;
        width: 60%;
        background: #fff;
        padding: 30px;
        border-radius: 10px;
        border: 1px solid #ccc;
        box-shadow: 0 0 10px rgba(0,0,0,0.3);
        z-index: 9999;
        font-family: 'Segoe UI', sans-serif;
    }

    .form-row {
        display: flex;
        justify-content: space-between;
        gap: 20px;
        margin-bottom: 15px;
    }

    .form-group {
        flex: 1;
        display: flex;
        flex-direction: column;
    }

    .form-group label {
        font-weight: 600;
        font-size: 14px;
        margin-bottom: 5px;
        color: #333;
    }

    .form-control {
        padding: 8px 10px;
        border: 1px solid #ccc;
        border-radius: 4px;
        font-size: 14px;
        background-color: #f9f9f9;
    }

    .form-buttons {
        display: flex;
        justify-content: flex-end;
        gap: 10px;
        margin-top: 20px;
    }

    .btn {
        padding: 8px 16px;
        font-weight: 600;
        font-size: 14px;
        border: none;
        border-radius: 4px;
        cursor: pointer;
    }

    .btn-success {
        background-color: #28a745;
        color: white;
    }

    .btn-secondary {
        background-color: #6c757d;
        color: white;
    }

    .gridview-style {
        width: 100%;
        height: 700px;  /* Set height of the grid */
        overflow-y: auto; /* Enable vertical scroll */
        display: block;
    }

    .gridview-style table {
        width: 100%;
        border-collapse: collapse;
    }

    .gridview-style th {
        position: sticky; /* Make headers sticky */
        top: 0; /* Stick to the top */
     
        z-index: 10; /* Ensure headers stay on top */
        box-shadow: 0 2px 5px rgba(0,0,0,0.1); /* Optional: Add shadow for visibility */
    }

    .gridview-style td, .gridview-style th {
        padding: 10px;
        border: 1px solid #ddd;
        text-align: left;
    }
</style>

</head>
<body style="background: linear-gradient(50deg, #7c4848, #FFFFFF)">
    <form id="form1" runat="server">
      <h1>
         PMS Quarterly Evaluation System  
    
                 <marquee  direction="right" style="font-size: xx-large; color:orangered">Maxxis Tyre (HRM Module)
                     <img src="https://media4.giphy.com/media/v1.Y2lkPTc5MGI3NjExeWkyeG94bGJieTV4MTZ3NGlhejByNGhpcTZhODF1ODduOTN3OGZkOSZlcD12MV9pbnRlcm5hbF9naWZfYnlfaWQmY3Q9cw/Mosh0RTmPkWFpcTrkF/giphy.gif" style="height:50px"/>
                     </marquee>
                     </h1>
<div style="display: flex; justify-content: space-between; align-items: center; width: 100%;">

    <div style="display: flex; align-items: center; gap: 20px;">
  
        <label id="Years" style="color: black; font-weight: bold; font-size: 14px; margin-right: 10px;">Years</label>
        
                       <%-- <asp:DropDownList ID="Yearr" runat="server" AutoPostBack="false" CssClass="dropdown-list" style="width: 150px;">
                          <asp:ListItem Text="All" Value="All"></asp:ListItem>
               
                       <asp:ListItem Text="2025" value="2025"></asp:ListItem>
                                       <asp:ListItem Text="2026" Value="2026"></asp:ListItem>
                        </asp:DropDownList>--%>

        <asp:DropDownList ID="Yearr" runat="server" AutoPostBack="false" CssClass="dropdown-list" style="width: 150px;">
    <asp:ListItem Text="All" Value="All"></asp:ListItem>
</asp:DropDownList>


      
        <label id="Quartar" style="color: black; font-weight: bold; font-size: 14px; margin-right: 10px;">Quarter</label>
        
  
        <asp:DropDownList ID="Quater" runat="server" AutoPostBack="false" CssClass="dropdown-list" style="width: 200px;">
          
        </asp:DropDownList>
        
            <input type="text" id="txtSearch" placeholder="Search..." class="form-control mb-3" />
    </div>
    <table>
        <tr>
            
            <td><asp:Button ID="Button1" runat="server" Text="Find" CssClass="btn-find" /></td>
            <td><asp:Button ID="Button2" runat="server" Text="Clear" CssClass="btn-clear" /> </td>
            <td>   <asp:LinkButton ID="pdfExport" runat="server" CssClass="btn " style="display: flex; align-items: center; justify-content: center; padding: 10px 20px;">
    <img src="/Bck_Img/excelpng-removebg-preview.png"  style="width: 45px; height: 30px; margin-right: 10px;"/>
</asp:LinkButton></td>
        </tr>
    </table>


<div style="display: flex; gap: 15px; align-items: center;">

    <!-- Styled Label for File Upload -->
    <label for="FileUploadExcel"
           style="display: inline-block; padding: 10px 20px; cursor: pointer; background-color: #28a745; color: white; border-radius: 5px; font-weight: 500;">
        Choose Excel File
    </label>

    <!-- Hidden FileUpload Control -->
    <asp:FileUpload ID="FileUploadExcel" runat="server"
        CssClass="form-control"
        style="display: none;" />

    <!-- Import Excel Button -->
    <asp:Button ID="btnImportExcel" runat="server" Text="Import"
        OnClick="btnImportExcel_Click"
        style="padding: 10px 20px; background-color: #007bff; color: white; border: none; border-radius: 5px; font-weight: 500; cursor: pointer;" />


    <!-- Download Sample Excel Button with Icon -->
   <asp:LinkButton ID="btnDownloadSample" runat="server" OnClick="btnDownloadSample_Click"
    style="display: flex; align-items: center; gap: 8px; padding: 10px 20px; background-color: #ffc107; color: black; border-radius: 5px; font-weight: 500; text-decoration: none;">
<img src="/bck_img/excel.jpg"  style="width :20px; height: 20px;"  />
    Sample
   </asp:LinkButton>
   

</div>


    <div style="display: flex;">
  
        <asp:LinkButton ID="pdf" runat="server" OnClientClick="openPdf(); return false;" CssClass="btn" style="display: flex; align-items: center; justify-content: center; padding: 10px 20px;">
<img src="/Bck_Img/Pdf_337946.png"   style="width:35px; height: 35px;"/>
 
        </asp:LinkButton>

<script type="text/javascript">
    function openPdf() {
        window.open('<%= ResolveUrl("~/PDF/01. PMS Quarter Evaluation System ( Increment and PBVP Both Eligible ).pdf") %>', '_blank');
    }
</script>

     <asp:LinkButton ID="LinkButton1" runat="server" CssClass="btn" style="display: flex; align-items: center; justify-content: center; padding: 10px 20px;">
    <!-- Logout Logo (Image) -->
    <img src="/Bck_Img/logouts.png"  alt="Logout" style="width: 35px; height: 35px;"/>

     </asp:LinkButton>
    </div>
</div>

        <div >


<script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
<script>
    $(document).ready(function () {
        $('#txtSearch').on('keyup', function () {
            var value = $(this).val().toLowerCase();

            // Filter GridView1 (skip the first row, typically the header)
            $("#<%= GridView1.ClientID %> tbody tr:not(:first)").filter(function () {
                $(this).toggle($(this).text().toLowerCase().indexOf(value) > -1);
            });

            // Filter GridView3 (skip the first row, typically the header)
            $("#<%= GridView3.ClientID %> tbody tr:not(:first)").filter(function () {
                $(this).toggle($(this).text().toLowerCase().indexOf(value) > -1);
            });
        });
    });
</script>

           

<asp:GridView ID="GridView1"  runat="server" CssClass="gridview-style" AutoGenerateColumns="False" AllowSorting="True">

    <Columns>
        <asp:BoundField DataField="SrNo" HeaderText="Sr No"  />
        <asp:TemplateField HeaderText="Action" ValidateRequestMode="Enabled">
            <ItemTemplate>
                <asp:LinkButton ID="lnkBtnEdit" runat="server" Text="Edit"
                    CssClass="btn btn-primary"
                    CommandName="EditPopup"
                    CommandArgument='<%# Eval("EmployeeCode") %>'>
                </asp:LinkButton>
            </ItemTemplate>
            <EditItemTemplate>
                <asp:LinkButton ID="btn_Update" runat="server" Text="Update" CommandName="Update" 
                    CommandArgument='<%# Bind("EmployeeCode") %>' EnableViewState="true" 
                    CausesValidation="False"></asp:LinkButton>
                <asp:LinkButton ID="btn_Cancel" runat="server" Text="Cancel" CommandName="Cancel"></asp:LinkButton>
            </EditItemTemplate>
        </asp:TemplateField>

        <asp:BoundField DataField="EmployeeCode" HeaderText="Employee Code"/>
        <asp:BoundField DataField="EmployeeName" HeaderText="Employee Name"  />
        <asp:BoundField DataField="Department" HeaderText="Department"  />
        <asp:BoundField DataField="Section" HeaderText="Section"  />
        <asp:BoundField DataField="Designation" HeaderText="Designation"  />
        <asp:BoundField DataField="Grade" HeaderText="Grade" />
        <asp:BoundField DataField="standard amount" HeaderText="Quaterly Standard Amount" />
        <asp:BoundField DataField="PMS_Score" HeaderText="PMS Score"  />
        <asp:BoundField DataField="INTO" HeaderText="Coefiecent"  />
        <asp:BoundField DataField="Final Amount" HeaderText="Quaterly Final Amount"  />
        <asp:BoundField DataField="EmpStatus" HeaderText="EmpStatus" />
        <asp:BoundField DataField="PbvpStatus" HeaderText="PbvpStatus"  />
        <asp:BoundField DataField="Remark" HeaderText="Remark"  />
    </Columns>
</asp:GridView>



<asp:GridView ID="GridView3" runat="server" CssClass="gridview-style" AutoGenerateColumns="False" AllowSorting="True">
    <Columns>
             <asp:BoundField DataField="SrNo" HeaderText="Sr No"  />
           <asp:TemplateField HeaderText="Action" ValidateRequestMode="Enabled">
       <ItemTemplate>
           <asp:LinkButton ID="lnkBtnEdit" runat="server" Text="Edit"
               CssClass="btn btn-primary"
               CommandName="EditPopup"
               CommandArgument='<%# Eval("EmployeeCode") %>'>
           </asp:LinkButton>
       </ItemTemplate>
       <EditItemTemplate>
           <asp:LinkButton ID="btn_Update" runat="server" Text="Update" CommandName="Update" 
               CommandArgument='<%# Bind("EmployeeCode") %>' EnableViewState="true" 
               CausesValidation="False"></asp:LinkButton>
           <asp:LinkButton ID="btn_Cancel" runat="server" Text="Cancel" CommandName="Cancel"></asp:LinkButton>
       </EditItemTemplate>
   </asp:TemplateField>
  
        <asp:BoundField DataField="EmployeeCode" HeaderText="Employee Code"  />
        <asp:BoundField DataField="EmployeeName" HeaderText="Employee Name" />
        <asp:BoundField DataField="Department" HeaderText="Department" />
        <asp:BoundField DataField="Section" HeaderText="Section"  />
        <asp:BoundField DataField="Designation" HeaderText="Designation" />
        <asp:BoundField DataField="Grade" HeaderText="Grade"/>
        <asp:BoundField DataField="Standard Amount" HeaderText="Standard Amount"  />
        <asp:BoundField DataField="EmpStatus" HeaderText="Employee Status"  />
        <asp:BoundField DataField="PbvpStatus" HeaderText="PBVP Status"  />
        <asp:BoundField DataField="Remark" HeaderText="Remark"  />
    </Columns>
</asp:GridView>


      <script type="text/javascript">
    function sortTable(n, tableId) {
        // Skip sorting the "Sr No" column (index 0)
        if (n === 0) return;  // Prevent sorting on first column (Sr No)

        var table, rows, switching, i, x, y, shouldSwitch, dir, switchcount = 0;
        table = document.getElementById(tableId);  // Use the passed tableId
        switching = true;
        dir = "asc"; // Set the sorting direction to ascending
        
        while (switching) {
            switching = false;
            rows = table.rows;
            for (i = 1; i < (rows.length - 1); i++) {
                shouldSwitch = false;
                x = rows[i].getElementsByTagName("TD")[n];
                y = rows[i + 1].getElementsByTagName("TD")[n];
                
                if (dir == "asc") {
                    if (x.innerHTML.toLowerCase() > y.innerHTML.toLowerCase()) {
                        shouldSwitch = true;
                        break;
                    }
                } else if (dir == "desc") {
                    if (x.innerHTML.toLowerCase() < y.innerHTML.toLowerCase()) {
                        shouldSwitch = true;
                        break;
                    }
                }
            }
            if (shouldSwitch) {
                rows[i].parentNode.insertBefore(rows[i + 1], rows[i]);
                switching = true;
                switchcount++;
            } else {
                if (switchcount == 0 && dir == "asc") {
                    dir = "desc";
                    switching = true;
                }
            }
        }
    }

    window.onload = function () {
        var headers1 = document.querySelectorAll("#GridView1 th");
        var headers3 = document.querySelectorAll("#GridView3 th");

        // Sortable headers for GridView1
        for (var i = 0; i < headers1.length; i++) {
            (function (index) {
                headers1[index].onclick = function () {
                    sortTable(index, "GridView1"); // Call sortTable() for GridView1
                };
            })(i);
        }

        // Sortable headers for GridView3
        for (var i = 0; i < headers3.length; i++) {
            (function (index) {
                headers3[index].onclick = function () {
                    sortTable(index, "GridView3"); // Call sortTable() for GridView3
                };
            })(i);
        }
    };
</script>



<%--
<script type="text/javascript">
    function sortTable(n) {
        var table, rows, switching, i, x, y, shouldSwitch, dir, switchcount = 0;
        table = document.getElementById("GridView1");
        switching = true;
        dir = "asc"; // Set the sorting direction to ascending
        while (switching) {
            switching = false;
            rows = table.rows;
            for (i = 1; i < (rows.length - 1); i++) {
                shouldSwitch = false;
                x = rows[i].getElementsByTagName("TD")[n];
                y = rows[i + 1].getElementsByTagName("TD")[n];
                if (dir == "asc") {
                    if (x.innerHTML.toLowerCase() > y.innerHTML.toLowerCase()) {
                        shouldSwitch = true;
                        break;
                    }
                } else if (dir == "desc") {
                    if (x.innerHTML.toLowerCase() < y.innerHTML.toLowerCase()) {
                        shouldSwitch = true;
                        break;
                    }
                }
            }
            if (shouldSwitch) {
                rows[i].parentNode.insertBefore(rows[i + 1], rows[i]);
                switching = true;
                switchcount++;
            } else {
                if (switchcount == 0 && dir == "asc") {
                    dir = "desc";
                    switching = true;
                }
            }
        }
    }

    window.onload = function () {
        var headers = document.querySelectorAll("#GridView1 th");
        for (var i = 0; i < headers.length; i++) {
            (function (index) {
                headers[index].onclick = function () {
                    sortTable(index); // Call sortTable() when header is clicked
                };
            })(i);
        }
    };
</script>--%>











            <div style="display:none">
                  <asp:GridView ID="GridView2" runat="server" ></asp:GridView>
      
            </div>


      
        </div>

<asp:HiddenField ID="hiddenEmpCode" runat="server" />

<div id="editPopup" class="modal fade" tabindex="-1" role="dialog" aria-labelledby="editPopupLabel" aria-hidden="true">
  <div class="modal-dialog modal-lg" role="document">
    <div class="modal-content">

      <div class="modal-header">
        <h4 class="modal-title" style="text-align:center; width:100%;">Edit Details</h4>
       
      </div>

      <div class="modal-body">
        <div class="form-row">
          <div class="form-group col-md-6">
            <label>Employee ID</label>
            <asp:TextBox ID="txtEmpID" runat="server" CssClass="form-control" readonly="true"/>
          </div>
          <div class="form-group col-md-6">
            <label>Employee Name</label>
            <asp:TextBox ID="txtEmpName" runat="server" CssClass="form-control" readonly="true"/>
          </div>
        </div>

        <div class="form-row">
          <div class="form-group col-md-4">
            <label>Department</label>
            <asp:TextBox ID="txtDepartment" runat="server" CssClass="form-control" readonly="true"/>
          </div>
          <div class="form-group col-md-4">
            <label>Section</label>
            <asp:TextBox ID="txtSection" runat="server" CssClass="form-control" readonly="true"/>
          </div>
              <div class="form-group col-md-4">
            <label>DOE</label>
        <asp:TextBox ID="txtdoedate" runat="server" CssClass="form-control dateInput" Placeholder="From Date" type="date"></asp:TextBox>          </div>
        </div>

       


        <div class="form-row">
          
          <div class="form-group col-md-6">
            <label>Status</label>
            <asp:DropDownList ID="ddlStatus" runat="server" CssClass="form-control">
              <asp:ListItem Text="Present" Value="Present" />
              <asp:ListItem Text="Left" Value="Left" />
                   <asp:ListItem Text="Resign" Value="Resign" />
            </asp:DropDownList>
          </div>

        <div class="form-group col-md-6">
  <label>Eligibility</label>
  <asp:DropDownList ID="ddlEligibility" runat="server" CssClass="form-control">
    <asp:ListItem Text="Eligible" Value="Eligible" />
    <asp:ListItem Text="Not Eligible" Value="Not Eligible" />
  </asp:DropDownList>
</div>
        </div>

        <div class="form-row">
          
          <div class="form-group col-md-6">
            <label>Remark</label>
            <asp:TextBox ID="txtRemark" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="2" />
          </div>


           <div class="form-row" style="justify-content: flex-end;margin-top:50px">
                <div class="form-group col-auto">
                    <asp:Button ID="btnSubmitEdit" runat="server" Text="Update" CssClass="btn btn-success" OnClick="btnSubmitEdit_Click" />
                </div>
                <div class="form-group col-auto">
                    <button type="button" class="btn btn-secondary" onclick="closePopup()">Cancel</button>
                </div>
            </div>

        </div>
      </div>




    </div>
  </div>
</div>
        <div id="popupOverlay"></div>


        <script type="text/javascript">
            function openPopup() {
                $('#editPopup').show();
                $('#popupOverlay').show();
            }

            function closePopup() {
                $('#editPopup').hide();
                $('#popupOverlay').hide();
            }
        </script>

    </form>
    
 

</body>
</html>
