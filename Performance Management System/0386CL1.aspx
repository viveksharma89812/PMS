<%@ Page Language="vb" AutoEventWireup="false" EnableEventValidation="false" MasterPageFile="~/Site1.Master" CodeBehind="0386CL1.aspx.vb" Inherits="Performance_Management_System._0386CL1" %>



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
                <table id="1" border="1" class="auto-style21" style="width:899px;border-collapse: collapse;">
                    <tr>
                        <td class="auto-style31" style="font-size: large; font-style: oblique; font-weight:bold">
                            <center>
                                <table class="nav-justified" style="border-collapse: collapse;">
                                    <tr>
                                        <td class="auto-style114">Performance Review  Form  for leader/Supervisor/Staff (Only for Level 2)Calendering Leader  領導/主管/一般員工績效考核表   僅適用於 第二級 </td>
                                        </em>
                                        <td class="auto-style323">
                                            <asp:CheckBox ID="CheckBox1" runat="server" Font-Size="Medium" Text="Supervisior / Leader" Checked="True" />
                                            &nbsp;<asp:CheckBox ID="CheckBox2" runat="server" Font-Size="Medium" Text="OP" Visible="False" />
                                        </td>
                                    </tr>
                                </table>
                            </center>
                        </td>
                    </tr>
                    </em></em><em>
                    <tr>
                        <td class="auto-style31" style="font-weight:bold">
                            <center class="auto-style68" style="background-color:#eea236 ">
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
                <table id="2" border="1" class="auto-style20" style="width:100%; border-collapse: collapse;">
                    <tr>
                        <td class="auto-style280">
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
                                                    &nbsp;&nbsp;</em><asp:CheckBox ID="month" runat="server" CssClass="auto-style280" Text="Monthly" />
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
                                    <td class="auto-style284" rowspan="2">1. Attendance 出勤率</td>
                                    <td class="auto-style309">Personal 個人<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="score1" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                                    </td>
                                    <td class="auto-style310">
                                        <table class="nav-justified">
                                            <tr>
                                                <td class="auto-style293">24%</td>
                                                <td class="auto-style304">
                                                    <em>
                                                    <asp:TextBox ID="score1" runat="server"  AutoPostBack="True" CssClass="auto-style165" style="text-align: center" TabIndex="1" Width="70px"></asp:TextBox>
                                                    </em>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                    <td class="auto-style311">4<span class="auto-style289">. Environment 5S (環境5S) <em>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="score6" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                                        </em></span></td>
                                    <td class="auto-style310">
                                        <table class="nav-justified">
                                            <tr>
                                                <td class="auto-style293">5%</span></td>
                                                <td class="auto-style131">
                                                    <em>
                                                    <asp:TextBox ID="score6" runat="server"  AutoPostBack="True" CssClass="auto-style165" style="text-align: center" TabIndex="7" Width="70px"></asp:TextBox>
                                                    </em>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="auto-style320">Shift 班別 <em>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="score2" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                                        </em></td>
                                    <td class="auto-style321">
                                        <table class="nav-justified">
                                            <tr>
                                                <td class="auto-style293">12%</span></td>
                                                <td class="auto-style131">
                                                    <em>
                                                    <asp:TextBox ID="score2" runat="server"  AutoPostBack="True" CssClass="auto-style165" style="text-align: center" TabIndex="2" Width="70px"></asp:TextBox>
                                                    </em>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                    <td class="auto-style322">5<span class="auto-style289">. Work assigned by Leader 上級交代事項 <em>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="score7" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                                        </em></span></td>
                                    <td class="auto-style321">
                                        <table class="nav-justified">
                                            <tr>
                                                <td class="auto-style293">3%</span></td>
                                                <td class="auto-style131">
                                                    <em>
                                                    <asp:TextBox ID="score7" runat="server"  AutoPostBack="True" CssClass="auto-style165" style="text-align: center" TabIndex="8" Width="70px"></asp:TextBox>
                                                    </em>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr >
                                    <td class="auto-style284" colspan="2" rowspan="2" >
                                        <table lass="nav-justified" style="width:100%; border-collapse: collapse; text-align:center" border="1" >
                                   
                                            <tr >
                                               
                                                <td class="auto-style324" rowspan="2"><br />2.Scrap/Defective rate<br /> 報廢率/不良率<br /><br /></td>
                                                <td class="auto-style122" rowspan="1">Raw materials (Rubber and Fabric) <br /> 原材料 (膠料和原紗)<em>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="score3" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                                                    </em></td>
                                            </tr>
                                            <tr >
                                                <td class="auto-style122" rowspan="1">Semi-product (PLY and Chafer) <br />半製品 (簾布和防擦布) <em>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="score4" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                                                    </em></td>
                                            </tr>
                                        </table>
                                    </td>
                                    <td class="auto-style129">
                                        <table class="nav-justified">
                                            <tr>
                                                <td class="auto-style293">
                                                    15%</span></td>
                                                <td class="auto-style131">
                                                    <em>
                                                    <asp:TextBox ID="score3" runat="server"  AutoPostBack="True" CssClass="auto-style165" style="text-align: center" TabIndex="3" Width="70px"  ></asp:TextBox>
                                                    </em>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                    <td class="auto-style130" rowspan="1">6<span class="auto-style289">.Level-1 maintenance checkpoints check
                                        <br />
                                        一級保養 <em>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="score8" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                                        </em></span></td>
                                    <td class="auto-style129">
                                        <table class="nav-justified">
                                            <tr>
                                                <td class="auto-style293">3%</span></td>
                                                <td class="auto-style131">
                                                    <em>
                                                    <asp:TextBox ID="score8" runat="server"  AutoPostBack="True" CssClass="auto-style165" style="text-align: center" TabIndex="9" Width="70px"></asp:TextBox>
                                                    </em>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="auto-style129"><em>
                                        <table class="nav-justified">
                                            <tr>
                                                <td class="auto-style293">15%</td>
                                                <td class="auto-style304">
                                                    <em>
                                                    <asp:TextBox ID="score4" runat="server"  AutoPostBack="True" CssClass="auto-style165" style="text-align: center" TabIndex="3" Width="70px"></asp:TextBox>
                                                    </em>
                                                </td>
                                            </tr>
                                        </table>
                                        </em></td>
                                    <td class="auto-style130" rowspan="1">7.Observation Skill, Detailed feedback to supervisors, Shift start/close meeting communication （觀察技巧，給主管的詳細反饋，輪班開始/結束會議溝通） <em>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ControlToValidate="score9" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                                        </em></td>
                                    <td class="auto-style129" rowspan="1"><em>
                                        <table class="nav-justified">
                                            <tr>
                                                <td class="auto-style293">4%</span></td>
                                                <td class="auto-style131">
                                                    <em>
                                                    <asp:TextBox ID="score9" runat="server"  AutoPostBack="True" CssClass="auto-style165" style="text-align: center" TabIndex="10" Width="70px"></asp:TextBox>
                                                    </em>
                                                </td>
                                            </tr>
                                        </table>
                                        </em></td>


                                    
                                </tr>
                                <tr>
                                    <td class="auto-style284" colspan="2" rowspan="1">3<span class="auto-style289">.Production achievement rate 生產達成率 
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="score5" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                                        </span></td>
                                    <td class="auto-style129"><em>
                                        <table class="nav-justified">
                                            <tr>
                                                <td class="auto-style293">10%</td>
                                                <td class="auto-style304">
                                                    <em>
                                                    <asp:TextBox ID="score5" runat="server"  AutoPostBack="True" CssClass="auto-style165"  style="text-align: center" TabIndex="5" Width="70px"></asp:TextBox>
                                                    </em>
                                                </td>
                                            </tr>
                                        </table>
                                        </em></td>
                                     <td class="auto-style130" rowspan="1">8.Proposals to improve (提案改善)&nbsp;
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ControlToValidate="score10" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                                    </td>
                                    <td class="auto-style129" rowspan="1"><em>
                                        <table class="nav-justified">
                                            <tr>
                                                <td class="auto-style293">5%</span></td>
                                                <td class="auto-style131">
                                                    <em>
                                                    <asp:TextBox ID="score10" runat="server" AutoPostBack="True" CssClass="auto-style165" style="text-align: center" TabIndex="11" Width="70px" ></asp:TextBox>
                                                    </em>
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
                <em></em><em></em>            
                    <tr><td><h4><u> Adhere to the above criteria based on your employee's supervised performance.  根據您員工的監督績效遵守上述標準</u></h4></td></tr>
