import phoneMask from "./phoneMask.js";

const tableBody = document.querySelector('#table-body');

export default function insertUsers(usersObj) {

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

    cellPhoneNumber.innerHTML = phoneMask(user.phone);
    cellEmail.innerHTML = user.email;

    let birthDate = new Date(user.birthDate);
    cellBirth.innerHTML = new Intl.DateTimeFormat('pt-BR').format(birthDate);

    if(user.isActive) {
      cellStatus.innerHTML = `<span class="status-active">Ativo</span>`;
    } else {
      cellStatus.innerHTML = `<span class="status-inactive">Inativo</span>`;
    }

    cellActions.innerHTML = `<div class="action-icons">
                              <a data-js=[editUser] href="./register.html?id=${user.id}">
                                <i>
                                  <ion-icon name="create-outline"></ion-icon>
                                </i>
                              </a>
                              <a onclick="deleteUser(${user.id})" data-js=[deleteUser] href="#">
                                <i>
                                  <ion-icon name="trash-outline"></ion-icon>
                                </i>
                              </a>
                            </div>`;
  });
}