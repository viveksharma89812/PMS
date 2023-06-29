<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site1.Master" CodeBehind="Registration.aspx.vb" Inherits="Performance_Management_System.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">   
    
    <style type="text/css">
    .auto-style1 {
        width: 4px;
    }
    .auto-style2 {
        width: 6px;
    }
    .auto-style5 {
        width: 602px;
        height: 245px;
            margin-left: 381px;
            margin-bottom:10px;
            margin-top:10px;
        }
        .auto-style6 {
            width: 382px;
            height: 50px;
        }
        .auto-style7 {
            width: 833px;
            height: 50px;
        }
        .auto-style10 {
            height: 28px;
        }
    .auto-style11 {
        margin-left: 436px;
    }
        .auto-style12 {
            height: 57px;
        }
        .auto-style17 {
        width: 382px;
        height: 57px;
    }
    </style>
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server"><Triggers><asp:PostBackTrigger ControlID="empcode" /></Triggers><ContentTemplate>
        
        <script type="text/javascript">  
        $(document).ready(function () {  
            $('#show_password').hover(function show() {  
                //Change the attribute to text  
                $('#ContentPlaceHolder1_pass').attr('type', 'text');  
                $('#ContentPlaceHolder1_confirmpass').attr('type', 'text');  
                $('.icon').removeClass('fa fa-eye-slash').addClass('fa fa-eye');  
            },  
            function () {  
                //Change the attribute back to password  
                $('#ContentPlaceHolder1_pass').attr('type', 'password');  
                $('#ContentPlaceHolder1_confirmpass').attr('type', 'password'); 
                $('.icon').removeClass('fa fa-eye').addClass('fa fa-eye-slash');  
            });  
            //CheckBox Show Password  
            $('#ShowPassword').click(function () {  
                $('#Password').attr('type', $(this).is(':checked') ? 'text' : 'password');  
            });  
        });  
    </script>  
             <script type="text/javascript">  
        $(document).ready(function () {  
            $('#show').hover(function show() {  
                //Change the attribute to text  
                $('#ContentPlaceHolder1_confirmpass').attr('type', 'text'); 
                $('#ContentPlaceHolder1_pass').attr('type', 'text');

                $('.icon').removeClass('fa fa-eye-slash').addClass('fa fa-eye');  
            },  
            function () {  
                //Change the attribute back to password  
                $('#ContentPlaceHolder1_confirmpass').attr('type', 'password');  
                  $('#ContentPlaceHolder1_pass').attr('type', 'password');
                $('.icon').removeClass('fa fa-eye').addClass('fa fa-eye-slash');  
            });  
            //CheckBox Show Password  
            $('#ShowPassword').click(function () {  
                $('#Password').attr('type', $(this).is(':checked') ? 'text' : 'password');  
            });  
        });  
    </script>  

        <div class="container" style="font-weight:bold;    padding-right: 5%;
    padding-left: 8% ;">
           <h2>Registered Your Detail Here</h2><hr /><br />
        <div class="row mb-3">
            <label for="inputEmail3" class="col-sm-2 col-form-label">Employee Code: </label>           
             <div class="col-sm-10 ">
                 <div class="input-group"><span class="input-group-addon" ><i class="fa fa-user fa-lg "></i></span>

     <asp:TextBox ID="empcode" runat="server" CssClass="form-control" placeholder="Enter Employee Code" TabIndex="1" Font-Bold="true" Font-Size="Large" AutoPostBack="true"></asp:TextBox>
           
                </div>
                 </div>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="empcode" Display="static" Text="*" ErrorMessage="Please enter EmployeeCode" ForeColor="Red" SetFocusOnError="True" ValidationGroup="insert"></asp:RequiredFieldValidator>
            </div>
             <div class="row mb-3">
            <label for="inputEmail3" class="col-sm-2 col-form-label">Employee Name:   </label>           
             <div class="col-sm-10 ">
                  <div class="input-group"><span class="input-group-addon" ><i class="fa fa-user fa-lg "></i></span>  <asp:TextBox ID="empname" runat="server" placeholder="Enter Employee Name"  TabIndex="2" Font-Bold="true" Font-Size="Large" cssclass="form-control"></asp:TextBox>
             </div></div>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="empname" Display="static" Text="*" ErrorMessage="Please enter employeename" ForeColor="Red" SetFocusOnError="True" ValidationGroup="insert"></asp:RequiredFieldValidator> 
                 
                 </div>
            <div class="row mb-3">
            <label for="inputEmail3" class="col-sm-2 col-form-label">Department:   </label>           
             <div class="col-sm-10 ">
                 <div class="input-group">                                              
                       <span class="input-group-addon"><i class="fa fa-building-o "></i> </span> 
                           <asp:TextBox ID="dept" runat="server" CssClass="form-control" Font-Bold="true" placeholder="Enter Department" Font-Size="Large"></asp:TextBox>
                       
                   </div>        
                 </div>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="dept" Display="static" Text="*" ErrorMessage="Please enter Department" ForeColor="Red" SetFocusOnError="True" ValidationGroup="insert"></asp:RequiredFieldValidator>

            </div>
             <div class="row mb-3">
            <label for="inputEmail3" class="col-sm-2 col-form-label">Section:   </label>           
             <div class="col-sm-10 ">
                  <div class="input-group">                                              
                       <span class="input-group-addon"><i class="fa fa-building-o "></i> </span> 
                           <asp:TextBox ID="section" runat="server" CssClass="form-control" placeholder="Enter Section" Font-Bold="true" Font-Size="Large"></asp:TextBox>
                              </div>
                </div>                                                                                            
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="section" Display="static" Text="*" ErrorMessage="Please enter section" ForeColor="Red" SetFocusOnError="True" ValidationGroup="insert"></asp:RequiredFieldValidator>
               </div>
             <div class="row mb-3">
            <label for="inputEmail3" class="col-sm-2 col-form-label">Create Password:   </label>           
             <div class="col-sm-10 ">
                 <div class="input-group">                                              
                       <span class="input-group-addon"><i class="fa fa-lock "></i> </span>   <asp:TextBox ID="pass" runat="server" placeholder="Enter Password" Font-Bold="true" Font-Size="Large" TabIndex="5" TextMode="Password"  CssClass="form-control"></asp:TextBox>  
                         
                         <span class="input-group-addon"><button id="show_password" class="btn-primary"  type="button" >  
                            <span class="fa fa-eye-slash icon"></span>    
                            </button>  
                         </span>
                 </div>
                </div>
                     <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="pass" Display="static" Text="*" ErrorMessage="Please enter password" ForeColor="Red" SetFocusOnError="True" ValidationGroup="insert"></asp:RequiredFieldValidator>
               <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="pass" Display="static" Text="*" ErrorMessage="Password lenth must be 6-10,one digit, one lowercase, one uppercase" ForeColor="Red" ValidateRequestMode="Enabled" ValidationExpression="^((?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{6,10})" ValidationGroup="insert"></asp:RegularExpressionValidator>
                 </div>
             <div class="row mb-3">
            <label for="inputEmail3" class="col-sm-2 col-form-label">Confirm Password:   </label>           
             <div class="col-sm-10 ">
                   <div class="input-group">                                              
                       <span class="input-group-addon"><i class="fa fa-lock "></i> </span><asp:TextBox ID="confirmpass" runat="server"  TabIndex="6" placeholder="Enter Confirm Password" Font-Bold="true" Font-Size="Large" TextMode="Password"  CssClass="form-control"></asp:TextBox>  
                             
                         <span class="input-group-addon"><button id="show" class="btn-primary"  type="button" >  
                            <span class="fa fa-eye-slash icon"></span>    
                            </button>  
                         </span> 
                 </div>
                </div>
                 <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="confirmpass" Display="static" Text="*" ErrorMessage="Please enter confirm Password" ForeColor="Red" SetFocusOnError="True" ValidationGroup="insert"></asp:RequiredFieldValidator>
            </div>
             <asp:Label ID="Label15" runat="server" ForeColor="Red" Text="Label" Visible="False"></asp:Label> 
              <div class="row mb-3">
            <label for="inputEmail3" class="col-sm-2 col-form-label"  style="visibility:hidden">Submit</label>    
            <div class="col-sm-10 ">
                <asp:Button ID="Button1" runat="server" Height="35px" CssClass="form-control" Style="background-color:#777; color:white; font-size:larger" TabIndex="7" Text="Register"  ValidationGroup="insert" />
               
                </div>
                  </div>
             <asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="auto-style11" ForeColor="Red" Width="429px" Font-Size="Larger" ShowMessageBox="True" ShowSummary="False" ValidationGroup="insert" />
            </div>



