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
    console.log(response);
    if(response.message) {
      console.log(`${response.message}`);
    }

    if(response.email) {
      window.localStorage.setItem('id', JSON.stringify(`${response.id}`));
      window.localStorage.setItem('fullname', JSON.stringify(`${response.name} ${response.lastname}`));
      window.localStorage.setItem('email', JSON.stringify(`${response.email}`));
      window.localStorage.setItem('auth', JSON.stringify(btoa(`${response.email}:${response.password}`)));

      window.location.href="/frontend/src/dashboard.html";
    }
  })

}

formLogin.addEventListener("submit", (event) => {
  event.preventDefault();

  login();

});