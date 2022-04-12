import searchUser from "./searchUser.js";
import insertUsers from "./insertUsers.js";

const url = 'https://localhost:7042/api/Users';

export default function listUsers() {

  fetch(url)
  .then(response => {
    return response.json();
  })
  .then( users => {
    searchUser(users);
    insertUsers(users);
  })

}