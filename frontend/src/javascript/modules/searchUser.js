import insertUsers from "./insertUsers.js";

const searchField = document.querySelector('#search-user');

export default function searchUser(usersList) {
  console.log(usersList);

  searchField.addEventListener("keyup", () => {

    const searched = usersList.filter(
      (user) =>
        user.name.toUpperCase().indexOf(searchField.value.toUpperCase()) >= 0 ||
        user.lastname.toUpperCase().indexOf(searchField.value.toUpperCase()) >= 0 ||
        user.email.toUpperCase().indexOf(searchField.value.toUpperCase()) >= 0
    );

    if (searchField.value != "" || searchField != null) {
      insertUsers(searched);
    } else {
      insertUsers(usersList);
    }
  })
}