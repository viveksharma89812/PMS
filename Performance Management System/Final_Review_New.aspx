<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site1.Master" CodeBehind="Final_Review_New.aspx.vb" Inherits="Performance_Management_System.Final_Review_New" %>

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
                       
                      Training / Probation Period Final Review Form (For Staff) 訓練期/試用期期滿評核表(大專人員)</td>
                </tr>
                <tr>
                    <td class="auto-style31" colspan="6" style="font-weight:bold;background-color:#61cbf3 ">
                       
                            A. Employee Information
                    </td>
                </tr>
                <tr>
                    <td class="auto-style24">Employee Name</td>
                    <td class="auto-style26" id="Empname" runat="server">
                        
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
                    <td class="auto-style24">Qualification</td>
                     <td class="auto-style122">
                        <asp:Label ID="Qual" runat="server" CssClass="auto-style280" Text="Label"></asp:Label>
                    </td>
                    <td class="auto-style25">Previous Experience</td>
                      <td class="auto-style122">
                        <asp:Label ID="PreExp" runat="server" CssClass="auto-style280" Text="Label"></asp:Label>
                    </td>
                    <td class="auto-style27">Reporting to</td>
                    <td class="auto-style122">
                                                    <asp:Label ID="repto" runat="server" CssClass="auto-style280" Text="Label"></asp:Label>
                                                </td>
                </tr>
                <tr>
                    <td>Period</td>
                     <td class="auto-style122" colspan="5" style="font-weight:bold"> <asp:CheckBox ID="trai" runat="server" CssClass="auto-style280" Text="Training Period" AutoPostBack="True"  /> &nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;
                        <asp:CheckBox ID="prob" runat="server" CssClass="auto-style280" Text="Probation Period" AutoPostBack="True"  />
                        &nbsp;&nbsp;&nbsp;     
                       
                    </td>
                   
                    
                </tr>
          
            </table>
            <table id="2" border="1" class="auto-style20" style="width:100%; text-align:center; border-collapse: collapse;">
               <tr>
                    <td class="auto-style31" colspan="10" style="font-weight:bold;background-color:#61cbf3 ">
                       
                            A.Employee Information
                    </td>
                   <td class="auto-style31"  style="font-weight:bold;background-color:#61cbf3 " width="106">
                       
                           10%
                    </td>
                </tr>
                <tr>
                    <table border="1" runat="server" style="width:100%; text-align:center; border-collapse: collapse;">
                        <tr>
                             <td class="auto-style63">Actual Working Days</td>
                              <td class="auto-style61">Actual Present Days</td>
                              <td class="auto-style61">CL</td>
                              <td class="auto-style61">SL</td>
                              <td class="auto-style61">PL</td>
                              <td class="auto-style61">LWP</td>
                              <td class="auto-style61">Other Leave</td>
                            <td class="auto-style61">Absent days</td>
                            <td class="auto-style61">Score</td>
                        </tr>
                         <tr>
                            <td class="auto-style62">
                                <label id="actwork" runat="server">0</label>
                            </td>
                            <td class="auto-style62">
                                <label id="actpre" runat="server">0</label>
                            </td>
                            <td class="auto-style62">
                                <label id="cl" runat="server">0</label>
                            </td>
                            <td class="auto-style62">
                                <label id="sl" runat="server">0</label>
                            </td>
                            <td class="auto-style62">
                                <label id="pl" runat="server">0</label>
                            </td>
                            <td class="auto-style62">
                                <label id="lwp" runat="server">0</label>
                            </td>
                            <td class="auto-style62">
                                <label id="otherleave" runat="server">0</label>
                            </td>
                            <td class="auto-style62">
                                <label id="absent" runat="server">0</label>
                            </td>
                            <td class="auto-style62">
                                <label id="scor" runat="server">0</label>
                            </td>
                        </tr>
                    </table>
                   
                </tr>
               
            </table>
            <table id="tb1" runat="server" border="1" class="auto-style20" style="width:100%; text-align:center; border-collapse: collapse;font-size:large">
                <tr>
                    <td class="auto-style83" colspan="6" style="font-weight:bold; background-color:#61cbf3">
                        
                            &nbsp;&nbsp;&nbsp;&nbsp; C. Performance Review (To be filled by the Appraiser)
                    </td>
                    <td class="auto-style84" colspan="2" style="font-weight:bold; background-color:#61cbf3">
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
                    <td class="auto-style86" title="a" style="text-align:left; " colspan="2"><b>1. Proficiency/competency in work(工作職能) : </b>  The capacity to understand a situation and to act reasonably, Creativity & innovatively.</td>
                    <td class="auto-style55" title="a" style="font-weight:bold">15</td>
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
                    <td class="auto-style86" colspan="2" style="text-align:left"><b>2. Quality of Work(工作品質) :</b> Gives considerable amount of effort and importance to maintain and upgrade quality standards of work for self and team.</td>
                    <td class="auto-style55" colspan="1" style="font-weight:bold">15</td>
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
                    <td class="auto-style86" style="text-align:left" colspan="2"><b>3. Problem Solving & Decision making(問題分析及解決能力) : </b> Ability to gather and analyze relevant data to solve problems and make decisions within the scope of authority.</td>
                    <td class="auto-style55" style="font-weight:bold ; width:50px">15</td>
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
                    <td class="auto-style86" style="text-align:left" colspan="2"><b>4. Initiative(工作積極性) :  </b> Shows a positive attitude & motivation towards work and the organization. Consistently developing new initiatives to ensure continued growth.</td>
                    <td class="auto-style55" style="font-weight:bold">15</td>
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
                    <td class="auto-style86" style="text-align:left" colspan="2"><b>5. Ability to Learn (訓後運用效果) :  </b> Ability to apply strategies which support learning and the ability to adapt to change.</td>
                    <td class="auto-style55" style="font-weight:bold">15</td>
                    <td colspan="5"><em>
                         <asp:CheckBoxList ID="score5" runat="server" AutoPostBack="True" CssClass="auto-style36" RepeatDirection="Horizontal" Width="191px">
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
                    <td class="auto-style86" style="text-align:left" colspan="2"><b>6. Involvement/participation in team effort(團隊合作) : </b> Can inspire confidence in others and creates enthusiasm and ensures collaboration amongst team members to attain stated objectives.</td>
                    <td class="auto-style55" style="font-weight:bold">15</td>
                    <td colspan="5"><em>
                         <asp:CheckBoxList ID="score6" runat="server" AutoPostBack="True" CssClass="auto-style36" RepeatDirection="Horizontal" Width="191px">
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
                    <td colspan="8" style="text-align:left">*(1) Mark a V (tick) against the appropriate rating. 5= Excellent(傑出), 4=Good(良好), 3=mediocre(尚符需求), 2=Improvement Required(須改進), 1=Fail(不適任)
