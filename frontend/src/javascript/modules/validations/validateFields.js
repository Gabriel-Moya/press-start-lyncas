import verifyBlankField from "./verifyBlankFields.js";
import validatePhone from "./validatePhone.js";
import validateEmail from "./validateEmail.js";
import validatePasswords from "./validatePasswords.js";

const inputName = document.getElementById('name');
const inputLastname = document.getElementById('lastname');
const inputPhonenumber = document.getElementById('phonenumber');
const inputBirthday = document.getElementById('birthday');
const inputEmail = document.getElementById('email');
const inputPassword = document.getElementById('password');
const inputRetypePassword = document.getElementById('retypePassword');

export default function validateFields() {
  
  inputName.addEventListener("blur", () => {
    verifyBlankField(inputName);
  });
  
  inputLastname.addEventListener("blur", () => {
    verifyBlankField(inputLastname);
  });
  
  inputPhonenumber.addEventListener("keyup", () => {
    verifyBlankField(inputPhonenumber);
  
    if ((inputPhonenumber.value).length < 14) {
      inputPhonenumber.value = inputPhonenumber.value
        .replace(/\D/g, "")
        .replace(/(\d{2})(\d)/, "($1) $2")
        .replace(/(\d{4})(\d)/, "$1-$2")
        .replace(/(-\d{4})(\d+?)$/, "$1");
    } else if ((inputPhonenumber.value).length > 14) {
      inputPhonenumber.value = inputPhonenumber.value
        .replace(/\D/g, "")
        .replace(/(\d{2})(\d)/, "($1) $2")
        .replace(/(\d{5})(\d)/, "$1-$2")
        .replace(/(-\d{4})(\d+?)$/, "$1");
    }
    
  });
  
  inputPhonenumber.addEventListener("blur", () => {
    validatePhone(inputPhonenumber);
  })
  
  inputBirthday.addEventListener("blur", () => {
    verifyBlankField(inputBirthday);
  });
  
  inputEmail.addEventListener("blur", () => {
    verifyBlankField(inputEmail);
    validateEmail(inputEmail);
  });

  inputPassword.addEventListener("blur", () => {
    verifyBlankField(inputPassword);
    validatePasswords(inputPassword, inputRetypePassword);
  });
  
  inputRetypePassword.addEventListener("blur", () => {
    verifyBlankField(inputRetypePassword);
    validatePasswords(inputPassword, inputRetypePassword);
  });

}