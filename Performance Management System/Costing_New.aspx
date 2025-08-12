<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site1.Master" CodeBehind="Costing_New.aspx.vb" Inherits="Performance_Management_System.Costing_New" %>
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
        .auto-style122 {
            border: 1px solid #000000;
        }
        .auto-style129 {
            width: 134px;
            border: 1px solid #000000;
        }
        .auto-style130 {
            width: 345px;
            border: 1px solid #000000;
            font-family: Calibri;
        }
        .auto-style131 {
            width: 67px;
        }
        .auto-style132 {
            width: 134px;
            border: 1px solid #000000;
            background-color: #D9E1F2;
            font-family: Calibri;
        }
        .auto-style133 {
            width: 345px;
            border: 1px solid #000000;
            background-color: #D9E1F2;
            font-family: Calibri;
        }
        .auto-style134 {
            border: 1px solid #000000;
            background-color: #D9E1F2;
            font-family: Calibri;
        }
        .auto-style137 {
            width: 407px;
            border: 1px solid #000000;
            font-family: Calibri;
            height: 28px;
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
        .auto-style284 {
            border: 1px solid #000000;
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
        .auto-style293 {
            width: 67px;
            font-family: Calibri;
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
            height: 28px;
        }
        .auto-style304 {
            width: 67px;
            text-align: center;
        }
        .auto-style309 {
            border: 1px solid #000000;
            font-family: Calibri;
            height: 22px;
        }
        .auto-style310 {
            width: 134px;
            border: 1px solid #000000;
            height: 22px;
        }
        .auto-style311 {
            width: 345px;
            border: 1px solid #000000;
            font-family: Calibri;
            height: 22px;
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
        .auto-style320 {
            border: 1px solid #000000;
            font-family: Calibri;
            height: 26px;
        }
        .auto-style321 {
            width: 134px;
            border: 1px solid #000000;
            height: 26px;
        }
        .auto-style322 {
            width: 345px;
            border: 1px solid #000000;
            font-family: Calibri;
            height: 26px;
        }
        .auto-style323 {
            font-style: normal;
        }
        .auto-style324 {
            border: 1px solid #000000;
            width: 50px;
        }
        .auto-style325 {
            width: 15px;
            border: 1px solid #000000;
            height: 28px;
        }
        </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server"><%--<Triggers><asp:PostBackTrigger ControlID="Button2" /></Triggers>--%><ContentTemplate>
      <center>
         
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
        
     </span>
            <div id="printableContent">
            <asp:Panel ID="Panel1" runat="server" BackColor="#ffffff" BorderStyle="Solid" CssClass="auto-style183" Width="900px">
                <table id="1" border="1" class="auto-style21" style="width:899px;border-collapse: collapse;">
                    <tr>
                        <td class="auto-style31" style="font-size: large; font-style: oblique; font-weight:bold">
                            <center>
                                <table class="nav-justified"  style="width:100%; border-collapse: collapse;">
                                    <tr>
                                        <td class="auto-style114">Performance Review  Form  for leader/Supervisor/Staff (Only for Level 2)<u style="color:red"> <span style="color:red">Costing </span></u> <br /> 領導/主管/員工績效考核表（僅適用於二級） 成本會計</td>
                                        </em>
                                       
                                    </tr>
                                </table>
                            </center>
                        </td>
                    </tr>
                    </em></em><em>
                    <tr>
                        <td class="auto-style31" style="font-weight:bold">
                            <center class="auto-style68" style="background-color:#FFD966 ">
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
                 <table id="2"  class="auto-style20" style="width:100%; border-collapse: collapse;">
                    <tr>
                        <td class="auto-style280">
                            <table class="nav-justified"  style="width:100%; border-collapse: collapse;">
                                <tr>
                                    <td class="auto-style122">
                                        <table class="nav-justified"  border="1"  style="width:100%; border-collapse: collapse;">
                                            <tr>
                                                <td class="auto-style325">Employee Name</td>
                                                <td class="auto-style326">
                                                    <asp:Label ID="empname" runat="server" CssClass="auto-style280" Text="Label"></asp:Label>
                                                </td>
                                                <td class="auto-style325">Employee Code</td>
                                                <em>
                                                <td class="auto-style326">
                                                    <em>
                                                    <asp:Label ID="empcode" runat="server" CssClass="auto-style280" Text="Label"></asp:Label>
                                                    </em>
                                                </td>
                                                <td class="auto-style325">Desgnation</td>
                                                <td class="auto-style327">
                                                    <em>
                                                    <asp:Label ID="desc" runat="server" CssClass="auto-style280" Text="Label"></asp:Label>
                                                    </em>
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
                                                    <asp:CheckBox ID="trai" runat="server" CssClass="auto-style280" Text="Training" Enabled="False" />
                                                    &nbsp;<asp:CheckBox ID="prob" runat="server" CssClass="auto-style280" Text="Probation" Enabled="False" />
                                                    &nbsp;<asp:CheckBox ID="conf" runat="server" CssClass="auto-style280" Text="Confirm" Enabled="False" />
                                                    &nbsp;&nbsp;</td>
                                                <td class="auto-style122" colspan="3">Year : <em>
                                                    <asp:Label ID="revmonth" runat="server" CssClass="auto-style280" Text="Label"></asp:Label>
                                                    &nbsp;&nbsp;</em><asp:CheckBox ID="weekly" runat="server" CssClass="auto-style280" Text="weekly" /> &nbsp;&nbsp;<asp:CheckBox ID="month" runat="server" CssClass="auto-style280" Text="Monthly" />
                                                    
                                                    &nbsp;<em>&nbsp;</em><asp:CheckBox ID="q1" runat="server" CssClass="auto-style280" Text="Q1" />
                                                    <em>&nbsp;</em><asp:CheckBox ID="q2" runat="server" CssClass="auto-style280" Text="Q2" />
                                                    <em>&nbsp;</em><asp:CheckBox ID="q3" runat="server" CssClass="auto-style280" Text="Q3" />
                                                    <em>&nbsp;</em><asp:CheckBox ID="q4" runat="server" CssClass="auto-style280" Text="Q4" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr style="width:100%; text-align:center; border-collapse: collapse;">
                        <td class="auto-style284"><strong>Assessment Parameters</strong></td>
                    </tr>
                    <em>
                    <tr>
                        <td class="auto-style280">
                            <table class="nav-justified" border="1" style="width:100%; text-align:center; border-collapse: collapse;">
                            <tr style="background-color: #D9E1F2; text-align:center">
                                    <td class="auto-style134" colspan="2"><strong>B. Fixed固定的</strong></td>
                                    <td class="auto-style132"><strong>76%</strong></td>
                                    <td class="auto-style133"><strong>C. Variable 可變的 (Work attitude 工作態度)</strong></td>
                                    <td class="auto-style132"><strong>20%</strong></td>
                                </tr>
                                <tr>
                                    <td class="auto-style284" rowspan="2" colspan="2">1. Attendance 出勤率</td>
                                    <td class="auto-style129" rowspan="2">
                                        <table class="nav-justified">
                                            <tr>
                                                <td class="auto-style293">10%</td>
                                                <td class="auto-style304">
                                                    <asp:TextBox ID="score1" runat="server" CssClass="auto-style165" Width="70px"  AutoPostBack="True" style="text-align:center" ></asp:TextBox>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                 
                                </tr>
                                 
                                <tr>
                                   
                                   <td class="auto-style322" rowspan="3">
                                        <span class="auto-style289">
                                            7. Team Management 團隊管理
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="score4" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                                        </span>
                                    </td>

                                    <td class="auto-style321" rowspan="3">
                                        <table class="nav-justified">
                                            <tr>
                                                <td class="auto-style293">5%</span></td>
                                                <td class="auto-style131">
                                                    <asp:TextBox ID="score6"   AutoPostBack="True" runat="server" CssClass="auto-style165" Width="70px"  style="text-align:center" ></asp:TextBox>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="auto-style284" rowspan="2" colspan="2">
                                        2. Prepare (monthly, quarterly and annual) cost forecasts 準備（每月、每季和每年）成本預測</td>
                                    <td class="auto-style129" rowspan="2">
                                        <table class="nav-justified">
                                            <tr>
                                                <td class="auto-style293">35%</span></td>
                                                <td class="auto-style131">
                                                    <asp:TextBox ID="score2" runat="server" CssClass="auto-style165" Width="70px"   AutoPostBack="True"  style="text-align:center"></asp:TextBox>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                   
                                </tr>
                                <%--this is empty tr--%>
                                 <tr>
                                    
                                </tr>
                                <%--this is empty tr--%>
                                 <tr>
                                    <td class="auto-style284" rowspan="2" colspan="2">
                                       3. .Review standard and actual costs for inaccuracies 檢查標準成本和實際成本是否不準確</td>
                                    <td class="auto-style129" rowspan="2">
                                        <table class="nav-justified">
                                            <tr>
                                                <td class="auto-style293">12%</span></td>
                                                <td class="auto-style131">
                                                    <asp:TextBox ID="score3" runat="server" CssClass="auto-style165" Width="70px"   AutoPostBack="True"  style="text-align:center"></asp:TextBox>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                   

                                     <td class="auto-style284" rowspan="2" >
                                       8.Employee Behaviour 員工行為</td>
                                    <td class="auto-style129" rowspan="2">
                                        <table class="nav-justified">
                                            <tr>
                                                <td class="auto-style293">5%</span></td>
                                                <td class="auto-style131">
                                                    <asp:TextBox ID="score7" runat="server" CssClass="auto-style165" Width="70px"     AutoPostBack="True"  style="text-align:center"></asp:TextBox>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                  <%--this is empty tr--%>
                                 <tr>
                                    
                                </tr>
                                <%--this is empty tr--%>
                                 <tr>
                                    <td class="auto-style284" rowspan="2" colspan="2">
                                        4. Collect cost information and maintain an expense database 收集成本資訊並維護費用資料庫</td>
                                    <td class="auto-style129" rowspan="2">
                                        <table class="nav-justified">
                                            <tr>
                                                <td class="auto-style293">10%</span></td>
                                                <td class="auto-style131">
                                                    <asp:TextBox ID="score4" runat="server" CssClass="auto-style165" Width="70px"   AutoPostBack="True"  style="text-align:center"></asp:TextBox>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                   

                                     <td class="auto-style284" rowspan="2" >
                                       9.Problem solving skills 解決問題的能力</td>
                                    <td class="auto-style129" rowspan="2">
                                        <table class="nav-justified">
                                            <tr>
                                                <td class="auto-style293">5%</span></td>
                                                <td class="auto-style131">
                                                    <asp:TextBox ID="score8" runat="server" CssClass="auto-style165" Width="70px"   AutoPostBack="True"  style="text-align:center"></asp:TextBox>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                 <%--this is empty tr--%>
                                 <tr>
                                    
                                </tr>
                                <%--this is empty tr--%>
                                 <tr>
                                    <td class="auto-style284" rowspan="2" colspan="2">
                                       5. Prepare budgeting reports 準備預算報告</td>
                                    <td class="auto-style129" rowspan="2">
                                        <table class="nav-justified">
                                            <tr>
                                                <td class="auto-style293">&nbsp; 9%</span></td>
                                                <td class="auto-style131">
                                                    <asp:TextBox ID="score5" runat="server" CssClass="auto-style165" Width="70px"   AutoPostBack="True"  style="text-align:center"></asp:TextBox>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                   

                                     <td class="auto-style284" rowspan="2" >
                                        10.Self Initiative approach   自我主動的方法</td>
                                    <td class="auto-style129" rowspan="2">
                                        <table class="nav-justified">
                                            <tr>
                                                <td class="auto-style293">5%</span></td>
                                                <td class="auto-style131">
                                                    <asp:TextBox ID="score9" runat="server" CssClass="auto-style165" Width="70px"   AutoPostBack="True"  style="text-align:center"></asp:TextBox>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    </em>
                </table>
                <em><em><em></td>
                </em>
                </tr>
                <em></em><em></em>                    <tr><td><h4><u> Adhere to the above criteria based on your employee's supervised performance.  根據您員工的監督績效遵守上述標準</u></h4></td></tr>
</em></em></em>
                <tr>
                    <td class="auto-style280">
                        <table class="nav-justified"  border="1"  style="width:100%; text-align:center; border-collapse: collapse; font-size:large; height:13%">
                            <tr style="font-size:large">
                                <td class="auto-style312" colspan="2" rowspan="2" style="background-color: #8EA9DB;text-align:center"><strong>D. Department/Section Review 部門/部門審查</strong></td>
                                <td class="auto-style314" style="background-color: #FFD966; text-align:center"><strong>4%</strong></td>
                            </tr>
                            <tr>
                                <td class="auto-style313" style="background-color: #FFD966; text-align:center">
                                    <table class="nav-justified" >
                                        <tr>
                                            <td class="auto-style284" >(0% but can change all)</td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                           
                            <tr>
                                <td class="auto-style291">1. CST Head</td>
                                <td class="auto-style138">
                                    <asp:TextBox ID="shead" runat="server"  placeholder="CST Head Name" style="text-align: center" CssClass="auto-style165" Width="244px" TabIndex="14"></asp:TextBox>
                                </td>
                                <td class="auto-style122">
                                    <asp:TextBox ID="score10" runat="server"  style="text-align: center" CssClass="auto-style165" Width="244px" AutoPostBack="True" TabIndex="13"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style291">2. MRI Department Head</td>
                                <td class="auto-style138">
                                    <asp:TextBox ID="dhead" runat="server" placeholder="MRI Department Head Name" style="text-align: center" CssClass="auto-style165" Width="244px" TabIndex="15"></asp:TextBox>
                                </td>
                                <td class="auto-style122">
                                    <asp:TextBox ID="score11" runat="server"   style="text-align: center" CssClass="auto-style165" Width="244px" AutoPostBack="True" TabIndex="14"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                        <span class="auto-style292"></span>
                    </td>
                </tr>
                </table>
                </em></em>
             
                </td>
                </tr>
                </table>
                </em></em></em></em>
                 <table id="Table1" runat="server" border="1" class="auto-style20" style="width:100%; border-collapse: collapse;">
              
                            <tr>
                                <td class="text-center" style="width:150px; background-color:#b4c6e7"><strong> &nbsp; </strong></td>
                               
                            </tr>
                        </table>
                <table id="tb1" runat="server" border="1" class="auto-style20" style="width:100%; border-collapse: collapse; height:15%;font-size:large">
                            <tr>
                                <td class="text-center" style="width:170px;font-size:x-large"><strong> Recommendation &
Summaries the overall performance and progress    建議和 總結該員整體表現</strong></td>
                                <td class="auto-style83">
                                    <asp:TextBox ID="remark" placeholder="Remark here.." runat="server" BackColor="White" BorderColor="White" BorderStyle="None" cssclass="form-control" Height="70px" style="width:100%;font-size:x-large; height:100%" TextMode="MultiLine" TabIndex="16"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                        <table border="1" class="auto-style169"  style="width:100%; text-align:center; border-collapse: collapse;height:25%; font-size:large">
                            <tr>
                                <td class="auto-style282" style="background-color:#FFD966" rowspan="2"><strong>Remarks 評論</strong></td>
                                <td class="auto-style334" rowspan="2"><strong>Status of Review Period</strong></td>
                                <td class="auto-style173" colspan="3" ><strong>
                                    <asp:CheckBox ID="pass" runat="server" AutoPostBack="True" CssClass="auto-style280" Text="Pass" />
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    <asp:CheckBox ID="extend" runat="server" AutoPostBack="True" CssClass="auto-style280" Text="Extend" />
                                    </strong></td>
                            </tr>
                            <tr>
                                <td class="auto-style173" colspan="3" style="background-color:#FFD966"><strong>Approvals 批准</strong></td>
                            </tr>
                            <em>
                            <tr style="font-size:large">
                                <td class="auto-style172" rowspan="3" style="text-align:left;"><span class="auto-style280">Performance status definition :績效評核定義</span>
                                    <br class="auto-style280" /><br />
                                    <span class="auto-style280">1.Pass: Score is 76 or more than 76 every time </span>
                                    <br class="auto-style280" />
                                    <span class="auto-style280">通過: 分數高於76分 </span>
                                    <br class="auto-style280" /><br />
                                    <span class="auto-style280">2.Extend : Score is 75 or below 75, turn to extend period(PIP), employee has three months to improve his/her performance.(CW/FT is Not Included in Extend Process; They are directly eligible for fail criteria ) </span>
                                    <br class="auto-style280" />
                                    <span class="auto-style280">延長：分數為75或低於75，轉為延長期(PIP)，員工有三個月的時間來提高他/她的績效（CW/FT 不包括在延長過程中；他們直接符合失敗標準）</span></td>
                                <td class="auto-style175" style="background-color:#FFD966"><strong>Total Score<br /> &nbsp;總得分<br /> &nbsp;100%</strong></td>
                                <td class="auto-style180"><span class="auto-style280"><strong>Department Head </strong></span><strong>
                                    <br class="auto-style280" />
                                    </strong><span class="auto-style280"><strong>部門主管</strong></span></td>
                                <td class="auto-style281"><strong>Section Head<br /> &nbsp;課長</strong></td>
                                <td class="auto-style180"><span class="auto-style280"><strong>Employee Signature</strong></span><strong><br class="auto-style280" /> </strong><span class="auto-style280"><strong>員工簽名</strong></span></td>
                            </tr>
                            <tr>
                                <td class="auto-style175" style="font-size:small">
                                    <asp:Label ID="totmarks" runat="server" Text="Label"></asp:Label>
                                </td>
                                <td class="auto-style178">
                                    <asp:CheckBox ID="ch1" runat="server" CssClass="auto-style280" />
                                </td>
                                <td class="auto-style178">
                                    <asp:CheckBox ID="ch2" runat="server" CssClass="auto-style280" />
                                </td>
                                <td class="auto-style178">
                                    <label id="lblEmpsign" runat="server"></label>
<label id="lblEmpDate" runat="server"></label>
                                    <asp:CheckBox ID="ch3" runat="server" CssClass="auto-style280 emps" style="display:none" onclick="if(!confirm('Are you sure you want to Accept?'))return false;" />
                                </td>
                            </tr>
                            </em>
                            <tr>
                                <td class="auto-style173" colspan="4" style="font-size:small">&nbsp;<asp:Label ID="Time" runat="server" Text="Label"></asp:Label>
                                </td>
                            </tr>
                        </table>
                       
                <em><em></td>
                </tr>
                </em></em></em>
            </asp:Panel>
                 <!-- This code for footer title -->
                <div style="display: flex; width:900px; justify-content: space-between; align-items: flex-end; text-align: center; margin-top:10px">
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
          </div>
          <center><br />
                            <asp:Button ID="insert" runat="server" cssclass="btn btn-primary" style="font-family: call; font-size: small;" Text="Submit" ValidationGroup="insert" />
                            <span class="auto-style184">&nbsp;<asp:Button ID="update" runat="server" cssclass="btn btn-primary" OnClick="update_Click" style="font-family: call; font-size: small;" Text="Update" ValidationGroup="insert" />
                            &nbsp;<asp:Button ID="show" runat="server" cssclass="btn btn-primary" style="font-family: call; font-size: small;" Text="Show" ValidationGroup="insert" />
                                              <asp:LinkButton runat="server" id="print" cssclass="btn btn-warning" OnClientClick = "printDiv('printableContent')"><i class="fa fa-print"></i> Print</asp:LinkButton>
                            </span>
                        </center>
       </center>
        <br/>
        </ContentTemplate></asp:UpdatePanel>
</asp:Content>
