<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site1.Master" CodeBehind="Summary.aspx.vb" Inherits="Performance_Management_System.Summary" EnableEventValidation="false" %>



<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <style>
        .tableStyle {
    font-family: Arial, sans-serif;
    border-collapse: collapse;
    width: 100%;
}

.tableStyle th, .tableStyle td {
    padding: 8px;
    text-align: center;

}

.tableStyle tr:nth-child(even) {
    background-color: #f2f2f2;
}

.tableStyle th {
    background-color: #4CAF50;
    color: white;
}

.tableStyle td {
    border: 1px solid #ddd;
}

    </style>

    <style>
       /* General reset and setup */
* {
    margin: 0;
    padding: 0;
    box-sizing: border-box;
}

/* Container for the heading, label, and cards */
.container {
    display: flex;
    flex-direction: column;
    align-items: center;
    gap: 20px;
}

/* Heading styling */
.heading {
    font-size: 32px;
    font-weight: bold;
    color: #333;
    text-shadow: 2px 2px 5px rgba(0, 0, 0, 0.2);
}

/* Count label styling */
.count-label {
    font-size: 24px;
    font-weight: 600;
    color: black;
    text-shadow: 1px 1px 4px rgba(0, 0, 0, 0.1);
}

/* Card container styling */
.card-container {
    display: flex;
    gap: 20px;
}

/* Individual card styling */
.card {
    width: 250px;
    height: 150px;
    border-radius: 8px;
    box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
    display: flex;
    justify-content: center;
    align-items: center;
    position: relative;
}

/* Colors for the cards */
.card-red {
    background-color:tomato;
}

.card-blue {
    background-color: cornflowerblue;
}

.card-green {
    background-color: greenyellow;
}

.card-yellow {
    background-color:cadetblue;
}

.card-purple {
    background-color: mediumpurple;
}

/* Label inside the card */
.card-label {
    font-size: 25px;
    font-weight: bold;
    color: black;
    text-shadow: 1px 1px 3px rgba(0, 0, 0, 0.5);
   
}

    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  

   
   


    <table style="width:100%">
        <tr>
            <td>
           
                <center>
                     <h3>Search Details</h3> <hr />
                <table>
                    <tr>
                        <td>
                             <div class="form-group">
                Department
                 <asp:DropDownList ID="department" runat="server" AutoPostBack="True" DataTextField="section_name" DataValueField="section_name"  CssClass="form-control" AppendDataBoundItems="True" >
                     <asp:ListItem Selected="True">All</asp:ListItem>
                </asp:DropDownList>
               </div>
                        </td>
                        <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
                        <td>
                            <div class="form-group">
                Section
                <asp:DropDownList ID="Sections" runat="server" AppendDataBoundItems="True" cssclass="form-control"  AutoPostBack="True" >
                    <asp:ListItem>All</asp:ListItem>
                </asp:DropDownList>
                </div>

                        </td>

                           <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
                          <td>
                              <div class="form-group">
           
                Year
                <asp:DropDownList ID="ddlYear" runat="server" AppendDataBoundItems="True" cssclass="form-control"  AutoPostBack="True" >
                    <asp:ListItem>All</asp:ListItem>
                </asp:DropDownList>
                </div>
                        </td>
                           <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
                         <td>
        
            <div class="form-group">
                Month
                <asp:DropDownList ID="month" runat="server" AppendDataBoundItems="True" cssclass="form-control"  AutoPostBack="True" >
                    <asp:ListItem>All</asp:ListItem>
                </asp:DropDownList>
                </div>
                        </td>
                    </tr>
                    
                   
                </table>
           
                </center>

            </td>
        </tr>

        <tr>
            <td>
               
   <div class="container">
    
        <div class="card-container">
          
            <div class="card card-red">
                <div class="card-label">Pending <br />
                    <br />
                    <center>
                    <asp:Label ID="Pending" runat="server" Text="Label"></asp:Label></center>
                </div>
            </div>
              <div class="card card-green">
                <div class="card-label">Done
                    <br />
                      <br /><center>
                    <asp:Label ID="done" runat="server" Text="Label"></asp:Label></center>
                </div>
            </div>
            <div class="card card-blue">
                <div class="card-label">Section Sign
                    <br />
                      <br /><center>
                    <asp:Label ID="section" runat="server" Text="Label"></asp:Label></center>
                </div>
            </div>
          
            <div class="card card-yellow">
                <div class="card-label">Department Sign
                    <br />
                    <br />
                    <center>
                    <asp:Label ID="deptment" runat="server" Text="Label"></asp:Label></center>
                </div>
            </div>
            <div class="card card-purple">
                <div class="card-label">Employee Sign
                    <br />
                      <br />
                    <center>
                    <asp:Label ID="employeee" runat="server" Text="Label"></asp:Label></center>
                </div>
            </div>
        </div>
    </div>
                <br />
                 <asp:Button ID="btnExport" runat="server" Text="Export to Excel" OnClick="btnExport_Click" style="background-color:#4CAF50"/>
            </td>
        </tr>
       <tr>
           <td>
               <asp:Panel ID="Panel1" runat="server" Height="600px" Width="100%" ScrollBars="Auto">
                   <br />
                   
    <asp:GridView ID="GridView2" runat="server" CssClass="tableStyle" GridLines="None" 
        BorderWidth="1px" BorderColor="#cccccc" Width="100%" AutoGenerateColumns="False" 
        OnRowCommand="GridView2_RowCommand">
        <Columns>
            <asp:BoundField DataField="Department" HeaderText="Department" SortExpression="Department" />
            <asp:BoundField DataField="Section" HeaderText="Section" SortExpression="Section" />
            <asp:BoundField DataField="Total" HeaderText="Total" SortExpression="Total" />
            <asp:BoundField DataField="Pending" HeaderText="Pending" SortExpression="Pending" />
            <asp:BoundField DataField="Done" HeaderText="Done" SortExpression="Done" />
            <asp:BoundField DataField="SectionHeadAccecpt" HeaderText="Section Head Accept" SortExpression="SectionHeadAccecpt" />
            <asp:BoundField DataField="DepartmentHeadAccecpt" HeaderText="Department Head Accept" SortExpression="DepartmentHeadAccecpt" />
            <asp:BoundField DataField="EmployeeHeadAccecpt" HeaderText="Employee Accept" SortExpression="EmployeeHeadAccecpt" />
            
            <asp:TemplateField>
                <ItemTemplate>
                    <%--<asp:Button ID="btnGetRowData" runat="server" Text="Send To EMail " 
                        CommandName="GetRowData" BackColor="#4CAF50" CommandArgument='<%# Container.DataItemIndex %>' />--%>
                    <asp:LinkButton ID="btnGetRowData" runat="server" CommandName="GetRowData"
    CommandArgument='<%# Container.DataItemIndex %>' CssClass="btn btn-success" OnClientClick="return confirm('Are you sure you want to send the mail?');">
    <i class="fa fa-send"></i> Send To Email
</asp:LinkButton>

                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Panel></td>

          
       </tr>

        </table>
</asp:Content>