*(2) 評核項目轉換分數:勾選選項*3分 (最高為15分，最低為3分)</td>
                </tr>
              
              
            </table>
           <table class="auto-style20" border="1" style="width:100%;  border-collapse: collapse;font-size:large;height:13%">
                 <tr><td class="text-center" style="width:200px;font-size:large">7. Recommendation & Summaries the overall performance and progress over probation / training period :<b> 員工總評建議: </b>&nbsp;<%--<asp:Button ID="Button4" runat="server" Text="+" CssClass="btn btn-primary" />--%></td>
                     <td id="rema" runat="server" >
                         <asp:TextBox ID="remark" runat="server" Height="90px"  style="width:100%;font-size:x-large;height:100%"  BackColor="White" BorderColor="White" BorderStyle="None" TextMode="MultiLine" CssClass="form-control"></asp:TextBox>
                     </td>
                </tr>
           </table>

             
  <table border="1" class="auto-style169" style="width:100%; text-align:center; border-collapse: collapse;font-size:large">
                            <tr> 
                                <td class="auto-style173" colspan="6" style="color:red"><strong>(Do not mention here any kind of increment %)  . 請勿於此表上填寫調薪百分比％。</strong></td>
                            </tr>

                            <tr>
                                <td class="auto-style282" style="background-color:#61cbf3" rowspan="2"><strong>Remarks 評論</strong></td>
                                <td class="auto-style334" rowspan="1" ><strong>Status of probation / Training period</strong></td>
                                <td class="auto-style173" colspan="4"><strong>
                                    <asp:CheckBox ID="Good" runat="server" AutoPostBack="True" CssClass="auto-style280" Text="&nbsp;&nbsp;&nbsp;Pass" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    <asp:CheckBox ID="Average" runat="server" AutoPostBack="True" CssClass="auto-style280" Text="&nbsp;&nbsp;&nbsp;Extend" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                        <asp:CheckBox ID="Fail" runat="server" AutoPostBack="True" CssClass="auto-style280" Text="&nbsp;&nbsp;&nbsp;Fail" />
                                    </strong></td>
                            </tr>
                            <tr> 
                                <td class="auto-style173" colspan="5" style="background-color:#61cbf3"><strong>Approvals 批准</strong></td>
                            </tr>
                            <em>
                            <tr style="font-size:medium">
                                <td class="auto-style172" rowspan="3" style="text-align:left; color:black;"><span class="auto-style280">*Performance result definition:<b> 考核結果說明 </b><br />
