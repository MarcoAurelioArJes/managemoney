const nighMode = document.querySelector("#cabecalho_Conteudo_Menu_Option_Dropdown_Menu_NightMode_Chave");
const body = document.querySelector("body");

nighMode.addEventListener("change", function () {
    body.classList.toggle("nighMode")
})