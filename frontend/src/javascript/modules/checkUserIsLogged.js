export default function checkUserIsLogged() {

  const id = window.localStorage.getItem('id');

  if(id) {
    window.location.href="/frontend/src/dashboard.html";
  }

}

window.onload=checkUserIsLogged