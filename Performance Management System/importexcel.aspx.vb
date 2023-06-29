Imports Excel = Microsoft.Office.Interop.Excel
Imports System.Runtime.InteropServices.COMException
Imports System.IO
Imports System.Data.SqlClient
Imports System.Data
Imports System.Collections.Generic
Imports System.Configuration

Public Class WebForm4
    Inherits System.Web.UI.Page
    ' Dim strsql As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    'Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
    '    Dim ds As New DataSet()
    '    ds.ReadXml(Server.MapPath("~/Dhara.xml"))

    '    'Dim appXL As Microsoft.Office.Interop.Excel.Application
    '    'Dim wbXl As Microsoft.Office.Interop.Excel.Workbook
    '    'Dim shXL As Microsoft.Office.Interop.Excel.Worksheet
    '    'Dim raXL As Microsoft.Office.Interop.Excel.Range
    '    'Dim raXL2 As Microsoft.Office.Interop.Excel.Range


    '    'appXL = New Excel.Application
    '    'wbXl = appXL.Workbooks.Open("D:\Emp Document\Dhara Detail")
    '    'shXL = wbXl.Worksheets("sheet1")
    '    'raXL = shXL.UsedRange

    '    ''MsgBox(shXL.Cells(2, 1).value)
    '    ''MsgBox(shXL.Cells(2, 2).value)
    '    ''MsgBox(shXL.Cells(2, 3).value)
    '    ''MsgBox(shXL.Cells(2, 4).value)
    '    ''MsgBox(shXL.Cells(2, 5).value)



    '    'Dim i As Integer = 2
    '    'For Each row In raXL.Rows
    '    '    With shXL
    '    '        MsgBox(shXL.Cells(i, 1).Value)
    '    '        MsgBox(shXL.Cells(i, 2).Value)
    '    '        MsgBox(shXL.Cells(i, 3).Value)
    '    '        MsgBox(shXL.Cells(i, 4).Value)
    '    '        MsgBox(shXL.Cells(i, 5).Value)

    '    '    End With
    '    '    i = i + 1

    '    'Next row

    '    'raXL = shXL.Range("A2", "D5")
    '    'raXL.EntireColumn.AutoFit()
    '    'raXL2 = shXL.Range("A:A", System.Type.Missing)
    '    'raXL2.EntireColumn.ColumnWidth = 35


    '    'wbXl.Close()
    '    'appXL.Quit()

    '    'releaseObject(appXL)
    '    'releaseObject(wbXl)
    '    'releaseObject(shXL)
    'End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim ds As New DataSet()
        ds.ReadXml(Server.MapPath("~/Dhara.xml"))

        '    Dim appXL As Microsoft.Office.Interop.Excel.Application
        '    Dim wbXl As Microsoft.Office.Interop.Excel.Workbook
        '    Dim shXL As Microsoft.Office.Interop.Excel.Worksheet
        '    Dim raXL As Microsoft.Office.Interop.Excel.Range
        '    ' Dim raXL2 As Microsoft.Office.Interop.Excel.Range


        '    Dim rCnt As Integer
        '    Dim cCnt As Integer
        '    Dim Obj As Object

        '    appXL = New Excel.Application
        '    wbXl = appXL.Workbooks.Open("D:\Emp Document\Dhara Detail")
        '    shXL = wbXl.Worksheets("sheet1")
        '    Dim sql As String = "select * from sheet1"

        '    raXL = shXL.UsedRange

        '    For rCnt = 2 To raXL.Rows.Count - 1
        '        For cCnt = 1 To raXL.Columns.Count
        '            Obj = CType(raXL.Cells(rCnt, cCnt), Excel.Range)
        '            MsgBox(Obj.value)
        '        Next
        '    Next

        '    wbXl.Close()
        '    appXL.Quit()

        '    releaseObject(appXL)
        '    releaseObject(wbXl)
        '    releaseObject(shXL)

    End Sub
    Private Sub releaseObject(ByVal obj As Object)
        Try
            System.Runtime.InteropServices.Marshal.ReleaseComObject(obj)
            obj = Nothing
        Catch ex As Exception
            obj = Nothing
        Finally
            GC.Collect()
        End Try
    End Sub


End Class