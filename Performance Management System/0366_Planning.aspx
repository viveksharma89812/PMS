<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site1.Master" CodeBehind="0366_Planning.aspx.vb" Inherits="Performance_Management_System.WebForm23" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style3 {
            width: 100%;
        }
        .auto-style8 {
            width: 57px;
        }
        .auto-style10 {
            width: 131px;
        }
         table, th, td {
            /*border: 1px solid black;*/
            align-content: center;
            text-align: center
        }
        .auto-style16 {
            width: 78px;
        }
        .auto-style23 {
            width: 190px;
        }
        .auto-style25 {
            width: 225px;
        }
        .auto-style28 {
            width: 130px;
        }
        .auto-style29 {
            width: 341px;
        }
        .auto-style30 {
            width: 143px;
        }
        .auto-style31 {
            width: 105px;
        }
        .auto-style32 {
            width: 109px;
        }
        .auto-style35 {
            width: 115px;
        }
        .auto-style36 {
            height: 23px;
        }
        </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server"><ContentTemplate>
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

          <div id="printableContent">
    <%--<asp:TextBox ID="TextBox11" runat="server" AutoPostBack="True"></asp:TextBox>--%>
<center><asp:Panel ID="Panel1" runat="server" BorderStyle="Solid"  Width="882px" BackColor="#ffffff">
        <table class="auto-style3" border="1" width="100%"  Height="25%"  style="width:100%; text-align:center; border-collapse: collapse;">
            <tr>
                <td colspan="6" style=" font-style: oblique; font-weight:bold" onclick="return false"><asp:CheckBox ID="c1" runat="server"></asp:CheckBox> Training / <asp:CheckBox ID="c2" runat="server"></asp:CheckBox> Probation Period Review Form (For Planning Operator)訓練期/試用期評核表(作業人員)</td>
            </tr>
            <tr>
                <td colspan="6" style="font-weight:bold;background-color:#eea236"><center>A. Employee Information(By HR)&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:CheckBox ID="CheckBox4" runat="server" Text="During Review" />
                    </center> </td>
            </tr>
            <tr>
                <td class="auto-style30">Employee Name</td>
                <td class="auto-style31">
                    <asp:Label ID="empname" runat="server" Text="Label"></asp:Label>
                </td>
                <td class="auto-style30">&nbsp;&nbsp; Employee Code</td>
                <td class="auto-style32">
                    <asp:Label ID="empcode" runat="server" Text="Label"></asp:Label>
                </td>
                <td class="auto-style35">Designation</td>
                <td>
                    <asp:Label ID="desc" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style30">Dept./Sect.</td>
                <td class="auto-style31">
                    <asp:Label ID="deptsect" runat="server" Text="Label"></asp:Label>
                </td>
                <td class="auto-style30">DOJ</td>
                <td class="auto-style32">
                    <asp:Label ID="doj" runat="server" Text="Label"></asp:Label>
                </td>
                <td class="auto-style35">Review Month</td>
                <td>
                    <asp:Label ID="revmonth" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
        </table>
        <table class="auto-style3" border="1"  Height="60%" style="width:100%; text-align:center; border-collapse: collapse;font-size:large">
        <tr>
            <td colspan="4" style="font-weight:bold; background-color:#eea236">B. Attendance Details (By HR)</td>
            <td colspan="4" style="font-weight:bold; background-color:#eea236">C. Performance Review (To be filled by Appraiser )</td>
        </tr>
        <tr>
            <td colspan="3">Actual Working Days</td>
            <td class="auto-style10">
                <asp:Label ID="actworking" runat="server" Text="Label"></asp:Label>
            </td>
            <td class="auto-style29" style="text-align:left">1.Attitude of work(Initiative)</td>
            <td class="auto-style23">
                20%</td>
            <td colspan="2" style="text-align:left">2. Accuracy of work產能達成率</td>
        </tr>
        <tr>
            <td colspan="3">Actual Present Days</td>
            <td class="auto-style10">
                <asp:Label ID="actpresent" runat="server" Text="Label"></asp:Label>
            </td>
            <td class="auto-style29" style="text-align:left">* Excellent=20 Point</td>
            <td class="auto-style23" rowspan="5">
                   
                <asp:TextBox ID="score1" runat="server" AutoPostBack="true"></asp:TextBox>
            </td>
            <td class="auto-style25">30%</td>
            <td>
                <asp:TextBox ID="score2" runat="server" AutoPostBack="true"></asp:TextBox>
            </td>
        </tr>
            <tr>
                <td colspan="3">Absent&nbsp; Days</td>
                <td class="auto-style10">
                    <asp:Label ID="absentdays" runat="server" Text="Label"></asp:Label>
                </td>
                <td class="auto-style29" style="text-align:left">* Good=15 Point</td>
                <td colspan="2" style="text-align:left">3. Quality & Productivity of work品質良率</td>
            </tr>
        <tr>
            <td class="auto-style28">CL</td>
            <td class="auto-style8">
                <asp:Label ID="cla" runat="server" Text="Label"></asp:Label>
            </td>
            <td class="auto-style16">SL</td>
            <td class="auto-style10">
                <asp:Label ID="sla" runat="server" Text="Label"></asp:Label>
            </td>
            <td class="auto-style29" style="text-align:left">* Satisfactoryt= 10 point</td>
            <td class="auto-style25">30%</td>
            <td>
                <asp:TextBox ID="score3" runat="server" AutoPostBack="true"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style28">PL</td>
            <td class="auto-style8">
                <asp:Label ID="pla" runat="server" Text="Label"></asp:Label>
            </td>
            <td class="auto-style16">LWP</td>
            <td class="auto-style10">
                <asp:Label ID="lwpa" runat="server" Text="Label"></asp:Label>
            </td>
            <td class="auto-style29" style="text-align:left">* Improvement Required=5 Point</td>
            <td class="auto-style25" rowspan="2" style="font-weight:bold; background-color:#eea236">Total Scores</td>
            <td rowspan="2" id="totscore" runat="server">
                
            </td>
        </tr>
        <tr>
            <td colspan="2">Score(20&nbsp;%)</td>
            <td colspan="2">
                <asp:Label ID="score" runat="server" Text="Label"></asp:Label>
            </td>
            <td class="auto-style29" style="text-align:left">* Fail=0 Point</td>
        </tr>
        <tr>
            <td style="text-align:left" colspan="4">4. Recommendation總評建議:</td>
            <td colspan="4">
                <asp:TextBox ID="remark"  Width="100%" Height="100%" runat="server" cssclass="form-control" TextMode="MultiLine"></asp:TextBox>
            </td>
        </tr>
        <tr style="height:10%;font-size:large">
            <td colspan="5" style="background-color:#eea236" class="auto-style36">Remarks</td>
            <td colspan="3" style="background-color:#eea236" class="auto-style36">Approvals</td>
        </tr>
        <tr>
            <td colspan="5" rowspan="2" style="text-align:left;font-size:x-large">1.Review employees' performance in this period and give feedback <br /> or guidance. 評核該區間之表現並給予回饋。<br /> 2. Fail definition: 不適任說明：<br /> Training: (1) scores are 55 or below 55 in the three months <br /> continuously,(2) Average Score is 55 or below 55.<br /> 連續三次低於55分或平均低於55分 <br /> Probation: (1) scores are 60 or below 60 in the three months <br /> continuously (2) Average Score is 60 or below 60 <br /> 連續三次低於60分或平均低於60分 <br /> In these two cases Employee services would be terminated.</td>
            <td class="auto-style23">Department
                <br />
                Head</td>
            <td class="auto-style25">Section
                <br />
                Head</td>
            <td>Employee Signature</td>
        </tr>
            <tr>
                <td class="auto-style23">
                    <asp:CheckBox ID="ch1" runat="server" />
                </td>
                <td class="auto-style25">
                    <asp:CheckBox ID="ch2" runat="server" />
                </td>
                <td>
                    <label id="lblEmpsign" runat="server"></label>
