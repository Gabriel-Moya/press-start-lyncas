import { errorLogin } from "./modules/errorLogin.js";

const url = 'https://localhost:7042/api/Login';
const email = document.querySelector('#email');
const password = document.querySelector('#password');
const formLogin = document.querySelector('form');

function login() {

  const data = {
    email: email.value,
    password: password.value
  }

  fetch(url, {
    method: 'POST',
    headers: { 'Content-Type': 'application/json' },
    body: JSON.stringify(data)
  })
  .then(function(response) {
    return response.json();
  })
  .then(function(response) {
    if(response.Message) {
      errorLogin(response.Message);
    }

    if(response.email) {
      window.localStorage.setItem('id', response.id);
      window.localStorage.setItem('fullname', `${response.name} ${response.lastname}`);
      window.localStorage.setItem('email', response.email);
      const auth = btoa(`${response.email}:${password.value}`);
      window.localStorage.setItem('auth', `Basic ${auth}`);

      window.location.href="/frontend/src/dashboard.html";
    }
  })

}

formLogin.addEventListener("submit", (event) => {
  event.preventDefault();

  login();

});