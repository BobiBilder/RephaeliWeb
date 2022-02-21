function Login() {
    var noError = (CheckUser() && CheckPass());
    if (noError) {
        document.getElementById('dropdown-form').style.display = "none";
        document.forms[0].submit();
    }
}

function CheckUser() {
    var user = document.getElementById('user').value;
    if (user == "") {
        document.getElementById("errorUser").style.visibility = "hidden";
        document.getElementById("emptyUser").style.visibility = "visible";
        return false;
    } else if (user != "") {
        document.getElementById("emptyUser").style.visibility = "hidden";
    }
    if (user.length != 9 && user != "") {
        document.getElementById("errorUser").style.visibility = "visible";
        return false;
    } else {
        document.getElementById("errorUser").style.visibility = "hidden";
    }
    return true;
}

function CheckPass() {
    var pass = document.getElementById('pass').value;
    if (pass.length < 7) {
        document.getElementById("emptyPass").style.visibility = "visible";
        return false;
    } else {
        document.getElementById("emptyPass").style.visibility = "hidden";
        return true;
    }
}