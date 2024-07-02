<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registration.aspx.cs" Inherits="FutBookFrontOffice.Registration" %>

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
<body style="background-color:#ed3b3b;">

    <nav class="navbar navbar-expand-sm navbar-dark fixed-top">
      <!-- Brand -->
      <a class="navbar-brand" href="Default_aut.aspx">FUTBOOK</a>

      <!-- Links -->
      <ul class="navbar-nav">
        <li class="nav-item">
          <asp:HyperLink ID="hypShop" runat="server" class="nav-link" NavigateUrl="~/ShopHome.aspx">SHOP</asp:HyperLink>
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
          <asp:HyperLink ID="hypSignUp" runat="server" class="nav-link" NavigateUrl="~/Registration.aspx">SIGN UP</asp:HyperLink>
        </li>

        <li class="nav-item">
          <asp:HyperLink ID="hypSignIn" runat="server" class="nav-link" NavigateUrl="~/SignIn.aspx">SIGN IN</asp:HyperLink>
        </li>

        <li class="nav-item ml-auto">
          <asp:HyperLink ID="hypSignOut" runat="server" class="nav-link" NavigateUrl="~/SignOut.aspx">SIGN OUT</asp:HyperLink>
        </li>


      </ul>
    </nav>
    <br>
  

    <div class="logo">
            <img src="IMG/logoFutBook.png" />
    </div>


    <div class="container min-vh-100">
      <div class="row" style="border: none; margin-left: 0px; margin-top:40px; width:50%; ">
                    <div class="col">
                        <h2>SIGN UP</h2>
                        <form runat="server">
                            <div class="form-group">
                                <label for="lblEmail">Email address</label>
                                <asp:TextBox class="form-control" id="idEmail" runat="server" aria-describedby="emailHelp" placeholder="Enter email"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <label for="lblFirstName">First name</label>
                                <asp:TextBox class="form-control" id="idFirstName" runat="server" placeholder="Enter first name"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <label for="lblSurname">Surname</label>
                                <asp:TextBox class="form-control" id="idSurname" runat="server" placeholder="Enter surname"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <label for="lblHouseNo">House no</label>
                                <asp:TextBox class="form-control" id="idHouseNo" runat="server" placeholder="Enter House no"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <label for="lblStreet">Street</label>
                                <asp:TextBox class="form-control" id="idStreet" runat="server" placeholder="Enter street"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <label for="lblCity">City</label>
                                <asp:TextBox class="form-control" id="idCity" runat="server" placeholder="Enter city"></asp:TextBox>                            
                            </div>
                            <div class="form-group">
                                <label for="lblPostCode">Postcode</label>
                                <asp:TextBox class="form-control" id="idPostCode" runat="server" placeholder="Enter postcode"></asp:TextBox>                            
                            </div>
                            <div class="form-group">
                                <label for="lblPhoneNo">Phone No</label>
                                <asp:TextBox class="form-control" id="idPhoneNo" runat="server" placeholder="Enter phone no"></asp:TextBox>                            
                            </div>
                             <div class="form-group">
                                <label for="lblPassword1">Create password</label>
                                <asp:TextBox type="password" class="form-control" id="idPassword1" placeholder="Password" runat="server" TextMode="Password"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <label for="lblPassword2">Confirm password</label>
                                <asp:TextBox type="password" class="form-control" id="idPassword2" placeholder="Password" runat="server" TextMode="Password"></asp:TextBox>
                            </div>
                            
                            <asp:Button ID="btnSignUp" runat="server" Text="Sign-Up" OnClick="btnSignUp_Click" class="btn btn-primary"/>
                            
                            <asp:Label ID="lblError" runat="server"></asp:Label>
                        </form>

                        
                    </div>
                    
       </div>
    </div>

    <div class="footer-pad">  
    <p class="text-center"> © FUTBOOK 2023 </p>  
    </div>  

</body>
</html>
