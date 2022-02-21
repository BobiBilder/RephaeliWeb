function checkRequest() {

}
function checkName() {
    var name = document.getElementById('name').value;
    if (name == "") {
        document.getElementById("errorName").style.visibility = "hidden";
        document.getElementById("emptyName").style.visibility = "visible";
    } else if (name != "") {
        document.getElementById("emptyName").style.visibility = "hidden";
    }
    if (/\d/.test(name)) {
        document.getElementById("errorName").style.visibility = "visible";
    } else {
        document.getElementById("errorName").style.visibility = "hidden";
    }
}
function checkPhone() {
    var tel = document.getElementById('tel').value;
    if (tel == "") {
        document.getElementById("errorTel").style.visibility = "hidden";
        document.getElementById("emptyTel").style.visibility = "visible";
    } else if (tel != "") {
        document.getElementById("emptyTel").style.visibility = "hidden";
        document.getElementById("errorTel").style.visibility = "hidden";
    }
    if ((/[a-z א-ת]/g.test(tel) || tel.length != 10 || tel.charAt(0) != "0" || tel.chatAt(1) != "5") && tel != "") {
        document.getElementById("errorTel").style.visibility = "visible";
    } else {
        document.getElementById("errorTel").style.visibility = "hidden";
    }
}
function checkEvent() {
    var event = document.getElementById('event').value;
    if (event == "") {
        document.getElementById("emptyEvent").style.visibility = "visible";
    } else if (event != "") {
        document.getElementById("emptyEvent").style.visibility = "hidden";
    }
}
function checkUser() {
    var user = document.getElementById('user').value;
    if (user == "") {
        document.getElementById("errorUser").style.visibility = "hidden";
        document.getElementById("emptyUser").style.visibility = "visible";
    } else if (user != "") {
        document.getElementById("emptyUser").style.visibility = "hidden";
    }
    if (user.length < 2 && user != "") {
        document.getElementById("errorUser").style.visibility = "visible";
    } else {
        document.getElementById("errorUser").style.visibility = "hidden";
    }
}
function checkPass() {
    var pass = document.getElementById('pass').value;
    if (pass.length < 7) {
        document.getElementById("emptyPass").style.visibility = "visible";
    } else {
        document.getElementById("emptyPass").style.visibility = "hidden";
    }
}

function WorkAssign() {
    if (CheckAssign()) {
        document.forms[1].submit();
    }
}
function CheckAssign() {
    var orderID = document.getElementsByName("orderID");
    for (var i = 0; i < orderID.length; i++) {
        if (orderID[i].checked) {
            document.getElementById("emptyCheckbox").style.visibility = "hidden";
            return true;
        }
    }
    document.getElementById("emptyCheckbox").style.visibility = "visible";
    return false;
}

function Focus() {
    document.getElementById('dropdown-form').style.display= "block";
    document.getElementById('user').focus();
}