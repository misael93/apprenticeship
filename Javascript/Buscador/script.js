var results;

var xhttp = new XMLHttpRequest();
xhttp.onreadystatechange = function() {
    if (this.readyState == 4 && this.status == 200) {
        results = JSON.parse(this.response);
        console.log(this.response)
    }
};

xhttp.open("GET", "/users.json", true);
xhttp.send();

function buscar() {
  limpiar();
  var nom = document.getElementById("nombre").value.toLowerCase();
  if (results) {
    var usersContainer = document.getElementById("users-container");
    for (var i = 0; i < results.length; i++) {
      if (results[i].name.toLowerCase().includes(nom) || foundHobby(nom, results[i].hobbies)) {
        var userTemplate = document.querySelector(".user-template").content.cloneNode(true);
        userTemplate.querySelector(".name").innerHTML = results[i].name;
        userTemplate.querySelector(".birth_year").innerHTML = results[i].birth_year;
        userTemplate.querySelector(".age").innerHTML = (new Date()).getFullYear() - results[i].birth_year;
        userTemplate.querySelector(".email").innerHTML = results[i].email;
        userTemplate.querySelector(".hobbies").innerHTML = results[i].hobbies.join(", ");
        usersContainer.appendChild(userTemplate);
      }
    }
  }
}

function foundHobby(search, hobbies) {
  for (var i = 0; i < hobbies.length; i++) {
    if (hobbies[i].toLowerCase().includes(search)) {
        return true;
    }
  }
}

function limpiar() {
  document.getElementById("users-container").innerHTML = "";
}

/*Tips
guardar el template para reusarlo Ej.
var template = document.querySelector(".user-template");

despues clonar el template, ver:
https://developer.mozilla.org/en-US/docs/Web/API/Node/cloneNode

y solo ir añadiendo
*/
