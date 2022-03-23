const userInformation = document.querySelector('.nameUser');

export default window.nameUserHeader = () => {

  const nameUser = JSON.parse(localStorage.getItem('fullname'));
  userInformation.innerHTML = nameUser;

}

window.onload=nameUserHeader