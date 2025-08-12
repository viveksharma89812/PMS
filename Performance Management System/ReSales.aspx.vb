Imports DocumentFormat.OpenXml.Drawing.Diagrams
Imports DocumentFormat.OpenXml.Wordprocessing
Imports Microsoft.VisualBasic.Devices
Imports System.IO
Imports System.Net
Imports System.Security.Cryptography

Public Class ReSales
    Inherits System.Web.UI.Page
    Dim strsql As String
    Dim tot As String
    Dim mon As String
    Dim tyear As String
    Public PMSclass As New PMSClass()
    Dim fst As String
    Dim sec As String
    Dim tblname As String
    Dim uniqGrade As String
    Dim totscr As Integer = 0
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        fst = If(Session("empl code") IsNot Nothing, Session("empl code").ToString(), String.Empty)
        sec = If(Session("form empid") IsNot Nothing, Session("form empid").ToString(), String.Empty)

        Try
            If Session("access power") = "" Then
                Response.Redirect("login.aspx")
            End If
            If Session("access power") = "3" Then
                outerimgdiv.Visible = True
            Else
                outerimgdiv.Visible = False
            End If
            If Session("access power") IsNot Nothing AndAlso Session("access power").ToString() = "1" Then
                ch3.Style("display") = "block"
            Else
                ch3.Style("display") = "none"
            End If

            If IsPostBack Then
                If Session("year") = "" Then
                    eve()
                End If
            Else
                If Session("year") <> "" Then
                    insert.Visible = False
                    ch3.Enabled = True
                    ch1.Enabled = True
                    ch2.Enabled = True
                    print.Visible = True

                End If
                If Session("access power") = "2" Then
                    ch3.Enabled = False
                    ch1.Enabled = False
                    ch2.Enabled = True
                    print.Visible = False
                ElseIf Session("access power") = "4" Then
                    ch3.Enabled = False
                    ch1.Enabled = True
                    ch2.Enabled = False
                    print.Visible = False
                Else
                    If Session("access power") = "3" Then
                        ch3.Enabled = True
                        ch1.Enabled = False
                        ch2.Enabled = False
                        print.Visible = False
                        Time.Text = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")
                    End If
                End If

            End If
            Dim dtt As DataTable = PMSclass.Loadfirst(fst, sec)
            If dtt IsNot Nothing AndAlso dtt.Rows.Count > 0 Then
                lblEmployeeCode.Text = Convert.ToString(dtt.Rows(0)("EmployeeCode"))
                lblEmpName.Text = Convert.ToString(dtt.Rows(0)("EmployeeName"))
                lblDesignation.Text = Convert.ToString(dtt.Rows(0)("Designation"))

                Dim dept As String = Convert.ToString(dtt.Rows(0)("Department"))
                Dim sect As String = Convert.ToString(dtt.Rows(0)("Section"))
                lblJoinDate.Text = Convert.ToString(dtt.Rows(0)("DOJ"))
                'qual.InnerText = Convert.ToString(dtt.Rows(0)("Qualification"))
                'prev.InnerText = Convert.ToString(dtt.Rows(0)("PreviousExperience"))
                lblReviewer.Text = Convert.ToString(dtt.Rows(0)("ReportingPersonName"))
                uniqGrade = Convert.ToString(dtt.Rows(0)("Grade"))
                lblGrade.Text = uniqGrade
                Session("uniqGrade") = uniqGrade
                lblDeptSection.Text = dept + "/" + sect
                Dim revperiod As String = Convert.ToString(dtt.Rows(0)("Review_Period"))
                revperiod = revperiod.Trim()
                ' lblReviewPeriod.Text = revperiod
                Dim dt As String
                If revperiod = "Training" Then
                    'trai.Checked = "true"
                    'prob.Checked = "false"
                    'conf.Checked = "false"
                    'Dim mont As Integer = DateTime.Now.AddMonths(-1).ToString("MM")
                    'If mont <= "12" Then
                    '    Month.Checked = True
                    'End If
                ElseIf revperiod = "Probation" Then
                    'prob.Checked = "true"
                    'trai.Checked = "false"
                    'conf.Checked = "false"
                    'Dim mont As Integer = DateTime.Now.AddMonths(-1).ToString("MM")
                    'If mont <= "12" Then
                    '    Month.Checked = True
                    'End If
                ElseIf revperiod = "Confirm" Then
                    If Session("year") <> "" Then
                        Dim str As String = Session("year")
                        Dim f As String = str.Substring(0, 2)
                        If f = "Ma" Then
                            dt = "03"
                        ElseIf f = "Ju" Then
                            dt = "06"
                        ElseIf f = "Se" Then
                            dt = "09"
                        ElseIf f = "De" Then
                            dt = "12"
                        End If
                    Else
                        Dim mont As Integer = DateTime.Now.AddMonths(-1).ToString("MM")
                        dt = DateTime.Now.AddMonths(-1).ToString("MM")
                    End If

                    If dt = "03" Then
                        q1.Checked = True
                    ElseIf dt = "06" Then
                        q2.Checked = True
                    ElseIf dt = "09" Then
                        q3.Checked = True
                    ElseIf dt = "12" Then
                        q4.Checked = True
                    End If
                Else
                    Response.Write("<script>alert('Your detail not insereted');</script>")

                End If
            End If
            '   Dim mon As String = DateTime.Now.Month
            mon = DateTime.Now.AddMonths(-1).ToString("MMM")
            Dim yea As String = DateTime.Now.Year
            tyear = DateTime.Now.ToString("yy")
            If mon = "Dec" Then
                yea = DateTime.Now.AddYears(-1).ToString("yyyy")
                tyear = DateTime.Now.AddYears(-1).ToString("yy")
            End If

            If Session("year") <> "" Then
                tyear = Session("year")
                Dim lastTwoNumbers As String = tyear.Substring(tyear.Length - 2)
                yea = $"20{lastTwoNumbers}"
            Else
                tyear = mon + "-" + tyear
            End If
            tot = yea
            tot = "[dbo]" + ". " + "[" + tot + "]"
            tblname = tot
            Dim dt1 As DataTable = PMSclass.Loadsecond(fst, sec, tot, tyear)
            If dt1 IsNot Nothing AndAlso dt1.Rows.Count > 0 Then

                Dim deptsi As String = Convert.ToString(dt1.Rows(0)("Dept_Accept"))
                Dim sectsi As String = Convert.ToString(dt1.Rows(0)("Sect_Accept"))
                Dim empsi As String = Convert.ToString(dt1.Rows(0)("Emp_Accept"))
                Dim sign As String = Convert.ToString(dt1.Rows(0)("time"))
                Dim totlmrk = Convert.ToString(dt1.Rows(0)("TotalMarks"))

                Dim remrks = Convert.ToString(dt1.Rows(0)("Remark"))
                    If overallcomments.Text = "" Then
                        overallcomments.Text = remrks
                    End If

                    finlamnt.InnerText = totlmrk



                ' Dim Plheadaccept As String = Convert.ToString(dt1.Rows(0)("Plheadaccept"))
                'If Plheadaccept = "Done" Then
                '    ch4.Checked = True
                'End If
                If deptsi = "Done" Then
                    ch1.Checked = True

                End If
                If Session("access power") IsNot Nothing AndAlso Session("access power").ToString() = "1" AndAlso empsi = "DONE" Or empsi = "Done" Then

                    lblEmpsign.InnerText = Convert.ToString(dt1.Rows(0)("EmployeeName"))
                    lblEmpDate.InnerText = Convert.ToString(dt1.Rows(0)("time"))

                    ch3.Style("display") = "none"
                Else
                    lblEmpsign.Visible = False
                    lblEmpDate.Visible = False
                End If

                If sectsi = "Done" Then
                    ch2.Checked = True
                End If
                If Session("access power") <> "3" Then
                    If empsi = "Done" Then
                        ch3.Checked = True
                        Time.Text = sign
                    Else
                        If Session("access power") <> "2" And Session("access power") <> "4" Then
                            Time.Text = "The employee has not signed yet."
                            Time.ForeColor = System.Drawing.Color.Red
                        End If

                    End If
                End If



            End If
            ' Dim ReSalesdt As DataTable = PMSclass.LoadReSales(fst, tyear)


            Dim yearOnly As String = tyear.Split("-"c)(1)
            Dim ReSalesdt As DataTable = PMSclass.LoadReSales(fst, yearOnly)


            If ReSalesdt IsNot Nothing Then
                Dim monthMap As New Dictionary(Of String, String) From {
        {"Jan", "Jan<br>一月"}, {"Feb", "Feb<br>二月"}, {"Mar", "Mar<br>三月"},
        {"Apr", "Apr<br>四月"}, {"May", "May<br>五月"}, {"Jun", "Jun<br>六月"},
        {"Jul", "Jul<br>七月"}, {"Aug", "Aug<br>八月"}, {"Sep", "Sep<br>九月"},
        {"Oct", "Oct<br>十月"}, {"Nov", "Nov<br>十一月"}, {"Dec", "Dec<br>十二月"}
    }

                Dim quarters As New Dictionary(Of String, List(Of String)) From {
        {"Q1", New List(Of String) From {"Jan", "Feb", "Mar"}},
        {"Q2", New List(Of String) From {"Apr", "May", "Jun"}},
        {"Q3", New List(Of String) From {"Jul", "Aug", "Sep"}},
        {"Q4", New List(Of String) From {"Oct", "Nov", "Dec"}}
    }

                Dim htmlBuilder As New StringBuilder()

                Dim yearTotalTeamMembers As Decimal = 0D
                Dim yearTotalTW_Value As Decimal = 0D
                Dim yearTotalIndian_Value As Decimal = 0D
                Dim yearavarage_Value As Decimal = 0D
                Dim yearTotalPlan_Percentage As Decimal = 0D
                Dim yearTotalExpect_Percentage As Decimal = 0D
                Dim yearTotalExpect_Tires As Decimal = 0D
                Dim yearTotalActual_Value As Decimal = 0D
                Dim yearTotalAchivement_Value As Decimal = 0D
                Dim yearTotalExtraTires As Decimal = 0D
                Dim yearTotalRate As Decimal = 0D
                Dim yearTotalPieceRateAmount As Decimal = 0D
                Dim yearTotalVariablepay As Decimal = 0D
                Dim yearTotalResultScore As Double = 0D
                Dim yearTotalCoefficient As Double = 0D
                Dim yearFinalAmtVP As Decimal = 0D
                Dim yearValidCount As Integer = 0
                Dim yearscoreAverage As Integer = 0
                For Each quarter In quarters
                    Dim quarterName As String = quarter.Key
                    Dim months As List(Of String) = quarter.Value
                    Dim isFirstRow As Boolean = True

                    ' Reset accumulators per quarter
                    Dim totalTeamMembers As Decimal = 0D
                    Dim totalTW_Value As Decimal = 0D
                    Dim totalIndian_Value As Decimal = 0D
                    Dim totalPlan_Percentage As Decimal = 0D
                    Dim totalExpect_Percentage As Decimal = 0D
                    Dim totalExpect_Tires As Decimal = 0D
                    Dim totalActual_Value As Decimal = 0D
                    Dim totalRate As Decimal = 0D
                    Dim totalPieceRateAmount As Decimal = 0D
                    Dim coefficient As Double = 0
                    Dim validCount As Integer = 0
                    Dim totalVariablepay As Decimal = 0D
                    Dim totalResultScore As Double = 0D




                    For Each monthAbbr In months
                        Dim matchedRow As DataRow = ReSalesdt.AsEnumerable().
                FirstOrDefault(Function(r) r.Field(Of String)("Months").StartsWith(monthAbbr))


                        htmlBuilder.Append("<tr>")
                        If isFirstRow Then
                            htmlBuilder.Append("<td rowspan='" & months.Count & "'>" & quarterName & "</td>")
                            isFirstRow = False
                        End If

                        Dim monthDisplay As String = If(monthMap.ContainsKey(monthAbbr), monthMap(monthAbbr), monthAbbr)
                        htmlBuilder.Append("<td>" & monthDisplay & "</td>")

                        ' Extract and accumulate safely
                        If matchedRow IsNot Nothing Then
                            validCount += 1

                            totalTeamMembers += SafeDecimal(matchedRow("TeamMembers"))
                            totalTW_Value += SafeDecimal(matchedRow("TW_Value"))
                            totalIndian_Value += SafeDecimal(matchedRow("Indian_Value"))
                            totalPlan_Percentage += SafeDecimal(matchedRow("Plan_Percentage"))
                            totalExpect_Percentage += SafeDecimal(matchedRow("Expect_Percentage"))
                            totalExpect_Tires += SafeDecimal(matchedRow("Expect_Tires"))
                            totalActual_Value += SafeDecimal(matchedRow("Actual_Value"))
                            totalRate += SafeDecimal(matchedRow("Rate"))
                            totalPieceRateAmount += SafeDecimal(matchedRow("PieceRateAmount"))
                        End If

                        Dim pieceRatePlusVP As Decimal = 0D

                        If matchedRow IsNot Nothing Then
                            Dim pieceRateAmount As Decimal = SafeDecimal(matchedRow("PieceRateAmount"))
                            Dim variablePay As Decimal = SafeDecimal(matchedRow("VariablePay"))
                            pieceRatePlusVP = pieceRateAmount + variablePay
                        End If
                        'Dim t9 As Double
                        'Double.TryParse(SafeValue(matchedRow, "Expect_Percentage"), t9)

                        'Dim n9 As Double
                        'Double.TryParse(SafeValue(matchedRow, "Achievement_Percentage"), n9)

                        'Dim result As Double = 0

                        'Dim diffPercent As Double = (t9 - n9) / n9

                        'If t9 = n9 And t9 <> 0 And n9 <> 0 Then
                        '    result = 76
                        'ElseIf diffPercent >= 0.001 AndAlso diffPercent < 0.05 Then
                        '    result = 77.2
                        'ElseIf diffPercent >= 0.05 AndAlso diffPercent < 0.1 Then
                        '    result = 78.4
                        'ElseIf diffPercent >= 0.1 AndAlso diffPercent < 0.15 Then
                        '    result = 79.6
                        'ElseIf diffPercent >= 0.15 AndAlso diffPercent < 0.2 Then
                        '    result = 80.8
                        'ElseIf diffPercent >= 0.2 AndAlso diffPercent < 0.25 Then
                        '    result = 82
                        'ElseIf diffPercent >= 0.25 AndAlso diffPercent < 0.3 Then
                        '    result = 83.2
                        'ElseIf diffPercent >= 0.3 AndAlso diffPercent < 0.35 Then
                        '    result = 84.4
                        'ElseIf diffPercent >= 0.35 AndAlso diffPercent < 0.4 Then
                        '    result = 85.6
                        'ElseIf diffPercent >= 0.4 AndAlso diffPercent < 0.45 Then
                        '    result = 86.8
                        'ElseIf diffPercent >= 0.45 AndAlso diffPercent < 0.5 Then
                        '    result = 88
                        'ElseIf diffPercent >= 0.5 AndAlso diffPercent < 0.55 Then
                        '    result = 89.2
                        'ElseIf diffPercent >= 0.55 AndAlso diffPercent < 0.6 Then
                        '    result = 90.4
                        'ElseIf diffPercent >= 0.6 AndAlso diffPercent < 0.65 Then
                        '    result = 91.6
                        'ElseIf diffPercent >= 0.65 AndAlso diffPercent < 0.7 Then
                        '    result = 92.8
                        'ElseIf diffPercent >= 0.7 AndAlso diffPercent < 0.75 Then
                        '    result = 94
                        'ElseIf diffPercent >= 0.75 AndAlso diffPercent < 0.8 Then
                        '    result = 95.2
                        'ElseIf diffPercent >= 0.8 AndAlso diffPercent < 0.85 Then
                        '    result = 96.4
                        'ElseIf diffPercent >= 0.85 AndAlso diffPercent < 0.9 Then
                        '    result = 97.6
                        'ElseIf diffPercent >= 0.9 AndAlso diffPercent < 0.95 Then
                        '    result = 98.8
                        'ElseIf diffPercent >= 0.95 Then
                        '    result = 100
                        'ElseIf diffPercent <= 0 AndAlso diffPercent > -0.05 Then
                        '    result = 75
                        'ElseIf diffPercent <= -0.05 AndAlso diffPercent > -0.1 Then
                        '    result = 74
                        'ElseIf diffPercent <= -0.1 AndAlso diffPercent > -0.15 Then
                        '    result = 72
                        'ElseIf diffPercent <= -0.15 AndAlso diffPercent > -0.2 Then
                        '    result = 71
                        'ElseIf diffPercent <= -0.2 AndAlso diffPercent > -0.25 Then
                        '    result = 70
                        'ElseIf diffPercent <= -0.25 AndAlso diffPercent > -0.3 Then
                        '    result = 69
                        'ElseIf diffPercent <= -0.3 AndAlso diffPercent > -0.35 Then
                        '    result = 68
                        'ElseIf diffPercent <= -0.35 AndAlso diffPercent > -0.4 Then
                        '    result = 66
                        'Else
                        '    result = 0
                        'End If
                        Dim Expect_Percentage As Double
                        Double.TryParse(SafeValue(matchedRow, "Expect_Percentage"), Expect_Percentage)

                        Dim Achievement_Percentage As Double
                        Double.TryParse(SafeValue(matchedRow, "Achievement_Percentage"), Achievement_Percentage)

                        Dim TW_Value As Double
                        Double.TryParse(SafeValue(matchedRow, "TW_Value"), TW_Value)
                        Dim Indian_Value As Double
                        Double.TryParse(SafeValue(matchedRow, "Indian_Value"), Indian_Value)

                        Dim result As Double = 0

                        If TW_Value = 0 OrElse Indian_Value = 0 Then
                            result = 0
                        ElseIf Achievement_Percentage = Expect_Percentage Then
                            result = 76
                        ElseIf Achievement_Percentage > Expect_Percentage Then
                            Dim diffPercent As Double = (Achievement_Percentage - Expect_Percentage) / Expect_Percentage * 100
                            diffPercent = Int(diffPercent)
                            If diffPercent >= 0.1 AndAlso diffPercent <= 5 Then
                                result = 77.2
                            ElseIf diffPercent > 5 AndAlso diffPercent <= 10 Then
                                result = 78.4
                            ElseIf diffPercent > 10 AndAlso diffPercent <= 15 Then
                                result = 79.6
                            ElseIf diffPercent > 15 AndAlso diffPercent <= 20 Then
                                result = 80.8
                            ElseIf diffPercent > 20 AndAlso diffPercent <= 25 Then
                                result = 82
                            ElseIf diffPercent > 25 AndAlso diffPercent <= 30 Then
                                result = 83.2
                            ElseIf diffPercent > 30 AndAlso diffPercent <= 35 Then
                                result = 84.4
                            ElseIf diffPercent > 35 AndAlso diffPercent <= 40 Then
                                result = 85.6
                            ElseIf diffPercent > 40 AndAlso diffPercent <= 45 Then
                                result = 86.8
                            ElseIf diffPercent > 45 AndAlso diffPercent <= 50 Then
                                result = 88
                            ElseIf diffPercent > 50 AndAlso diffPercent <= 55 Then
                                result = 89.2
                            ElseIf diffPercent > 55 AndAlso diffPercent <= 60 Then
                                result = 90.4
                            ElseIf diffPercent > 60 AndAlso diffPercent <= 65 Then
                                result = 91.6
                            ElseIf diffPercent > 65 AndAlso diffPercent <= 70 Then
                                result = 92.8
                            ElseIf diffPercent > 70 AndAlso diffPercent <= 75 Then
                                result = 94
                            ElseIf diffPercent > 75 AndAlso diffPercent <= 80 Then
                                result = 95.2
                            ElseIf diffPercent > 80 AndAlso diffPercent <= 85 Then
                                result = 96.4
                            ElseIf diffPercent > 85 AndAlso diffPercent <= 90 Then
                                result = 97.6
                            ElseIf diffPercent > 90 AndAlso diffPercent <= 95 Then
                                result = 98.8
                            ElseIf diffPercent > 95 Then ' Covers 95-100% and above
                                result = 100
                            End If
                        Else ' Achievement_Percentage < Expect_Percentage
                            Dim diffPercent As Double = (Expect_Percentage - Achievement_Percentage) / Expect_Percentage * 100
                            diffPercent = Int(diffPercent)
                            If diffPercent <= 5 Then
                                result = 75
                            ElseIf diffPercent > 5 AndAlso diffPercent <= 10 Then
                                result = 74
                            ElseIf diffPercent > 10 AndAlso diffPercent <= 15 Then
                                result = 72
                            ElseIf diffPercent > 15 AndAlso diffPercent <= 20 Then
                                result = 71
                            ElseIf diffPercent > 20 AndAlso diffPercent <= 25 Then
                                result = 70
                            ElseIf diffPercent > 25 AndAlso diffPercent <= 30 Then
                                result = 69
                            ElseIf diffPercent > 30 AndAlso diffPercent <= 35 Then
                                result = 68
                            ElseIf diffPercent > 35 AndAlso diffPercent <= 40 Then
                                result = 66
                            End If
                        End If
                        If result <> 0 Then
                            finlamnt.InnerText = Convert.ToInt32(result)
                        End If
                        totalResultScore += result




                        Dim T12 As Double
                        Double.TryParse(SafeValue(matchedRow, "Achievement_Percentage"), T12)

                        ' N12 = Expect_Percentage
                        Dim N12 As Double
                        Double.TryParse(SafeValue(matchedRow, "Expect_Percentage"), N12)
                        coefficient = CalculateValue(T12, N12)
                        Dim txtcon As Double
                        Double.TryParse(SafeValue(matchedRow, "VariablePay"), txtcon)

                        totalVariablepay += txtcon

                        ' Output data row
                        htmlBuilder.Append("<td>" & SafeValue(matchedRow, "TeamMembers") & "</td>")
                        htmlBuilder.Append("<td>" & SafeValue(matchedRow, "TW_Value") & "</td>")
                        htmlBuilder.Append("<td>" & SafeValue(matchedRow, "Indian_Value") & "</td>")
                        htmlBuilder.Append("<td>" & SafeValue(matchedRow, "Average_Value") & "</td>")
                        htmlBuilder.Append("<td>" & SafeValue(matchedRow, "Plan_Percentage") & "</td>")
                        htmlBuilder.Append("<td>" & SafeValue(matchedRow, "Expect_Percentage") & "</td>")
                        htmlBuilder.Append("<td>" & SafeValue(matchedRow, "Expect_Tires") & "</td>")
                        htmlBuilder.Append("<td>" & SafeValue(matchedRow, "Actual_Value") & "</td>")
                        htmlBuilder.Append("<td>" & SafeValue(matchedRow, "Achievement_Percentage") & "</td>")
                        htmlBuilder.Append("<td>" & SafeValue(matchedRow, "Extra_Tires") & "</td>")
                        htmlBuilder.Append("<td>" & SafeValue(matchedRow, "Rate") & "</td>")
                        htmlBuilder.Append("<td>" & SafeValue(matchedRow, "PieceRateAmount") & "</td>")
                        htmlBuilder.Append("<td>" & SafeValue(matchedRow, "VariablePay") & "</td>")


                        htmlBuilder.Append("<td>-</td>")
                        htmlBuilder.Append("<td class='highlight-yellow'>" & pieceRatePlusVP & "</td>")
                        htmlBuilder.Append("<td class='highlight-yellow'>" & result & "</td>")
                        htmlBuilder.Append("</tr>")
                    Next

                    ' Calculated Averages
                    Dim avgTeamMembers = If(validCount > 0, totalTeamMembers / validCount, 0)
                    Dim avgExpect_Percentage = If(validCount > 0, totalExpect_Percentage / validCount, 0)
                    Dim monthCount As Integer = months.Count
                    Dim avgExpect_Percentage1 = If(monthCount > 0, totalExpect_Percentage / monthCount, 0)

                    Dim avgExpect_Tires = If(validCount > 0, totalExpect_Tires / validCount, 0)


                    Dim AchivementPersentage As Decimal = 0
                    If totalPlan_Percentage <> 0 Then
                        AchivementPersentage = totalActual_Value / totalPlan_Percentage
                    End If
                    AchivementPersentage = Math.Round(AchivementPersentage, 2)

                    Dim TotalExtraTires As Decimal = totalActual_Value - totalExpect_Tires
                    TotalExtraTires = Math.Round(TotalExtraTires, 2)

                    Dim averageOfSums As Decimal = 0D
                    If totalTW_Value + totalIndian_Value <> 0 Then
                        averageOfSums = (totalTW_Value + totalIndian_Value) / 2
                    End If
                    Dim finalamtVP = totalVariablepay * coefficient
                    Dim scoreAverage As Double = If(validCount > 0, Math.Round(totalResultScore / validCount, 2), 0)

                    htmlBuilder.Append("<tr class='bold'>")
                    htmlBuilder.Append("<td colspan='2'>Q. incentive<br>Q. 激励</td>")
                    htmlBuilder.Append("<td class='highlight-yellow'>" & Math.Round(avgTeamMembers, 2) & "</td>")
                    htmlBuilder.Append("<td class='highlight-yellow'>" & totalTW_Value & "</td>")
                    htmlBuilder.Append("<td class='highlight-yellow'>" & totalIndian_Value & "</td>")
                    htmlBuilder.Append("<td class='highlight-yellow'>" & averageOfSums & "</td>")
                    htmlBuilder.Append("<td class='highlight-yellow'>" & totalPlan_Percentage & "</td>")
                    htmlBuilder.Append("<td class='highlight-yellow'>" & Math.Round(avgExpect_Percentage, 2) & "</td>")
                    htmlBuilder.Append("<td class='highlight-yellow'>" & totalExpect_Tires & "</td>")
                    htmlBuilder.Append("<td class='highlight-yellow'>" & totalActual_Value & "</td>")
                    htmlBuilder.Append("<td class='highlight-yellow'>" & AchivementPersentage & "</td>")
                    htmlBuilder.Append("<td class='highlight-yellow'>" & TotalExtraTires & "</td>")
                    htmlBuilder.Append("<td class='highlight-yellow'>" & totalRate & "</td>")
                    htmlBuilder.Append("<td class='highlight-yellow'>" & totalPieceRateAmount & "</td>")
                    htmlBuilder.Append("<td class='highlight-yellow'>" & totalVariablepay & "</td>")
                    htmlBuilder.Append("<td class='highlight-yellow'>" & coefficient & "</td>")
                    htmlBuilder.Append("<td class='highlight-yellow'>" & finalamtVP & "</td>")
                    htmlBuilder.Append("<td class='highlight-yellow'>" & scoreAverage & "</td>")
                    htmlBuilder.Append("</tr>")


                    ' Accumulate totals
                    yearTotalTeamMembers += totalTeamMembers
                    yearTotalTW_Value += totalTW_Value
                    yearTotalIndian_Value += totalIndian_Value
                    yearavarage_Value += averageOfSums
                    yearTotalPlan_Percentage += totalPlan_Percentage
                    yearTotalExpect_Percentage += totalExpect_Percentage
                    yearTotalExpect_Tires += totalExpect_Tires
                    yearTotalActual_Value += totalActual_Value
                    yearTotalAchivement_Value += AchivementPersentage
                    yearTotalExtraTires += TotalExtraTires
                    yearTotalRate += totalRate
                    yearTotalPieceRateAmount += totalPieceRateAmount
                    yearTotalVariablepay += totalVariablepay
                    yearTotalResultScore += totalResultScore
                    yearTotalCoefficient += coefficient
                    yearFinalAmtVP += finalamtVP
                    yearscoreAverage += scoreAverage ' If this is a sum, this is fine.
                    Dim totlVp = yearTotalVariablepay * yearTotalCoefficient
                    ' Set summed values to HTML table cells
                    tdTeamMembers.InnerText = yearTotalTeamMembers.ToString()
                    tdTW_Value.InnerText = yearTotalTW_Value.ToString("N2")
                    tdIndian_Value.InnerText = yearTotalIndian_Value.ToString("N2")
                    tdyearavarage_Value.InnerText = yearavarage_Value.ToString("N2")
                    tdPlan_Percentage.InnerText = yearTotalPlan_Percentage.ToString("N2") ' Show as number, not percentage
                    tdExpect_Percentage.InnerText = yearTotalExpect_Percentage.ToString("N2") ' Show as number
                    tdExpect_Tires.InnerText = yearTotalExpect_Tires.ToString()
                    tdActual_Value.InnerText = yearTotalActual_Value.ToString("N2")
                    tdAchivement_Value.InnerText = yearTotalAchivement_Value.ToString("N2")
                    tdyearTotalExtraTires.InnerText = yearTotalExtraTires.ToString("N2")
                    tdRate.InnerText = yearTotalRate.ToString("N2")
                    tdPieceRateAmount.InnerText = yearTotalPieceRateAmount.ToString("N2")
                    tdVariablepay.InnerText = yearTotalVariablepay.ToString("N2")
                    tdCoefficient.InnerText = yearTotalCoefficient.ToString("N2")
                    tdyearscoreAverage.InnerText = yearscoreAverage.ToString("N2")

                    tdFinalAmtVP.InnerText = totlVp.ToString("N2")



                Next

                placeholderTable.InnerHtml = htmlBuilder.ToString()
            End If



        Catch ex As Exception
            Response.Write("<script language='javascript'>alert('" + Server.HtmlEncode(ex.Message) + "')</script>")

        End Try
    End Sub
    Function CalculateValue(T12 As Double, N12 As Double) As Double
        Dim diffPercent As Double = ((T12 - N12) / N12) * 100

        If T12 = N12 And T12 <> 0 And N12 <> 0 Then
            Return 1
        ElseIf T12 > N12 Then
            If diffPercent >= 0.1 AndAlso diffPercent <= 5 Then
                Return 1
            ElseIf diffPercent > 5 AndAlso diffPercent <= 10 Then
                Return 1
            ElseIf diffPercent > 10 AndAlso diffPercent <= 15 Then
                Return 1
            ElseIf diffPercent > 15 AndAlso diffPercent <= 40 Then
                Return 1.1
            ElseIf diffPercent > 40 AndAlso diffPercent <= 70 Then
                Return 1.2
            ElseIf diffPercent > 70 Then
                Return 1.3
            End If
        ElseIf T12 < N12 Then
            If diffPercent >= -5 Then
                Return 0.96
            ElseIf diffPercent > -20 Then
                Return 0.96
            ElseIf diffPercent > -30 Then
                Return 0.8
            ElseIf diffPercent > -40 Then
                Return 0.7
            Else
                Return 0
            End If
        End If

        Return 0 ' default fallback
    End Function

    Private Function SafeDecimal(value As Object) As Decimal
        Dim result As Decimal = 0
        If value IsNot Nothing AndAlso Decimal.TryParse(value.ToString(), result) Then
            Return result
        End If
        Return 0
    End Function

    Private Function SafeValue(row As DataRow, columnName As String) As String
        If row IsNot Nothing AndAlso row.Table.Columns.Contains(columnName) Then
            Dim val As Object = row(columnName)
            Return If(val IsNot DBNull.Value, Server.HtmlEncode(val.ToString()), "-")
        End If
        Return "-"
    End Function

    Public Sub eve()

        mon = DateTime.Now.AddMonths(-1).ToString("MMM")

        Dim yea As String = DateTime.Now.Year
        tyear = DateTime.Now.ToString("yy")
        If mon = "Dec" Then
            yea = DateTime.Now.AddYears(-1).ToString("yyyy")
            tyear = DateTime.Now.AddYears(-1).ToString("yy")
        End If


        tyear = mon + "-" + tyear
        tot = yea
        tot = "[dbo]" + ". " + "[" + tot + "]"

        Dim dt1 As DataTable = PMSclass.Loadsecond(fst, sec, tot, tyear)
        If dt1 IsNot Nothing AndAlso dt1.Rows.Count > 0 Then

            Dim deptsi As String = Convert.ToString(dt1.Rows(0)("Dept_Accept"))
            Dim sectsi As String = Convert.ToString(dt1.Rows(0)("Sect_Accept"))
            Dim Plheadaccept As String = Convert.ToString(dt1.Rows(0)("Plheadaccept"))
            'If Plheadaccept = "Done" Then
            '    ch4.Checked = True
            'End If
            If deptsi = "Done" Then
                ch1.Checked = True
            End If
            If sectsi = "Done" Then
                ch2.Checked = True
            End If
            If deptsi = "Done" Or sectsi = "Done" Then

                Dim stat As String = Convert.ToString(dt1.Rows(0)("Status"))
                If stat = "Pass" Then
                    'Good.Checked = True
                ElseIf stat = "Extend" Then
                    'Average.Checked = True
                ElseIf stat = "Fail" Then
                    'Fail.Checked = True
                End If
                'remark.Text = Convert.ToString(dt1.Rows(0)("Remark"))
            End If
        End If
    End Sub
    Protected Sub insert_Click(sender As Object, e As EventArgs) Handles insert.Click

        If Not ch1.Checked AndAlso Not ch2.Checked Then
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "AlertMessage", "alert('Please check either Department Head or Section Head before submitting.');", True)
            Exit Sub
        End If

        mon = DateTime.Now.AddMonths(-1).ToString("MMM")

        Dim yea As String = DateTime.Now.Year
        tyear = DateTime.Now.ToString("yy")
        If mon = "Dec" Then
            yea = DateTime.Now.AddYears(-1).ToString("yyyy")
            tyear = DateTime.Now.AddYears(-1).ToString("yy")
        End If


        tyear = mon + "-" + tyear
        tot = yea
        tot = "[dbo]" + ". " + "[" + tot + "]"

        Dim status As String = ""
        Dim emp As String = ""


        Dim deptaccept As String = ""
        Dim sectaccept As String = ""
        If ch3.Checked = True Then
            emp = "Done"
        End If
        If ch1.Checked = True Then
            deptaccept = "Done"
            ch2.Checked = True
        End If
        If ch2.Checked AndAlso Session("uniqGrade") IsNot Nothing AndAlso {"E-3", "E-4", "E-5", "T-1", "T-2", "T-3", "T-4", "T-5", "T-6"}.Contains(Session("uniqGrade").ToString()) Then
            sectaccept = "Done"
            ch1.Checked = True
            deptaccept = "Done"
            status = "DONE"
        End If
        If ch2.Checked = True Then
            sectaccept = "Done"
            status = "PENDING"
        End If
        If status Is Nothing Then
            status = "PENDING"
        End If

        If ch2.Checked = True And ch1.Checked = True Then
            status = "DONE"
        End If

        Dim currentDateTime As DateTime = DateTime.Now
        Dim remrkdata = overallcomments.Text
        Dim totscrRounded As Integer = Convert.ToInt32(Math.Round(Convert.ToDecimal(finlamnt.InnerText)))
        strsql = $" update {tot} set Sect_Accept='{sectaccept}',Emp_Accept='{emp}',Dept_Accept='{deptaccept}',Form_ID='92',Form_Status='{status}',Remark='{remrkdata}',TotalMarks='{totscrRounded}',time='{currentDateTime}'  where EmployeeCode='{Session("empl code")}' and ReviewMonth='{tyear}' "
        If sqlexe(constr, strsql) Then

            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Messagebox", "alert('Data Entered successfully');window.close()", True)
        End If
        If Session("access power") = "3" Then
            Response.Redirect("View_Details.aspx")
        Else
            Response.Redirect("Employee_Details.aspx")
        End If
    End Sub

    Protected Sub ch3_CheckedChanged(sender As Object, e As EventArgs) Handles ch3.CheckedChanged
        Dim empcode As String = CType(Session("form empid"), String)
        Dim empmonth As String = tyear
        Dim picnames As String = empcode & "_" & DateTime.Now.ToString("MM-yyyy")

        ' Construct the file path
        Dim filePath As String = HttpContext.Current.Server.MapPath(String.Format("~/Captures/{0}.jpg", picnames))
        If File.Exists(filePath) Then
            strsql = "update" + " " + tot + " " + "Set Emp_Accept='Done',time  = '" & Time.Text & "',SignPic = '" & picnames & "' where EmployeeCode='" & Session("form empid") & "' and ReviewMonth='" & tyear & "'"
        Else
            strsql = "update" + " " + tot + " " + "Set Emp_Accept='Done',time  = '" & Time.Text & "' where EmployeeCode='" & Session("form empid") & "' and ReviewMonth='" & tyear & "'"
        End If

        If sqlexe(constr, strsql) Then
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Messagebox", "alert('Submitted successfully');", True)
        End If
        If Session("access power") = "3" Then
            Response.Redirect("View_Details.aspx")
        Else
            Response.Redirect("Employee_Details.aspx")
        End If
    End Sub




    Protected Sub print_Click(sender As Object, e As EventArgs) Handles print.Click

    End Sub
End Class