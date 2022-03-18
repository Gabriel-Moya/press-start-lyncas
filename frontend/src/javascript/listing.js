const url = 'https://localhost:7042/api/Users';

const content = document.querySelector('#content');
const tableBody = document.querySelector('#table-body');

function insertUsers(usersObj) {

  tableBody.innerHTML = '';

  usersObj.forEach(user => {
    const numberLines = tableBody.rows.lenght;
    const row = tableBody.insertRow(numberLines);

    const cellName = row.insertCell(0);
    const cellPhoneNumber = row.insertCell(1);
    const cellEmail = row.insertCell(2);
    const cellBirth = row.insertCell(3);
    const cellStatus = row.insertCell(4);
    const cellActions = row.insertCell(5);

    cellName.innerHTML = `<div class="user">
                            <img src="images/user-300x300.png" alt="Foto do usuário">
                            <span>${user.name} ${user.lastname}</span>
                          </div>`;

    user.phone = phoneMask(user.phone);
    cellPhoneNumber.innerHTML = user.phone;
    cellEmail.innerHTML = user.email;

    let birthDate = new Date(user.birthDate);
    cellBirth.innerHTML = new Intl.DateTimeFormat('pt-BR').format(birthDate);

    if(user.isActive) {
      cellStatus.innerHTML = `<span class="status-active">Ativo</span>`;
    } else {
      cellStatus.innerHTML = `<span class="status-inactive">Inativo</span>`;
    }

    cellActions.innerHTML = `<div class="action-icons">
                              <a data-js=[editUser] href="${url}/${user.id}">
                                <i>
                                  <ion-icon name="create-outline"></ion-icon>
                                </i>
                              </a>
                              <a data-js=[deleteUser] href="javascript:deleteUser(${user.id})">
                                <i>
                                  <ion-icon name="trash-outline"></ion-icon>
                                </i>
                              </a>
                            </div>`;
  });
}


function phoneMask(number) {

  if (number.length == 10) {
    number = number
      .replace(/(\d{2})(\d)/, "($1) $2")
      .replace(/(\d{4})(\d)/, "$1-$2")
      .replace(/(-\d{4})(\d+?)$/, "$1");

    return number;
  }
  
  if (number.length == 11) {
    number = number
      .replace(/(\d{2})(\d)/, "($1) $2")
      .replace(/(\d{5})(\d)/, "$1-$2")
      .replace(/(-\d{4})(\d+?)$/, "$1");

    return number;
  }

}


async function deleteUser(id) {

  await fetch(`${url}/${id}`, {
    method: 'DELETE',
    headers: { 'Content-Type': 'application/json' }
  })

  listUsers();

}


function listUsers() {

  fetch(url)
  .then(response => {
    return response.json();
  })
  .then( users => {
    insertUsers(users);
  })

}


window.onload(listUsers());