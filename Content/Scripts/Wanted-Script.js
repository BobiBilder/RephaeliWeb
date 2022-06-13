    function checkSignIn() {
    var noError = checkFName() && checkLName() && checkID() && checkPass1() && checkEmail() && checkPhone();
    if (noError) {
        document.forms[1].submit();
    }
}

function checkFName() {
    var name = document.getElementById('fname').value;
    if (name == "") {
        document.getElementById("errorFname").style.visibility = "hidden";
        document.getElementById("emptyFname").style.visibility = "visible";
        return false;
    } else if (name != "") {
        document.getElementById("emptyFname").style.visibility = "hidden";
    }
    if (/\d/.test(name)) {
        document.getElementById("errorFname").style.visibility = "visible";
        return false;
    } else {
        document.getElementById("errorFname").style.visibility = "hidden";
    }
    return true;
}
function checkLName() {
    var name = document.getElementById('lname').value;
    if (name == "") {
        document.getElementById("errorLname").style.visibility = "hidden";
        document.getElementById("emptyLname").style.visibility = "visible";
        return false;
    } else if (name != "") {
        document.getElementById("emptyLname").style.visibility = "hidden";
    }
    if (/\d/.test(name)) {
        document.getElementById("errorLname").style.visibility = "visible";
        return false;
    } else {
        document.getElementById("errorLname").style.visibility = "hidden";
    }
    return true;
}
function checkID() {
    var id = document.getElementById('ID').value;
    if (id.length < 9) {
        document.getElementById("errorID1").style.visibility = "hidden";
        document.getElementById("emptyID1").style.visibility = "visible";
        return false;
    } else if (id.length == 9) {
        document.getElementById("emptyID1").style.visibility = "hidden";
    }
    if (/[a-z א-ת]/g.test(id)) {
        document.getElementById("errorID1").style.visibility = "visible";
        return false;
    } else {
        document.getElementById("errorID1").style.visibility = "hidden";
    }
    return true;
}
function checkEmail() {
    var email = document.getElementById('email').value;
    if (email == "") {
        document.getElementById("errorEmail").style.visibility = "hidden";
        document.getElementById("emptyEmail").style.visibility = "visible";
        return false;
    } else if (email != "") {
        document.getElementById("emptyEmail").style.visibility = "hidden";
    }
    var ampersandIndex = email.indexOf("@");
    var dotIndex = email.lastIndexOf(".");
    if ((dotIndex - ampersandIndex < 2 || ampersandIndex < 1) && email != "") {
        document.getElementById("errorEmail").style.visibility = "visible";
        return false;
    } else {
        document.getElementById("errorEmail").style.visibility = "hidden";
    }
    return true;
}
function checkPhone() {
    var phone = document.getElementById('phone').value;
    if (phone == "") {
        document.getElementById("errorPhone").style.visibility = "hidden";
        document.getElementById("emptyPhone").style.visibility = "visible";
        return false;
    } else if (phone != "") {
        document.getElementById("emptyPhone").style.visibility = "hidden";
        document.getElementById("errorPhone").style.visibility = "hidden";
    }
    if ((/[a-z א-ת]/g.test(phone) || phone.length != 10 || phone.charAt(0) != "0" || phone.charAt(1) != "5") && phone != "") {
        document.getElementById("errorPhone").style.visibility = "visible";
        return false;
    } else {
        document.getElementById("errorPhone").style.visibility = "hidden";
    }
    return true;
}
function checkPass1() {
    var pass = document.getElementById('pass1').value;
    if (pass.length < 7) {
        document.getElementById("emptyPass1").style.visibility = "visible";
        return false;
        return false;
    } else {
        document.getElementById("emptyPass1").style.visibility = "hidden";
        return true;
    }
    return false;
}

function checkAddition() {
    var noError = checkFName() && checkDescription() && checkPrice() && checkPicture() && checkFtype();
    if (noError) {
        document.forms[1].submit();
    }
}
function checkDescription() {
    var name = document.getElementById('fdescription').value;
    if (name == "") {
        document.getElementById("emptyFDescription").style.visibility = "visible";
        return false;
    } else if (name != "") {
        document.getElementById("emptyFDescription").style.visibility = "hidden";
    }
    return true;
}
function checkPrice() {
    var price = document.getElementById('fprice').value;
    if (price == "") {
        document.getElementById("errorFPrice").style.visibility = "hidden";
        document.getElementById("emptyFPrice").style.visibility = "visible";
        return false;
    } else if (price != "") {
        document.getElementById("emptyFPrice").style.visibility = "hidden";
    }
    if (/[a-z א-ת]/g.test(price)) {
        document.getElementById("errorFPrice").style.visibility = "visible";
        return false;
    } else {
        document.getElementById("errorFPrice").style.visibility = "hidden";
    }
    return true;
}
function checkFtype() {
    var types = document.getElementById("ftype");
    var type = types.options[types.selectedIndex].value;
    if (type == "0") {
        document.getElementById("emptyType").style.visibility = "visible";
        return false;
    } else {
        document.getElementById("emptyType").style.visibility = "hidden";
        return true;
    }
}
function checkPicture() {
    var picture = document.getElementById('fpicture').value;
    if (picture == "") {
        document.getElementById("emptyFPicture").style.visibility = "visible";
        return false;
    } else if (picture != "") {
        document.getElementById("emptyFPicture").style.visibility = "hidden";
    }
    return true;
}
