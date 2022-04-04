import listUsers from "./listUser.js";

const url = 'https://localhost:7042/api/Users';

export default window.deleteUser = async function(id) {

  const confirmDelete = window.confirm("Deseja realmente excluir o usuário?");

  if (confirmDelete) {
    await fetch(`${url}/${id}`, {
      method: 'DELETE',
      headers: {
        'Accept': 'Application/Json',
        'Content-Type': 'application/json',
        'Authorization': localStorage.getItem('auth')
      }
    })
    .then(function(response) {
      response.json();
      console.log(id, localStorage.getItem('id'))
      if(id == localStorage.getItem('id')) {
        localStorage.clear();
        location.href='/frontend/src/login.html';
      }
    });

    listUsers();
  }

}