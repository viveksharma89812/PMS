<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site1.Master" CodeBehind="Line.aspx.vb" Inherits="Performance_Management_System.Line" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <style>
        .report-header {
            font-size: 1.25em;
            font-weight: bold;
            margin-bottom: 20px;
        }
        .report-section {
            margin-bottom: 15px;
        }
        .report-section h6 {
            font-size: 1.1em;
            font-weight: bold;
            margin-bottom: 5px;
        }
        .report-content {
            margin-left: 20px;
        }
    </style>
    <style>
    .btn-green {
        background-color: green; /* Green background */
        color: white; /* White text */
        border: none; /* Remove default border */
        padding: 10px 20px; /* Add some padding */
        text-align: center; /* Center text */
        text-decoration: none; /* Remove underline */
        display: inline-block; /* Ensure it behaves as a button */
        font-size: 16px; /* Set font size */
        margin: 4px 2px; /* Add margin */
        cursor: pointer; /* Add pointer cursor on hover */
        border-radius: 5px; /* Optional: rounded corners */
    }
    
    .btn-green:hover {
        background-color: darkgreen; /* Darker green on hover */
    }
</style>
    <style>
    .btn-orange {
        background-color: orange; /* Orange background */
        color: white; /* White text */
        border: none; /* Remove default border */
        padding: 10px 20px; /* Add padding */
        text-align: center; /* Center text */
        text-decoration: none; /* Remove underline */
        display: inline-block; /* Ensure it behaves as a button */
        font-size: 16px; /* Set font size */
        margin: 4px 2px; /* Add margin */
        cursor: pointer; /* Add pointer cursor on hover */
        border-radius: 5px; /* Optional: rounded corners */
    }
    
    .btn-orange:hover {
        background-color: darkorange; /* Darker orange on hover */
    }
</style>

        <style>
    .btn-Blue {
        background-color: Blue; /* Orange background */
        color: white; /* White text */
        border: none; /* Remove default border */
        padding: 5px 10px; /* Add padding */
        text-align: center; /* Center text */
        text-decoration: none; /* Remove underline */
        display: inline-block; /* Ensure it behaves as a button */
        font-size: 10px; /* Set font size */
        margin: 2px 1px; /* Add margin */
        cursor: pointer; /* Add pointer cursor on hover */
        border-radius: 5px; /* Optional: rounded corners */
    }
    
    .btn-orange:hover {
        background-color: darkblue; /* Darker orange on hover */
    }
</style>

   <script type="text/javascript">
    function validateTextBoxes() {
        // Get all textboxes on the page
        var textboxes = document.querySelectorAll('input[type="text"]');
        textboxes.forEach(function(textbox) {
            if (textbox.value.trim() === '') {
                textbox.style.backgroundColor = '#ffe6e6';
            } else {
                textbox.style.backgroundColor = ''; // Reset color if not empty
            }
        });
    }

    // Run validation on page load
    window.onload = function() {
        validateTextBoxes();

        // Add input event listeners to all textboxes
        var textboxes = document.querySelectorAll('input[type="text"]');
        textboxes.forEach(function(textbox) {
            textbox.addEventListener('input', validateTextBoxes);
        });
    };
</script>


     <script type="text/javascript">
    function confirmSendAndPassword2() {
        // Show confirmation dialog
        if (confirm("Do you really want to send to line Group-1?")) {
            // Prompt for password
            var password = prompt("Please enter your password:");
            
            // Replace 'yourPassword' with the actual password or handle validation
            if (password === "Group1@321") {
                return true; // Proceed with the form submission
            } else {
                alert("Incorrect password.");
                return false; // Cancel the form submission
            }
        } else {
            return false; // Cancel the form submission if not confirmed
        }
    }
</script>

     <script type="text/javascript">
    function confirmSendAndPassword3() {
        // Show confirmation dialog
        if (confirm("Do you really want to send to line Group-2?")) {
            // Prompt for password
            var password = prompt("Please enter your password:");
            
            // Replace 'yourPassword' with the actual password or handle validation
            if (password === "Group2@321") {
                return true; // Proceed with the form submission
            } else {
                alert("Incorrect password.");
                return false; // Cancel the form submission
            }
        } else {
            return false; // Cancel the form submission if not confirmed
        }
    }