<%--         <div class="modal-dialog" style="height:auto; ">
        <!-- Modal content-->
        <div class="modal-content"  style="background-color:beige">
            <div class="modal-header">
                <button type="button" class="close" data-dismiss="modal" >
                     
                    &times;</button><center> 
                      
                <h3 class="modal-title" >
                      Please Registered Your Detail Here</h3></center> 
            </div>
            
            <div class="modal-body">
                
              <div class="col-lg-12 col-sm-8 col-md-8 col-xs-8">
                                        
                    <div class="form-group">
                     
                       <asp:Label ID="Label2" runat="server" Text="Employee Code" Font-Bold="true" Font-Size="Large"></asp:Label>
 <div class="input-group"><span class="input-group-addon" ><i class="fa fa-user fa-lg "></i></span>

     <asp:TextBox ID="empcode" runat="server" CssClass="form-control" placeholder="Enter Employee Code" TabIndex="1" Font-Bold="true" Font-Size="Large" AutoPostBack="true"></asp:TextBox>
           
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="empcode" Display="None" ErrorMessage="Please enter EmployeeCode" ForeColor="Red" SetFocusOnError="True" ValidationGroup="insert"></asp:RequiredFieldValidator></div>
                        <asp:Label ID="Label10" runat="server" Text="Employee Name" Font-Bold="true" Font-Size="Large"></asp:Label>  
                       <div class="input-group"><span class="input-group-addon" ><i class="fa fa-user fa-lg "></i></span>  <asp:TextBox ID="empname" runat="server" placeholder="Enter Employee Name"  TabIndex="2" Font-Bold="true" Font-Size="Large" cssclass="form-control"></asp:TextBox>
             
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="empname" Display="None" ErrorMessage="Please enter employeename" ForeColor="Red" SetFocusOnError="True" ValidationGroup="insert"></asp:RequiredFieldValidator> </div>          
                   <asp:Label ID="Label11" runat="server" Text="Department" Font-Bold="true" Font-Size="Large"></asp:Label>
                       <div class="input-group">                                              
                       <span class="input-group-addon"><i class="fa fa-building-o "></i> </span> 
                           <asp:TextBox ID="dept" runat="server" CssClass="form-control" Font-Bold="true" placeholder="Enter Department" Font-Size="Large"></asp:TextBox>
                       
                           <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="dept" Display="None" ErrorMessage="Please enter Department" ForeColor="Red" SetFocusOnError="True" ValidationGroup="insert"></asp:RequiredFieldValidator>
                       </div>
                        <asp:Label ID="Label12" runat="server" Text="Section" Font-Bold="true" Font-Size="Large" ></asp:Label>            
                       <div class="input-group">                                              
                       <span class="input-group-addon"><i class="fa fa-building-o "></i> </span> 
                           <asp:TextBox ID="section" runat="server" CssClass="form-control" placeholder="Enter Section" Font-Bold="true" Font-Size="Large"></asp:TextBox>
                         

                                                                                                  
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="section" Display="None" ErrorMessage="Please enter section" ForeColor="Red" SetFocusOnError="True" ValidationGroup="insert"></asp:RequiredFieldValidator>
                       </div>
                        <asp:Label ID="Label13" runat="server" Text="Create Password" Font-Bold="true" Font-Size="Large"></asp:Label>   <div class="input-group">                                              
                       <span class="input-group-addon"><i class="fa fa-lock "></i> </span>   <asp:TextBox ID="pass" runat="server" placeholder="Enter Password" Font-Bold="true" Font-Size="Large" TabIndex="5" TextMode="Password"  CssClass="form-control"></asp:TextBox>  
                             <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="pass" Display="None" ErrorMessage="Please enter password" ForeColor="Red" SetFocusOnError="True" ValidationGroup="insert"></asp:RequiredFieldValidator>
               <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="pass" Display="None" ErrorMessage="Password lenth must be 6-10,one digit, one lowercase, one uppercase" ForeColor="Red" ValidateRequestMode="Enabled" ValidationExpression="^((?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{6,10})" ValidationGroup="insert"></asp:RegularExpressionValidator>
                         <span class="input-group-addon"><button id="show_password" class="btn-primary"  type="button" >  
                            <span class="fa fa-eye-slash icon"></span>    
                            </button>  
                         </span> </div>
                        <asp:Label ID="Label14" runat="server" Text="Confirm Password" Font-Bold="true" Font-Size="Large"></asp:Label>
                        <div class="input-group">                                              
                       <span class="input-group-addon"><i class="fa fa-lock "></i> </span><asp:TextBox ID="confirmpass" runat="server"  TabIndex="6" placeholder="Enter Confirm Password" Font-Bold="true" Font-Size="Large" TextMode="Password"  CssClass="form-control"></asp:TextBox>  
                             <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="confirmpass" Display="None" ErrorMessage="Please enter confirm Password" ForeColor="Red" SetFocusOnError="True" ValidationGroup="insert"></asp:RequiredFieldValidator>
                         <span class="input-group-addon"><button id="show" class="btn-primary"  type="button" >  
                            <span class="fa fa-eye-slash icon"></span>    
                            </button>  
                         </span> </div>
                       
                 <asp:Label ID="Label15" runat="server" ForeColor="Red" Text="Label" Visible="False"></asp:Label> 
                     
                    </div>                   
                  </div>
                         
            <div class="modal-footer">
                 <div class="col-lg-12 col-sm-8 col-md-8 col-xs-8">
                           <div class="form-group">
                               <asp:Button ID="Button1" runat="server" Height="35px" CssClass="form-control" BackColor="#669999"  ForeColor="White" Font-Bold="True" Font-Size="Larger" TabIndex="7" Text="Register"  ValidationGroup="insert" />
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="auto-style11" ForeColor="Red" Width="429px" Font-Size="Larger" ShowMessageBox="True" ShowSummary="False" ValidationGroup="insert" />
               </div></div>
            </div>
              
        </div>
           
    </div></div>--%>
                                                         
         <div id="dvMessage" runat="server" visible="false" class="alert alert-danger">
        <strong>Error!</strong>
        <asp:Label ID="lblMessage" runat="server" />
    </div>
                   

   
               
        </ContentTemplate></asp:UpdatePanel>
       
</asp:Content>
