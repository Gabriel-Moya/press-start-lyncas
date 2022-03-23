const url = 'https://localhost:7042/api/Login';

export default window.verifyLogin = () => {

  const data = {
    id: window.localStorage.getItem('id'),
    fullname: window.localStorage.getItem('fullname'),
    email: window.localStorage.getItem('email')
  }

  if(!data.id) {
    window.location.href="/frontend/src/login.html"
  }

}

window.onload = verifyLogin();