<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site1.Master" CodeBehind="Cheff.aspx.vb" Inherits="Performance_Management_System.Cheff" %>
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
            width: 145px;
        }

        .auto-style25 {
            width: 204px;
        }

        .auto-style26 {
            width: 154px;
        }

        .auto-style27 {
            width: 251px;
        }

        .auto-style31 {
            height: 22px;
        }

        .auto-style43 {
            width: 400px;
        }

        .auto-style55 {
            width: 7px;
        }

        .auto-style56 {
            width: 33px;
        }

        .auto-style59 {
            width: 15px;
        }

        .auto-style61 {
            width: 536px;
        }

        .auto-style62 {
            width: 232px;
        }

        .auto-style63 {
            width: 273px;
        }

        .auto-style64 {
            width: 159px;
        }

        .auto-style65 {
            width: 188px;
        }

        .auto-style66 {
            width: 189px;
        }

        .auto-style67 {
            width: 432px;
        }

        .auto-style69 {
            width: 173px;
        }

        .auto-style83 {
            height: 25px;
        }

        .auto-style84 {
            width: 15px;
            height: 25px;
        }

        .auto-style86 {
            width: 602px;
        }

        .auto-style87 {
            width: 232px;
            height: 25px;
        }

        .auto-style88 {
            width: 273px;
            height: 25px;
        }

        .auto-style89 {
            width: 159px;
            height: 25px;
        }

        .auto-style90 {
            width: 188px;
            height: 25px;
        }

        .auto-style91 {
            width: 189px;
            height: 25px;
        }

        .auto-style92 {
            width: 432px;
            height: 25px;
        }

        .auto-style93 {
            width: 536px;
            height: 25px;
        }

        .auto-style94 {
            width: 392px;
            height: 25px;
        }

        .auto-style95 {
            width: 37px;
        }

        .auto-style96 {
            width: 35px;
        }

        .auto-style97 {
            width: 36px;
        }

        .auto-style99 {
            margin-top: 0px;
        }

        table, th, td {
            /*border: 1px solid black;*/
            align-content: center;
            text-align: center
        }
        .auto-style114 {
            width:100%;
        }
        .auto-style115 {
            width: 197px;
        }


        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            
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
    
            <script type="text/javascript">
    function MutExChkList1(chk) {
        var chkList = chk.parentNode.parentNode.parentNode;
        var chks = chkList.getElementsByTagName("input");
        for (var i = 0; i < chks.length; i++) {
            if (chks[i] != chk && chk.checked) {
                chks[i].checked = false;
            }
        }
                }
                 function MutExChkList2(chk) {
        var chkList = chk.parentNode.parentNode.parentNode;
        var chks = chkList.getElementsByTagName("input");
        for (var i = 0; i < chks.length; i++) {
            if (chks[i] != chk && chk.checked) {
                chks[i].checked = false;
            }
        }
                }
                 function MutExChkList3(chk) {
        var chkList = chk.parentNode.parentNode.parentNode;
        var chks = chkList.getElementsByTagName("input");
        for (var i = 0; i < chks.length; i++) {
            if (chks[i] != chk && chk.checked) {
                chks[i].checked = false;
            }
        }
                }
                 function MutExChkList4(chk) {
        var chkList = chk.parentNode.parentNode.parentNode;
        var chks = chkList.getElementsByTagName("input");
        for (var i = 0; i < chks.length; i++) {
            if (chks[i] != chk && chk.checked) {
                chks[i].checked = false;
            }
        }
                }
                 function MutExChkList5(chk) {
        var chkList = chk.parentNode.parentNode.parentNode;
        var chks = chkList.getElementsByTagName("input");
        for (var i = 0; i < chks.length; i++) {
            if (chks[i] != chk && chk.checked) {
                chks[i].checked = false;
            }
        }
                }
                 function MutExChkList6(chk) {
        var chkList = chk.parentNode.parentNode.parentNode;
        var chks = chkList.getElementsByTagName("input");
        for (var i = 0; i < chks.length; i++) {
            if (chks[i] != chk && chk.checked) {
                chks[i].checked = false;
            }
        }
    }
</script>

         
        <asp:Label ID="Label22" runat="server" ForeColor="Red" Text="Label" Visible="False"></asp:Label>
            </center>
            
              
            &nbsp;<br />
