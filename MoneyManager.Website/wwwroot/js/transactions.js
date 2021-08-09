function GetByAjax() {
    let option = document.querySelector('#format');
    $.ajax({
        url: "/Transaction/Movements",
        type: "GET",
        data: { id: option.value },
        dataType: "html",
        success: function (response) {
            $("#transact-table").html(response);
        }
    });
    updateAmount();
}
    function updateAmount() {
        let result = 0;
        let amountsD = document.getElementsByClassName('depot');
        let amountsR = document.getElementsByClassName('retrait');
        for (i = 0; i < amountsD.length; i++) {
            result += parseInt(amountsD[i].innerHTML, 10);
        }
        for (i = 0; i < amountsR.length; i++) {
            result += parseInt(amountsR[i].innerHTML, 10);
        }
        document.getElementById('total').innerHTML = result;
    }

