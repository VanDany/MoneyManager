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
function closeModal(modal) {
    if (modal == null) return
    modal.classList.remove('active');
    overlay.classList.remove('active');
}

//Delay to hide the first minimization of the window "créer une nouvelle transaction"
function DisplayPopup() {
    var millisecondsToWait = 500;
    setTimeout(function () {
        let doc = document.getElementById("transactWindow");
        doc.style.display = "block";
    }, millisecondsToWait);
}
//open window "créer une nouvelle transaction"
function openModal(modal) {
    if (modal == null) return
    modal.classList.add('active');
    overlay.classList.add('active');
    $.ajax({
        url: '/Transaction/GetCategories',
        type: "GET",
        dataType: "json",
        success: function (response) {
            var element = document.getElementById("Categories");
            while (element.firstChild) {
                element.removeChild(element.lastChild);
            }
            if (response.length === 0) {
                $("Categories").append("<option>Categories not found!</option>");
            }
            else {
                response.forEach(function (Category) {
                    addCategoryIntoSelect(Category.name, Category.id);
                });
            }
        },
        failure: function (response) {
            alert(response);
        }
    });
    function addCategoryIntoSelect(Name, Id) {
        let option = document.createElement("option");
        option.text = Name;
        option.value = Id;
        var element = document.getElementById("Categories");
        element.appendChild(option);
        console.log(option.text);
        console.log(option.value);
    }
}