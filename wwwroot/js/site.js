if (document.querySelector('body').offsetHeight < window.innerHeight) {
    document.getElementById('rodapeBox').classList.add("footer_fixed");
}

document.getElementById("botaoVoltarTelas").addEventListener('click', (e) => {
    e.preventDefault();
    window.history.back();

});