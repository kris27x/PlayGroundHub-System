<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ShopHome.aspx.cs" Inherits="FutBookFrontOffice.ShopHome" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <link href="CSS/FutBookStyle.css" rel="stylesheet" />
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@4.6.2/dist/css/bootstrap.min.css" />
    <script src="https://cdn.jsdelivr.net/npm/jquery@3.6.1/dist/jquery.slim.min.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/popper.js@1.16.1/dist/umd/popper.min.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@4.6.2/dist/js/bootstrap.bundle.min.js"></script>
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

        <div id="mySidebar" class="sidebar">
            <a href="javascript:void(0)" class="closebtn" onclick="closeNav()">x</a>

            <asp:Panel ID="categoryLinks" runat="server">
                <!-- The category links will be added by the DisplayStockItems method in the code-behind -->
            </asp:Panel>
        </div>

        

        <script>
            function openNav() {
                document.getElementById("mySidebar").style.width = "250px";
                document.getElementById("main").style.marginLeft = "250px";
            }

            function closeNav() {
                document.getElementById("mySidebar").style.width = "0";
                document.getElementById("main").style.marginLeft = "0";
            }

            $(document).ready(function () {
                $('.category-link').click(function () {
                    let category = $(this).data('category');
                    if (category === 'all') {
                        $('#all-products .col-sm-4').show();
                    } else {
                        $('#all-products .col-sm-4').each(function () {
                            const productCategory = $(this).find('.thumbnail a').data('category');
                            if (productCategory === category) {
                                $(this).show();
                            } else {
                                $(this).hide();
                            }
                        });
                    }
                });

                $('.myButton').click(function () {
                    const searchTerm = $('#product').val().toLowerCase();
                    $('.product-category').each(function () {
                        $(this).find('.col-sm-4').each(function () {
                            const productName = $(this).find('h5').text().toLowerCase();
                            if (productName.includes(searchTerm)) {
                                $(this).show();
                            } else {
                                $(this).hide();
                            }
                        });
                    });
                });

                $('.thumbnail').click(function (event) {                    
                    const extraDescription = $(this).find('.extra-description');
                    if (extraDescription.is(':visible')) {
                        extraDescription.hide();
                    } else {
                        extraDescription.show();
                    }
                });

            });

        </script>

        <div class="row" style="border: none; margin-left: 0px; margin-top: 40px; color: #ffffff">
            <div class="col">
                <h1 class="text-center">Welcome to FUTBOOK SHOP!</h1>
                <br />
            </div>

        </div>

        <div class="search text-center">
            <label for="product"><b style="color: #fff">SEARCH PRODUCT :</b> </label>
            <input type="text" id="product" name="product" />
            <input type="submit" class="myButton" value="SUBMIT" />
        </div>

        <br />
        <br />

        <div id="main">
            <button class="openbtn" onclick="openNav()">☰ Show categories</button>
            <p style="color:white;">Click on the button above to see the categories.</p>
        </div>

        <br />



        <div id="stockItemsContainer" runat="server"></div>



    </div>



    <div class="footer-pad">
        <p class="text-center">© FUTBOOK 2023 </p>
    </div>
</body>
</html>

