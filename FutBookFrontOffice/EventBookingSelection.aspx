<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EventBookingSelection.aspx.cs" Inherits="FutBookFrontOffice.EventBookingSelection" %>

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
<%--        <li class="nav-item">
          <asp:HyperLink ID="hypShop" runat="server" class="nav-link" NavigateUrl="~/ShopHome.aspx">SHOP</asp:HyperLink>
        </li>
        <li class="nav-item">
                <asp:HyperLink ID="hypAddStock" runat="server" class="nav-link" NavigateUrl="~/ShopAdd.aspx">ADD STOCK</asp:HyperLink>
            </li>

            <li class="nav-item">
                <asp:HyperLink ID="hypUpdateStock" runat="server" class="nav-link" NavigateUrl="~/ShopUpdate.aspx">UPDATE STOCK</asp:HyperLink>
            </li>

            <li class="nav-item ml-auto">
                <asp:HyperLink ID="hypDeleteStock" runat="server" class="nav-link" NavigateUrl="~/ShopDelete.aspx">DELETE STOCK</asp:HyperLink>
            </li>--%>
        
        <!-- Dropdown -->
        <li class="nav-item dropdown">
          <a class="nav-link dropdown-toggle" href="#" id="navbardrop" data-toggle="dropdown">
            BOOKINGS
          </a>
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


    <div class="container min-vh-100">
    <div class="row" style="border: none; margin-left: 0px; margin-top:40px; color:#ffffff">
        <div class="col">
            <h1 class="text-center">Welcome to FUTBOOK - indoor football! You are on the manage booking event page please select what you need to do.</h1>
            <br />

            <form runat="server">
            <!-- Add your buttons here -->
            <div class="d-flex flex-column align-items-center">
                
                <a href="EventBooking.aspx" class="btn btn-primary btn-lg mb-3 w-50">Make a Booking</a>

<%--                <a href="EventBookingUpdate.aspx" class="btn btn-secondary btn-lg mb-3 w-50">Update Booking</a>
                <a href="EventBookingDelete.aspx" class="btn btn-success btn-lg w-50">Cancel Existing Booking</a>--%>

<%--                <asp:LinkButton ID="btnUpdateBooking" runat="server" Text="Update Booking" CssClass="btn btn-secondary btn-lg mb-3 w-50" PostBackUrl="~/EventBookingUpdate.aspx" />--%>

<%--                <asp:LinkButton ID="btnCancelBooking" runat="server" Text="Cancel Existing Booking" CssClass="btn btn-success btn-lg w-50" PostBackUrl="~/EventBookingDelete.aspx" />--%>

                    
                  <asp:HyperLink ID="hypbtnCancelBooking" runat="server" class="btn btn-secondary btn-lg mb-3 w-50" NavigateUrl="~/EventBookingDelete.aspx">Update Booking</asp:HyperLink>

                 <asp:HyperLink ID="hypbtnUpdateBooking" runat="server" class="btn btn-success btn-lg w-50" NavigateUrl="~/EventBookingUpdate.aspx">Update Booking</asp:HyperLink>



                </form>
            </div>
        </div>
    </div>
</div>


    <div class="footer-pad">  
    <p class="text-center"> © FUTBOOK 2023 </p>  
    </div>  
</body>
</html>