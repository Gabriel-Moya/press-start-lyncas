import searchUser from "./searchUser.js";
import insertUsers from "./insertUsers.js";

const url = 'https://localhost:7042/api/Users';
const options = {
  'headers': {
    'Accept': 'Application/Json',
    'Content-Type': 'Application/Json',
    'Authorization': JSON.parse(localStorage.getItem('auth'))
  }
}

export default function listUsers() {

  fetch(url, options)
  .then(response => {
    return response.json();
  })
  .then( users => {
    searchUser(users);
    insertUsers(users);
  })

}