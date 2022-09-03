function checkPassword(form) {
    senhaid1 = form.senhaid1.value;
    senhaid2 = form.senhaid2.value;

    // If password not entered
    if (senhaid1 == '')
        alert("Por Favor Insira sua Senha!");

    // If confirm password not entered
    else if (senhaid2 == '')
        alert("Por favor confirme sua senha!");

    // If Not same return False.    
    else if (senhaid1 != senhaid2) {
        alert("\nSenhas não Correspondem. Tente Novamente!")
        return false;
    }
}

function poof(i) {
    var a = document.getElementById(i);
    a.style["visibility"] = 'visible';
}