</script>
    <script type="text/javascript">
    function validateLength(textBox) {
        var maxLength = 400;
        var currentLength = textBox.value.length;
        
        // If the text exceeds the max length, trim it
        if (currentLength > maxLength) {
            textBox.value = textBox.value.substring(0, maxLength);
            currentLength = maxLength; // Update currentLength to the max length after trimming
        }
        
        // Update the character count display
        var charCounter = document.getElementById('charCounter');
        charCounter.textContent = currentLength + '/' + maxLength + ' characters used';
    }
</script>




       <script type="text/javascript">
    function validateLength22(textBox) {
        var maxLength = 20;
        var currentLength = textBox.value.length;
        
        // If the text exceeds the max length, trim it
        if (currentLength > maxLength) {
            textBox.value = textBox.value.substring(0, maxLength);
            currentLength = maxLength; // Update currentLength to the max length after trimming
        }
        
        // Update the character count display
        var charCounter22 = document.getElementById('charCounter22');
        charCounter22.textContent = currentLength + '/' + maxLength + ' characters used';
    }
</script>
         <script type="text/javascript">
    function validateLength23(textBox) {
        var maxLength = 20;
        var currentLength = textBox.value.length;
        
        // If the text exceeds the max length, trim it
        if (currentLength > maxLength) {
            textBox.value = textBox.value.substring(0, maxLength);
            currentLength = maxLength; // Update currentLength to the max length after trimming
        }
        
        // Update the character count display
        var charCounter23 = document.getElementById('charCounter23');
        charCounter23.textContent = currentLength + '/' + maxLength + ' characters used';
    }
</script>

         <script type="text/javascript">
    function validateLength24(textBox) {
        var maxLength =20;
        var currentLength = textBox.value.length;
        
        // If the text exceeds the max length, trim it
        if (currentLength > maxLength) {
            textBox.value = textBox.value.substring(0, maxLength);
            currentLength = maxLength; // Update currentLength to the max length after trimming
        }
        
        // Update the character count display
        var charCounter24 = document.getElementById('charCounter24');
        charCounter24.textContent = currentLength + '/' + maxLength + ' characters used';
    }
</script>
         <script type="text/javascript">
    function validateLength25(textBox) {
        var maxLength = 20;
        var currentLength = textBox.value.length;
        
        // If the text exceeds the max length, trim it
        if (currentLength > maxLength) {
            textBox.value = textBox.value.substring(0, maxLength);
            currentLength = maxLength; // Update currentLength to the max length after trimming
        }
        
        // Update the character count display
        var charCounter25 = document.getElementById('charCounter25');
        charCounter25.textContent = currentLength + '/' + maxLength + ' characters used';
    }
</script>
         <script type="text/javascript">
    function validateLength27(textBox) {
        var maxLength =20;
        var currentLength = textBox.value.length;
        
        // If the text exceeds the max length, trim it
        if (currentLength > maxLength) {
            textBox.value = textBox.value.substring(0, maxLength);
            currentLength = maxLength; // Update currentLength to the max length after trimming
        }
        
        // Update the character count display
        var charCounter27 = document.getElementById('charCounter27');
        charCounter27.textContent = currentLength + '/' + maxLength + ' characters used';
    }
</script>
         <script type="text/javascript">
    function validateLength28(textBox) {
        var maxLength = 20;
        var currentLength = textBox.value.length;
        
        // If the text exceeds the max length, trim it
        if (currentLength > maxLength) {
            textBox.value = textBox.value.substring(0, maxLength);
            currentLength = maxLength; // Update currentLength to the max length after trimming
        }
        
        // Update the character count display
        var charCounter28 = document.getElementById('charCounter28');
        charCounter28.textContent = currentLength + '/' + maxLength + ' characters used';
    }
</script>



