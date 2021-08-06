var amounts = document.getElementsByClassName('amount');
for (i = 0; i < amounts.length; i++) {
    if (amounts[i].innerHTML >= 0) {
        amounts[i].style.color = "green";
    }
    else {
        amounts[i].style.color = "red";
    }
}
function addAccountId() {
    let option = document.querySelector('#format');
    let button = document.getElementById("newTransaction");
    button.setAttribute("href", "/Transaction/Create/" + option.value);
    console.log(button);
}