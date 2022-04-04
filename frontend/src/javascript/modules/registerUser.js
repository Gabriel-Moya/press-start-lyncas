import verifyBlankField from "./validations/verifyBlankFields.js";
import validatePasswords from "./validations/validatePasswords.js";
import validatePhone from "./validations/validatePhone.js";
import validateBirthday from "./validations/validateBirthday.js";
import validateEmail from "./validations/validateEmail.js";
import setSuccess from "./setSuccess.js";
import setError from "./setError.js";
import clearInfo from "./clearInfo.js";

const url = 'https://localhost:7042/api/Users';
const form = document.querySelector('form');
const inputName = document.getElementById('name');
const inputLastname = document.getElementById('lastname');
const inputPhonenumber = document.getElementById('phonenumber');
const inputBirthday = document.getElementById('birthday');
const inputEmail = document.getElementById('email');
const inputPassword = document.getElementById('password');
const inputRetypePassword = document.getElementById('retypePassword');
const inputActive = document.getElementById('active');
const submitButton = document.getElementsByName('submit');

export default function registerUser() {

  form.addEventListener("submit", (event) => {
      event.preventDefault();

      verifyBlankField(inputName);
      verifyBlankField(inputLastname);
      validatePhone(inputPhonenumber);
      validateBirthday(inputBirthday);
      validateEmail(inputEmail);
      validatePasswords(inputPassword, inputRetypePassword);

      if (validatePhone(inputPhonenumber)
          && validateBirthday(inputBirthday)
          && validateEmail(inputEmail)
          && validatePasswords(inputPassword, inputRetypePassword))
          {

            const data = {
              name: inputName.value,
              lastname: inputLastname.value,
              email: inputEmail.value,
              phone: inputPhonenumber.value,
              birthDate: inputBirthday.value,
              password: inputPassword.value,
              isActive: inputActive.checked
            };

            fetch(url, {
              method: 'POST',
              headers: {
                'Accept': 'Application/Json',
                'Content-Type': 'application/json',
                'Authorization': localStorage.getItem('auth')
              },
              body: JSON.stringify(data)
            })
            .then(function(response) {
              return response.json()
            })
            .then(function(response) {
              if(response.id){
                setSuccess('Usuário cadastrado com sucesso');

                setTimeout(() => {
                  inputName.value = '';
                  inputLastname.value = '';
                  inputPhonenumber.value = '';
                  inputBirthday.value = '';
                  inputEmail.value = '';
                  inputPassword.value = '';
                  inputRetypePassword.value = '';
                  inputActive.checked = false;

                  clearInfo(form);
                }, 2000);

              } else {
                setError(form, 'errorResponse', response.Message);
              }
            })
          }
    });

}