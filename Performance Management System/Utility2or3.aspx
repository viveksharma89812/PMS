<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site1.Master" CodeBehind="Utility2or3.aspx.vb" Inherits="Performance_Management_System.Utility2or3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style20 {
            width: 100%;
        }
        .auto-style21 {
            width: 100%;
            height: 83px;
        }
         .auto-style24 {
            width: 74px;
        }
        .auto-style31 {
            height: 22px;
        }
        .auto-style68 {
            margin-bottom: 0px;
        }
        table, th, td {
            /*border: 1px solid black;*/
            align-content: center;
            text-align: center
        }
        .auto-style114 {
            width: 650px;
            font-style: normal;
        }
        .auto-style117 {
            border: 1px solid #000000;
            width: 145px;
        }
        .auto-style122 {
            border: 1px solid #000000;
        }
        .auto-style132 {
            width: 134px;
            border: 1px solid #000000;
            background-color: #FFFFFF;
            font-family: Calibri;
        }
        .auto-style133 {
            width: 345px;
            border: 1px solid #000000;
            background-color: #FFFFFF;
            font-family: Calibri;
        }
        .auto-style137 {
            width: 407px;
            border: 1px solid #000000;
            font-family: Calibri;
        }
        .auto-style138 {
            width: 15px;
            border: 1px solid #000000;
        }
        .auto-style165 {
            font-size: small;
            font-family: Calibri;
        }
        .auto-style169 {
            width: 899px;
        }
        .auto-style172 {
            width: 405px;
            height: 23px;
        }
        .auto-style173 {
            height: 23px;
            font-family: Calibri;
        }
        .auto-style175 {
            width: 150px;
            font-family: Calibri;
        }
        .auto-style178 {
            width: 100px;
        }
        .auto-style180 {
            width: 100px;
            height: 69px;
        }
        .auto-style183 {
            font-family: call;
            font-style: normal;
            font-size: small;
        }
        .auto-style184 {
            font-family: call;
            font-size: small;
        }
        .auto-style209 {
            border: 1px dashed #000000;
        }
        .auto-style213 {
            border: 1px dashed #000000;
            font-size: small;
            font-family: Calibri;
        }
        .auto-style226 {
            border: 1px dashed #000000;
            width: 1626px;
        }
        .auto-style227 {
            border: 1px dashed #000000;
            width: 150px;
        }
        .auto-style228 {
            border: 1px dashed #000000;
            width: 549px;
        }
        .auto-style231 {
            border: 1px dashed #000000;
            width: 100px;
        }
        .auto-style280 {
            font-family: Calibri;
        }
        .auto-style281 {
            width: 100px;
            height: 69px;
            font-family: Calibri;
        }
        .auto-style282 {
            width: 405px;
            height: 23px;
            font-family: Calibri;
        }
        .auto-style283 {
            width: 351px;
            border: 1px solid #000000;
            font-family: Calibri;
        }
        .auto-style284 {
            border: 1px solid #000000;
            font-family: Calibri;
        }
        .auto-style285 {
            border: 1px dashed #000000;
            width: 549px;
            font-family: Calibri;
        }
        .auto-style286 {
            border: 1px dashed #000000;
            font-family: Calibri;
        }
        .auto-style287 {
            border: 1px dashed #000000;
            width: 1626px;
            font-family: Calibri;
        }
        .auto-style289 {
            font-weight: normal;
        }
        .auto-style291 {
            width: 407px;
            border: 1px solid #000000;
            font-family: Calibri;
            font-weight: normal;
        }
        .auto-style292 {
            font-family: call;
        }
        .auto-style297 {
            border: 1px solid #000000;
            height: 19px;
        }
        .auto-style298 {
            border: 1px solid #000000;
            width: 106px;
        }
        .auto-style299 {
            font-size: small;
        }
        .auto-style301 {
            border: 1px solid #000000;
            width: 158px;
        }
        .auto-style302 {
            border: 1px solid #000000;
            width: 139px;
        }
        .auto-style303 {
            border: 1px solid #000000;
            text-align: left;
        }
        .auto-style305 {
            border: 1px solid #000000;
            font-family: Calibri;
            background-color: #B4C6E7;
        }
        .auto-style307 {
            border: 1px dashed #000000;
            width: 100px;
            height: 38px;
        }
        .auto-style308 {
            border: 1px dashed #000000;
            width: 150px;
            height: 38px;
        }
        .auto-style312 {
            border: 1px solid #000000;
            font-family: Calibri;
            background-color: #8EA9DB;
        }
        .auto-style313 {
            border: 1px solid #000000;
            background-color: #FFD966;
        }
        .auto-style314 {
            border: 1px solid #000000;
            font-family: Calibri;
            background-color: #FFD966;
        }
        .auto-style315 {
            border: 1px solid #000000;
            background-color: #B4C6E7;
        }
        .auto-style316 {
            border: 1px solid #000000;
            width: 84px;
        }
        .auto-style317 {
            border: 1px solid #000000;
            width: 78px;
        }
        .auto-style318 {
            border-left: 1px solid #000000;
            border-right: 1px solid #000000;
            border-bottom: 1px solid #000000;
            height: 19px;
            width: 78px;
        }
        .auto-style319 {
            border-left: 1px solid #000000;
            border-right: 1px solid #000000;
        }
        .auto-style323 {
            font-style: normal;
        }
        .auto-style336 {
            border: 1px solid #000000;
            background-color: #D9E1F2;
            font-family: Calibri;
            height: 20px;
        }
        .auto-style337 {
            width: 130px;
            border: 1px solid #000000;
            background-color: #D9E1F2;
            font-family: Calibri;
            height: 20px;
        }
        .auto-style338 {
            width: 345px;
            border: 1px solid #000000;
            background-color: #D9E1F2;
            font-family: Calibri;
            height: 20px;
        }
        .auto-style339 {
            width: 134px;
            border: 1px solid #000000;
            background-color: #D9E1F2;
            font-family: Calibri;
            height: 20px;
        }
        .auto-style341 {
            width: 100%;
            height: 251px;
        }
        .auto-style342 {
            border: 1px solid #000000;
            background-color: #FFFFFF;
            font-family: Calibri;
            height: 55px;
        }
        .auto-style343 {
            width: 130px;
            border: 1px solid #000000;
            background-color: #FFFFFF;
            font-family: Calibri;
            height: 55px;
        }
        .auto-style344 {
            border: 1px solid #000000;
            height: 55px;
        }
        .auto-style345 {
            width: 130px;
            border: 1px solid #000000;
            background-color: #FFFFFF;
            font-family: Calibri;
        }
        .auto-style346 {
            border: 1px solid #000000;
            background-color: #FFFFFF;
            font-family: Calibri;
        }
        </style>
      <script>
