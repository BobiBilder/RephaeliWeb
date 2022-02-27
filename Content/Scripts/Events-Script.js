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

function SelectYear() {
    document.getElementById('short-day-date').style.display = "none";
    document.getElementById('feb-day-date').style.display = "none";
    document.getElementById('long-day-date').style.display = "none";
    document.getElementById('current-day-date').style.display = "none";
    var years = document.getElementById('year');
    var selectedYear = years.options[years.selectedIndex].value;
    var date = new Date();
    var currentYear = date.getFullYear();
    if (selectedYear == currentYear) {
        document.getElementById('other-month-date').style.display = "none";
        document.getElementById('current-month-date').style.display = "block";
    } else {
        document.getElementById('current-month-date').style.display = "none";
        document.getElementById('other-month-date').style.display = "block";
    }
}

function SelectMonth() {
    var years = document.getElementById('year');
    var selectedYear = years.options[years.selectedIndex].value;
    var date = new Date();
    var currentYear = date.getFullYear();
    if (selectedYear == currentYear) {
        var months = document.getElementById('current-month');
    } else {
        var months = document.getElementById('other-month');
    }
    var selectedMonth = months.options[months.selectedIndex].value;
    var currentMonth = date.getMonth() + 1;
    if (selectedMonth == currentMonth && selectedYear == currentYear) {
        document.getElementById('short-day-date').style.display = "none";
        document.getElementById('feb-day-date').style.display = "none";
        document.getElementById('long-day-date').style.display = "none";
        document.getElementById('current-day-date').style.display = "block";
    } else if (selectedMonth == 1 || selectedMonth == 3 || selectedMonth == 5 || selectedMonth == 7 || selectedMonth == 8 || selectedMonth == 10 || selectedMonth == 12) {
        document.getElementById('short-day-date').style.display = "none";
        document.getElementById('feb-day-date').style.display = "none";
        document.getElementById('current-day-date').style.display = "none";
        document.getElementById('long-day-date').style.display = "block";
    } else if (selectedMonth == 4 || selectedMonth == 6 || selectedMonth == 9 || selectedMonth == 11) {
        document.getElementById('long-day-date').style.display = "none";
        document.getElementById('feb-day-date').style.display = "none";
        document.getElementById('current-day-date').style.display = "none";
        document.getElementById('short-day-date').style.display = "block";
    } else{
        document.getElementById('long-day-date').style.display = "none";
        document.getElementById('short-day-date').style.display = "none";
        document.getElementById('current-day-date').style.display = "none";
        document.getElementById('feb-day-date').style.display = "block";
    }
}