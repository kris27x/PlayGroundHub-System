<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SignIn.aspx.cs" Inherits="FutBookFrontOffice.SignIn" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <link href="CSS/FutBookStyle.css" rel="stylesheet" />
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@4.6.2/dist/css/bootstrap.min.css"/>
    <script src="https://cdn.jsdelivr.net/npm/jquery@3.6.1/dist/jquery.slim.min.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/popper.js@1.16.1/dist/umd/popper.min.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@4.6.2/dist/js/bootstrap.bundle.min.js"></script>
    <title>FutBook</title>
</head>
<body>
    <body style="background-color:#ed3b3b;">

    <nav class="navbar navbar-expand-sm navbar-dark fixed-top">
      <!-- Brand -->
      <a class="navbar-brand" href="Default_aut.aspx">FUTBOOK</a>

      <!-- Links -->
      <ul class="navbar-nav">
        <li class="nav-item">
          <a class="nav-link" href="ShopHome.aspx">SHOP</a>
        </li>
        
        <!-- Dropdown -->
        <li class="nav-item dropdown">
          <a class="nav-link dropdown-toggle" href="#" id="navbardrop" data-toggle="dropdown">
            BOOKINGS
          </a>
          <div class="dropdown-menu">
            <a class="dropdown-item" href="#">PITCH</a>
            <a class="dropdown-item" href="EventBooking.aspx">EVENT</a>
          </div>
        </li>

        <li class="nav-item">
          <a class="nav-link" href="Registration.aspx">SIGN UP</a>
        </li>

        <li class="nav-item">
          <a class="nav-link" href="SignIn.aspx">SIGN IN</a>
        </li>


      </ul>
    </nav>
    <br/>
  

    <div class="logo">
            <img src="IMG/logoFutBook.png" />
    </div>


    <div class="container min-vh-100">
      <div class="row" style="border: none; margin-left: 0px; margin-top:40px;">
                    <div class="col">
                        <h2>SIGN IN</h2>
                        <form runat="server">
                            <div class="form-group">
                                <label for="lblEmail">Email address</label>
                                <asp:TextBox class="form-control" id="idEmail" runat="server" aria-describedby="emailHelp" placeholder="Enter email address"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <label for="lblPassword">Password</label>
                                <asp:TextBox type="password" class="form-control" id="idPassword" placeholder="Password" runat="server" TextMode="Password"></asp:TextBox>
                            </div>
                                                        
                            <asp:Button ID="btnSignIn" runat="server" Text="SIGN IN" OnClick="btnSignIn_Click" class="btn btn-primary"/>
                                                        
                            <asp:Label ID="lblError" runat="server"></asp:Label>


                             
                        </form>

                        
                    </div>

                    <div class="col">
                        <h2>REGISTER</h2>
                            <p style="font-size: 14px; color: #e6e6e6;">Don't have account? Please click below to register</p>
                            <div class="col" style="margin-left:0px;">
                                <a href="Registration.aspx"><button type="button" class="btn btn-primary">REGISTER</button></a>
                            </div>
                     </div>
                    
       </div>
    </div>

    <div class="footer-pad">  
    <p class="text-center"> © FUTBOOK 2023 </p>  
    </div>  
</body>
</html>
