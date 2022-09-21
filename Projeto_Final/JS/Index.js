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

function LogOff() {
    // Data no passado
    var data = new Date(2010, 0, 01);
    // Converte a data para GMT
    data = data.toGMTString();
    // Apaga o cookie
    document.cookie = 'UserLogin=; expires = ' + data + '; path = /';
    window.location.href = "/HTMLCSS/Index.cshtml";
}

let slideIndex = 0;
showSlides();

function showSlides() {
    let i;
    let slides = document.getElementsByClassName("mySlides");
    for (i = 0; i < slides.length; i++) {
        slides[i].style.display = "none";
    }
    slideIndex++;
    if (slideIndex > slides.length) { slideIndex = 1 }
    slides[slideIndex - 1].style.display = "block";
    setTimeout(showSlides, 10000); 
}
