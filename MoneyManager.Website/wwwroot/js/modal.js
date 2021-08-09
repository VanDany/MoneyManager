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