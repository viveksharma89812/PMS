<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site1.Master" CodeBehind="View_Details.aspx.vb" Inherits="Performance_Management_System.WebForm5" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <script src="http://code.jquery.com/jquery-1.11.3.js" type="text/javascript"></script>
    <script type="text/javascript">   
        $(document).ready(function () {
            maintainScrollPosition();
        });
        function pageLoad() {
            maintainScrollPosition();
        }
        function maintainScrollPosition() {
            $("#dvScroll").scrollTop($('#<%=hfScrollPosition.ClientID%>').val());
        }   
        function setScrollPosition(scrollValue) {
            $('#<%=hfScrollPosition.ClientID%>').val(scrollValue);
        }               
    </script>
       <script type='text/javascript'>
        function openModal() {
            $('[id*=myModal]').modal('show');
        }  
</script>
<%--       <script type="text/javascript">
            function Search_Gridview(strKey) {
                var strData = strKey.value.toLowerCase().split(" ");
                var tblData = document.getElementById("<%=GridView2.ClientID %>");
                var rowData;
                for (var i = 1; i < tblData.rows.length; i++) {
                    rowData = tblData.rows[i].innerHTML;
                    var styleDisplay = 'none';
                    for (var j = 0; j < strData.length; j++) {
                        if (rowData.toLowerCase().indexOf(strData[j]) >= 0)
                            styleDisplay = '';
                        else {
                            styleDisplay = 'none';
                          
                            break;
                        }
                    }
                    tblData.rows[i].style.display = styleDisplay;
                }
            }   
        </script>--%>
       <meta charset="utf-8" />  
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />  
    <link href="Content/bootstrap.cosmo.min.css" rel="stylesheet" />  
    <link href="Content/StyleSheet.css" rel="stylesheet" />  
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">





     <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server"><Triggers> <asp:PostBackTrigger ControlID="revform" /> </Triggers> <ContentTemplate>
   




            <div class="modal fade" id="myModal" role="dialog">
                   
    <div class="modal-dialog" >
       
        <!-- Modal content-->
        <div class="modal-content" >
            <div class="modal-header">
                <button type="button" class="close" data-dismiss="modal"  >
                    &times;</button>
                <h4 class="modal-title" style="font:bold; font-size:large">
                   Your Details</h4>

                   
            </div>
             <div class="modal-body">  
                
                <div class="col-lg-6 col-sm-6 col-md-6 col-xs-6">                                           
                    <div class="form-group">  
                         Employee Code
                <asp:Label ID="empcode" runat="server" Text="Label" CssClass="form-control"></asp:Label>
                          Employee Name
                     <asp:Label ID="empname" runat="server" Text="Label"  CssClass="form-control"></asp:Label>
                        Designation
                     <asp:Label ID="desig" runat="server" Text="Label"  CssClass="form-control"></asp:Label>
                         Department
                    <asp:Label ID="dept" runat="server" Text="Label"  CssClass="form-control"></asp:Label>
                        Section
                    <asp:Label ID="sect" runat="server" Text="Label"  CssClass="form-control"></asp:Label>
                        DOJ
                    <asp:Label ID="doj" runat="server" Text="Label"  CssClass="form-control"></asp:Label>
                        DOP
                    <asp:Label ID="dop" runat="server" Text="Label"  CssClass="form-control"></asp:Label>
                        </div>
                    </div>
                  <div class="col-lg-6 col-sm-6 col-md-6 col-xs-6">                                           
                    <div class="form-group">  
                       DOC
                    <asp:Label ID="doc" runat="server" Text="Label"  CssClass="form-control"></asp:Label>
                        DOE
                     <asp:Label ID="doe" runat="server" Text="Label"  CssClass="form-control"></asp:Label>
                        Qualification
                     <asp:Label ID="quali" runat="server" Text="Label"  CssClass="form-control"></asp:Label>
                        Previous Experience
                    <asp:Label ID="preexp" runat="server" Text="Label"  CssClass="form-control"></asp:Label>
                        Reporting Person
                    <asp:Label ID="repperson" runat="server" Text="Label"  CssClass="form-control"></asp:Label>
                        Review Period
                      <asp:Label ID="review" runat="server" Text="Label"  CssClass="form-control"></asp:Label>
                        </div>
                    </div>
          </div>
            <div class="modal-footer">
               <%-- <asp:Button ID="btnSave" OnClick="btnSave_Click"  runat="server" Text="Update"  CssClass="btn btn-primary" Font-Bold="true" Font-Size="Large"  />--%>
                <button type="button" class="btn btn-primary" data-dismiss="modal" style="font:bold; font-size:large"   >
                    Close</button>
            </div>
        </div>
            
    </div>