function printDiv(divId) {
    var printableContent = document.getElementById(divId).innerHTML;
    var originalContent = document.body.innerHTML;

    // Create a new window for printing
    var printWindow = window.open('', '_blank');

    printWindow.document.write('<html><head><title></title>');
    printWindow.document.write('<style type="text/css">');
    printWindow.document.write('@media print {');
    printWindow.document.write('    body {');
    printWindow.document.write('        font-family: Arial, sans-serif;');
    printWindow.document.write('        color: #333; /* Text color */');
    printWindow.document.write('        text-align: center; /* Center align text */');
    // Add more CSS styles as needed
    printWindow.document.write('    }');
    printWindow.document.write('}');
    printWindow.document.write('</style>');
    printWindow.document.write('</head><body>');

    // Write printable content into the new window
    printWindow.document.write(printableContent);

    printWindow.document.write('</body></html>');
    printWindow.document.close();

    // Focus and print the new window
    printWindow.focus();
    printWindow.print();
    printWindow.close();

    // Restore original content on the main page
    document.body.innerHTML = originalContent;
}
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server"><%--<Triggers><asp:PostBackTrigger ControlID="Button2" /></Triggers>--%><ContentTemplate>
       <center>
            <center>
                
                <span class="auto-style184"><%--<asp:Button ID="Button2" runat="server" CssClass="auto-style102" Height="43px" Text="Export To PDF" />--%></span>
      </center>
           <script>
               $(function () {
                   var power = '<%= Session("access power") %>';
                   if (power == 3) {
                       var webcamWidth = $('#webcam').width();
                       var webcamHeight = $('#webcam').height();

                       Webcam.set({
                           width: webcamWidth,
                           height: webcamHeight,
                           image_format: 'jpeg',
                           jpeg_quality: 90
                       });

                       Webcam.attach('#webcam');

                       $("#btnCapture").click(function () {
                           Webcam.snap(function (data_uri) {
                               var img = new Image();
                               img.src = data_uri;
                               img.onload = function () {
                                   var canvas = document.createElement('canvas');
                                   var ctx = canvas.getContext('2d');

                                   canvas.width = img.width;
                                   canvas.height = img.height + 30;

                                   ctx.drawImage(img, 0, 0);

                                   ctx.font = '20px Arial';
                                   ctx.fillStyle = 'white';
                                   ctx.textAlign = 'center';

                                   var currentDate = new Date();
                                   var dateTimeText = currentDate.toLocaleString();

                                   ctx.fillText(dateTimeText, canvas.width / 2, canvas.height - 10);

                                   var finalImage = canvas.toDataURL('image/jpeg');

                                   $("#imgCapture")[0].src = finalImage;

                               };
                           });
                       });

                       $("#btnUpload").click(function () {
                           var imageData = $("#imgCapture")[0].src;

                           $.ajax({
                               type: "POST",
                               url: "Finance_Accounting_Payable_New.aspx/SaveCapturedImage",
                               data: JSON.stringify({ data: imageData }),
                               contentType: "application/json; charset=utf-8",
                               dataType: "json",
                               success: function (r) {
                                   alert('Image saved successfully!');
                                   chk3Display()
                               },
                               error: function (xhr, status, error) {
                                   alert("There was an error uploading the image.");
                               }
                           });
                       });
                   }
               });

               function chk3Display() {
                   $(".emps").css("display", "block");
               }

           </script>
           <%-- <br class="auto-style184" />
            <span class="auto-style184">
            <script type="text/javascript">--%>
   <%-- function ValidateCheckBoxList(sender, args) {
        var checkBoxList = document.getElementById("<%=CheckBoxList1.ClientID %>"); 
        var checkboxes = checkBoxList.getElementsByTagName("input");
        var isValid = false;
        for (var i = 0; i < checkboxes.length; i++) {
            if (checkboxes[i].checked) {
                isValid = true;
                break;
            }
        }
        args.IsValid = isValid;
        }
         function ValidateCheckBoxList1(sender, args) {
        var checkBoxList = document.getElementById("<%=CheckBoxList2.ClientID %>"); 
        var checkboxes = checkBoxList.getElementsByTagName("input");
        var isValid = false;
        for (var i = 0; i < checkboxes.length; i++) {
            if (checkboxes[i].checked) {
                isValid = true;
                break;
            }
        }
        args.IsValid = isValid;
        }
         function ValidateCheckBoxList2(sender, args) {
        var checkBoxList = document.getElementById("<%=CheckBoxList3.ClientID %>"); 
        var checkboxes = checkBoxList.getElementsByTagName("input");
        var isValid = false;
        for (var i = 0; i < checkboxes.length; i++) {
            if (checkboxes[i].checked) {
                isValid = true;
                break;
            }
        }
        args.IsValid = isValid;
        }
         function ValidateCheckBoxList3(sender, args) {
        var checkBoxList = document.getElementById("<%=CheckBoxList4.ClientID %>"); 
        var checkboxes = checkBoxList.getElementsByTagName("input");
        var isValid = false;
        for (var i = 0; i < checkboxes.length; i++) {
            if (checkboxes[i].checked) {
                isValid = true;
                break;
            }
        }
        args.IsValid = isValid;
        }
         function ValidateCheckBoxList4(sender, args) {
        var checkBoxList = document.getElementById("<%=CheckBoxList5.ClientID %>"); 
        var checkboxes = checkBoxList.getElementsByTagName("input");
        var isValid = false;
        for (var i = 0; i < checkboxes.length; i++) {
            if (checkboxes[i].checked) {
                isValid = true;
                break;
            }
        }
        args.IsValid = isValid;
        }
        --%>
<%--</script>--%>

     </span>
                        <!-- Webcam Container -->
<div id="outerimgdiv" style="position:fixed;" runat="server">
    <div class="camera-container">
        <div id="webcam"></div>
         <button id="btnCapture" type="button" class="btn-success form-control">Capture</button>
    </div>
    <br />
    <div class="camera-container">
        <img id="imgCapture" />
        <button id="btnUpload" type="button" class="form-control btn-primary" >Upload</button>
    </div>
