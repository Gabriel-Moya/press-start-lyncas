import listUsers from "./listUser.js";

const url = 'https://localhost:7042/api/Users';

export default window.deleteUser = async function(id) {

  const confirmDelete = window.confirm("Deseja realmente excluir o usuário?");

  if (confirmDelete) {
    await fetch(`${url}/${id}`, {
      method: 'DELETE',
      headers: { 'Content-Type': 'application/json' }
    })
  }

  listUsers();

}