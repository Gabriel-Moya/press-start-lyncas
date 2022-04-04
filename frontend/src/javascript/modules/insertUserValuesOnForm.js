import phoneMask from "./phoneMask.js";

const inputName = document.getElementById('name');
const inputLastname = document.getElementById('lastname');
const inputPhonenumber = document.getElementById('phonenumber');
const inputBirthday = document.getElementById('birthday');
const inputEmail = document.getElementById('email');
const inputPassword = document.getElementById('password');
const inputRetypePassword = document.getElementById('retypePassword');
const inputActive = document.getElementById('active');

export default function insertUserValuesOnForm(user) {

  inputName.value = user.name;
  inputLastname.value = user.lastname;
  inputPhonenumber.value = phoneMask(user.phone);
  inputBirthday.value = user.birthDate.split("T")[0];
  inputEmail.value = user.email;
  inputActive.checked = user.isActive;

  inputPassword.required = false;
  inputRetypePassword.required = false;

}