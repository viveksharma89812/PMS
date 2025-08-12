<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/Site1.Master" CodeBehind="PmsLogs.aspx.vb" Inherits="Performance_Management_System.PmsLogs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
  <meta http-equiv="refresh" content="200" />
 <!-- Refresh every 5 seconds -->
    <style>
        /* Styling the form container */
        .form-container {
            margin: 20px;
            padding: 10px;
            background-color: #f4f4f4;
            border-radius: 5px;
            box-shadow: 0px 0px 10px rgba(0, 0, 0, 0.1);
            width: 300px;
        }

        /* Styling the label */
        .form-container label {
            display: block;
            font-size: 16px;
            font-weight: bold;
            margin-bottom: 5px;
            color: #333;
        }

        /* Styling the dropdown */
        #dropdown {
            padding: 10px;
            font-size: 14px;
            border-radius: 5px;
            border: 1px solid #ccc;
            outline: none;
            width: 100%;
            box-sizing: border-box;
        }

        /* Hover effect for the dropdown */
        #dropdown:hover {
            border-color: #888;
        }

        /* Focus effect for the dropdown */
        #dropdown:focus {
            border-color: #5cb85c;
            box-shadow: 0 0 5px rgba(0, 123, 255, 0.5);
        }

        /* Styling the table */
        .table-container {
            width: 100%;
            border-collapse: collapse;

        }

       #ContentPlaceHolder1_logsTables {
    height: 400px;
    width: 100%;
    overflow: auto; /* Allows scrolling of the content */
}

.table-container {
    width: 100%;
    border-collapse: collapse;
}

.table-container th {

    position: sticky;
    top: 0; /* Keep the header on top */
    background-color: #fff; /* Set a background color to make sure the header stands out */
    z-index: 1; /* Make sure the header stays above other content */
    border-bottom: 2px solid #ddd; /* Optional: Adds a border at the bottom of the header */
}

.table-container td, .table-container th {
    padding: 8px;
    border: 1px solid #ddd;
}

.table-container thead {
    background-color: #f4f4f4;
}



        .table-container th, .table-container td {
            padding: 12px;
            text-align: left;
            border: 1px solid #ddd;
        }

        .table-container th {
            background-color: #4CAF50;
            color: white;
            font-weight: bold;
        }

        .table-container tr:nth-child(even) {
            background-color: #f2f2f2;
        }

        .table-container tr:hover {
            background-color: #ddd;
        }
        
        /* Style for the Date Inputs */
.dateInput {
    padding: 8px;
    font-size: 14px;
    width: 220px;
    border: 1px solid #ccc;
    border-radius: 4px;
    transition: border-color 0.3s ease, box-shadow 0.3s ease;
}

/* Add a border change when date is selected */
.dateInput:focus {
    border-color: #4CAF50;
    box-shadow: 0 0 8px rgba(76, 175, 80, 0.3);
}

/* Date input background color when the date is selected */
.dateInput:not(:empty) {
    background-color: #f0f8ff; /* Light blue background */
}

/* Hover effect on the Date Input */
.dateInput:hover {
    border-color: #888;
}

/* Button Styling */
.btnFind {
    padding: 8px 16px;
    background-color: #4CAF50;
    color: white;
    font-size: 14px;
    border: none;
    border-radius: 4px;
    cursor: pointer;
    transition: background-color 0.3s ease;
}

.btnFind:hover {
    background-color: #45a049;
}
.btnFind1 {
    padding: 8px 16px;
    background-color: #e34242;
    color: white;
    font-size: 14px;
    border: none;
    border-radius: 4px;
    cursor: pointer;
    transition: background-color 0.3s ease;
}

.btnFind1:hover {
    background-color: #e34242;
}
.label {
    font-size: 20px !important;
    font-weight: bold;
    margin-right: 5px;
    color:black !important;
}

    </style>



</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <br />
    <br />
    <!-- Date filter and Find button -->
    <div style="display: flex; justify-content: center; border: 1px solid; align-items: center; gap: 10px; background-color: gold; padding: 13px; padding-right: 21px">
        <asp:Label ID="Label1" runat="server" Text="Employee Code: " CssClass="label" AssociatedControlID="TextBox1" />
        <asp:TextBox ID="TextBox1" runat="server" CssClass="dateInput" Placeholder="Employee Code" type="text"></asp:TextBox>

        <!-- From Date Label and TextBox -->
        <asp:Label ID="lblFromDate" runat="server" Text="From Date:" CssClass="label" AssociatedControlID="txtFromDate" />
        <asp:TextBox ID="txtFromDate" runat="server" CssClass="dateInput" Placeholder="From Date" type="date"></asp:TextBox>

        <!-- To Date Label and TextBox -->
        <asp:Label ID="lblToDate" runat="server" Text="To Date:" CssClass="label" AssociatedControlID="txtToDate" />
        <asp:TextBox ID="txtToDate" runat="server" CssClass="dateInput" Placeholder="To Date" type="date"></asp:TextBox>

        <!-- Find Button -->
        <asp:Button ID="btnFind" runat="server" Text="Find" CssClass="btnFind" OnClick="btnFind_Click" />
        <asp:Button ID="btnFind1" runat="server" Text="Reset" CssClass="btnFind1" OnClick="btnReset_Click" />
    </div>

    <br />
    <!-- Dynamically rendered table -->
    <div id="logsTables" runat="server" style="margin-top: -18px;"></div>

    <asp:Label ID="lblMessage" runat="server" ForeColor="Red" Visible="false"></asp:Label>
</asp:Content>