</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <center>
  <asp:Button runat="server" Text="Show" OnClick="Unnamed6_Click" ID="Button5" style="text-align:right" />     &nbsp;&nbsp; <---------  first click on show.</center>  
    <hr style="border: 1px solid black;" />

   <div class="report-header">
           <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label> MRI Plant Daily Report: (印度廠日報告:)<br /><br />
     Attendance yesterday  (昨日出席出勤) <asp:textbox  Width="55px" runat="server" ID="textbox1"></asp:textbox> people / Total number of people (人/總人數) <asp:textbox runat="server"  Width="55px" ID="textbox2"></asp:textbox> (人)        &nbsp;&nbsp;  <asp:CheckBox ID="CheckBox1" runat="server" />    <asp:Button runat="server" Text="Submit or Update" OnClick="Unnamed3_Click" ID="Button6" CssClass="btn-Blue" /> { HR }            
        </div>
    <hr style="border: 1px solid black;" />
        <div class="report-section">
            <h6>1. Today's Contractor Work: (一.本日外包商件數:)      <asp:Button runat="server" Text="Submit or Update" OnClick="Unnamed3_Click" ID="Button2" CssClass="btn-Blue" />   { EHS }   </h6>
            <div class="report-content"> 
                <p> 1. General Operations: (1.一般作業:): <asp:textbox runat="server" ID="textbox3"  Width="55px"></asp:textbox>  cases    (件)  <asp:CheckBox ID="CheckBox2" runat="server" /></p>
                <p> 2. Hot Work Operations: (2.明火作業:) :<asp:textbox runat="server" ID="textbox4"  Width="55px"></asp:textbox> cases    (件)  <asp:CheckBox ID="CheckBox3" runat="server" /></p>
                <p> 3. High-altitude Operations:(3.高空作業:) <asp:textbox runat="server" ID="textbox5"  Width="55px"></asp:textbox> cases   (件)     <asp:CheckBox ID="CheckBox4" runat="server" /></p>
            </div>
        </div>
        <hr style="border: 1px solid black;" />
        <div class="report-section">
            <h6> 2.<asp:Label ID="Label2" runat="server" Text="Label"></asp:Label> Production Brief: (二. <asp:Label ID="Label9" runat="server" Text="Label"></asp:Label>生產簡報:) </h6>
            <div class="report-content">
                <p>1. Molding: (1.成型:) <asp:textbox runat="server" ID="textbox6"  Width="55px"></asp:textbox> units; Achievement Rate: (條;達成率:)  <asp:textbox runat="server"  Width="55px" ID="textbox7"></asp:textbox>%        <asp:CheckBox ID="CheckBox5" runat="server" />     <asp:Button runat="server" Text="Submit or Update" OnClick="Unnamed3_Click" ID="Button7" CssClass="btn-Blue" />   { TB } </p>
                    <hr style="border: 1px solid black;" />
                <p>2. Vulcanization:  (2.加硫:)  <asp:textbox runat="server"  Width="55px" ID="textbox8"></asp:textbox> units; Achievement Rate: (條;達成率:)  <asp:textbox runat="server"  Width="55px" ID="textbox9"></asp:textbox>%        <asp:CheckBox ID="CheckBox6" runat="server" />    <asp:Button runat="server" Text="Submit or Update" OnClick="Unnamed3_Click" ID="Button8" CssClass="btn-Blue" />   { Curing }</p>
                    <hr style="border: 1px solid black;" />
                <p>3. Finished Product Defect Rate: (3.成品廢品不良率:)  <asp:textbox runat="server"  Width="55px" ID="textbox10"></asp:textbox>%       <asp:CheckBox ID="CheckBox7" runat="server" />    <asp:Button runat="server" Text="Submit or Update" OnClick="Unnamed3_Click" ID="Button9" CssClass="btn-Blue" />   { QA } </p>
                <p>4. First Pass Yield: (4.成品首次合格率:)  <asp:textbox runat="server"  Width="55px" ID="textbox11"></asp:textbox>%       <asp:CheckBox ID="CheckBox8" runat="server" /></p>
            </div>
        </div>
        <hr style="border: 1px solid black;" />
        <div class="report-section">
            <h6>3. <asp:Label ID="Label5" runat="server" Text="Label"></asp:Label> Finished Goods Shipment:  (三.<asp:Label ID="Label8" runat="server" Text="Label"></asp:Label>成品出貨:) </h6>
            <div class="report-content">
                <p> 1. Progressive Domestic Shipment Volume: (1.累計內銷出貨量:) <asp:textbox runat="server"  Width="55px" ID="textbox12"></asp:textbox> units  (條)       <asp:CheckBox ID="CheckBox9" runat="server" />   <asp:Button runat="server" Text="Submit or Update" OnClick="Unnamed3_Click" ID="Button10" CssClass="btn-Blue" />   { Commecial } </p>
                <p> 2. Progressive Export Shipment Volume: (2.累計外銷出貨量:)  <asp:textbox runat="server"  Width="55px" ID="textbox13"></asp:textbox> units (條)         <asp:CheckBox ID="CheckBox10" runat="server" /></p>
                    <hr style="border: 1px solid black;" />
                <p> 3. Progressive to yesterday Finished Goods Inventory: (3.截至昨日成品庫存量:)<asp:textbox runat="server"  Width="55px" ID="textbox14"></asp:textbox>  units (條)        <asp:CheckBox ID="CheckBox11" runat="server" />  <asp:Button runat="server" Text="Submit or Update" OnClick="Unnamed3_Click" ID="Button11" CssClass="btn-Blue" />     { Where HOuse}</p>
                    <hr style="border: 1px solid black;" />
                <p> 4. Progressive to yesterday Raw Material (Rubber) Inventory: (4.截至昨日原材料（膠料）庫存量：)<asp:textbox runat="server"  Width="55px" ID="textbox15"></asp:textbox>  tons (噸)      <asp:CheckBox ID="CheckBox12" runat="server" />  <asp:Button runat="server" Text="Submit or Update" OnClick="Unnamed3_Click" ID="Button12" CssClass="btn-Blue" />   { Raw Material Purchase }</p>
            </div>
        </div>
        <hr style="border: 1px solid black;" />
        <div class="report-section">
            <h6>4. <asp:Label ID="Label4" runat="server" Text="Label"></asp:Label> Mixing Plant Production Brief:  (四. <asp:Label ID="Label7" runat="server" Text="Label"></asp:Label>混煉廠生產簡報:) <asp:Button runat="server" Text="Submit or Update" OnClick="Unnamed3_Click" ID="Button13" CssClass="btn-Blue" />     { Mixxing } </h6>
            <div class="report-content">
                <p> 1. Operating Machines (1.開機台數) <asp:textbox runat="server" ID="textbox16"  Width="55px"></asp:textbox> units / Total Machines (台/總台數) <asp:textbox runat="server"  Width="55px" ID="textbox17"></asp:textbox> units / Utilization Rate:  (台/稼動率:) <asp:textbox  Width="55px" runat="server" ID="textbox18"></asp:textbox>%          <asp:CheckBox ID="CheckBox13" runat="server" /></p>
                <p> 2. Production Volume (2.生產量) <asp:textbox runat="server" ID="textbox19"  Width="55px"></asp:textbox> units / Equipment Capacity (手/設備產能) <asp:textbox runat="server"  Width="55px" ID="textbox20"></asp:textbox>  units / Utilization Rate: (手/稼動率:) <asp:textbox  Width="55px" runat="server" ID="textbox21"></asp:textbox>%         <asp:CheckBox ID="CheckBox14" runat="server" /></p>
            </div>
        </div>
        <hr style="border: 1px solid black;" />
        <div class="report-section">
            <h6>5.<asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>  Production TOC: (五. <asp:Label ID="Label6" runat="server" Text="Label"></asp:Label> 生產TOC:) <asp:Button runat="server" Text="Submit or Update" OnClick="Unnamed3_Click" ID="Button14" CssClass="btn-Blue" />     { Plant Head}</h6>
            <div class="report-content">
                <p><table>
                    <tr>
                        <td>1. Description: (1.描述:) <asp:textbox runat="server" ID="textbox22"  Width="411px" oninput="validateLength22(this)"  TextMode="MultiLine"></asp:textbox>  <div id="charCounter22" style="margin-top: 5px;">0/20 characters used</div> </td>
                    <td>  &nbsp;&nbsp;/ Countermeasure:(/對策:)  <asp:textbox runat="server" oninput="validateLength23(this)"  TextMode="MultiLine"  Width="424px" ID="textbox23"></asp:textbox>   &nbsp;&nbsp;    <div id="charCounter23" style="margin-top: 5px;">0/20 characters used</div>    
                       
                        </td>
                        <td>
                                  &nbsp;&nbsp;<asp:CheckBox ID="CheckBox15" runat="server" />
                         </td>
                        </tr>
                   </table>

                </p>
                <p> <table>
                    <tr>
                        <td>
                  2. Description: (2.描述:) <asp:textbox runat="server" ID="textbox24" oninput="validateLength24(this)"  TextMode="MultiLine" Width="411px"></asp:textbox>  <div id="charCounter24" style="margin-top: 5px;">0/20 characters used</div>
                        </td>
                        <td>
                             &nbsp;&nbsp;   / Countermeasure: (/對策:) <asp:textbox runat="server" oninput="validateLength25(this)"  TextMode="MultiLine" Width="424px" ID="textbox25"></asp:textbox>   &nbsp;&nbsp;    <div id="charCounter25" style="margin-top: 5px;">0/20 characters used</div> 
                        </td>
                        <td>
                                &nbsp;&nbsp; <asp:CheckBox ID="CheckBox16" runat="server" />
                        </td>
                    </tr>
                    </table>   

                </p>
                <p>  
                  <Table>
                      <tr>
                          <td>   3. Description: (3.描述:) <asp:textbox runat="server" ID="textbox27" oninput="validateLength27(this)"  TextMode="MultiLine" Width="411px"></asp:textbox>   <div id="charCounter27" style="margin-top: 5px;">0/20 characters used</div></td>
                          <td>           &nbsp;&nbsp;     / Countermeasure: (/對策:) <asp:textbox runat="server" oninput="validateLength27(this)"  TextMode="MultiLine"  Width="424px" ID="textbox28"></asp:textbox>    &nbsp;&nbsp;   <div id="charCounter28" style="margin-top: 5px;">0/20 characters used</div> </td>
                          <td>      &nbsp;&nbsp;       <asp:CheckBox ID="CheckBox18" runat="server" /></td>
                      </tr>
                  </Table>
     </p>
               <%-- <p>   4. Description: (4.描述:) <asp:textbox runat="server" ID="textbox29" Width="411px"></asp:textbox>  / Countermeasure: (/對策:) <asp:textbox runat="server"  Width="424px" ID="textbox30"></asp:textbox>        <asp:CheckBox ID="CheckBox19" runat="server" /></p>
                <p>   5. Description: (5.描述:) <asp:textbox runat="server" ID="textbox31" Width="411px"></asp:textbox>  / Countermeasure: (/對策:) <asp:textbox runat="server"  Width="424px" ID="textbox32"></asp:textbox>        <asp:CheckBox ID="CheckBox20" runat="server" /></p>--%>

                

            </div>
        </div>
        <hr style="border: 1px solid black;" />
        <div class="report-section">
            <h6>6. Plant Manager's Key Reports from Internal Management Review:(六.廠長自廠管理檢視重要報告:)  <asp:Button runat="server" Text="Submit or Update" OnClick="Unnamed3_Click" ID="Button15" CssClass="btn-Blue" />     { Plant Head} </h6>
            <div class="report-content">
                <p>1.Description: (1.描述:)     <asp:CheckBox ID="CheckBox17" runat="server" /></p><asp:TextBox runat="server" ID="textbox26" Height="105px" Width="1666px" oninput="validateLength(this)"  TextMode="MultiLine"></asp:TextBox>