</em></em></em>
                <tr>
                    <td class="auto-style280">
                        <table class="nav-justified"  border="1"  style="width:100%; text-align:center; border-collapse: collapse;font-size:large; height:20%">
                            <tr>
                                <td class="auto-style312" colspan="2" rowspan="2"  style="background-color: #8EA9DB;text-align:center"><strong>D. Department/Section Review 部門/部門審查</strong></td>
                                <td class="auto-style314" style="background-color: #FFD966; text-align:center"><strong>4%</strong></td>
                            </tr>
                            <tr>
                                <td class="auto-style313" style="background-color: #FFD966; text-align:center">
                                    <table class="nav-justified">
                                        <tr>
                                            <td class="auto-style284">(0% but can change all)</td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style137">1. Leader  </td>
                                <td class="auto-style325">
                                    <asp:TextBox ID="ldr" runat="server"  placeholder="Leader Name" CssClass="auto-style165" Width="244px" TabIndex="13" MaxLength="25" style="text-align: center"></asp:TextBox>
                                </td>
                                <td class="auto-style303">
                                    <em>
                                    <table class="nav-justified">
                                        <tr>
                                            <td class="auto-style293">4%</td>
                                            <td class="auto-style304"><em>
                                                <asp:TextBox ID="score11" runat="server"  AutoPostBack="True" style="text-align: center" CssClass="auto-style165" TabIndex="12" Width="70px" ></asp:TextBox>
                                                </em></td>
                                        </tr>
                                    </table>
                                    </em>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style291">2. Section Head</td>
                                <td class="auto-style138">
                                    <asp:TextBox ID="shead" runat="server"  placeholder="Section Head Name" style="text-align: center" CssClass="auto-style165" Width="244px" TabIndex="14"></asp:TextBox>
                                </td>
                                <td class="auto-style122">
                                    <asp:TextBox ID="score12" runat="server"  style="text-align: center" CssClass="auto-style165" Width="244px" AutoPostBack="True" TabIndex="13"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style291">3. Department Head</td>
                                <td class="auto-style138">
                                    <asp:TextBox ID="dhead" runat="server" placeholder="Dept Head Name" style="text-align: center" CssClass="auto-style165" Width="244px" TabIndex="15"></asp:TextBox>
                                </td>
                                <td class="auto-style122">
                                    <asp:TextBox ID="score13" runat="server"   style="text-align: center" CssClass="auto-style165" Width="244px" AutoPostBack="True" TabIndex="14"></asp:TextBox>
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
                                <td class="text-center" style="width:150px; background-color:#8EA9DB"><strong> &nbsp; </strong></td>
                               
                            </tr>
                        </table>
                <table id="tb1" runat="server" border="1" class="auto-style20"  style="width:100%;  border-collapse: collapse;height:10%;font-size:large">
                            <tr>
                                <td class="text-center" style="width:170px; font-size:large" ><strong>Recommendation &amp; Summaries the overall performance and progress 建議和總結該員整體表現</strong></td>
                                <td class="auto-style83">
                                    <asp:TextBox ID="remark" placeholder="Remark here.." runat="server" BackColor="White" BorderColor="White" BorderStyle="None" cssclass="form-control" Height="70px" style="width:100%;font-size:x-large; height:100%" TextMode="MultiLine" TabIndex="16"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                        <table border="1" class="auto-style169"  style="width:100%; text-align:center; border-collapse: collapse; font-size:large">
                            <tr>
                                <td class="auto-style282" style="background-color:#eea236" rowspan="2"><strong>Remarks 評論</strong></td>
                                <td class="auto-style334" rowspan="2" style="background-color:#eea236"><strong>Status of Review Period</strong></td>
                                <td class="auto-style173" colspan="3" style="background-color:#eea236"><strong>
                                    <asp:CheckBox ID="pass" runat="server" AutoPostBack="True" CssClass="auto-style280" Text="Pass" />
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    <asp:CheckBox ID="extend" runat="server" AutoPostBack="True" CssClass="auto-style280" Text="Extend" />
                                    </strong></td>
                            </tr>
                            <tr>
                                <td class="auto-style173" colspan="3" style="background-color:#eea236"><strong>Approvals 批准</strong></td>
                            </tr>
                            <em>
                            <tr style="font-size:large">
                                <td class="auto-style172" rowspan="3" style="text-align:left;"><span class="auto-style280">Performance status definition :考核結果說明 </span>
                                    <br class="auto-style280" />
                                    <span class="auto-style280">1.Pass: Score is 76 or more than 76 every time </span>
                                    <br class="auto-style280" />
                                    <span class="auto-style280">適任: 分數高於76分 </span>
                                    <br class="auto-style280" />
                                    <span class="auto-style280">2.Extend : Score is 75 or below 75, turn to extend period(PIP), employee has three months to improve his/her performance.(CW/FT is Not Included in Extend Process; They are directly eligible for fail criteria ) </span>
                                    <br class="auto-style280" />
                                    <span class="auto-style280">延長:分數低於75分，進入績效改善階段，共三個月之改善期間。（CW/FT 不包括在扩展过程中；它们直接符合失败标准）</span></td>
                                <td class="auto-style175" style="background-color:#eea236"><strong>Total Score<br /> &nbsp;總得分<br /> &nbsp;100%</strong></td>
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
                <div style="display: flex; width:900px; justify-content: space-between; align-items: flex-end; text-align: center; margin-top:7px">
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