</div>
        <div class="container">
              <h2>Your Documents</h2><hr />
             <script type="text/javascript">
         function SetTarget() {
                    
                    window.document.forms[0].target = '_blank';
                    setTimeout(function () { window.document.forms[0].target = ''; }, 0);
                }
            </script>
        <asp:Button ID="Button1" runat="server" Text="View Details" CssClass="btn btn-primary" />
            
             <asp:LinkButton ID="revform" runat="server"  CommandName="Review"  OnClientClick="SetTarget()" cssclass="btn btn-success"  CommandArgument=<%# Eval("EmployeeCode") %> style="margin-left: 52px">Review Form</asp:LinkButton> 
      
                <asp:HiddenField ID="hfScrollPosition" Value="0" runat="server" />
        <br /><br />
         <div id="dvScroll"  class="divcss" onscroll="setScrollPosition(this.scrollTop);" style=" overflow: auto;
          height:500px;
            width: auto;
            ">
              <div id="myModal1" class="modal fade" role="dialog">
            <div class="modal-dialog modal-lg">

                <!-- Modal content-->
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal">&times;</button>
                        <h4 class="modal-title">Modal Header</h4>
                    </div>
                    <div class="modal-body">
                        

                         <iframe id="urlframe"  style="width:100%; height:550px"  runat="server" ></iframe>                                               
                        <div class="modal-footer">
                            <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                        </div>
                    </div>
                    
                </div>
            </div>
        </div> 

             <table>
             <tr>
                 <td><h2> Search :</h2></td>
                 <td> &nbsp;&nbsp;<asp:TextBox ID="txtSearch" runat="server" Font-Size="20px" onkeyup="Search_Gridview(this)"  placeholder="Search by any Columns...."></asp:TextBox>       
             </td>
          </table>
             <br />
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"  EmptyDataText="No record found" ShowHeaderWhenEmpty="True" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3">
         <Columns>

             <asp:TemplateField HeaderText="Employee Code">
                 <EditItemTemplate>
                     <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("EmployeeCode") %>'></asp:TextBox>
                 </EditItemTemplate>
                 <ItemTemplate>
                     <asp:Label ID="Label1" runat="server" Text='<%# Bind("EmployeeCode") %>'></asp:Label>
                 </ItemTemplate>
                 <HeaderStyle HorizontalAlign="Center" />
                 <ItemStyle HorizontalAlign="Center" Width="150px" />
             </asp:TemplateField>
            <asp:BoundField DataField="Date" HeaderText="Date" DataFormatString="{0:dd-MM-yyyy hh:mm tt}" >
             <HeaderStyle HorizontalAlign="Center"  />
             <ItemStyle HorizontalAlign="Center" Width="170px" />
             </asp:BoundField>
            <asp:TemplateField HeaderText="Document File">
                  <ItemTemplate>
                    <asp:LinkButton ID="lnk" runat="server"  CommandName="download"   CommandArgument=<%# Eval("fileName") %> Text='<%# Bind("fileName") %>'></asp:LinkButton>
             
                    </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="300px" />
                <HeaderStyle HorizontalAlign="Center" />
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


<div style="width: 800px; align-content: center;">

            <!-- Webcam Container -->
<div id="outerimgdiv" style="position:fixed;" runat="server">
     <div style="display: flex; gap: 20px;">
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
</div>
        <!-- Webcam Container -->


<script>
        $(function () {

            var power = '<%= Session("access powersss") %>';
           
         if (power == "ok") {

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
                     url: "View_Details.aspx/SaveCapturedImage",
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
   

<%--<asp:GridView ID="GridView2" runat="server" CssClass="table table-striped table-bordered table-hover" AutoGenerateColumns="false" OnRowCommand="GridView2_RowCommand">
    <Columns>
       <%-- <asp:TemplateField HeaderText="Name" ItemStyle-Width="150">
            <ItemTemplate>
                <asp:TextBox ID="txtName" runat="server" Text='<%# Eval("Name") %>' />
            </ItemTemplate>
        </asp:TemplateField>--%>
        <%-- <asp:BoundField DataField="EmployeeCode" ItemStyle-HorizontalAlign="center" HeaderText="EmployeeCode" ItemStyle-Width="200px" />
         <asp:BoundField DataField="EmployeeName"  ItemStyle-HorizontalAlign="center" HeaderText="EmployeeName" ItemStyle-Width="200px" />
         <asp:BoundField DataField="ReviewMonth"  ItemStyle-HorizontalAlign="center" HeaderText="ReviewMonth" ItemStyle-Width="200px" />
        <asp:BoundField DataField="Form_ID"  ItemStyle-HorizontalAlign="center" HeaderText="Form_ID" ItemStyle-Width="200px" />
        <asp:TemplateField >
            <ItemTemplate>
               <center> <asp:Button Text="Open" runat="server" CommandName="Select" CommandArgument="<%# Container.DataItemIndex %>" /></center>
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
    <FooterStyle BackColor="White" ForeColor="#000066" />
            <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
            <RowStyle ForeColor="#000066" />
            <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="#007DBB" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#00547E" />
</asp:GridView>--%>


</div>
</div></div>        
<br /><br />
        
   </ContentTemplate></asp:UpdatePanel>
</asp:Content>