</div>
        <!-- Webcam Container -->
             <div id="printableContent">
            <asp:Panel ID="Panel1" runat="server" BackColor="#ffffff" BorderStyle="Solid" CssClass="auto-style183" Width="900px">
                <table id="1" border="1" class="auto-style21" style="width:895px">
                    <tr>
                        <td class="auto-style31" style="font-size: medium; font-style: oblique; font-weight:bold">
                            <center>
                                <table class="nav-justified">
                                    <tr>
                                        <td class="auto-style114">Performance Review  Form ( for level 2 and Level 3) Engineering Department Utility Section  績效評估表（二級、三級） 工程部公用科                                                 </td>
                                        </em>
                                       
                                    </tr>
                                </table>
                            </center>
                        </td>
                    </tr>
                    </em></em><em>
                    <tr>
                        <td class="auto-style31" style="font-weight:bold">
                            <center class="auto-style68" style="background-color:#61cbf3;">
                                A. Employee Information 員工信息</center>
                        </td>
                    </tr>
                    </em>
                </table>
                <em><em>
                <tr>
                    <td class="auto-style24">
                    </td>
                </tr>
             
                </em></em>
                <table id="2" class="auto-style20"   style="width:100%; border-collapse: collapse; text-align:center">
                    <tr>
                        <td class="auto-style280">
                            <table class="nav-justified" style="width:100%; border-collapse: collapse; text-align:center">
                                <tr>
                                    <td class="auto-style122">
                                        <table class="nav-justified" border="1"  style="width:100%; border-collapse: collapse; text-align:center">
                                            <tr>
                                                <td class="auto-style302">Employee Name</td>
                                                <td class="auto-style301">
                                                    <asp:Label ID="empname" runat="server" CssClass="auto-style280" Text="Label"></asp:Label>
                                                </td>
                                                <td class="auto-style302">Employee Code</td>
                                                <em>
                                                <td class="auto-style301">
                                                    <asp:Label ID="empcode" runat="server" CssClass="auto-style280" Text="Label"></asp:Label>
                                                </td>
                                                <td class="auto-style302">Desgnation</td>
                                                <td class="auto-style122">
                                                    <asp:Label ID="desc" runat="server" CssClass="auto-style280" Text="Label"></asp:Label>
                                                </td>
                                                </em>
                                            </tr>
                                            <tr>
                                                <td class="auto-style302">Dept./ Section</td>
                                                <td class="auto-style301">
                                                    <asp:Label ID="deptsect" runat="server" CssClass="auto-style280" Text="Label"></asp:Label>
                                                </td>
                                                <td class="auto-style302">DOJ</td>
                                                <td class="auto-style301">
                                                    <asp:Label ID="doj" runat="server" CssClass="auto-style280" Text="Label"></asp:Label>
                                                </td>
                                                <td class="auto-style302">Reporting To</td>
                                                <td class="auto-style122">
                                                    <asp:Label ID="repto" runat="server" CssClass="auto-style280" Text="Label"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="auto-style302">Review Time</td>
                                                <td class="auto-style122" colspan="2">
                                                    <asp:CheckBox ID="trai" runat="server" CssClass="auto-style280" Text="Training" AutoPostBack="True" Enabled="False" />
                                                    &nbsp;<asp:CheckBox ID="prob" runat="server" CssClass="auto-style280" Text="Probation" AutoPostBack="True" Enabled="False" />
                                                    &nbsp;<asp:CheckBox ID="conf" runat="server" CssClass="auto-style280" Text="Confirm" AutoPostBack="True" Enabled="False" />
                                                </td>
                                                <td class="auto-style122" colspan="3">Year : <em>
                                                    <asp:Label ID="revmonth" runat="server" CssClass="auto-style280" Text="Label"></asp:Label>
                                                    &nbsp;
                                                    </em>
                                                    <asp:CheckBox ID="month" runat="server" CssClass="auto-style280" Text="Monthly" AutoPostBack="True"  />
                                                     &nbsp;&nbsp;&nbsp;     
                        <asp:CheckBox ID="quaterly" runat="server" CssClass="auto-style280" Text="Quarterly" AutoPostBack="True"  />
                        &nbsp;
                                                    <em>&nbsp;</em><asp:CheckBox ID="q1" runat="server" CssClass="auto-style280" Text="Q1" AutoPostBack="True" Visible="False" />
                                                    <em>&nbsp;</em><asp:CheckBox ID="q2" runat="server" CssClass="auto-style280" Text="Q2" AutoPostBack="True" Visible="False" />
                                                    <em>&nbsp;</em><asp:CheckBox ID="q3" runat="server" CssClass="auto-style280" Text="Q3" AutoPostBack="True" Visible="False" />
                                                    <em>&nbsp;</em><asp:CheckBox ID="q4" runat="server" CssClass="auto-style280" Text="Q4" AutoPostBack="True" Visible="False" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style284" style="border-collapse: collapse; background-color:#f7c7ac; font-weight:bold; font-size:medium">Utility Assessment Parameters for
                             <em>&nbsp;</em><asp:CheckBox ID="CheckBox1" runat="server" CssClass="auto-style280" Text="Elec & Main" AutoPostBack="True" Visible="true" />
                                                    <em>&nbsp;</em><asp:CheckBox ID="CheckBox2" runat="server" CssClass="auto-style280" Text="Operation" AutoPostBack="True" Visible="true" />
                        </td>
                    </tr>
                    <em>
                   <%-- <tr>
                        <td class="auto-style280">
                            <table class="nav-justified"  border ="1" style="width:100%; border-collapse: collapse; text-align:center">
                                <tr style="background-color: #D9E1F2; text-align:center">
                                    <td class="auto-style336" colspan="2"><strong>B. Fixed固定的</strong></td>
                                    <td class="auto-style337"><strong>76%</strong></td>
                                    <td class="auto-style338"><strong>C. Variable 可變的 (Work attitude 工作態度)</strong></td>
                                    <td class="auto-style339"><strong>24%</strong></td>
                                </tr>
                            </table>
                            <table class="nav-justified"  border ="1" style="width:100%; border-collapse: collapse; text-align:center">
                                <tr>
                                    <td class="auto-style346" rowspan="3">Morale</td>
                                    <td class="auto-style346">Attendance 出勤率</td>
                                    <td class="auto-style345"><em>
                                        <table class="nav-justified">
                                            <tr>
                                                <td class="auto-style293">20%</td>
                                                <td class="auto-style304">
                                                    <asp:TextBox ID="score1" runat="server" CssClass="auto-style165" Width="70px" AutoPostBack="True" style="text-align:center" TabIndex="1" ></asp:TextBox>
                                                </td>
                                            </tr>
                                        </table>
                                        </em></td>
                                    <td class="auto-style133" rowspan="3">
                                        <table  class="nav-justified" border="1"  style="width:100%; height:100%; border-collapse: collapse; text-align:center">
                                            <tr>
                                                <td class="auto-style122" rowspan="2"><br /><br /><br /><br />Communication<br /><br /><br /><br /></td>
                                                <td class="auto-style122">System Observation reporting to Leader/ Supervisor
                                                    <br />
                                                    公用設備- 問題發現/通報</td>
                                            </tr>
                                            <tr>
                                                <td class="auto-style344">Inter/Intra department communication and behavior
                                                    <br />
                                                    部門內/外- 溝通/協調</td>
                                            </tr>
                                        </table>
                                    </td>
                                    <td class="auto-style132" rowspan="2"><em>
                                        <table class="nav-justified">
                                            <tr>
                                                <td class="auto-style293">6%</td>
                                                <td class="auto-style304">
                                                    <asp:TextBox ID="score10" runat="server" CssClass="auto-style165" Width="70px" AutoPostBack="True" style="text-align:center" TabIndex="10"></asp:TextBox>
                                                </td>
                                            </tr>
                                        </table>
                                        </em></td>
                                </tr>
                                <tr>
                                    <td class="auto-style346">Dicipline / Adhering organisation rules 紀律/遵守組織規則</td>
                                    <td class="auto-style345"><em>
                                        <table class="nav-justified">
                                            <tr>
                                                <td class="auto-style293">5%</td>
                                                <td class="auto-style304">
                                                    <asp:TextBox ID="score2" runat="server" CssClass="auto-style165" Width="70px" AutoPostBack="True" style="text-align:center" TabIndex="2"></asp:TextBox>
                                                </td>
                                            </tr>
                                        </table>
                                        </em></td>
                                </tr>
                                <tr>
                                    <td class="auto-style346">Work attitude - As per Management time line/ requirement 工作態度/ 完成時間</td>
                                    <td class="auto-style345"><em>
                                        <table class="nav-justified">
                                            <tr>
                                                <td class="auto-style293">5%</td>
                                                <td class="auto-style304">
                                                    <asp:TextBox ID="score3" runat="server" CssClass="auto-style165" Width="70px" AutoPostBack="True" style="text-align:center" TabIndex="3"></asp:TextBox>
                                                </td>
                                            </tr>
                                        </table>
                                        </em></td>
                                    <td class="auto-style132"><em>
                                        <table class="nav-justified">
                                            <tr>
                                                <td class="auto-style293">6%</td>
                                                <td class="auto-style304">
                                                    <asp:TextBox ID="score11" runat="server" CssClass="auto-style165" Width="70px" AutoPostBack="True" style="text-align:center" TabIndex="11"></asp:TextBox>
                                                </td>
                                            </tr>
                                        </table>
                                        </em></td>
                                </tr>
                                <tr>
                                    <td class="auto-style346" rowspan="4">Work rate achievement</td>
                                    <td class="auto-style346">Work completion rate / Following orders 工作交辦/ 指令服從</td>
                                    <td class="auto-style345"><em>
                                        <table class="nav-justified">
                                            <tr>
                                                <td class="auto-style293">5%</td>
                                                <td class="auto-style304">
                                                    <asp:TextBox ID="score4" runat="server" CssClass="auto-style165" Width="70px" AutoPostBack="True" style="text-align:center" TabIndex="4"></asp:TextBox>
                                                </td>
                                            </tr>
                                        </table>
                                        </em></td>
                                    <td class="auto-style133" rowspan="6">
                                        <table class="nav-justified"  border ="1" style="width:100%; border-collapse: collapse; text-align:center">
                                            <tr>
                                                <td class="auto-style122" rowspan="2"><br /><br /><br /><br /><br /><br />Material/Equipment Management<br /><br /><br /><br /><br /><br /><br /></td>
                                                <td class="auto-style122">Effective material usage/ Management / Methods 化學品/材料- 有效利用/管理</td>
                                            </tr>
                                            <tr>
                                                <td class="auto-style122">Problem solving ability - Utility equipment
                                                    <br />
                                                    公用設備 - 機故即時處理能力</td>
                                            </tr>
                                        </table>
                                    </td>
                                    <td class="auto-style132" rowspan="3"><em>
                                        <table class="nav-justified">
                                            <tr>
                                                <td class="auto-style293">6%</td>
                                                <td class="auto-style304">
                                                    <asp:TextBox ID="score12" runat="server" CssClass="auto-style165" Width="70px" AutoPostBack="True" style="text-align:center" TabIndex="12"></asp:TextBox>
                                                </td>
                                            </tr>
                                        </table>
                                        </em></td>
                                </tr>
                                <tr>
                                    <td class="auto-style346"><em>Operation as per control limits/ Maintaining parameters 一級檢點/ 數據維持</em></td>
                                    <td class="auto-style345"><em>
                                        <table class="nav-justified">
                                            <tr>
                                                <td class="auto-style293">20%</td>
                                                <td class="auto-style304">
                                                    <asp:TextBox ID="score5" runat="server" CssClass="auto-style165" Width="70px" AutoPostBack="True" style="text-align:center" TabIndex="5"></asp:TextBox>
                                                </td>
                                            </tr>
                                        </table>
                                        </em></td>
                                </tr>
                                <tr>
                                    <td class="auto-style346">Machine availability down time management 設備停機時間</td>
                                    <td class="auto-style345"><em>
                                        <table class="nav-justified">
                                            <tr>
                                                <td class="auto-style293">6%</td>
                                                <td class="auto-style304">
                                                    <asp:TextBox ID="score6" runat="server" CssClass="auto-style165" Width="70px" AutoPostBack="True" style="text-align:center" TabIndex="6"></asp:TextBox>
                                                </td>
                                            </tr>
                                        </table>
                                        </em></td>
                                </tr>
                                <tr>
                                    <td class="auto-style346">Satety/ Major breakdown due to negligence 安全/疏忽-重大異常</td>
                                    <td class="auto-style345"><em>
                                        <table class="nav-justified">
                                            <tr>
                                                <td class="auto-style293">5%</td>
                                                <td class="auto-style304">
                                                    <asp:TextBox ID="score7" runat="server" CssClass="auto-style165" Width="70px" AutoPostBack="True" style="text-align:center" TabIndex="7"></asp:TextBox>
                                                </td>
                                            </tr>
                                        </table>
                                        </em></td>
                                    <td class="auto-style132" rowspan="3"><em>
                                        <table class="nav-justified">
                                            <tr>
                                                <td class="auto-style293">6%</td>
                                                <td class="auto-style304">
                                                    <asp:TextBox ID="score13" runat="server" CssClass="auto-style165" Width="70px" AutoPostBack="True" style="text-align:center" TabIndex="13"></asp:TextBox>
                                                </td>
                                            </tr>
                                        </table>
                                        </em></td>
                                </tr>
                                <tr>
                                    <td class="auto-style346" rowspan="2">Improvement</td>
                                    <td class="auto-style342">Continuous learning/ improvements in the existing process 持續學習/提案改善</td>
                                    <td class="auto-style343"><em>
                                        <table class="nav-justified">
                                            <tr>
                                                <td class="auto-style293">5%</td>
                                                <td class="auto-style304">
                                                    <asp:TextBox ID="score8" runat="server" CssClass="auto-style165" Width="70px" AutoPostBack="True" style="text-align:center" TabIndex="8"></asp:TextBox>
                                                </td>
                                            </tr>
                                        </table>
                                        </em></td>
                                </tr>
                                <tr>
                                    <td class="auto-style346">5S for the Work Place 環境維持</td>
                                    <td class="auto-style345"><em>
                                        <table class="nav-justified">
                                            <tr>
                                                <td class="auto-style293">5%</td>
                                                <td class="auto-style304">
                                                    <asp:TextBox ID="score9" runat="server" CssClass="auto-style165" Width="70px" AutoPostBack="True" style="text-align:center" TabIndex="9"></asp:TextBox>
                                                </td>
                                            </tr>
                                        </table>
                                        </em></td>
                                </tr>
                            </table>
                        </td>
                    </tr>--%>
                        <tr>
                            <td class="auto-style280">
                            <!--start here-->
                                <table class="nav-justified"  border ="1" style="width:100%; border-collapse: collapse; text-align:center">
                                <tr style="background-color: #D9E1F2; text-align:center">
                                    <td class="auto-style336" colspan="2"><strong>B. Fixed固定的</strong></td>
                                    <td class="auto-style337"><strong>76%</strong></td>
                                    <td class="auto-style338"><strong>C. Variable 可變的 (Work attitude 工作態度)</strong></td>
                                    <td class="auto-style339"><strong>24%</strong></td>
                                </tr>
                               </table>
                            <table class="nav-justified"  border ="1" style="width:100%; border-collapse: collapse; text-align:center">
                                <tr>
                                    <td class="auto-style346" rowspan="3"style="transform: rotate(-90deg); text-align: center; background-color:unset !important;font-size:medium">Morale</td>
                                    <td class="auto-style346" style="width:300px">Attendance 出勤率</td>
                                    <td class="auto-style345"><em>
                                        <table class="nav-justified">
                                            <tr>
                                                <td class="auto-style293">20%</td>
                                                <td class="auto-style304">
                                                    <asp:TextBox ID="score1" runat="server" CssClass="auto-style165" Width="70px" AutoPostBack="True" style="text-align:center" TabIndex="1" ></asp:TextBox>
                                                </td>
                                            </tr>
                                        </table>
                                        </em>

                                    </td>
                                    <td class="auto-style133" rowspan="3">
                                        <table  class="nav-justified" border="1"  style="width:100%; height:100%; border-collapse: collapse; text-align:center">
                                            <tr>
                                                <td class="auto-style122" rowspan="2" style="transform: rotate(-90deg); text-align: center; background-color: unset !important; font-size: medium;">