<center>
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

          <asp:Panel ID="Panel1" runat="server" BorderStyle="Solid" EnableViewState="true" Width="920px" BackColor="#ffffff" CssClass="auto-style99">

            <table id="1" border="1" class="auto-style21" style="visibility: visible; width:915px; list-style-type: circle; table-layout: fixed; border-collapse: separate; border-spacing: inherit; width:100%; text-align:center; border-collapse: collapse;font-size:large">
                <tr>
                    <td class="auto-style31" colspan="6" style="font-size:large; font-style: oblique; font-weight:bold ">
                       
                        Performance review Form of Probation Period During/Final Review / Permanent Period (For Chef)</td>
                </tr>
                <tr>
                    <td class="auto-style31" colspan="6" style="font-weight:bold;background-color:#ffd966 ">
                       
                            A.Employee Information
                    </td>
                </tr>
                <tr>
                    <td class="auto-style24">Employee Name</td>
                    <td class="auto-style26" id="empname" runat="server">
                        
                    </td>
                    <td class="auto-style25">Employee Code</td>
                    <td class="auto-style69" id="empcode" runat="server">
                    
                    </td>
                    <td class="auto-style27">Designation</td>
                    <td id="desc" runat="server">
                     
                    </td>
                </tr>
                <tr>
                    <td class="auto-style24">Dept./Section</td>
                    <td class="auto-style26" id="deptsec" runat="server">
                        
                    </td>
                    <td class="auto-style25">DOJ</td>
                    <td class="auto-style69" id="doj" runat="server">
                       
                    </td>
                    <td class="auto-style27">Review Month</td>
                    <td id="review" runat="server">
                       
                    </td>
                </tr>
                <tr>
                    <td>Review Time</td>
                     <td class="auto-style122" colspan="5" style="font-weight:bold">Year : 
                        <asp:Label ID="revmonth" runat="server" CssClass="auto-style280" Text="Label"></asp:Label>
                        &nbsp;
                        <asp:CheckBox ID="month" runat="server" CssClass="auto-style280" Text="Monthly" AutoPostBack="True"  />
                        &nbsp;&nbsp;&nbsp;     
                       
                        <asp:CheckBox ID="q1" runat="server" CssClass="auto-style280" Text="Q1" AutoPostBack="True"  /> &nbsp;&nbsp;&nbsp;
                        <asp:CheckBox ID="q2" runat="server" CssClass="auto-style280" Text="Q2" AutoPostBack="True" />&nbsp;&nbsp;&nbsp;
                        <asp:CheckBox ID="q3" runat="server" CssClass="auto-style280" Text="Q3" AutoPostBack="True"  />&nbsp;&nbsp;&nbsp;
                        <asp:CheckBox ID="q4" runat="server" CssClass="auto-style280" Text="Q4" AutoPostBack="True" />
                    </td>
                   
                    
                </tr>
          
            </table>
            <table id="2" border="1" class="auto-style20" style="width:100%; text-align:center; border-collapse: collapse;">
               
                <tr>
                    <td class="auto-style62" colspan="2" style="width:14% ; background-color:#ffd966">B. Attendance Detail (by HR)</td>
                    <td class="auto-style63">Actual Working Days</td>
                   <td class="auto-style62" style="width:80px">
                        <label id="actwork" runat="server"></label>
                    </td>
                    <td class="auto-style61">Actual Present Days</td>
                    <td class="auto-style62" style="width:80px"> <label id="actpre" runat="server"></label></td>
                    <td class="auto-style61">Absent days</td>
                    <td class="auto-style62" style="width:80px"><label id="absent" runat="server"></label></td>
                    <td class="auto-style43">
                        <table border="1" style="width:100%;height: 100px;">
                            <tr style="height:30px; background-color:#ffd966">
                                <td colspan="2" style="text-align: center;">Score ( 10% )</td>
                            </tr>
                            <tr>
                               <td colspan="2" style="text-align: center;">
                                   <label id="Attendenancescore" runat="server"></label>