1.Pass:<b> 適任</b>  <br />
 <b> Training:</b>Average score is 66 or more than 66.<br />
<b>訓練期：平均高於66分</b> <br />
<b>Probation:</b> Average score is 71 or more than 71.<br />
                                    <b>試用期：平均高於71分</b><br />
                                    <b>2.Extend: 延長</b><br />
                                    <b>Training: </b>Average score is equal to or between 56-65 <br />
                                    <b>訓練期：平均落於56-65分</b><br />
                                    <b>Probation:</b>Average score is equal to or between 61-70.<br />
                                    <b>試用期：平均落於61-70分</b><br />
                                    3.In Extend plan Employee has three months to improve his/her performance.
                                    <b>延長期間共有三個月可進行改善</b>



                                 </td>
                                <td class="auto-style175"  style="background-color:#61cbf3"><strong>Total Score<br /> &nbsp;總得分<br /> &nbsp;100%</strong></td>
                                 <td class="auto-style281"><strong>Plant Head<br /> &nbsp;廠長</strong></td>
                                <td class="auto-style180"><span class="auto-style280"><strong>Department Head </strong></span><strong>
                                    <br class="auto-style280" />
                                    </strong><span class="auto-style280"><strong>部門主管</strong></span></td>
                                <td class="auto-style281"><strong>Section Head<br /> &nbsp;課長</strong></td>
                                <td class="auto-style180"><span class="auto-style280"><strong>Employee Signature</strong></span><strong><br class="auto-style280" /> </strong><span class="auto-style280"><strong>員工簽名</strong></span></td>
                            </tr>
                            <tr>
                                 <td id="totmarks" runat="server" >
                                </td>
                                 <td class="auto-style178" style="height:151px">
                                    <asp:CheckBox ID="ch4" runat="server" CssClass="auto-style280" />
                                </td>
                                <td class="auto-style178" style="height:151px">
                                    <asp:CheckBox ID="ch1" runat="server" CssClass="auto-style280" />
                                </td>
                                <td class="auto-style178">
                                    <asp:CheckBox ID="ch2" runat="server" CssClass="auto-style280" />
                                </td>
                                <td class="auto-style178">
                                    <label id="lblEmpsign" runat="server"></label>
<label id="lblEmpDate" runat="server"></label>
                                    <asp:CheckBox ID="ch3" runat="server" CssClass="auto-style280 emps"  style="display:none" onclick="if(!confirm('Are you sure you want to Accept?'))return false;" />
                                </td>
                            </tr>
                            </em>
                            <tr>
                                <td class="auto-style173" colspan="5" style="font-size:small">&nbsp;<asp:Label ID="Time" runat="server" Text="Label"></asp:Label>
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