<label id="lblEmpDate" runat="server"></label>
                    <asp:CheckBox ID="ch3" runat="server" CssClass="emps"  style="display:none" AutoPostBack="true" onclick="if(!confirm('Are you sure you want to Accept?'))return false;" />
                </td>
                
            </tr>
      <tr>
           <td colspan="8">  <center><asp:Label ID="Time" runat="server" Text="Label"></asp:Label></center> </td>
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
</center>

       </div><br />
     <center>
             <asp:Button ID="insert" runat="server"  Text="Submit"  cssclass="btn btn-primary"/>  
                   <%-- <asp:Button ID="Button3" runat="server" CssClass="auto-style102" Height="43px" Text="Export To Pdf" />--%>
             &nbsp;<em></td></tr></em><span class="auto-style184"><asp:Button ID="update" runat="server" cssclass="btn btn-primary" OnClick="update_Click" style="font-family: call; font-size: small;" Text="Update" ValidationGroup="insert" />
             &nbsp;<asp:Button ID="show" runat="server" cssclass="btn btn-primary" style="font-family: call; font-size: small;" Text="Show" ValidationGroup="insert" />
             <asp:LinkButton runat="server" id="print" cssclass="btn btn-warning" OnClientClick = "printDiv('printableContent')"><i class="fa fa-print"></i> Print</asp:LinkButton>

             </span>
        </center>
<br /> </ContentTemplate></asp:UpdatePanel>
</asp:Content>
