const openModalbuttons = document.querySelectorAll('[data-transactWindow-target]');
const closeModalbuttons = document.querySelectorAll('[data-close-button]');
const overlay = document.getElementById('overlay');
openModalbuttons.forEach(button => {
    button.addEventListener('click', () => {
        const modal = document.querySelector('#transactWindow');
        openModal(modal);
    })
})

closeModalbuttons.forEach(button => {
    button.addEventListener('click', () => {
        const modal = button.closest('#transactWindow');
        closeModal(modal);
    })
})
function openModal(modal) {
    if (modal == null) return
    modal.classList.add('active');
    overlay.classList.add('active');
    //$.ajax({
    //    url: '@Url.Action("GetByAccount")',
    //    type: "POST",
    //    data: { id: option.value },
    //    dataType: "json",
    //    success: function (response) {
    //        $("#transact-table tbody tr").remove();
    //        if (response.length === 0) {
    //            $("transact-table").append("<tr><td>Transacts not found!</td></tr>");
    //        }
    //        else {
    //            response.forEach(function (Transact) {
    //                addTransactIntoTable(Transact.id, Transact.userAccountId, Transact.userAccount, Transact.dateTransact, Transact.description, Transact.categoryId, Transact.name, Transact.amount, Transact.expenseOrIncome);

    //            });
    //            colorize();
    //            updateAmount();
    //        }
    //    },
    //    failure: function (response) {
    //        alert(response);
    //    }
    //});
    //function addTransactIntoTable(Id, AccountId, UserAccount, DateTransact, Description, CategoryId, Name, Amount, ExpenseOrIncome) {
    //    if (ExpenseOrIncome == true) {
    //        Amount = "-" + Amount;
    //    }
    //    let mytable =
    //        '<tr><td data-label="NomCompte">' + UserAccount +
    //        '</td><td data-label="Date">' + DateTransact +
    //        '</td><td data-label="Description">' + Description +
    //        '</td><td data-label="Catégorie">' + Name +
    //        '</td><td data-label="Montant" class="amount">' + Amount +
    //        '</td><td> <a href="/Transaction/Edit/' + Id + '"><img id="modify" src="img/modify.png" alt="bin-del"></a><a href="/Transaction/Delete/' + Id +
    //        '"><img id="bin-delete" src="img/bin-delete.png" alt="bin-del"></a> </td></tr>';
    //    $('.account').append(UserAccount);
    //    $('.date').append(DateTransact);
    //    $('.description').append(Description);
    //    $('.category').append(Name);
    //    $('.amount').append(Amount);
    //    $('.icons').append(mytable);
    //    $('#transact-table').append(mytable);
    //}
}
function closeModal(modal) {
    if (modal == null) return
    modal.classList.remove('active');
    overlay.classList.remove('active');
}