<div id="charCounter" style="margin-top: 5px;">0/400 characters used</div>

       
            </div>
        </div>
    <center>
 <asp:Button runat="server" Text="審核完畢確認/Confirm" OnClick="Unnamed1_Click" ID="btnSubmit" CssClass="btn-orange" />

        <asp:Button runat="server" Text="寄給自己/Send Self " OnClick="Unnamed112_Click" ID="btnsendtoself" CssClass="btn-green"    />

    <asp:Button runat="server" Text="寄給生產群組/Send line Group1" OnClick="Unnamed2_Click" ID="btnsendline" CssClass="btn-green" OnClientClick="return confirmSendAndPassword2();"  />
         <asp:Button runat="server" Text="寄給董事長群組/Send line Group2" OnClick="Unnamedg2_Click" ID="btnsendline2" CssClass="btn-green"  OnClientClick="return confirmSendAndPassword3();" />

    
    </center>


     
                 <div class="modal fade" id="myModal1" role="dialog" data-backdrop="static">
                   
    <div class="modal-dialog modal-sm">
       
      
        <div class="modal-content" <%--style="background-color:lightsteelblue" --%>>
            <div class="modal-header">
                <button type="button" class="close" data-dismiss="modal"  >
                    &times;</button>
                <h4 class="modal-title" style="font:bold; font-size:large">
                    Enter Password</h4>
            </div>
            <div class="modal-body"> 
                 <div class="col-lg-12 col-sm-12 col-md-12 col-xs-12">                                           
                    <div class="form-group">  
                     Password:
                          <asp:TextBox ID="txtpass"   runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>                                              
                         <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Password fill please!" ValidationGroup="insert" ForeColor="Red" ControlToValidate="txtpass"></asp:RequiredFieldValidator>
                
                    </div>
                     </div>
                 </div>
         
            
            <div class="modal-footer">
            <center>    <asp:Button ID="Button1"  runat="server" Text="Submit"  OnClick="btnconfirm_Click"  CssClass="btn btn-success" Font-Bold="true"   /> 
                     <asp:Button ID="Button4" runat="server" Text="CANCEL" CssClass="btn btn-primary" OnClick="btncancel_click" Font-Bold="true" />
            </center> 
                 
            </div>
        </div>
            
    </div>
