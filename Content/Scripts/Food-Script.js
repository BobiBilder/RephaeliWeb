function checkOrder() {
    var noError = false;
    if (noError) {
        document.forms[1].submit();
    }
}


function OrderSupply() {
    if (CheckAssign()) {
        document.forms[1].submit();
    }
}
function CheckAssign() {
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