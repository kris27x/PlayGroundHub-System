
<!DOCTYPE html>
<html>
<head>
    <meta charset="utf-8" />
    <link href="CSS/FutBookStyle.css" rel="stylesheet" />
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@4.6.2/dist/css/bootstrap.min.css">
    <script src="https://cdn.jsdelivr.net/npm/jquery@3.6.1/dist/jquery.slim.min.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/popper.js@1.16.1/dist/umd/popper.min.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@4.6.2/dist/js/bootstrap.bundle.min.js"></script>
    <title>FutBook</title>
</head>
<body style="background-color:#ed3b3b;">

    <nav class="navbar navbar-expand-sm navbar-dark fixed-top">
      <!-- Brand -->
      <a class="navbar-brand" href="Default.aspx">FUTBOOK</a>

      <!-- Links -->
      <ul class="navbar-nav">
        <li class="nav-item">
          <a class="nav-link" href="Shop.aspx">SHOP</a>
        </li>
        
        <!-- Dropdown -->
        <li class="nav-item dropdown">
          <a class="nav-link dropdown-toggle" href="#" id="navbardrop" data-toggle="dropdown">
            BOOKINGS
          </a>
          <div class="dropdown-menu">
            <a class="dropdown-item" href="#">PITCH</a>
            <a class="dropdown-item" href="#">EVENT</a>
          </div>
        </li>

        <li class="nav-item">
          <a class="nav-link" href="SignUp.aspx">SIGN UP</a>
        </li>

        <li class="nav-item">
          <a class="nav-link" href="Login.aspx">LOG IN</a>
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
                        <form>
                            <div class="form-group">
                                <label for="lblEmail">Email address</label>
                                <input type="email" class="form-control" id="idEmail" aria-describedby="emailHelp" placeholder="Enter email">
                            </div>
                            <div class="form-group">
                                <label for="lblFirstName">First name</label>
                                <input type="firstName" class="form-control" id="idFirstName" placeholder="Enter email">
                            </div>
                            <div class="form-group">
                                <label for="lblLastName">Last name</label>
                                <input type="lastName" class="form-control" id="idLastName" placeholder="Enter email">
                            </div>
                            <div class="form-group">
                                <label for="lblAddress">Address</label>
                                <input type="address" class="form-control" id="idAddress" placeholder="Enter email">
                            </div>
                            <div class="form-group">
                                <label for="lblPhoneNo">PhoneNo</label>
                                <input type="phoneNo" class="form-control" id="idPhoneNo" placeholder="Enter email">
                            </div>
                            <div class="form-group">
                                <label for="lblPassword">Create password</label>
                                <input type="password" class="form-control" id="idPassword" placeholder="Password">
                            </div>
                            <div class="form-group">
                                <label for="lblPassword">Confirm password</label>
                                <input type="password" class="form-control" id="idPassword" placeholder="Password">
                            </div>
                            <button type="submit" class="btn btn-primary">SUBMIT</button>
                        </form>
                    </div>
                    
       </div>
    </div>

    <div class="footer-pad">  
    <p class="text-center"> © FUTBOOK 2023 </p>  
    </div>  





</body>
</html>