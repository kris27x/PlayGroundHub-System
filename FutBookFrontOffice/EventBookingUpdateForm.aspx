<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EventBookingUpdateForm.aspx.cs" Inherits="FutBookFrontOffice.EventBookingUpdateForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <link href="CSS/FutBookStyle.css" rel="stylesheet" />
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@4.6.2/dist/css/bootstrap.min.css" />
    <script src="https://cdn.jsdelivr.net/npm/jquery@3.6.1/dist/jquery.slim.min.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/popper.js@1.16.1/dist/umd/popper.min.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@4.6.2/dist/js/bootstrap.bundle.min.js"></script>
    <link rel="stylesheet" href="https://code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css"/>
    <!-- jQuery UI -->
    <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.min.js"></script>



        <%-- function for calculating price per person with discount over 10 and 30 participants --%>

    <script>
        function updatePrice() {
            var participants = document.getElementById('Participants').value;
            var pricePerPerson;

            // Calculate the price per person based on the number of participants
            if (participants >= 3 && participants <= 10) {
                pricePerPerson = 20;
            } else if (participants > 10 && participants <= 30) {
                pricePerPerson = 18;
            } else {
                pricePerPerson = 15;
            }

            var price = participants * pricePerPerson;
            document.getElementById('lblPrice').innerHTML = "Total Price: £" + price;
        }
    </script>

    <title>FutBook</title>
</head>

<body>

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
    <br />


    <div class="logo">
        <img src="IMG/logoFutBook.png" />
    </div>

    <div class="container min-vh-100">

        
        <div class="row" style="border: none; margin-left: 0px; margin-top: 40px; color: #ffffff">
            <div class="col">
                <h1 class="text-center">ADMIN - UPDATE Event Booking</h1>
                <br />
            </div>

        </div>

        <div class="col">
                        
                        <form runat="server">
                            <div class="form-group">
                                <label for="lblEventName">Event Name:</label>
                                <asp:TextBox class="form-control" id="EventName" runat="server" placeholder="Enter Event Name"></asp:TextBox>
                            </div>
							<div class="form-group">
                                <label for="lblParticipants">Participants</label>
                                <input type="number" class="form-control" id="Participants" runat="server" min="3" max="50" step="1" value="2" oninput="updatePrice()" />
                            </div>
							<div class="form-group">
                                <label id="lblPrice" class="font-weight-bold">Total Price: £20</label>
                            </div>
                            <div class="form-group">
                                <label for="lblDate">Date</label>
                                <asp:TextBox class="form-control" id="EventDate" runat="server" placeholder="Select date" type="date"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <label for="lblSpecialRequests">Special Requests</label>
                                <asp:TextBox class="form-control" id="SpecialRequests" runat="server" placeholder="Enter special requests" TextMode="MultiLine"></asp:TextBox>
                            </div>
                                                      
                            
                            <asp:Button ID="btnUpdateEventBooking" runat="server" Text="Update Event Booking" OnClick="btnUpdateEventBooking_Click" class="myButton"/>
                            <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" class="myButton"/>
                            
                            <asp:Label ID="lblError" runat="server"></asp:Label>
                        </form>

                        
                    </div>     
        <br />
        <br />

    </div>

    <div class="footer-pad">
        <p class="text-center">© FUTBOOK 2023 </p>
    </div>
</body>
</html>
