<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default_aut.aspx.cs" Inherits="FutBookFrontOffice.Default_aut" %>

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

            <!-- Dropdown for Admin -->
            <li class="nav-item dropdown">
                <asp:HyperLink ID="hypAdmin" runat="server" class="nav-link dropdown-toggle" data-toggle="dropdown" href="#">ADMIN</asp:HyperLink>
                <div class="dropdown-menu">
                    <a class="dropdown-item" href="ShopAdd.aspx">ADD STOCK</a>
                    <a class="dropdown-item" href="ShopUpdate.aspx">UPDATE STOCK</a>
                    <a class="dropdown-item" href="ShopDelete.aspx">DELETE STOCK</a>
                    <a class="dropdown-item" href="EventBookingUpdate.aspx">UPDATE EVENT</a>
                    <a class="dropdown-item" href="EventBookingDelete.aspx">CANCEL EVENT</a>
                </div>
            </li>

            <!-- Dropdown for Bookings -->
            <li class="nav-item dropdown">
                <a class="nav-link dropdown-toggle" href="#" id="navbardrop" data-toggle="dropdown">BOOKINGS</a>
                <div class="dropdown-menu">
                    <a class="dropdown-item" href="BookingPitch.aspx">PITCH</a>
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


        <asp:Label ID="lblGreeting" runat="server" class="nav-link ml-auto lblGreeting"></asp:Label>
    </nav>
    <br/>
  

    <div class="logo">
            <img src="IMG/logoFutBook.png" />
    </div>


    <div class="container min-vh-100" >
       <div class="row" style="border: none; margin-left: 0px; margin-top:40px; color:#ffffff">
                    <div class="col">
                        <h1 class="text-center">Welcome to FUTBOOK - indoor football!</h1>

                        <br />
                        <p>Futbook allows people to purchase football furniture, book a pitch for indoor sports, and even book special events such as birthday training sessions. We offering a wide range of products including football boots, balls, jerseys and accessories. Whether you're looking for a new pair of boots or a new jersey to show your support for your favorite team. We also offer a wide range of small 5-a-side indoor pitches for rent, as well as special event spaces for birthday training sessions and other events. Our website is easy to use, and allows users to quickly and easily book their desired pitches and buy furnitures. We look forward to helping you create the perfect football experience.</p>
                    
                    </div>
                    
            <img src="IMG/footballindoor.jpg" class="img-fluid rounded" alt="Responsive image" style="margin-bottom:40px;">

        </div>
    </div>

    <div class="footer-pad">  
    <p class="text-center"> © FUTBOOK 2023 </p>  
    </div>  
</body>
</html>

