const url = 'https://localhost:7042/api/Users';

function deleteUserById(id) {

  fetch(`${url}/${id}`, {
    method: 'DELETE'
  })

}