function updateAmount() {
    let result = 0;
    let amountsD = document.getElementsByClassName('depot');
    let amountsR = document.getElementsByClassName('retrait');
    for (i = 0; i < amountsD.length; i++) {
        result += parseFloat(amountsD[i].innerHTML.replace(",","."), 10);
        console.log(parseFloat(amountsD[i].innerHTML.replace(",", "."), 10));
    }
    for (i = 0; i < amountsR.length; i++) {
        result += parseFloat(amountsR[i].innerHTML.replace(",", "."), 10);
        console.log(parseFloat(amountsR[i].innerHTML.replace(",", "."), 10));
    }
    console.log(result);
    document.getElementById('total').innerHTML = 'BALANCE : ' + result;
}

function GetByAjax() {
    let option = document.querySelector('#format');
    if (option.value == 0) {
        document.getElementById("newTransaction").style.pointerEvents = "none";

    }
    else {
        document.getElementById("newTransaction").style.pointerEvents = "auto";
    }
    $.ajax({
        url: "/Transaction/Movements",
        type: "GET",
        data: { id: option.value },
        dataType: "html",
        success: function (response) {
            $("#transact-table").html(response);
            updateAmount();
        }
    });
    
}

function PostByAjax() {
    let option = document.querySelector('#format');
    let description = document.getElementById('Description');
    let expense = $('#ExpenseOrIncome').prop('checked') == true ? "true" : "false";
    let amount = document.getElementById('Amount');
    let categories = $('#Categories').val();
    let formData = new FormData();

    formData.append("UserAccountId", option.options[option.selectedIndex].value);
    formData.append("Description", description.value);
    formData.append("ExpenseOrIncome", expense);
    formData.append("Amount", amount.value);
    formData.append("CategoryId", categories);
    $.ajax({
        url: '/Transaction/Create',
        type: 'POST',
        cache: false,
        contentType: false,
        processData: false,
        data: formData,
        success: function (response) {
            const modal = document.querySelector('#transactWindow');
            closeModal(modal);
            GetByAjax();
        }
    });
}

