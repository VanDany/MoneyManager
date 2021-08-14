function updateAmount() {
    let result = 0;
    let amountsD = document.getElementsByClassName('depot');
    let amountsR = document.getElementsByClassName('retrait');
    for (i = 0; i < amountsD.length; i++) {
        result += parseFloat(amountsD[i].innerHTML.replace(",","."), 10);
    }
    for (i = 0; i < amountsR.length; i++) {
        result += parseFloat(amountsR[i].innerHTML.replace(",", "."), 10);
    }
    document.getElementById('total').innerHTML = 'BALANCE : ' + result;
}
//Call the following page
function GetByAjax() {
    page++;
    CallAjax(page);
}
//Call the first page
function GetByAjaxChange() {

    page = 1;
    CallAjax(page);
}
//Call with selected number of pages
function GetByAjaxCurrentPage(page) {

    CallAjax(page);
}
//Call the previous page
function GetByAjaxMoins() {

    page--;
    if (page < 1) {
        page = 1;
    }
    CallAjax(page);
}

function CallAjax(pageNum) {
    if (page == 1) {
        document.getElementById("PageMoinsButton").style.display = "none";
    }
    else {
        document.getElementById("PageMoinsButton").style.display = "block";
    }
    let option = document.querySelector('#format');
    if (option.value == 0) {
        document.getElementById("newTransaction").style.pointerEvents = "none";

    }
    else {
        document.getElementById("newTransaction").style.pointerEvents = "auto";
    }
    rowsSelected = document.getElementById("selectRows").value;
    console.log(rowsSelected);
    $.ajax({
        url: "/Transaction/Movements",
        type: "GET",
        data: { id: option.value, rows: rowsSelected, pageNumber: pageNum },
        dataType: "html",
        success: function (response){
            $("#transact-table").html(response);
            //Update amount only when it's page 1 with 'tout' number of pages !
            if (page == 1 && rowsSelected == 30000) {
                updateAmount();
            }
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
            GetByAjaxChange();
        }
    });
}

