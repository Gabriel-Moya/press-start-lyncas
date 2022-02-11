const url = 'https://api.jsonbin.io/b/6202562f69b72261be54dd53';

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
                            <span>${user.name}</span>
                          </div>`;

    cellPhoneNumber.innerHTML = user.phonenumber;
    cellEmail.innerHTML = user.email;
    cellBirth.innerHTML = user.birth;

    if(user.status) {
      cellStatus.innerHTML = `<span class="status-active">Ativo</span>`;
    } else {
      cellStatus.innerHTML = `<span class="status-inactive">Inativo</span>`;
    }
    
    cellActions.innerHTML = `<div class="action-icons">
                              <a href="">
                                <i>
                                  <ion-icon name="create-outline"></ion-icon>
                                </i>
                              </a>
                              <a href="">
                                <i>
                                  <ion-icon name="trash-outline"></ion-icon>
                                </i>
                              </a>
                            </div>`;
  });
}


fetch(url)
  .then(response => {
    return response.json();
  })
  .then( users => {
    insertUsers(users);
  })