</td>

                            </tr>
                        </table>
                    </td>

                </tr>
               
            </table>
            <table id="tb1" runat="server" border="1" class="auto-style20" style="width:100%; text-align:center; border-collapse: collapse;font-size:large">
                <tr>
                    <td class="auto-style83" colspan="6" style="font-weight:bold; background-color:#ffd966">
                        
                            &nbsp;&nbsp;&nbsp;&nbsp; C. Performance Review (To be filled by the Appraiser)
                    </td>
                    <td class="auto-style84" colspan="2" style="font-weight:bold; background-color:#ffd966">
                        <center>
                            90%</center>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style86" colspan="2" >
                        <center>
                            Assessment Parameter</center>
                    </td>
                    <td class="auto-style55">%</td>
                    <td class="auto-style56">5</td>
                    <td class="auto-style95">4</td>
                    <td class="auto-style96">3</td>
                    <td class="auto-style97">2</td>
                    <td class="auto-style59">1</td>
                </tr>
                <tr itemid="1" style="font-size:medium">
                    <td class="auto-style86" title="a" style="text-align:left; " colspan="2"><b>1. Behaviour: </b> It includes Personal grooming & hygiene, Always wears the proper & Clean uniform and systematic behaviour with staff Members & Customers.</td>
                    <td class="auto-style55" title="a" style="font-weight:bold">20</td>
                    <td colspan="5" title="a"><em>
                        <asp:CheckBoxList ID="score1" runat="server" AutoPostBack="True" CssClass="auto-style36" RepeatDirection="Horizontal" Width="191px">
                      <asp:ListItem  Value="5" onclick="MutExChkList1(this);" />
    <asp:ListItem  Value="4" onclick="MutExChkList1(this);" />
    <asp:ListItem  Value="3" onclick="MutExChkList1(this);" />
    <asp:ListItem  Value="2" onclick="MutExChkList1(this);" />
    <asp:ListItem  Value="1" onclick="MutExChkList1(this);" />
                </asp:CheckBoxList>
                        </em>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style86" colspan="2" style="text-align:left"><b>2. Customers:</b> It involves the customer satisfaction in respect of food test and food presentation , it also covers the views of customers.</td>
                    <td class="auto-style55" colspan="1" style="font-weight:bold">25</td>
                    <td colspan="5"><em>
                             <asp:CheckBoxList ID="score2" runat="server" AutoPostBack="True" CssClass="auto-style36" RepeatDirection="Horizontal" Width="191px">
                      <asp:ListItem  Value="5" onclick="MutExChkList2(this);" />
    <asp:ListItem  Value="4" onclick="MutExChkList2(this);" />
    <asp:ListItem  Value="3" onclick="MutExChkList2(this);" />
    <asp:ListItem  Value="2" onclick="MutExChkList2(this);" />
    <asp:ListItem  Value="1" onclick="MutExChkList2(this);" />
                </asp:CheckBoxList>
                        </em>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style86" style="text-align:left" colspan="2"><b>3. Cost Management: </b> It covers the budget of kitchen. Also ordering of food and production, holding & presentation of food.</td>
                    <td class="auto-style55" style="font-weight:bold ; width:50px">25</td>
                    <td colspan="5"><em>
                         <asp:CheckBoxList ID="score3" runat="server" AutoPostBack="True" CssClass="auto-style36" RepeatDirection="Horizontal" Width="191px">
                      <asp:ListItem  Value="5" onclick="MutExChkList3(this);" />
    <asp:ListItem  Value="4" onclick="MutExChkList3(this);" />
    <asp:ListItem  Value="3" onclick="MutExChkList3(this);" />
    <asp:ListItem  Value="2" onclick="MutExChkList3(this);" />
    <asp:ListItem  Value="1" onclick="MutExChkList3(this);" />
                </asp:CheckBoxList>
                        </em>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style86" style="text-align:left" colspan="2"><b>4. CLOSING: </b> Properly closes station including cleaning, FIFO, Label & Dating, equipment maintenance.</td>
                    <td class="auto-style55" style="font-weight:bold">20</td>
                    <td colspan="5"><em>
                         <asp:CheckBoxList ID="score4" runat="server" AutoPostBack="True" CssClass="auto-style36" RepeatDirection="Horizontal" Width="191px">
                      <asp:ListItem  Value="5" onclick="MutExChkList4(this);" />
    <asp:ListItem  Value="4" onclick="MutExChkList4(this);" />
    <asp:ListItem  Value="3" onclick="MutExChkList4(this);" />
    <asp:ListItem  Value="2" onclick="MutExChkList4(this);" />
    <asp:ListItem  Value="1" onclick="MutExChkList4(this);" />
                </asp:CheckBoxList>
                        </em>
                    </td>
                </tr>
              
               
                  <tr>
                    <td colspan="8" style="text-align:left">*(1) Mark a V (tick) against the appropriate rating. 5= Excellent(傑出), 4=Good(良好), 3=Mediocre(尚符需求), 2=Improvement Required(須改進), 1=Fail(不適任)
