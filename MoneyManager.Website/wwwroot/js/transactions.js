var amounts = document.getElementsByClassName('amount');
for (i = 0; i < amounts.length; i++) {
    if (amounts[i].innerHTML >= 0) {
        amounts[i].style.color = "green";
    }
    else {
        amounts[i].style.color = "red";
    }
}
function colorizeAmount() {
    var amounts = document.getElementsByClassName('amount');
    console.log(amounts);
    for (i = 0; i < amounts.length; i++) {
        if (amounts[i].innerHTML >= 0) {
            amounts[i].style.color = "green";
        }
        else {
            amounts[i].style.color = "red";
        }
    }
}