<br /><br /><br />Communication<br /><br /><br /><br />
</td>

                                                <td class="auto-style122">System Observation reporting to Leader/ Supervisor
                                                    <br />
                                                    公用設備- 問題發現/通報</td>
                                            </tr>
                                            <tr>
                                                <td class="auto-style344">Inter/Intra department communication and behavior
                                                    <br />
                                                    部門內/外- 溝通/協調</td>
                                            </tr>
                                        </table>
                                    </td>
                                    <td class="auto-style132" rowspan="2"><em>
                                        <table class="nav-justified">
                                            <tr>
                                                <td class="auto-style293">6%</td>
                                                <td class="auto-style304">
                                                    <asp:TextBox ID="score14" runat="server" CssClass="auto-style165" Width="70px" AutoPostBack="True" style="text-align:center" TabIndex="14"></asp:TextBox>
                                                </td>
                                            </tr>
                                        </table>
                                        </em></td>
                                </tr>
                                <tr>
                                    <td class="auto-style346">Dicipline / Adhering organisation rules 紀律/遵守組織規則</td>
                                    <td class="auto-style345"><em>
                                        <table class="nav-justified">
                                            <tr>
                                                <td class="auto-style293">5%</td>
                                                <td class="auto-style304">
                                                    <asp:TextBox ID="score2" runat="server" CssClass="auto-style165" Width="70px" AutoPostBack="True" style="text-align:center" TabIndex="2"></asp:TextBox>
                                                </td>
                                            </tr>
                                        </table>
                                        </em></td>
                                </tr>
                                <tr>
                                    <td class="auto-style346">Work attitude - As per Management time line/ requirement 工作態度/ 完成時間</td>
                                    <td class="auto-style345"><em>
                                        <table class="nav-justified">
                                            <tr>
                                                <td class="auto-style293">5%</td>
                                                <td class="auto-style304">
                                                    <asp:TextBox ID="score3" runat="server" CssClass="auto-style165" Width="70px" AutoPostBack="True" style="text-align:center" TabIndex="3"></asp:TextBox>
                                                </td>
                                            </tr>
                                        </table>
                                        </em></td>
                                    <td class="auto-style132"><em>
                                        <table class="nav-justified">
                                            <tr>
                                                <td class="auto-style293">6%</td>
                                                <td class="auto-style304">
                                                    <asp:TextBox ID="score15" runat="server" CssClass="auto-style165" Width="70px" AutoPostBack="True" style="text-align:center" TabIndex="15"></asp:TextBox>
                                                </td>
                                            </tr>
                                        </table>
                                        </em></td>
                                </tr>
                                <tr>
                                    <td class="auto-style346" rowspan="2">Work rate achievement</td>
                                    <td class="auto-style346">
                                         <table class="nav-justified" border="1"  style="border-collapse: collapse;">
                                             <tr>
                                                  <td rowspan="5">
                                                   <asp:CheckBox ID="CheckBox3" runat="server" CssClass="auto-style280"  Text="&nbsp;&nbsp;Electrical & Mechanical Team" Enabled="true"  AutoPostBack="true" />
                                                    </td>
                                              </tr>
                                             <tr>
                                                 <td> Work completion rate / Following orders   工作交辦/ 指令服從</td>
                                            
                                             </tr>
                                              <tr>
                                                 <td>Contact form, PM and breakdown maintenance achiev 聯絡單/ 保養達成率</td>
                                            
                                             </tr>
                                             <tr>
                                                 <td>Machine availability down time management 設備停機時間</td>
                                            
                                             </tr>
                                              <tr>
                                                 <td>Satety/ Major breakdown due to negligence  安全/疏忽-重大異常</td>
                                            
                                             </tr>
                                            <%--</tr>--%>
                                        </table>
                                    </td>
                                  <%--  <td class="auto-style345"><em>
                                       
                                  <table class="nav-justified" border="0" style="border-collapse: collapse;width:100%">
                                <tr style=" border-bottom:1px solid gray">
                                    <td class="auto-style293">15%</td>
                                    <td class="auto-style304">
                                        <asp:TextBox ID="score4" runat="server" CssClass="auto-style165" Width="70px" AutoPostBack="True" style="text-align:center;" TabIndex="1"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr style=" border-bottom:1px solid gray">
                                    <td class="auto-style293">10%</td>
                                    <td class="auto-style304">
                                        <asp:TextBox ID="score5" runat="server" CssClass="auto-style165" Width="70px" AutoPostBack="True" style="text-align:center;" TabIndex="2"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr style="  border-bottom:1px solid gray">
                                    <td class="auto-style293">6%</td>
                                    <td class="auto-style304">
                                        <asp:TextBox ID="score6" runat="server" CssClass="auto-style165" Width="70px" AutoPostBack="True" style="text-align:center;" TabIndex="3"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr style="  border-bottom:1px solid gray">
                                    <td class="auto-style293">5%</td>
                                    <td class="auto-style304">
                                        <asp:TextBox ID="score7" runat="server" CssClass="auto-style165" Width="70px" AutoPostBack="True" style="text-align:center;" TabIndex="4"></asp:TextBox>
                                    </td>
                                </tr>
                            </table>




                                        </em></td>--%>
                                 <td class="auto-style345">
    <em>
        <table class="nav-justified" border="0" style="border-collapse: collapse; width: 100%;">
            <tr style="border-bottom: 1px solid gray; height: 60px;"> <!-- Same height here -->
                <td class="auto-style293" style="text-align: center;">15%</td>
                <td class="auto-style304" style="text-align: center;">
                    <asp:TextBox ID="score4" runat="server" CssClass="auto-style165" Width="70px" AutoPostBack="True" style="text-align:center;" TabIndex="4"></asp:TextBox>
                </td>
            </tr>
            <tr style="border-bottom: 1px solid gray; height: 78px;"> <!-- Same height here -->
                <td class="auto-style293" style="text-align: center;">10%</td>
                <td class="auto-style304" style="text-align: center;">
                    <asp:TextBox ID="score5" runat="server" CssClass="auto-style165" Width="70px" AutoPostBack="True" style="text-align:center;" TabIndex="5"></asp:TextBox>
                </td>
            </tr>
            <tr style="border-bottom: 1px solid gray; height: 68px;"> <!-- Same height here -->
                <td class="auto-style293" style="text-align: center;">6%</td>
                <td class="auto-style304" style="text-align: center;">
                    <asp:TextBox ID="score6" runat="server" CssClass="auto-style165" Width="70px" AutoPostBack="True" style="text-align:center;" TabIndex="6"></asp:TextBox>
                </td>
            </tr>
            <tr style="border-bottom: 1px solid gray; height: 63px;"> 
                <td class="auto-style293" style="text-align: center;">5%</td>
                <td class="auto-style304" style="text-align: center;">
                    <asp:TextBox ID="score7" runat="server" CssClass="auto-style165" Width="70px" AutoPostBack="True" style="text-align:center;" TabIndex="7"></asp:TextBox>
                </td>
            </tr>
        </table>
    </em>
