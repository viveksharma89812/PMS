<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site1.Master" CodeBehind="login.aspx.vb" Inherits="Performance_Management_System.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
     <style>
    .imgcontainer {
  text-align: center;
  margin: 10px 0 6px 0;
}
    .img1container{
        text-align:right;
        margin:10px 10px 10px 10px;
    }

img.avatar {
  width: 30%;
  border-radius: 50%;
}

.container {
  padding: 5px;
}

span.psw {
  float: right;
  padding-top: 5px;
}

/* Change styles for span and cancel button on extra small screens */
@media screen and (max-width: 300px) {
  span.psw {
     display: block;
     float: none;
  }
  .cancelbtn {
     width: 100%;
  }
}
</style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server"><%--<div style="background-image:url(Images/Webp.net-resizeimage.jpg);background-size:100%;">--%><br />
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server"><ContentTemplate>        
                  
         <div class="container" style="font-weight:bold">
                         
              <div  style="width: 50%;
    margin-left: 25%;
    margin-right: 25%;
    margin-top: 10%;
    margin-bottom: 10%;
    background-color: #838d967d;
    padding-left: 5%;
    padding-right: 5%;
    border: 2px solid white;
    padding-bottom: 5%;
    border-radius: 1%;">  <%--border-right: 1px solid black;--%>
                  <h2 style="color: white;
    font-style: italic;">Login Here :</h2><hr />
                
                  <div class="form-group" style="font-weight:bold;color:white">
                      User ID: <br />
                    <div class="input-group"><span class="input-group-addon" style="border-top-left-radius: 10px;
    border-bottom-left-radius: 10px;" ><i class="fa fa-user fa-lg "></i></span>  <asp:TextBox ID="empcode" runat="server" placeholder="Employee ID" TabIndex="1" ForeColor="Black"  Height="36px" CssClass="form-control" Style="border-top-right-radius: 10px;
    border-bottom-right-radius: 10px;"  required></asp:TextBox></div>
                      Password: <br />
                   <div class="input-group">                                              
                       <span class="input-group-addon" style="border-top-left-radius: 10px;
    border-bottom-left-radius: 10px;" ><i class="fa fa-key "></i> </span>    <asp:TextBox ID="pass" runat="server"  CssClass="form-control" placeholder="Password" Height="36px" TextMode="Password" TabIndex="2" required></asp:TextBox>
                         <span class="input-group-addon" Style="border-top-right-radius: 10px;
    border-bottom-right-radius: 10px;"><button id="show_password"  type="button"  >  
                            <span class="fa fa-eye-slash icon"></span>    
                            </button>  
                         </span> </div>
                       </div> 
                      <asp:Button ID="login" runat="server" Text="Login"  CssClass="form-control"  Style="background-color:#547fa5; border-color:#405465; color:white; padding:2px 10px; font-weight:bold; font-size:larger;border-top-left-radius: 10px;
    border-bottom-left-radius: 10px;
    border-top-right-radius: 10px;
    border-bottom-right-radius: 10px;" TabIndex="3"   />
                   <asp:Label ID="Label1" runat="server" ForeColor="Red" Text="Label" Visible="False"></asp:Label>
                  <asp:Label ID="Label3" runat="server"  TabIndex="5" Visible="false"></asp:Label>
                  </div>

                <br />                                   
         </div>  <div id="dvMessage" runat="server" visible="false" class="alert alert-danger">
        <strong>Error!</strong>
        <asp:Label ID="lblMessage" runat="server" />
   </div>
                   
     <script type="text/javascript">  
        $(document).ready(function () {  
            $('#show_password').hover(function show() {  
                //Change the attribute to text  
                $('#ContentPlaceHolder1_pass').attr('type', 'text');  
                $('.icon').removeClass('fa fa-eye-slash').addClass('fa fa-eye');  
            },  
            function () {  
                //Change the attribute back to password  
                $('#ContentPlaceHolder1_pass').attr('type', 'password');  
                $('.icon').removeClass('fa fa-eye').addClass('fa fa-eye-slash');  
            });  
            //CheckBox Show Password  
            $('#ShowPassword').click(function () {  
                $('#Password').attr('type', $(this).is(':checked') ? 'text' : 'password');  
            });  
        });  
    </script>   
   
     <br />
  <br />
       
     </ContentTemplate></asp:UpdatePanel>
</asp:Content>