</div>


              <div class="modal fade" id="myModal" role="dialog" data-backdrop="static">
                   
    <div class="modal-dialog modal-sm">
       
        <!-- Modal content-->
        <div class="modal-content" <%--style="background-color:lightsteelblue" --%>>
            <div class="modal-header">
                <button type="button" class="close" data-dismiss="modal"  >
                    &times;</button>
                <h4 class="modal-title" style="font:bold; font-size:large">
                    
                    Enter your Details</h4>
            </div>
            <div class="modal-body">  
                
                
                Employee Name:
                          <asp:TextBox ID="txtname" runat="server" CssClass="form-control"   ></asp:TextBox>                                              
                         <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Please fill name!" ValidationGroup="insert" ForeColor="Red" ControlToValidate="txtname"></asp:RequiredFieldValidator>
                <br />
                  Employee Code:
                          <asp:TextBox ID="txtcode" runat="server" CssClass="form-control" ></asp:TextBox>                                              
                         <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Please fill code!" ValidationGroup="insert" ForeColor="Red" ControlToValidate="txtcode"></asp:RequiredFieldValidator>
              
            <div class="modal-footer">
               <center>              <asp:Button ID="btnSave" OnClick="btnSave_Click"  runat="server" Text="Submit"  CssClass="btn btn-success" Font-Bold="true" Font-Size="Large"   />
           
                <asp:Button ID="Button3" runat="server" Text="CANCEL" CssClass="btn btn-primary" OnClick="btncancel1_click" Font-Bold="true" Font-Size="Large" />
                   </center>
  
            
            </div>
        </div>
            
    </div>
</div>

</asp:Content>