</td>


                                    <td class="auto-style133" rowspan="1">
                                        <table class="nav-justified"  border ="1" style="width:100%; border-collapse: collapse; text-align:center;height: 269px;">
                                            <tr>
                                                <td class="auto-style122" rowspan="2"><br /><br /><br /> Material/Equipment Management<br /><br /><br /><br /></td>
                                                <td class="auto-style122" style="width: 194px;">Effective material usage/ Management / Methods 化學品/材料- 有效利用/管理</td>
                                            </tr>
                                            <tr>
                                                <td class="auto-style122">Problem solving ability - Utility equipment
                                                    <br />
                                                    公用設備 - 機故即時處理能力</td>
                                            </tr>
                                        </table>
                                    </td>
                                 <td class="auto-style132" " style="display: flex; flex-direction: column; height: 100%; justify-content: space-between;">
                                     <div style="border-bottom:1px solid gray">
                                           
                                            <table class="nav-justified" style="height: 134px;" >
                                                <tr style="border:1px solid gray">
                                                    <td class="auto-style293">6%</td>
                                                    <td class="auto-style304">
                                                        <asp:TextBox ID="score16" runat="server" CssClass="auto-style165" Width="70px" AutoPostBack="True" style="text-align:center" TabIndex="16"></asp:TextBox>
                                                    </td>
                                                </tr>

                                            </table>
                                         </div>

                                          
                                            <table class="nav-justified" style="height: 134px;">
                                                <tr >
                                                    <td class="auto-style293">6%</td>
                                                    <td class="auto-style304">
                                                        <asp:TextBox ID="score17" runat="server" CssClass="auto-style165" Width="70px" AutoPostBack="True" style="text-align:center" TabIndex="17"></asp:TextBox>
                                                    </td>
                                                </tr>
                                            </table>

                                        </td>


                                  
                                </tr>
                                <tr>
                                    <td class="auto-style346">
                                         <table class="nav-justified" border="1"  style="border-collapse: collapse;">
                                             <tr>
                                                  <td rowspan="5">
                                                   <asp:CheckBox ID="CheckBox4" runat="server" CssClass="auto-style280"  Text="&nbsp;&nbsp;Operation Team" Enabled="true"  AutoPostBack="true" />
                                                    </td>
                                              </tr>
                                             <tr>
                                                 <td> Work completion rate / Following orders 工作交辦/ 指令服從</td>
                                            
                                             </tr>
                                              <tr>
                                                 <td>Operation as per control limits/ Maintaining parameters  一級檢點/ 數據維持</td>
                                            
                                             </tr>
                                             <tr>
                                                 <td>Machine availability down time management 設備停機時間</td>
                                            
                                             </tr>
                                              <tr>
                                                 <td>Satety/ Major breakdown due to negligence  安全/疏忽-重大異常</td>
                                            
                                             </tr>
                                          
                                        </table>

                                    </td>
                                     <td class="auto-style345"><em>
                                       
                                  <table class="nav-justified" border="0" style="border-collapse: collapse;width:100%">
                                <tr style="height: 60px; border-bottom:1px solid gray;">
                                    <td class="auto-style293">5%</td>
                                    <td class="auto-style304">
                                        <asp:TextBox ID="score8" runat="server" CssClass="auto-style165" Width="70px" AutoPostBack="True" style="text-align:center;" TabIndex="8"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr style="height: 78px; border-bottom:1px solid gray">
                                    <td class="auto-style293">20%</td>
                                    <td class="auto-style304">
                                        <asp:TextBox ID="score9" runat="server" CssClass="auto-style165" Width="70px" AutoPostBack="True" style="text-align:center;" TabIndex="9"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr style="height: 68px; border-bottom:1px solid gray">
                                    <td class="auto-style293">6%</td>
                                    <td class="auto-style304">
                                        <asp:TextBox ID="score10" runat="server" CssClass="auto-style165" Width="70px" AutoPostBack="True" style="text-align:center;" TabIndex="10"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr style="height: 63px; border-bottom:1px solid gray">
                                    <td class="auto-style293">5%</td>
                                    <td class="auto-style304">
                                        <asp:TextBox ID="score11" runat="server" CssClass="auto-style165" Width="70px" AutoPostBack="True" style="text-align:center;" TabIndex="11"></asp:TextBox>
                                    </td>
                                </tr>
                            </table>


                                        </em></td>
                                 <td rowspan="2" colspan="2">
                                     <div style="background-color: #c0e6f5; padding:5px;margin-top:-60px">
                                    <label style=" font-size: medium; font-weight: bold; padding: 5px; ">
                                        Recommendation & Areas of Improvement / Comment of Supervisor 主管的建議和改進領域/評論：
                                    </label>
                                     </div>
                                    <asp:TextBox ID="remark4" runat="server" TextMode="MultiLine" Rows="12" Columns="50" 
                                                 style="width: 100%;  box-sizing: border-box; border: none; margin-top: 5px;" />
                                </td>



                                     <td rowspan="1" colspan="1"  >
                                          
                                    </td>
                                </tr>
                                <tr>
                                   
                                    <td class="auto-style346" rowspan="2">Improvement</td>
                                    <td class="auto-style342">Continuous learning/ improvements in the existing process 持續學習/提案改善</td>
                                    <td class="auto-style343"><em>
                                        <table class="nav-justified">
                                            <tr>
                                                <td class="auto-style293">5%</td>
                                                <td class="auto-style304">
                                                    <asp:TextBox ID="score12" runat="server" AutoPostBack="True" CssClass="auto-style165" style="text-align:center" TabIndex="12" Width="70px"></asp:TextBox>
                                                </td>
                                            </tr>
                                        </table>
                                        </em></td>
                                </tr>
                                <tr>
                                    <td class="auto-style346">5S for the Work Place 環境維持</td>
                                    <td class="auto-style345"><em>
                                        <table class="nav-justified" >
                                            <tr>
                                                <td class="auto-style293">5%</td>
                                                <td class="auto-style304" colspan="2">
                                                    <asp:TextBox ID="score13" runat="server" CssClass="auto-style165" Width="70px" AutoPostBack="True" style="text-align:center" TabIndex="13"></asp:TextBox>
                                                </td>
                                            </tr>
                                        </table>
                                        </em></td>
                                </tr>
                            </table>
                           

                            </td>
                            </tr>

                    </em>
                </table>
                <em><em><em></td>
                </em>
                </tr>
                <em></em><em></em></em></em></em>
                <tr>
                    <td class="auto-style280">
                        <table  class="nav-justified"  border ="1" style="width:100%; border-collapse: collapse; text-align:center">
                            <tr>
                                <td class="auto-style312" colspan="2" rowspan="2"  style="background-color: #83cceb;text-align:center"><strong>D. Leaders Review 領導者</strong></td>
                                <td class="auto-style314" style="background-color: #61cbf3; text-align:center">0<strong>%</strong></td>
                            </tr>
                            <tr >
                                <td class="auto-style313"  style="background-color: #61cbf3; text-align:center">
                                    (0% but can change all)</td>
                            </tr>
                            <tr>
                                <td class="auto-style137">1. Leader </td>
                                <td class="auto-style138">
                                    <asp:TextBox ID="ldr" runat="server" CssClass="auto-style165" Width="244px" AutoPostBack="True" style="text-align:center" TabIndex="18"></asp:TextBox>
                                </td>
                                <td class="auto-style303">
                                    <asp:TextBox ID="score18" runat="server" CssClass="auto-style165" Width="244px" AutoPostBack="True" style="text-align:center" TabIndex="19"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style291">2. Section Head</td>
                                <td class="auto-style138">
                                    <asp:TextBox ID="shead" runat="server" CssClass="auto-style165" Width="244px" AutoPostBack="True" style="text-align:center" TabIndex="20"></asp:TextBox>
                                </td>
                                <td class="auto-style122">
                                    <asp:TextBox ID="score19" runat="server" CssClass="auto-style165" Width="244px" AutoPostBack="True" style="text-align:center" TabIndex="21"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style291">3. Department Head</td>
                                <td class="auto-style138">
                                    <asp:TextBox ID="dhead" runat="server" CssClass="auto-style165" Width="244px" AutoPostBack="True" style="text-align:center" TabIndex="22"></asp:TextBox>
                                </td>
                                <td class="auto-style122">
                                    <asp:TextBox ID="score20" runat="server" CssClass="auto-style165" Width="244px" AutoPostBack="True" style="text-align:center" TabIndex="23"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                        <span class="auto-style292"></span>
                    </td>
                </tr>
                </table>
                </em></em>
                  <table class="nav-justified" border="1" style="width:100%; border-collapse: collapse; text-align:center;">
    <tr>
        <td class="auto-style284" colspan="2">
            <table class="nav-justified" border="1" style="width:100%; border-collapse: collapse; text-align:center;">
                <tr style="background-color: #D9E1F2; text-align:center">
                    <td class="auto-style315" colspan="5" style="background-color: #83cceb; font-weight:bold; font-size:small">
                        <strong>E. Criteria of after Monthly /Quarterly /Yearly performance 月/季/年 績後標準 (Only those who completed 1 year since DOJ)</strong>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style122" rowspan="2">Performance Evaluation based on assessment
                        <span class="auto-style289">
                            <asp:Label ID="Label30" runat="server" CssClass="auto-style280" Text="Label"></asp:Label>
                        </span>
                    </td>
                    <td class="auto-style122" colspan="2"><strong>
                        <asp:CheckBox ID="pass" runat="server" CssClass="auto-style280" Text="&nbsp;Pass" AutoPostBack="True" />
                    </strong></td>
                    <td class="auto-style317" style="background-color: #83cceb">Total Score</td>
                    <td class="auto-style122"><strong>
                        <asp:CheckBox ID="extend" runat="server" CssClass="auto-style280" Text="&nbsp;Extend" AutoPostBack="True" />
                    </strong></td>
                </tr>
                <tr>
                    <td class="auto-style122" colspan="2">100
                        <asp:Image ID="Image8" runat="server" Height="20px" ImageUrl="~/Images/messageImage_1662634718713.jpg" Width="160px" />
                    </td>
                    <td class="auto-style317" style="background-color: #83cceb">76</td>
                    <td class="auto-style122">
                        <asp:Image ID="Image9" runat="server" Height="20px" ImageUrl="~/Images/messageImage_1662634733964.jpg" Width="160px" />
                        &nbsp;0
                    </td>
                </tr>
            </table>
        </td>
    </tr>

    <table class="nav-justified" border="1" style="width:100%; border-collapse: collapse; text-align:center;">
        <tr id="newsection">
          
            <td class="auto-style122" style="width:39.5%; text-align:center;">
                <table class="nav-justified" border="1" style="width:100%; border-collapse: collapse; text-align:center; height: 58px;">
                    <tr>
                        <td class="auto-style319">Actual working days</td>
                        <td class="auto-style319">Actual present days</td>
                        <td class="auto-style319">Total Absent</td>
                    </tr>
                    <tr>
                        <td class="auto-style122" id="actwork" runat="server"></td>
                        <td class="auto-style122" id="actpre" runat="server"></td>
                        <td class="auto-style122" id="absent" runat="server"></td>
                    </tr>
                </table>
            </td>

      
            <td class="auto-style122" style="width:31%; text-align:center;">
                <table class="nav-justified" id="tbl" border="1" style="width:100%; border-collapse: collapse; text-align:center; height: 58px;">
                    <tr>
                        <td class="auto-style319">Above 85</td>
                        <td class="auto-style319">80-84</td>
                    </tr>
                    <tr>
                        <td class="auto-style122">60</td>
                        <td class="auto-style122">40</td>
                    </tr>
                </table>
            </td>

           
            <td class="auto-style122" style="width:33%; text-align:center;">
                <table class="nav-justified" id="tbl1" border="1" style="width:100%; border-collapse: collapse; text-align:center; height: 58px;">
                    <tr>
                        <td class="auto-style319">76-79</td>
                        <td class="auto-style319">Below 76</td>
                    </tr>
                    <tr>
                        <td class="auto-style122">30</td>
                        <td class="auto-style122">0</td>
                    </tr>
                </table>
            </td>
             <tr>
        <td class="auto-style122" style="width:33%; text-align:center; font-size:medium">
            Final Amount per Month = (Actual present day * Rules Amount as PMS)
        </td>
       <td class="auto-style122" style="text-align:center; border:none;">
    <asp:TextBox ID="famnt1" runat="server" AutoPostBack="True" CssClass="auto-style214" Height="46px" 
                 Style="font-family: Calibri; font-size: medium; width: 196%; padding: 5px; text-align:center" />
 
