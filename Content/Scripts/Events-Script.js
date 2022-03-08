function checkRequest() {
    var noError = checkName() && checkPhone() && checkEtype() && checkGuests() && checkDate();
    if (noError) {
        document.forms[1].submit();
    }
}
function checkName() {
    var name = document.getElementById('name').value;
    if (name == "") {
        document.getElementById("errorName").style.visibility = "hidden";
        document.getElementById("emptyName").style.visibility = "visible";
        return false;
    } else if (name != "") {
        document.getElementById("emptyName").style.visibility = "hidden";
    }
    if (/\d/.test(name)) {
        document.getElementById("errorName").style.visibility = "visible";
        return false;
    } else {
        document.getElementById("errorName").style.visibility = "hidden";
    }
    return true;
}
function checkPhone() {
    var phone = document.getElementById('phone').value;
    if (phone == "") {
        document.getElementById("errorTel").style.visibility = "hidden";
        document.getElementById("emptyTel").style.visibility = "visible";
        return false;
    } else if (phone != "") {
        document.getElementById("emptyTel").style.visibility = "hidden";
        document.getElementById("errorTel").style.visibility = "hidden";
    }
    if ((/[a-z א-ת]/g.test(phone) || phone.length != 10 || phone.charAt(0) != "0" || phone.charAt(1) != "5") && phone != "") {
        document.getElementById("errorTel").style.visibility = "visible";
        return false;
    } else {
        document.getElementById("errorTel").style.visibility = "hidden";
    }
    return true;
}
function checkEtype() {
    var events = document.getElementById("event");
    var event = events.options[events.selectedIndex].value;
    if (event == "0") {
        document.getElementById("emptyEvent").style.visibility = "visible";
        return false;
    } else {
        document.getElementById("emptyEvent").style.visibility = "hidden";
        return true;
    }
}
function checkGuests() {
    var guests = document.getElementById('Guests').value;
    if (guests == "") {
        document.getElementById("errorGuests").style.visibility = "hidden";
        document.getElementById("emptyGuests").style.visibility = "visible";
        return false;
    } else if (guests != "") {
        document.getElementById("emptyGuests").style.visibility = "hidden";
    }
    if (/[a-z א-ת]/g.test(guests)) {
        document.getElementById("errorGuests").style.visibility = "visible";
        return false;
    } else {
        document.getElementById("errorGuests").style.visibility = "hidden";
    }
    return true;
}
function checkDate() {
    var sum = 0;
    var selected = document.getElementsByClassName('date-day');
    for (var i = 0; i < 4; i++) {
        sum += parseInt(selected[i].options[selected[i].selectedIndex].value);
    }
    if (sum == 0) {
        document.getElementById("emptyDate").style.visibility = "visible";
        return false;
    }
    else {
        document.getElementById("emptyDate").style.visibility = "hidden";
        return true;
    }
}

function Focus() {
    document.getElementById('dropdown-form').style.display= "block";
    document.getElementById('user').focus();
}

$("document").ready(
    function () {
        $(".date-month").click(function () {
            $('.date-day').prop('selectedIndex', 0);
        });

        $(".date-year").click(function () {
            $('.date-month').prop('selectedIndex', 0);
            $('.date-day').prop('selectedIndex', 0);
        });
    }
);
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
    }
    else {
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
    }
    else {
        var months = document.getElementById('other-month');
    }
    var selectedMonth = months.options[months.selectedIndex].value;
    var currentMonth = date.getMonth() + 1;
    if (selectedMonth == currentMonth && selectedYear == currentYear) {
        document.getElementById('short-day-date').style.display = "none";
        document.getElementById('feb-day-date').style.display = "none";
        document.getElementById('long-day-date').style.display = "none";
        document.getElementById('current-day-date').style.display = "block";
    }
    else if (selectedMonth == 1 || selectedMonth == 3 || selectedMonth == 5 || selectedMonth == 7 || selectedMonth == 8 || selectedMonth == 10 || selectedMonth == 12) {
        document.getElementById('short-day-date').style.display = "none";
        document.getElementById('feb-day-date').style.display = "none";
        document.getElementById('current-day-date').style.display = "none";
        document.getElementById('long-day-date').style.display = "block";
    }
    else if (selectedMonth == 4 || selectedMonth == 6 || selectedMonth == 9 || selectedMonth == 11) {
        document.getElementById('long-day-date').style.display = "none";
        document.getElementById('feb-day-date').style.display = "none";
        document.getElementById('current-day-date').style.display = "none";
        document.getElementById('short-day-date').style.display = "block";
    }
    else {
        document.getElementById('long-day-date').style.display = "none";
        document.getElementById('short-day-date').style.display = "none";
        document.getElementById('current-day-date').style.display = "none";
        document.getElementById('feb-day-date').style.display = "block";
    }
}




function WorkAssign() {
    if (CheckAssign()) {
        document.forms[1].submit();
    }
}
function CheckAssign() {
    var EventID = document.getElementsByName("EventID");
    for (var i = 0; i < orderID.length; i++) {
        if (EventID[i].checked) {
            document.getElementById("emptyCheckbox").style.visibility = "hidden";
            return true;
        }
    }
    document.getElementById("emptyCheckbox").style.visibility = "visible";
    return false;
}
