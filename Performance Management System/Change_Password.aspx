<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site1.Master" CodeBehind="Change_Password.aspx.vb" Inherits="Performance_Management_System.WebForm39" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <style type="text/css">
        .auto-style3 {
            width: 35%;
            /*margin-top:120px;*/
             /*margin-left: auto;*/
             height: 178px;
             /*margin-right: auto;
             margin-bottom: 40px;*/
           
             margin-top: 150px;
             margin:50px auto;
         }
        .auto-style5 {
            height: 59px;
        }
        .auto-style6 {
            margin-left: 346px;
        }
         .auto-style14 {
             height: 41px;
         }
         .auto-style17 {
             width: 158px;
             height: 41px;
         }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <br />
     <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
     <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <Triggers>
            <asp:PostBackTrigger ControlID="Button1" />
        </Triggers>
        <ContentTemplate>
            <br /><br />  <script type="text/javascript">  
        $(document).ready(function () {  
            $('#show_pass1').hover(function show() {  
                //Change the attribute to text  
                $('#ContentPlaceHolder1_oldpass').attr('type', 'text');  
                $('#ContentPlaceHolder1_newpass').attr('type', 'text');  
                 $('#ContentPlaceHolder1_confirmpass').attr('type', 'text');  
                $('.icon').removeClass('fa fa-eye-slash').addClass('fa fa-eye');  
            },  
            function () {  
                //Change the attribute back to password  
                $('#ContentPlaceHolder1_oldpass').attr('type', 'password');  
                $('#ContentPlaceHolder1_newpass').attr('type', 'password'); 
                 $('#ContentPlaceHolder1_confirmpass').attr('type', 'password'); 
                $('.icon').removeClass('fa fa-eye').addClass('fa fa-eye-slash');  
            });  
            //CheckBox Show Password  
            $('#ShowPassword').click(function () {  
                $('#Password').attr('type', $(this).is(':checked') ? 'text' : 'password');  
            });  
        });  
    
        $(document).ready(function () {  
            $('#show_pass2').hover(function show() {  
                //Change the attribute to text  
               $('#ContentPlaceHolder1_oldpass').attr('type', 'text');  
                $('#ContentPlaceHolder1_newpass').attr('type', 'text');  
                 $('#ContentPlaceHolder1_confirmpass').attr('type', 'text');  

                $('.icon').removeClass('fa fa-eye-slash').addClass('fa fa-eye');  
            },  
            function () {  
                //Change the attribute back to password  
                $('#ContentPlaceHolder1_oldpass').attr('type', 'password');  
                $('#ContentPlaceHolder1_newpass').attr('type', 'password'); 
                 $('#ContentPlaceHolder1_confirmpass').attr('type', 'password'); 
                $('.icon').removeClass('fa fa-eye').addClass('fa fa-eye-slash');  
            });  
            //CheckBox Show Password  
            $('#ShowPassword').click(function () {  
                $('#Password').attr('type', $(this).is(':checked') ? 'text' : 'password');  
            });  
         });  

          $(document).ready(function () {  
            $('#show_pass3').hover(function show() {  
                //Change the attribute to text  
               $('#ContentPlaceHolder1_oldpass').attr('type', 'text');  
                $('#ContentPlaceHolder1_newpass').attr('type', 'text');  
                 $('#ContentPlaceHolder1_confirmpass').attr('type', 'text');  

                $('.icon').removeClass('fa fa-eye-slash').addClass('fa fa-eye');  
            },  
            function () {  
                //Change the attribute back to password  
                $('#ContentPlaceHolder1_oldpass').attr('type', 'password');  
                $('#ContentPlaceHolder1_newpass').attr('type', 'password'); 
                 $('#ContentPlaceHolder1_confirmpass').attr('type', 'password'); 
                $('.icon').removeClass('fa fa-eye').addClass('fa fa-eye-slash');  
            });  
            //CheckBox Show Password  
            $('#ShowPassword').click(function () {  
                $('#Password').attr('type', $(this).is(':checked') ? 'text' : 'password');  
            });  
        });  
    </script>
    <div class="container" style="font-weight:bold;    padding-right: 5%;
    padding-left: 8%">
           <h2>Change Your Password</h2><hr /><br />
        <div class="row mb-3">
            <label for="inputEmail3" class="col-sm-2 col-form-label">Old Password: </label>           
             <div class="col-sm-10 ">
                                                               
                     <div class="input-group"><span class="input-group-addon" ><i class="fa fa-key fa-lg"></i></span>
                         <asp:TextBox ID="oldpass" runat="server" placeholder="old password" cssclass="form-control" TabIndex="1" TextMode="Password"></asp:TextBox>
                         <span class="input-group-addon"><button id="show_pass1" class="btn-primary"  type="button" >  
                            <span class="fa fa-eye-slash icon"></span>    
                            </button>  
                         </span></div></div>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="oldpass"  Display="Static" Text="*" ErrorMessage="Please enter old password" ForeColor="Red" ValidationGroup="insert"></asp:RequiredFieldValidator>
        </div>
                        <%--<div class="col-lg-8 col-sm-8 col-md-8 col-xs-6">
                  <div class="form-group">--%>
        <div class="row mb-3">
            <label for="inputEmail3" class="col-sm-2 col-form-label">New Password:</label>           
             <div class="col-sm-10 ">
                         
                        <div class="input-group"><span class="input-group-addon" ><i class="fa fa-key fa-lg"></i></span>
                       <asp:TextBox ID="newpass" runat="server" placeholder="new password" cssclass="form-control" TabIndex="2" TextMode="Password"></asp:TextBox>
                     <span class="input-group-addon"><button id="show_pass2" class="btn-primary"  type="button" >  
                            <span class="fa fa-eye-slash icon"></span>    
                            </button>  
                         </span></div></div>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="newpass" Display="Static" Text="*" ErrorMessage="Please enter new password" ForeColor="Red" ValidationGroup="insert"></asp:RequiredFieldValidator>
        </div>
                         <div class="row mb-3">
            <label for="inputEmail3" class="col-sm-2 col-form-label">Confirm Password:   </label>           
             <div class="col-sm-10 ">
                              
                        <div class="input-group"><span class="input-group-addon" ><i class="fa fa-key fa-lg"></i></span>
                      <asp:TextBox ID="confirmpass" runat="server" placeholder="confirm password" cssclass="form-control" TabIndex="3" TextMode="Password"></asp:TextBox>
                     <span class="input-group-addon"><button id="show_pass3" class="btn-primary"  type="button" >  
                            <span class="fa fa-eye-slash icon"></span>    
                            </button>  
                         </span></div></div>
                             <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="confirmpass"  Display="Static" Text="*" ErrorMessage="Please enter confirm password" ForeColor="Red" ValidationGroup="insert"></asp:RequiredFieldValidator>
                                  <asp:CompareValidator ID="CompareValidator2" runat="server" ControlToCompare="newpass" Text="*" ControlToValidate="confirmpass" Display="Static" ErrorMessage="New Password and Confirm Password Not Match" ForeColor="Red" ValidationGroup="insert"></asp:CompareValidator>
                         </div>
                             <%--<div class="col-lg-8 col-sm-8 col-md-8 col-xs-6">
                  <div class="form-group">--%>
        <div class="row mb-3">
            <label for="inputEmail3" class="col-sm-2 col-form-label"  style="visibility:hidden">Submit</label>    
            <div class="col-sm-10 ">
                       <asp:Button ID="Button1" runat="server" Text="Change Password" Style="background-color:#777; color:white; font-size:larger" TabIndex="4"  cssclass="form-control"  ValidationGroup="insert"></asp:Button>
                  </div>
                  </div>
           
        <%--<asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="newpass" ErrorMessage="Your new password is incorrect,Password lenth must be 6-10,one digit, one lowercase" ForeColor="Red" ValidationExpression="^((?=.*\d)(?=.*[a-z]).{6,10})" Display="None" ValidationGroup="insert"></asp:RegularExpressionValidator>--%></td>     
                <%--<asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="confirmpass" ErrorMessage="Password lenth must be 6-10,one digit, one lowercase, one uppercase" ForeColor="#FF3300" ValidationExpression="^((?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{6,10})" Display="None" ValidationGroup="insert"></asp:RegularExpressionValidator>--%></td>       
                        
                
    <br />
        <asp:Label ID="Label3" runat="server" ForeColor="Red" Text="Label" Visible="False"></asp:Label>
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="auto-style6" ForeColor="Red" ValidationGroup="insert" Width="686px" ShowMessageBox="True" ShowSummary="False" />
           
       <br />
       <br />
   <br />
     </ContentTemplate>
   </asp:UpdatePanel>

</asp:Content>