</td>

    </tr>
        </tr>
    </table>

 
   
</table>
                </td>
                </tr>
                </table>
                </em></em></em></em>
                   <table style="width: 100%; border-collapse: collapse;">
    <tr style="background-color: #83cceb; text-align:center">
        <td class="auto-style305" colspan="2" style="background-color: #83cceb; font-weight:bold; font-size:medium">
            <strong>F. The final decision is taken by Department Head for Incentive Payment 最後決定由獎勳支付部門負責人做出</strong>
        </td>
    </tr>
    <tr>
        <td class="auto-style283" style="font-size:medium; font-weight:bold">
            Final decision for Incentive 激勳的最終決定
        </td>
        <td class="auto-style122">
            <table class="nav-justified" border="1" style="width:100%; border-collapse: collapse; text-align:center;">
                <tr>
                    <td class="auto-style117">
                        <em>
                            <asp:CheckBox ID="Eligible" Enabled="false" runat="server" CssClass="auto-style280" AutoPostBack="True" 
                                          />
                        </em>
                        <span class="auto-style280">Eligible 有資格的</span>
                    </td>
                    <td class="auto-style117">
                        <em>
                            <asp:CheckBox ID="Not_Eligible" Enabled="false" runat="server" CssClass="auto-style280" AutoPostBack="True" 
                                       />
                        </em>
                        <span class="auto-style280">Not Eligible 不符合資格</span>
                    </td>
                    <td class="auto-style117">
                     
                        <span class="auto-style280">Reason 原因</span>
                        <table class="nav-justified" border="1" style="width:100%; border-collapse: collapse; text-align:center; height: 58px;">
                            <tr>
                                <td class="auto-style122">
                                    <em>
                                        <asp:CheckBox ID="CheckBox7" Enabled="false" runat="server" CssClass="auto-style280" AutoPostBack="True" 
                                                     />
                                    </em>
                                    <span class="auto-style280">Resign 辭職</span>
                                </td>
                                <td class="auto-style122">
                                    <em>
                                        <asp:CheckBox ID="CheckBox8" Enabled="false" runat="server" CssClass="auto-style280" AutoPostBack="True" 
                                                      />
                                    </em>
                                    <span class="auto-style280">Disciplinary action 紀律處分</span>
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td class="auto-style117">
                        <em>
                            <asp:CheckBox ID="CheckBox6" Enabled="false" runat="server" CssClass="auto-style280" 
                                         />
                        </em>
                        <span class="auto-style280">Incentive as per rule 按規定給予獎勳</span>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>

                <table  border="1" class="auto-style169"  style="width:100%; border-collapse: collapse; text-align:center">
                    <tr>
                        <td class="auto-style282" style="background-color:#0f9ed5"><strong>Remarks 評論</strong></td>
                        <td class="auto-style175" rowspan="2" style="background-color:#0f9ed5"><strong>Total Score<br /> &nbsp;總得分<br /> &nbsp;100%</strong></td>
                        <td class="auto-style173" colspan="3" style="background-color:#0f9ed5"><strong>Approvals 批准</strong></td>
                    </tr>
                    <em>
                    <tr>
                        <td class="auto-style172" rowspan="3" style="text-align:left; font-size:small"><span class="auto-style280">Performance status definition :考核結果說明 </span>
                            <br class="auto-style280" />
                            <span class="auto-style280">1.Pass: Score is 76 or more than 76 every time </span>
                            <br class="auto-style280" />
                            <span class="auto-style280">適任: 分數高於76分 </span>
                            <br class="auto-style280" />
                            <span class="auto-style280">2.Extend : Score is 75 or below 75, turn to extend period(PIP), employee has three months to improve his/her performance.(CW/FT is Not Included in Extend Process; They are directly eligible for fail criteria ) </span>
                            <br class="auto-style280" />
                            <span class="auto-style280">延長:分數低於75分，進入績效改善階段，共三個月之改善期間。（CW/FT 不包括在扩展过程中；它们直接符合失败标准）</span></td>
                        <td class="auto-style180"><span class="auto-style280"><strong>Department Head </strong> </span>
                            <strong>
                            <br class="auto-style280" />
                            </strong>
                            <span class="auto-style280"><strong>部門主管</strong></span></td>
                        <td class="auto-style281"><strong>Section Head<br /> &nbsp;課 長</strong></td>
                        <td class="auto-style180"><span class="auto-style280"><strong>Employee Signature</strong></span><strong><br class="auto-style280" /> </strong> <span class="auto-style280"><strong>員工簽名</strong></span></td>
                    </tr>
                    <tr>
                        <td class="auto-style175" style="font-size:small">
                            <asp:Label ID="totmarks" runat="server" Text="marks"></asp:Label>
                        </td>
                        <td class="auto-style178">
                            <asp:CheckBox ID="ch1" runat="server" CssClass="auto-style280" AutoPostBack="True" />
                        </td>
                        <td class="auto-style178">
                            <asp:CheckBox ID="ch2" runat="server" CssClass="auto-style280" AutoPostBack="True" />
                        </td>
                        <td class="auto-style178">
                            <label id="lblEmpsign" runat="server"></label>