*(2) 評核項目轉換分數:前三項為勾選選項*4分；後兩項為勾選分數*3分</td>
                </tr>
              
              
            </table>
           <table class="auto-style20" border="1" style="width:100%;  border-collapse: collapse;font-size:large;height:13%">
                 <tr><td class="text-center" style="width:170px;font-size:x-large">6. Summarise the overall performance or comment : 總評建議: &nbsp;<%--<asp:Button ID="Button4" runat="server" Text="+" CssClass="btn btn-primary" />--%></td>
                     <td id="rema" runat="server" >
                         <asp:TextBox ID="remark" runat="server" Height="90px"  style="width:100%;font-size:x-large;height:100%"  BackColor="White" BorderColor="White" BorderStyle="None" TextMode="MultiLine" CssClass="form-control"></asp:TextBox>
                     </td>
                </tr>
           </table>

             
  <table border="1" class="auto-style169" style="width:100%; text-align:center; border-collapse: collapse;font-size:large">
                            <tr>
                                <td class="auto-style282" style="background-color:#ffd966" rowspan="2"><strong>Remarks 評論</strong></td>
                                <td class="auto-style334" rowspan="2" style="background-color:#ffd966"><strong>Status of Review Period</strong></td>
                                <td class="auto-style173" colspan="3" style="background-color:#ffd966"><strong>
                                    <asp:CheckBox ID="Good" runat="server" AutoPostBack="True" CssClass="auto-style280" Text="&nbsp;&nbsp;&nbsp;Pass" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    <asp:CheckBox ID="Average" runat="server" AutoPostBack="True" CssClass="auto-style280" Text="&nbsp;&nbsp;&nbsp;Extend" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                      
                                    </strong></td>
                            </tr>
                            <tr> 
                                <td class="auto-style173" colspan="3" style="background-color:#ffd966"><strong>Approvals 批准</strong></td>
                            </tr>
                            <em>
                            <tr style="font-size:x-large">
                                <td class="auto-style172" rowspan="3" style="text-align:left; color:deepskyblue;"><span class="auto-style280">Performance status definition :<br />
1. Pass: The score is 76 or above 76,<br />
2. Extend: If employee get the score on or between 66 ~ 75. The employee services<br /> be turn into Performance improvement plan. 
Employee has three months to improve his performance.

                                 </td>
                                <td class="auto-style175" style="background-color:#ffd966"><strong>Total Score<br /> &nbsp;總得分<br /> &nbsp;100%</strong></td>
                                <td class="auto-style180"><span class="auto-style280"><strong>Department Head </strong></span><strong>
                                    <br class="auto-style280" />
                                    </strong><span class="auto-style280"><strong>部門主管</strong></span></td>
                                <td class="auto-style281"><strong>Section Head<br /> &nbsp;課長</strong></td>
                                <td class="auto-style180"><span class="auto-style280"><strong>Employee Signature</strong></span><strong><br class="auto-style280" /> </strong><span class="auto-style280"><strong>員工簽名</strong></span></td>
                            </tr>
                            <tr>
                                 <td id="totmarks" runat="server" >
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
             
        </asp:Panel>
            <!-- This code for footer title -->
                <div style="display: flex; width:900px; justify-content: space-between; align-items: flex-end; text-align: center; margin-top:7px;">
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
    <br />
     <center>
               <asp:Button ID="insert" runat="server" cssclass="btn btn-primary" style="font-family: call; font-size: small;" Text="Submit" ValidationGroup="insert" />
                  <em></td>
                  </tr>
           </em></em>&nbsp;<span class="auto-style184"><asp:Button ID="update" runat="server" cssclass="btn btn-primary" OnClick="update_Click" style="font-family: call; font-size: small;" Text="Update" ValidationGroup="insert" />
                  &nbsp;<asp:Button ID="show" runat="server" cssclass="btn btn-primary" style="font-family: call; font-size: small;" Text="Show" ValidationGroup="insert" />
                    <asp:LinkButton runat="server" id="print" cssclass="btn btn-warning" OnClientClick = "printDiv('printableContent')"><i class="fa fa-print"></i> Print</asp:LinkButton>

               </span>
            </center><br />
        </ContentTemplate>
       
    </asp:UpdatePanel>
</asp:Content>

