function obterValoresDosCampos() {
    return {
        nome: $("#inputEmailEntrar").val(),
        senha: $("#inputSenhaEntrar").val()
    };
}

$("#LoginButton").bind('click', (e) => {
    e.preventDefault();

    fetch('http://localhost:5274/usuario/login', {
        method: 'POST',
        headers: {
            "content-type": 'application/json'
        },
        body: JSON.stringify(obterValoresDosCampos())
    }).then(res => res.json())
        .then(data => console.log(data))
        .then(() => {
            fetch('http://localhost:5274/usuario/login', {
                method: 'POST',
                headers: {
                    "content-type": 'application/json',
                    "authorization": window.localStorage.getItem("token")
                },
            }).then(() => {
                  window.open("https://localhost:7052/Lancamento");
            })
        })
});