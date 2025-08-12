<%@ Page Language="VB" AutoEventWireup="false" MasterPageFile="~/Site1.Master" CodeBehind="ReSales.aspx.vb" Inherits="Performance_Management_System.ReSales" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>ReSales Page</title>
    <meta charset="utf-8" />
    <style>
        body {
            font-family: Arial, sans-serif;
            font-size: 12px;
            margin: 20px;
        }
        .form-container {
            padding: 15px;
        }
        table {
            width: 100%;
            border-collapse: collapse;
            text-align: center;
        }
        th, td {
            border: 1px solid black;
            padding: 5px;
        }
        th {
            background-color: #f2f2f2;
        }
        .header-title {
            background-color: #d9e1f2;
            font-size: 18px;
            font-weight: bold;
            text-align: center;
            padding: 10px;
        }
        .section-title {
            background-color: #bdd7ee;
            font-weight: bold;
            text-align: center;
        }
        .highlight-yellow {
            background-color: #ffff00;
        }
        .highlight-blue {
            background-color: #daeef3;
        }
        .bold {
            font-weight: bold;
        }
        .pink-text {
            color: #f511e2;
        }
        .skyblue-bg {
            background-color: skyblue;
        }
        .chocolate-bg {
            background-color: chocolate;
            color: white; /* Ensure text is visible on dark background */
        }
        .cornflowerblue-bg {
            background-color: cornflowerblue;
        }
        .darkblue-bg {
            background-color: #31598f;
            color: white; /* Ensure text is visible on dark background */
        }
        .text-left {
            text-align: left;
        }
        .text-center {
            text-align: center;
        }

        /* --- Print Specific Styles --- */
        @media print {
            .whttxt{
                color:white !important;
            }
    body {
        -webkit-print-color-adjust: exact; /* For Webkit browsers */
        print-color-adjust: exact;         /* Standard property */
        font-size: 9pt;                    /* Slightly smaller font for more content */
        margin: 0;                         /* Remove default body margins */
        padding: 0;
    }

    /* Target the main content panel for printing */
    #printableContent {
        width: 100%; /* Use 100% of the available print width */
        max-width: 8.27in; /* A4 width is 8.27 inches, adjust for Letter if needed */
        margin: 0 auto; /* Center the content if it's less than max-width */
        padding: 0.1in; /* Small padding from edges, adjust as needed */
        box-sizing: border-box; /* Include padding in the width calculation */
    }

    .form-container {
        padding: 0 !important; /* Reduce padding to maximize space */
    }

    table {
        width: 100% !important; /* Ensure table takes full width */
        border-collapse: collapse;
        table-layout: fixed; /* Important: Distributes column widths evenly or as specified */
    }

    th, td {
        border: 1px solid black !important;
        padding: 3px 5px !important; /* Reduced padding for cells */
        font-size: 8pt; /* Even smaller font size for table content */
        word-wrap: break-word; /* Allow long words to break */
        white-space: normal; /* Allow text to wrap naturally */
        -webkit-print-color-adjust: exact;
        print-color-adjust: exact;
    }

    /* Force background colors with !important */
    .header-title { background-color: #d9e1f2 !important; }
    .section-title { background-color: #bdd7ee !important; }
    .highlight-yellow { background-color: #ffff00 !important; }
    .highlight-blue { background-color: #daeef3 !important; }
    .skyblue-bg { background-color: skyblue !important; }
    .chocolate-bg {
        background-color: chocolate !important;
        color: white !important;
    }
    .cornflowerblue-bg { background-color: cornflowerblue !important; }
    .darkblue-bg {
        background-color: #31598f !important;
        color: white !important;
    }

    /* Hide elements not needed in print */
    #outerimgdiv, .camera-container, #btnCapture, #btnUpload, .btn-primary, .btn-warning, #insert, #print {
        display: none !important;
    }

    /* Specific adjustments for checkbox appearance in print */
    input[type="checkbox"] {
        -webkit-appearance: none;
        -moz-appearance: none;
        appearance: none;
        border: 1px solid black; /* Show border */
        width: 8px; /* Make it smaller */
        height: 8px;
        display: inline-block;
        vertical-align: middle;
        margin-right: 2px;
    }

    /* Add a checkmark for checked checkboxes */
    input[type="checkbox"]:checked::before {
        content: '\2713'; /* Unicode checkmark */
        display: block;
        color: black;
        font-size: 8px;
        line-height: 8px;
        text-align: center;
    }

    /* Make ASP.NET Label text render without any ASP.NET specific styling */
    .aspNetDisabled {
        color: inherit !important;
        background-color: inherit !important;
    }

    /* Adjust column widths more precisely if table-layout: fixed; is used */
    /* You'll need to inspect your table and decide which columns can be narrower.
       For example, the first two columns (Quarter, Month) can be very narrow. */
    #tblHeader td:nth-child(1), /* Quarter */
    #tblHeader td:nth-child(2)  /* Month */ {
        width: 5%; /* Example: Make these very narrow */
    }
    /* Continue for other columns, ensuring total is 100% or slightly less to avoid overflow */
    /* Example:
    #tblHeader td:nth-child(3) { width: 10%; } /* No. of Team Member */
    /* ... and so on */
}
    </style>

    <script>
        function printDiv(divId) {
            var printContents = document.getElementById(divId).innerHTML;
            var originalContents = document.body.innerHTML; // Not strictly needed if print window is closed

            var a = window.open('', '', 'height=700, width=900'); // Larger window for better preview

            var headContent = document.head.innerHTML; // Get all head content to include all styles/links

            a.document.write('<html><head><title>Performance Review</title>');
            a.document.write(headContent); // Include all collected CSS links and style tags directly
            a.document.write('</head><body>');
            a.document.write(printContents); // Write the inner HTML of the printable div
            a.document.write('</body></html>');
            a.document.close();
            a.print();
            // The print window is a separate entity and will be closed after printing or by user.
            // No need to restore original content on the main page.
        }
        //function printDiv(divId) {
        //    var printableContent = document.getElementById(divId).innerHTML;
        //    var originalContent = document.body.innerHTML;

        //    // Get all the styles from the head of the current document
        //    var styles = document.head.innerHTML.match(/<style[^>]*>[\s\S]*?<\/style>/gi) || [];
        //    var allStyles = '';
        //    styles.forEach(function (styleTag) {
        //        allStyles += styleTag;
        //    });

        //    // Create a new window for printing
        //    var printWindow = window.open('', '_blank');

        //    printWindow.document.write('<html><head><title>Performance Review</title>');
        //    printWindow.document.write(allStyles); // Include all original styles
        //    printWindow.document.write('</head><body>');

        //    // Write printable content into the new window
        //    printWindow.document.write(printableContent);

        //    printWindow.document.write('</body></html>');
        //    printWindow.document.close();

        //    // Focus and print the new window
        //    printWindow.focus();
        //    printWindow.print();
        //    printWindow.close();

        //    // Restore original content on the main page (though often not strictly necessary if you close the print window)
        //    // This line might cause issues if the original page state needs to be perfectly preserved.
        //    // For most print scenarios, it's not critical as the print window is closed.
        //    // document.body.innerHTML = originalContent; 
        //}
    </script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%-- Camera section - hidden in print via CSS --%>
    <div id="outerimgdiv" style="position:fixed;" runat="server">
        <div class="camera-container">
            <div id="webcam"></div>
            <button id="btnCapture" type="button" class="btn-success form-control">Capture</button>
        </div>
        <script>
            $(function () {
                var power = '<%= Session("access power") %>';
                if (power == 3) {
                    var webcamWidth = $('#webcam').width();
                    var webcamHeight = $('#webcam').height();

                    // Only attach webcam if it's available and power is 3
                    if (typeof Webcam !== 'undefined') { // Check if Webcam.js is loaded
                        Webcam.set({
                            width: webcamWidth,
                            height: webcamHeight,
                            image_format: 'jpeg',
                            jpeg_quality: 90
                        });
                        Webcam.attach('#webcam');
                    } else {
                        console.warn("Webcam.js not loaded. Camera functionality disabled.");
                    }

                    $("#btnCapture").click(function () {
                        if (typeof Webcam !== 'undefined') {
                            Webcam.snap(function (data_uri) {
                                var img = new Image();
                                img.src = data_uri;
                                img.onload = function () {
                                    var canvas = document.createElement('canvas');
                                    var ctx = canvas.getContext('2d');

                                    canvas.width = img.width;
                                    canvas.height = img.height + 30; // Extra space for date/time

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
                        }
                    });

                    $("#btnUpload").click(function () {
                        var imageData = $("#imgCapture")[0].src;

                        // Check if an image has been captured before uploading
                        if (imageData && imageData.indexOf('data:image/') === 0) {
                            $.ajax({
                                type: "POST",
                                url: "Finance_Accounting_Payable_New.aspx/SaveCapturedImage", // Verify this URL is correct for your project
                                data: JSON.stringify({ data: imageData }),
                                contentType: "application/json; charset=utf-8",
                                dataType: "json",
                                success: function (r) {
                                    alert('Image saved successfully!');
                                    chk3Display();
                                },
                                error: function (xhr, status, error) {
                                    console.error("Upload error:", status, error, xhr.responseText);
                                    alert("There was an error uploading the image. See console for details.");
                                }
                            });
                        } else {
                            alert("Please capture an image first.");
                        }
                    });
                }
            });

            function chk3Display() {
                $(".emps").css("display", "block");
            }

        </script>
        <br />
        <div class="camera-container">
            <img id="imgCapture" />
            <button id="btnUpload" type="button" class="form-control btn-primary">Upload</button>
        </div>
    </div>

    <%-- Main printable content --%>
    <div id="printableContent">
        <center>
            <asp:Panel ID="Panel1" runat="server" BackColor="#ffffff"  CssClass="auto-style183" Width="1100px">

                <div class="form-container">
                    <table>
                        <tr class="header-title">
                            <td colspan="18">Performance Review Form <span class="pink-text">(For Commercial : Sales Team Leader) 績效評估表（商業：銷售團隊負責人）</span></td>
                        </tr>

                        <tr class="cornflowerblue-bg">
                            <td colspan="18">A. Employee Information 員工信息</td>
                        </tr>
                        <tr>
                            <td colspan="2">Employee Name<br>員工姓名</td>

                            <td colspan="2"><asp:Label ID="lblEmpName" runat="server"></asp:Label></td>
                            <td colspan="2">Employee Code<br>員工編號</td>
                            <td colspan="2"><asp:Label ID="lblEmployeeCode" runat="server"></asp:Label></td>
                            <td colspan="2">Designation<br>指定</td>
                            <td colspan="2"><asp:Label ID="lblDesignation" runat="server"></asp:Label></td>
                            <td colspan="3">Level<br>等級</td>
                            <td colspan="3"><asp:Label ID="lblLevel" runat="server"></asp:Label></td>
                        </tr>

                        <tr>
                            <td colspan="2">Dept./Section<br>部門/科別</td>
                            <td colspan="2"><asp:Label ID="lblDeptSection" runat="server"></asp:Label></td>
                            <td colspan="2">DOJ<br>美國司法部</td>
                            <td colspan="2"><asp:Label ID="lblJoinDate" runat="server"></asp:Label></td>
                            <td colspan="2">Reporting To<br>報告對象</td>
                            <td colspan="2"><asp:Label ID="lblReviewer" runat="server"></asp:Label></td>
                            <td colspan="3">Salary Grade (Grade & Semi )<br>薪資等級</td>
                            <td colspan="3"><asp:Label ID="lblGrade" runat="server"></asp:Label></td>
                        </tr>
                        <tr>
                            <td colspan="2">Review Time<br>評核期間</td>
                            <td colspan="16">
                                <asp:CheckBox ID="q1" runat="server" Text="Q1" />
                                <asp:CheckBox ID="q2" runat="server" Text="Q2" />
                                <asp:CheckBox ID="q3" runat="server" Text="Q3" />
                                <asp:CheckBox ID="q4" runat="server" Text="Q4" />
                                <span>Other: Monthly Mar'25</span>
                            </td>
                        </tr>

                        <tr>
                            <td colspan="17" class="section-title">B. Evaluation Result of Sales Performance (by HR)</td>
                            <td rowspan="2" colspan="1" class="skyblue-bg">100%</td>
                        </tr>
                        <tr class="chocolate-bg">
                            <td colspan="2">Details<br>細節</td>
                            <td colspan="7">Team Plan & Team Expectation<br>團隊計劃和團隊期望</td>
                            <td colspan="3">Team Achievement<br>團隊成就</td>
                            <td colspan="5">Team rate<br>團隊率</td>
                        </tr>

                        <tr id="tblHeader">
                            <td>Quarter<br>四分之一</td>
                            <td>Month<br>月</td>
                            <td>No. of Team Member<br>團隊成員人數</td>
                            <td>TW<br>台灣</td>
                            <td>Indian<br>印度人</td>
                            <td>Average<br>平均數</td>
                            <td>Plan<br>計劃</td>
                            <td>Expect %<br>預計%</td>
                            <td>Expect Tires<br>期待輪胎</td>
                            <td>Actual<br>實際的</td>
                            <td>% (比例)</td>
                            <td>Extra Tires<br>額外的輪胎</td>
                            <td>Rate<br>速度</td>
                            <td>Pice Rate Amount<br>計件金額</td>
                            <td>Variable Pay<br>可變薪酬</td>
                            <td>Coefficient<br>係數</td>
                            <td>piece rate + VP<br>計件費 + 可變績效金額</td>
                            <td>Score<br>分數</td>
                        </tr>

                        <tbody id="placeholderTable" runat="server">
                            </tbody>

                        <tr id="trYearTotal" runat="server" class="bold">
                            <td id="tdTitle" runat="server" colspan="2">Total (End of Year)<br />總計（年末）</td>
                            <td id="tdTeamMembers" runat="server" class="highlight-yellow"></td>
                            <td id="tdTW_Value" runat="server" class="highlight-yellow"></td>
                            <td id="tdIndian_Value" runat="server" class="highlight-yellow"></td>
                            <td id="tdyearavarage_Value" runat="server" class="highlight-yellow"></td>
                            <td id="tdPlan_Percentage" runat="server" class="highlight-yellow"></td>
                            <td id="tdExpect_Percentage" runat="server" class="highlight-yellow"></td>
                            <td id="tdExpect_Tires" runat="server" class="highlight-yellow"></td>
                            <td id="tdActual_Value" runat="server" class="highlight-yellow"></td>
                            <td id="tdAchivement_Value" runat="server" class="highlight-yellow"></td>
                            <td id="tdyearTotalExtraTires" runat="server" class="highlight-yellow"></td>
                            <td id="tdRate" runat="server" class="highlight-yellow"></td>
                            <td id="tdPieceRateAmount" runat="server" class="highlight-yellow"></td>
                            <td id="tdVariablepay" runat="server" class="highlight-yellow"></td>
                            <td id="tdCoefficient" runat="server" class="highlight-yellow"></td>
                            <td id="tdFinalAmtVP" runat="server" class="highlight-yellow"></td>
                            <td id="tdyearscoreAverage" runat="server" class="highlight-yellow"></td>

                        </tr>


                        <tr class="bold">
                            <td colspan="2">Remarks<br>評論</td>
                            <td colspan="16" id="txtRemarks" runat="server"></td>
                        </tr>

                        <tr class="bold">
                            <td colspan="4" class="pink-text">6. Summaries the overall performance or comment :<br>總評建議:</td>
                            <td colspan="14"></td>
                        </tr>

                        <tr class="bold">
                            <td class="highlight-blue" colspan="18">C. Criteria of after Monthly /Quarterly /Yearly performance 後月/季/年業績標準</td>
                        </tr>

                        <tr class="bold">
                            <td colspan="6">Performance Evaluation on base of Mar'25</td>
                            <td colspan="4">Status of Review Period</td>
                            <td colspan="4"><asp:CheckBox ID="chkPass" runat="server" Text="Pass" /></td>
                            <td colspan="4"><asp:CheckBox ID="chkExtend" runat="server" Text="Extend" /></td>
                        </tr>

                        <tr class="bold">
                            <td class="chocolate-bg" colspan="18">Resales Piece rate deduction rule (If some circumstances we have accepted only below mention terms in Your performance)轉售件費扣除規則（如果某些情況下我們只接受了您的表現中提到的以下條款）</td>
                        </tr>

                        <tr class="bold">
                            <td colspan="9" class="cornflowerblue-bg whttxt">Terms of allowing to Employee 允許僱員的條款</td>
                            
                            <td colspan="9" class="cornflowerblue-bg whttxt">Terms of allowing to Distributor 允許經銷商的條款</td>
                        </tr>

                        <tr class="text-center bold">
                            <td><asp:CheckBox ID="chkTerm1" runat="server" /></td>
                            <td colspan="4">1.Pandemic Situation & natural calamities 大流行情況和自然災害</td>
                            
                            <td><asp:CheckBox ID="chkTerm6" runat="server" /></td>
                            <td colspan="3">6.Suddenly decline or cancel the agreement & below mention the condition 突然拒絕或取消協議及以下提及的條件</td>
                            <td><asp:CheckBox ID="chkTermDist1" runat="server" /></td>
                            <td colspan="8">1.Pandemic Situation & natural calamities 大流行情況和自然災害</td>
                        </tr>
                        <tr class="text-center bold">
                            <td><asp:CheckBox ID="CheckBox1" runat="server" /></td>
                            <td colspan="4">2.shortage of Products from MRI Side MRI側產品短缺</td>
                            <td><asp:CheckBox ID="CheckBox2" runat="server" /></td>
                            <td colspan="3">A. Found some fault & fraud 發現一些錯誤和欺詐</td>
                            <td><asp:CheckBox ID="CheckBox3" runat="server" /></td>
                            <td colspan="8">2.shortage of Products from MRI Side MRI側產品短缺</td>
                        </tr>
                        <tr class="text-center bold">
                            <td><asp:CheckBox ID="CheckBox4" runat="server" /></td>
                            <td colspan="4">3.Due to Employee Sickness or any Medical Emergency (Operation,Accident Personal or In Family ) 由於員工生病或任何醫療緊急情況（手術、個人或家庭事故）</td>
                            <td><asp:CheckBox ID="CheckBox5" runat="server" /></td>
                            <td colspan="3">B.not accepted terms and conditions & not follow the agreement condition. 不接受條款和條件 & 不遵守協議條件。</td>
                            <td><asp:CheckBox ID="CheckBox6" runat="server" /></td>
                            <td colspan="8">5. Govt. rule and regulation change 政府規則和法規的變化</td>
                        </tr>
                        <tr class="text-center bold">
                            <td><asp:CheckBox ID="CheckBox7" runat="server" /></td>
                            <td colspan="4">4. Distributor issues Ex. Product-related, supply chain or govt. issue or external factor . 分銷商問題產品相關、供應鍊或政府。問題或外部因素</td>
                            <td><asp:CheckBox ID="CheckBox8" runat="server" /></td>
                            <td colspan="3">C.Not provide documents as per company requirement. 未按公司要求提供文件。</td>
                            <td><asp:CheckBox ID="CheckBox9" runat="server" /></td>
                            <td colspan="8">6. Other Special Reason 其他特殊原因</td>
                        </tr>
                        <tr class="text-center bold">
                            <td><asp:CheckBox ID="CheckBox10" runat="server" /></td>
                            <td colspan="4">5. Govt. rule and regulation change 政府規則和法規的變化</td>
                            <td><asp:CheckBox ID="CheckBox11" runat="server" /></td>
                            <td colspan="3">6. Other Special Reason 其他特殊原因</td>
                            <td rowspan="3" colspan="9" class="text-left">Comments: <asp:TextBox ID="overallcomments" runat="server" TextMode="MultiLine" cssclass="form-control"></asp:TextBox>
                        </tr>

                        <tr class="text-center">
                            <td colspan="9">Note: Only Training or Probation period employees we will allow only 3 times and Confirmed employee we will be allowed 2 times in a year. 注意：只有培訓或試用期的員工我們將只允許 3 次，確認員工我們將在一年內允許 2 次。</td>
                        </tr>

                        <tr class="text-left bold">
                            <td colspan="9">Comments: 註釋：</td>
                        </tr>

                        <tr class="darkblue-bg text-center">
                            <td colspan="18" class="whttxt">If when you fail in Review Month 如果你在 Review Month 中失敗了</td>
                        </tr>

                        <tr>
                            <td colspan="3">Evaluate By<br>評估依據</td>
                            <td colspan="6">Salary Effect of Monthly base<br>月基工資效應</td>
                            <td colspan="4">Remarks /Comment<br>備註/評論</td>
                            <td colspan="5">Employee Signature<br>員工簽名</td>
                        </tr>
                        <tr>
                            <td colspan="3">By Own Self (Employee)<br>自己（員工）</td>
                            <td><input type="checkbox"></td>
                            <td colspan="2">Same as (No deduct)<br>與（不扣除）相同</td>
                            <td><input type="checkbox"></td>
                            <td colspan="2">Salary decrease (Deduct)<br>減薪（扣除）</td>
                            <td colspan="4"></td>
                            <td colspan="5"></td>
                        </tr>
                        <tr>
                            <td colspan="3">By Leader<br>領導者</td>
                            <td><input type="checkbox"></td>
                            <td colspan="2">Same as (No deduct)<br>與（不扣除）相同</td>
                            <td><input type="checkbox"></td>
                            <td colspan="2">Salary decrease (Deduct)<br>減薪（扣除）</td>
                            <td colspan="4"></td>
                            <td colspan="5"></td>
                        </tr>
                        <tr>
                            <td colspan="3">By Section Head<br>按科長</td>
                            <td><input type="checkbox"></td>
                            <td colspan="2">Same as (No deduct)<br>與（不扣除）相同</td>
                            <td><input type="checkbox"></td>
                            <td colspan="2">Salary decrease (Deduct)<br>減薪（扣除）</td>
                            <td colspan="4"></td>
                            <td colspan="5"></td>
                        </tr>
                        <tr>
                            <td colspan="3">By Dept. Head<br>部門負責人</td>
                            <td><input type="checkbox"></td>
                            <td colspan="2">Same as (No deduct)<br>與（不扣除）相同</td>
                            <td><input type="checkbox"></td>
                            <td colspan="2">Salary decrease (Deduct)<br>減薪（扣除）</td>
                            <td colspan="4"></td>
                            <td colspan="5"></td>
                        </tr>

                        <tr>
                            <td colspan="18" class="skyblue-bg whttxt">The final decision is taken by Department Head for deduction for salary 扣除工資的最終決定由部門負責人做出</td>
                        </tr>

                        <tr>
                            <td colspan="3">Salary Effect<br>薪酬效應</td>
                            <td colspan="4"><asp:CheckBox ID="chkSame" runat="server" Text="Same as 與...一樣" /></td>
                            <td colspan="4"><asp:CheckBox ID="chkIncrease" runat="server" Text="Salary Increase 漲薪" /></td>
                            <td colspan="3"><asp:CheckBox ID="chkDecrease" runat="server" Text="Salary decrease 減薪" /></td>
                            <td colspan="4">Other: 其他：</td>
                        </tr>

                        <tr class="darkblue-bg">
                            <td colspan="5" class="whttxt">Remarks 評論</td>
                            <td colspan="2" rowspan="2" class="whttxt">Total Score<br>總得分<br>100%</td>
                            <td colspan="11" class="whttxt">Approvals 批准</td>
                        </tr>

                        <tr>
                            <td colspan="5" class="pink-text text-left" rowspan="2">
                                Performance status definition :考核結果說明<br>
                                1.Pass: Score is 76 or more than 76 every time<br>
                                適任: 分數高於76分<br>
                                2.Extend : Score is 75 or below 75, turn to extend period(PIP), employee has three months to improve his/her performance.<br>
                                延長:分數低於75分，進入績效改善階段，共三個月之改善期間。
                            </td>
                            <td colspan="2">Department Head<br>部門主管</td>
                            <td colspan="5" class="text-center">Section Head 科長</td>
                            <td colspan="4">Employee Signature員工簽名</td>
                        </tr>

                        <tr>
                            <td colspan="2" rowspan="3" id="finlamnt" runat="server"></td>
                            <td colspan="2" style="height: 80px;"> <asp:CheckBox ID="ch1" runat="server" /></td>
                            <td colspan="5" style="height: 80px;"> <asp:CheckBox ID="ch2" runat="server" /></td>
                            <td colspan="4" style="height: 80px;" class="text-center">
                                <label id="lblEmpsign" runat="server"></label>
                                <label id="lblEmpDate" runat="server"></label>
                                <asp:CheckBox ID="ch3" runat="server" CssClass="auto-style280 emps" style="display:none" onclick="if(!confirm('Are you sure you want to Accept?'))return false;" />
                            </td>

                        </tr>
                        <tr>
                            <td colspan="5"></td>
                            <td class="auto-style173" colspan="11" style="font-size:small;height: 30px;">&nbsp;<asp:Label ID="Time" runat="server" Text="Label"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </div>

            </asp:Panel>
                                <!-- This code for footer title -->
                <div style="display: flex; width:1100px; justify-content: space-between; align-items: flex-end; text-align: center; margin-top:7px;">
    <div style="text-align: left;">
        Retention Period: Keep until <br />
        the employee's relieving <br />
        period is completed <br />
        label
    </div>
    <div style="text-align: center;">MAXXIS RUBBER INDIA PVT. LTD.</div>
    <div style="text-align: right;">A4/A3 No. 0399-1</div>
</div>
        </center>
        <br />
        <br />
    </div>
    <br />
    <br />
    <center>
        <asp:Button ID="insert" runat="server" CssClass="btn btn-primary"
            Style="font-family: call; font-size: small;"
            Text="Submit" ValidationGroup="insert" />

        &nbsp;

        &nbsp;

        &nbsp;

        <asp:LinkButton runat="server" ID="print" CssClass="btn btn-warning" OnClientClick="printDiv('printableContent'); return false;">
            <i class="fa fa-print"></i> Print
        </asp:LinkButton>
        <br />
        <br />
    </center>
    <br />
    <br />
</asp:Content>