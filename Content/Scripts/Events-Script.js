function checkRequest1() {
    var noError = checkName1() && checkPhone1() && checkEtype1() && checkGuests1() && checkDate1();
    if (noError) {
        document.forms[1].submit();
    }
}
function checkName1() {
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
function checkPhone1() {
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
function checkEtype1() {
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
function checkGuests1() {
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
function checkDate1() {
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


function SelectYear1() {
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
function SelectMonth1() {
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

function checkRequest2(orderCounter) {
    var noError = checkName2(orderCounter) && checkPhone2(orderCounter) && checkEtype2(orderCounter) && checkGuests2(orderCounter) && checkDate2(orderCounter);
    if (noError) {
        document.forms["EventForm_" + orderCounter].submit();
    }
}
function deleteRequest(orderCounter) {
    document.forms["EventForm_" + orderCounter].submit();
}
function checkName2(orderCounter) {
    var name = document.getElementById("name_" + orderCounter).value;
    if (name == "") {
        document.getElementById("errorName_" + orderCounter).style.visibility = "hidden";
        document.getElementById("emptyName_" + orderCounter).style.visibility = "visible";
        return false;
    } else if (name != "") {
        document.getElementById("emptyName_" + orderCounter).style.visibility = "hidden";
    }
    if (/\d/.test(name)) {
        document.getElementById("errorName_" + orderCounter).style.visibility = "visible";
        return false;
    } else {
        document.getElementById("errorName_" + orderCounter).style.visibility = "hidden";
    }
    return true;
}
function checkPhone2(orderCounter) {
    var phone = document.getElementById("phone_" + orderCounter).value;
    if (phone == "") {
        document.getElementById("errorTel_" + orderCounter).style.visibility = "hidden";
        document.getElementById("emptyTel_" + orderCounter).style.visibility = "visible";
        return false;
    } else if (phone != "") {
        document.getElementById("emptyTel_" + orderCounter).style.visibility = "hidden";
        document.getElementById("errorTel_" + orderCounter).style.visibility = "hidden";
    }
    if ((/[a-z א-ת]/g.test(phone) || phone.length != 10 || phone.charAt(0) != "0" || phone.charAt(1) != "5") && phone != "") {
        document.getElementById("errorTel_" + orderCounter).style.visibility = "visible";
        return false;
    } else {
        document.getElementById("errorTel_" + orderCounter).style.visibility = "hidden";
    }
    return true;
}
function checkEtype2(orderCounter) {
    var events = document.getElementById("event_" + orderCounter);
    var event = events.options[events.selectedIndex].value;
    if (event == "0") {
        document.getElementById("emptyEvent_" + orderCounter).style.visibility = "visible";
        return false;
    } else {
        document.getElementById("emptyEvent_" + orderCounter).style.visibility = "hidden";
        return true;
    }
}
function checkGuests2(orderCounter) {
    var guests = document.getElementById("Guests_" + orderCounter).value;
    if (guests == "") {
        document.getElementById("errorGuests_" + orderCounter).style.visibility = "hidden";
        document.getElementById("emptyGuests_" + orderCounter).style.visibility = "visible";
        return false;
    } else if (guests != "") {
        document.getElementById("emptyGuests_" + orderCounter).style.visibility = "hidden";
    }
    if (/[a-z א-ת]/g.test(guests)) {
        document.getElementById("errorGuests_" + orderCounter).style.visibility = "visible";
        return false;
    } else {
        document.getElementById("errorGuests_" + orderCounter).style.visibility = "hidden";
    }
    return true;
}
function checkDate2(orderCounter) {
    var sum = 0;
    var selected = document.getElementsByClassName("date-day_" + orderCounter);
    for (var i = 0; i < 4; i++) {
        sum += parseInt(selected[i].options[selected[i].selectedIndex].value);
    }
    if (sum == 0) {
        document.getElementById("emptyDate_" + orderCounter).style.visibility = "visible";
        return false;
    }
    else {
        document.getElementById("emptyDate_" + orderCounter).style.visibility = "hidden";
        return true;
    }
}


function SelectYear2(orderCounter) {
    document.getElementById("short-day-date_" + orderCounter).style.display = "none";
    document.getElementById("feb-day-date_" + orderCounter).style.display = "none";
    document.getElementById("long-day-date_" + orderCounter).style.display = "none";
    document.getElementById("current-day-date_" + orderCounter).style.display = "none";
    var years = document.getElementById("year_" + orderCounter);
    var selectedYear = years.options[years.selectedIndex].value;
    var date = new Date();
    var currentYear = date.getFullYear();
    if (selectedYear == currentYear) {
        document.getElementById("other-month-date_" + orderCounter).style.display = "none";
        document.getElementById("current-month-date_" + orderCounter).style.display = "block";
    }
    else {
        document.getElementById("current-month-date_" + orderCounter).style.display = "none";
        document.getElementById("other-month-date_" + orderCounter).style.display = "block";
    }
}
function SelectMonth2(orderCounter) {
    var years = document.getElementById("year_" + orderCounter);
    var selectedYear = years.options[years.selectedIndex].value;
    var date = new Date();
    var currentYear = date.getFullYear();
    if (selectedYear == currentYear) {
        var months = document.getElementById("current-month_" + orderCounter);
    }
    else {
        var months = document.getElementById("other-month_" + orderCounter);
    }
    var selectedMonth = months.options[months.selectedIndex].value;
    var currentMonth = date.getMonth() + 1;
    if (selectedMonth == currentMonth && selectedYear == currentYear) {
        document.getElementById("short-day-date_" + orderCounter).style.display = "none";
        document.getElementById("feb-day-date_" + orderCounter).style.display = "none";
        document.getElementById("long-day-date_" + orderCounter).style.display = "none";
        document.getElementById("current-day-date_" + orderCounter).style.display = "block";
    }
    else if (selectedMonth == 1 || selectedMonth == 3 || selectedMonth == 5 || selectedMonth == 7 || selectedMonth == 8 || selectedMonth == 10 || selectedMonth == 12) {
        document.getElementById("short-day-date_" + orderCounter).style.display = "none";
        document.getElementById("feb-day-date_" + orderCounter).style.display = "none";
        document.getElementById("current-day-date_" + orderCounter).style.display = "none";
        document.getElementById("long-day-date_" + orderCounter).style.display = "block";
    }
    else if (selectedMonth == 4 || selectedMonth == 6 || selectedMonth == 9 || selectedMonth == 11) {
        document.getElementById("feb-day-date_" + orderCounter).style.display = "none";
        document.getElementById("long-day-date_" + orderCounter).style.display = "none";
        document.getElementById("current-day-date_" + orderCounter).style.display = "none";
        document.getElementById("short-day-date_" + orderCounter).style.display = "block";
    }
    else {
        document.getElementById("short-day-date_" + orderCounter).style.display = "none";
        document.getElementById("long-day-date_" + orderCounter).style.display = "none";
        document.getElementById("current-day-date_" + orderCounter).style.display = "none";
        document.getElementById("feb-day-date_" + orderCounter).style.display = "block";
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