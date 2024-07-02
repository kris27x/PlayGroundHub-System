<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ShopAdmin.aspx.cs" Inherits="FutBookFrontOffice.ShopAdmin" %>

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
                <asp:HyperLink ID="hypShop" runat="server" class="nav-link" NavigateUrl="~/ShopAdmin.aspx">SHOP</asp:HyperLink>
            </li>

            <li class="nav-item">
                <asp:HyperLink ID="hypAddStock" runat="server" class="nav-link" NavigateUrl="~/ShopAdd.aspx">ADD STOCK</asp:HyperLink>
            </li>

            <li class="nav-item">
                <asp:HyperLink ID="hypUpdateStock" runat="server" class="nav-link" NavigateUrl="~/ShopUpdate.aspx">UPDATE STOCK</asp:HyperLink>
            </li>

            <li class="nav-item ml-auto">
                <asp:HyperLink ID="hypDeleteStock" runat="server" class="nav-link" NavigateUrl="~/ShopDelete.aspx">DELETE STOCK</asp:HyperLink>
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
            <a href="#" class="category-link" data-category="all">Show all</a>
            <a href="#" class="category-link" data-category="shirts">Shirts</a>
            <a href="#" class="category-link" data-category="bottoms">Bottoms</a>
            <a href="#" class="category-link" data-category="boots">Boots</a>
            <a href="#" class="category-link" data-category="other">Other equipment</a>
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
                        $('.product-category').show();
                    } else {
                        $('.product-category').hide();
                        $('#category-' + category).show();
                    }
                });

                $('.myButton').click(function () {
                    const searchTerm = $('#product').val().toLowerCase();
                    $('.product-category').each(function () {
                        $(this).find('.thumbnail').each(function () {
                            const productName = $(this).find('p').text().toLowerCase();
                            if (productName.includes(searchTerm)) {
                                $(this).show();
                            } else {
                                $(this).hide();
                            }
                        });
                    });
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
            <p>Click on the button above to see the categories.</p>
        </div>

        <br />


        <asp:Repeater ID="productRepeater" runat="server">
            <ItemTemplate>
                <div class="col-sm-4">
                    <div class="thumbnail">
                        <a href="#">
                            <img src='data:image/png;base64,<%# Convert.ToBase64String((byte[])Eval("StockImage")) %>' alt='<%# Eval("StockName") %>' />
                            <p><strong><%# Eval("StockName") %></strong></p>
                            <p><%# Eval("StockPrice", "{0:C}") %></p>
                            <p><%# Eval("StockCategory") %></p>
                        </a>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>


        <div class="row text-center product-category" id="category-shirts">
            <div class="col-sm-4">
                <div class="thumbnail">
                    <a href="ShopDescription.aspx">
                        <img src="IMG/tshirtRM.jpg" alt="T-shirt Real Madrid">
                        <p><strong>T-shirt Real Madrid</strong></p>
                    </a>
                </div>
            </div>
            <div class="col-sm-4">
                <div class="thumbnail">
                    <a href="#">
                        <img src="IMG/tshirtRM.jpg" alt="T-shirt Real Madrid">
                        <p><strong>T-shirt Real Madrid</strong></p>
                    </a>
                </div>
            </div>
            <div class="col-sm-4">
                <div class="thumbnail">
                    <a href="#">
                        <img src="IMG/tshirtRM.jpg" alt="T-shirt Real Madrid">
                        <p><strong>T-shirt Real Madrid</strong></p>
                    </a>
                </div>
            </div>
        </div>

        <div class="row text-center product-category" id="category-bottoms">
            <div class="col-sm-4">
                <div class="thumbnail">
                    <a href="#">
                        <img src="IMG/bottomsLFC.jpg" alt="Shorts Leicester City">
                        <p><strong>Shorts Leicester City</strong></p>
                    </a>
                </div>
            </div>
            <div class="col-sm-4">
                <div class="thumbnail">
                    <a href="#">
                        <img src="IMG/bottomsLFC.jpg" alt="Shorts Leicester City">
                        <p><strong>Shorts Leicester City</strong></p>
                    </a>
                </div>
            </div>
            <div class="col-sm-4">
                <div class="thumbnail">
                    <a href="#">
                        <img src="IMG/bottomsLFC.jpg" alt="Shorts Leicester City">
                        <p><strong>Shorts Leicester City</strong></p>
                    </a>
                </div>
            </div>
        </div>

        <div class="row text-center product-category" id="category-boots">
            <div class="col-sm-4">
                <div class="thumbnail">
                    <a href="#">
                        <img src="IMG/boots.jpg" alt="Dream Pair Football Boots">
                        <p><strong>Dream Pair Football Boots</strong></p>
                    </a>
                </div>
            </div>
            <div class="col-sm-4">
                <div class="thumbnail">
                    <a href="#">
                        <img src="IMG/boots.jpg" alt="Dream Pair Football Boots">
                        <p><strong>Dream Pair Football Boots</strong></p>
                    </a>
                </div>
            </div>
            <div class="col-sm-4">
                <div class="thumbnail">
                    <a href="#">
                        <img src="IMG/boots.jpg" alt="Dream Pair Football Boots">
                        <p><strong>Dream Pair Football Boots</strong></p>
                    </a>
                </div>
            </div>
        </div>

        <div class="row text-center product-category" id="category-other">
            <div class="col-sm-4">
                <div class="thumbnail">
                    <a href="#">
                        <img src="IMG/ballWC14.jpg" alt="Football World Cup 2014">
                        <p><strong>Football World Cup 2014</strong></p>
                    </a>
                </div>
            </div>
            <div class="col-sm-4">
                <div class="thumbnail">
                    <a href="#">
                        <img src="IMG/ballWC14.jpg" alt="Football World Cup 2014">
                        <p><strong>Football World Cup 2014</strong></p>
                    </a>
                </div>
            </div>
            <div class="col-sm-4">
                <div class="thumbnail">
                    <a href="#">
                        <img src="IMG/ballWC14.jpg" alt="Football World Cup 2014">
                        <p><strong>Football World Cup 2014</strong></p>
                    </a>
                </div>
            </div>
        </div>





    </div>



    <div class="footer-pad">
        <p class="text-center">© FUTBOOK 2023 </p>
    </div>
</body>
</html>
