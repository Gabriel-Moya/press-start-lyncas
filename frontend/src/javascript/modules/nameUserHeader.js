const userInformation = document.querySelector('.nameUser');

export default window.nameUserHeader = () => {

  const nameUser = localStorage.getItem('fullname');
  userInformation.innerHTML = nameUser;

}

window.onload=nameUserHeader