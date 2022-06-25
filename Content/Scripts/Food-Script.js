function checkOrder() {
    var noError = false;
    if (noError) {
        document.forms[1].submit();
    }
}


function OrderSupply() {
    if (CheckAssign1()) {
        document.forms[1].submit();
    }
}
function CheckAssign1() {
    var foodID = document.getElementsByName("FoodID");
    for (var i = 0; i < foodID.length; i++) {
        if (foodID[i].checked) {
            document.getElementById("emptyCheckbox").style.visibility = "hidden";
            return true;
        }
    }
    document.getElementById("emptyCheckbox").style.visibility = "visible";
    return false;
}

function DeleteOrderSupply() {
    if (CheckAssign2()) {
        document.forms[1].submit();
    }
}
function CheckAssign2() {
    var orderID = document.getElementsByName("OrderID");
    for (var i = 0; i < orderID.length; i++) {
        if (orderID[i].checked) {
            document.getElementById("emptyCheckbox").style.visibility = "hidden";
            return true;
        }
    }
    document.getElementById("emptyCheckbox").style.visibility = "visible";
    return false;
}