<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site1.Master" CodeBehind="Reporting Person Detail.aspx.vb" Inherits="Performance_Management_System.WebForm9" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style3 {
            width: 79%;
            height: 432px;
            margin-left: 178px;
        }
        .auto-style11 {
            height: 54px;
        }
        .auto-style13 {
            width: 56%;
            margin-left: 250px;
        }
        .auto-style14 {
            width: 192px;
        }
        .auto-style15 {
            width: 111px;
        }
        .auto-style16 {
            width: 255px;
        }
        .auto-style17 {
            margin-left: 251px;
        }
        .auto-style18 {
            margin-top: 10px;
        }
        .auto-style19 {
            height: 44px;
        }
        .auto-style20 {
            margin-left: 272px;
        }
        .auto-style21 {
            width: 167px;
            height: 40px;
        }
        .auto-style22 {
            width: 333px;
            height: 40px;
        }
        .auto-style23 {
            width: 177px;
            height: 40px;
        }
        .auto-style24 {
            height: 40px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <table class="auto-style3" style="background-position: center; border-style: ridge; color: #000000; background-attachment: fixed; background-image: inherit; background-color: burlywood; " aria-hidden="True">
        <tr>
            <td colspan="4" style="font-size: x-large" class="auto-style11">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Reporting Person Detail&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style21">Employee Code</td>
            <td class="auto-style22">
                <asp:TextBox ID="empcode" runat="server" Width="145px" Height="30px" AutoPostBack="True"></asp:TextBox>
            &nbsp;&nbsp;
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="empcode" Display="None" ErrorMessage="Please enter employee code" ForeColor="Red" ValidationGroup="insert"></asp:RequiredFieldValidator>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            </td>
            <td class="auto-style23">Section</td>
            <td class="auto-style24">
                <asp:DropDownList ID="sect" runat="server" Width="145px" Height="30px">
                    <asp:ListItem>---Select---</asp:ListItem>
                </asp:DropDownList>
            &nbsp;
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="sect" Display="None" ErrorMessage="Please select section" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style21">Employee Name</td>
            <td class="auto-style22">
                <asp:TextBox ID="empname" runat="server" Width="145px" Height="30px"></asp:TextBox>
            &nbsp;&nbsp;
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="empname" Display="None" ErrorMessage="Please insert employee name" ForeColor="Red" ValidationGroup="insert"></asp:RequiredFieldValidator>
            </td>
            <td class="auto-style23">Date of Joining</td>
            <td class="auto-style24">
                <asp:TextBox ID="doj" runat="server" Width="145px" Height="30px"></asp:TextBox>
            &nbsp;
                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="doj" Display="None" ErrorMessage="Please enter date of joining" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style21">Designation</td>
            <td class="auto-style22">
                <asp:TextBox ID="desig" runat="server" Width="145px" Height="30px"></asp:TextBox>
            &nbsp;&nbsp;
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="desig" Display="None" ErrorMessage="Please enter designation" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
            <td class="auto-style23">Date Of Ending</td>
            <td class="auto-style24">
                <asp:TextBox ID="doe" runat="server" Width="145px" Height="30px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style21">Department</td>
            <td class="auto-style22">
                <asp:DropDownList ID="dept" runat="server" Width="145px" Height="30px">
                     <asp:ListItem Selected="True">---Select---</asp:ListItem>
                            <asp:ListItem>Administration</asp:ListItem>
                            <asp:ListItem>Civil</asp:ListItem>
                            <asp:ListItem>EHS</asp:ListItem>
                            <asp:ListItem>Finance</asp:ListItem>
                            <asp:ListItem>Human Resource</asp:ListItem>
                            <asp:ListItem>Institutional Sales</asp:ListItem>
                            <asp:ListItem>IT</asp:ListItem>
                            <asp:ListItem>Marketing</asp:ListItem>
                            <asp:ListItem>Planning</asp:ListItem>
                            <asp:ListItem>QA</asp:ListItem>
                            <asp:ListItem>Production</asp:ListItem>
                            <asp:ListItem>RD1</asp:ListItem>
                            <asp:ListItem>RD2</asp:ListItem>
                            <asp:ListItem>Retail Sales</asp:ListItem>
                            <asp:ListItem>Service</asp:ListItem>
                </asp:DropDownList>
            &nbsp;&nbsp;&nbsp;
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="dept" Display="None" ErrorMessage="Please select department" ForeColor="Red" ValidationGroup="insert"></asp:RequiredFieldValidator>
            </td>
            <td class="auto-style23">Status</td>
            <td class="auto-style24">
                <asp:TextBox ID="status" runat="server" Width="145px" Height="30px"></asp:TextBox>
                &nbsp;
                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="status" Display="None" ErrorMessage="Please enter status" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td colspan="4" class="auto-style19">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;
                <asp:Button ID="Button1" runat="server" Height="37px" Text="Submit" Width="120px" CssClass="auto-style18" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;</td>
        </tr>
    </table>
    <br />
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Label ID="Label13" runat="server" ForeColor="Red" Text="Label"></asp:Label>
&nbsp;<asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="auto-style17" ForeColor="Red" Width="608px" />
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <table class="auto-style13">
        <tr>
            <td colspan="4">&nbsp; Search Details&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style14">Department</td>
            <td class="auto-style16">
                <asp:DropDownList ID="department" runat="server" AutoPostBack="True">
                     <asp:ListItem Selected="True">---Select---</asp:ListItem>
                            <asp:ListItem>Administration</asp:ListItem>
                            <asp:ListItem>Civil</asp:ListItem>
                            <asp:ListItem>EHS</asp:ListItem>
                            <asp:ListItem>Finance</asp:ListItem>
                            <asp:ListItem>Human Resource</asp:ListItem>
                            <asp:ListItem>Institutional Sales</asp:ListItem>
                            <asp:ListItem>IT</asp:ListItem>
                            <asp:ListItem>Marketing</asp:ListItem>
                            <asp:ListItem>Planning</asp:ListItem>
                            <asp:ListItem>QA</asp:ListItem>
                            <asp:ListItem>Production</asp:ListItem>
                            <asp:ListItem>RD1</asp:ListItem>
                            <asp:ListItem>RD2</asp:ListItem>
                            <asp:ListItem>Retail Sales</asp:ListItem>
                            <asp:ListItem>Service</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td class="auto-style15">Section</td>
            <td>
                <asp:DropDownList ID="section" runat="server" AutoPostBack="True">
                    <asp:ListItem>---Select---</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="auto-style14">&nbsp;</td>
            <td class="auto-style16">&nbsp;</td>
            <td class="auto-style15">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>
    <br />
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <br />
    <br />
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" CssClass="auto-style20">
        <Columns>
            <asp:TemplateField HeaderText="Employee Code">
                <EditItemTemplate>
                     <asp:Label ID="empcode" runat="server" Text='<%# Bind("EmployeeCode") %>'></asp:Label>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("EmployeeCode") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Employee Name">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("EmployeeName") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("EmployeeName") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Designation">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("Designation") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label3" runat="server" Text='<%# Bind("Designation") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Department">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("Department") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label4" runat="server" Text='<%# Bind("Department") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Section">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("Section") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label5" runat="server" Text='<%# Bind("Section") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Date Of Joining">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox6" runat="server" Text='<%# Bind("DOJ") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label6" runat="server" Text='<%# Bind("DOJ") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Date Of Ending">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox7" runat="server" Text='<%# Bind("DOE") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label7" runat="server" Text='<%# Bind("DOE") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Status">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox8" runat="server" Text='<%# Bind("Status") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label8" runat="server" Text='<%# Bind("Status") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <FooterStyle BackColor="White" ForeColor="#000066" />
        <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
        <RowStyle ForeColor="#000066" />
        <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#F1F1F1" />
        <SortedAscendingHeaderStyle BackColor="#007DBB" />
        <SortedDescendingCellStyle BackColor="#CAC9C9" />
        <SortedDescendingHeaderStyle BackColor="#00547E" />
    </asp:GridView>
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
</asp:Content>