<label id="lblEmpDate" runat="server"></label>
                            <asp:CheckBox ID="ch3" runat="server" AutoPostBack="true" CssClass="auto-style280 emps" style="display:none" onclick="if(!confirm('Are you sure you want to Accept?'))return false;" />
                        </td>
                    </tr>
                    </em>
                    <tr>
                        <td class="auto-style280" colspan="4" style="font-size:small">
                            <asp:Label ID="Time" runat="server" Text="Label"></asp:Label>
                        </td>
                    </tr>
                </table>
              
            </asp:Panel>
                  <!-- This code for footer title -->
                <div style="display: flex; width:880px; justify-content: space-between; align-items: flex-end; text-align: center; margin-top:7px;">
    <div style="text-align: left;">
        Retention Period: Keep until <br />
        the employee's relieving <br />
        period is completed <br />
        label
    </div>
    <div style="text-align: center;">MAXXIS RUBBER INDIA PVT. LTD.</div>
    <div style="text-align: right;">A4/A3 No. 0399-1</div>
</div>
                <!-- This code for footer title  end-->
                 </div><br />
             <asp:Button ID="insert" runat="server" cssclass="btn btn-primary" style="font-family: call; font-size: small;" Text="Submit" ValidationGroup="insert" />

                <em><em></td>
                </tr>
                </em></em></em>
                &nbsp;<span class="auto-style184"><asp:Button ID="update" runat="server" cssclass="btn btn-primary" OnClick="update_Click" style="font-family: call; font-size: small;" Text="Update" ValidationGroup="insert" />
                &nbsp;<asp:Button ID="show" runat="server" cssclass="btn btn-primary" style="font-family: call; font-size: small;" Text="Show" ValidationGroup="insert" />
                </span>
             <asp:LinkButton runat="server" id="print" cssclass="btn btn-warning" OnClientClick = "printDiv('printableContent')"><i class="fa fa-print"></i> Print</asp:LinkButton>
       </center>
        <br/>
        </ContentTemplate></asp:UpdatePanel>
</asp:Content>



