const url = 'https://localhost:7042/api/Users';
const inputName = document.getElementById('name');
const inputLastname = document.getElementById('lastname');
const inputPhonenumber = document.getElementById('phonenumber');
const inputBirthday = document.getElementById('birthday');
const inputEmail = document.getElementById('email');
const inputPassword = document.getElementById('password');
const inputRetypePassword = document.getElementById('retypePassword');
const inputActive = document.getElementById('active');
const submitButton = document.getElementsByName('submit');
const idUrl = location.href.split("?id=")[1];

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

if (idUrl != undefined) {
  getUser(idUrl);

  document.querySelector("form")
    .addEventListener("submit", (event) => {
      event.preventDefault();
  
      verifyBlankField(inputName);
      verifyBlankField(inputLastname);
      validatePhone(inputPhonenumber);
      validateBirthday(inputBirthday);
      validateEmail(inputEmail);
  
      if (validatePhone(inputPhonenumber)
          && validateBirthday(inputBirthday)
          && validateEmail(inputEmail))
          {
  
            const data = {
              name: inputName.value,
              lastname: inputLastname.value,
              email: inputEmail.value,
              phone: inputPhonenumber.value,
              birthDate: inputBirthday.value,
              isActive: inputActive.checked
            };
  
            fetch(`${url}/${idUrl}`, {
              method: 'PUT',
              headers: { 'Content-Type': 'application/json' },
              body: JSON.stringify(data)
            })
            .then(function(response) {
              return response.json()
            })
            .then(function(response) {
              console.log(response);
            })
  
            setSuccess('Usuário atualizado com sucesso');  // REFATORAR - SUCESSO SOMENTE SE RETORNAR 200 DO BACKEND
          }
    });

} else {

  inputPassword.addEventListener("blur", () => {
    verifyBlankField(inputPassword);
    validatePasswords(inputPassword, inputRetypePassword);
  });
  
  inputRetypePassword.addEventListener("blur", () => {
    verifyBlankField(inputRetypePassword);
    validatePasswords(inputPassword, inputRetypePassword);
  });
  
  document.querySelector("form")
    .addEventListener("submit", (event) => {
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
              headers: { 'Content-Type': 'application/json' },
              body: JSON.stringify(data)
            })
            .then(function(response) {
              return response.json()
            })
            .then(function(response) {
              console.log(response);
            })
  
            setSuccess('Usuário cadastrado com sucesso');  // REFATORAR - SUCESSO SOMENTE SE RETORNAR 200 DO BACKEND
          }
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

function verifyBlankField(field) {
  const blankFieldMessage = "Campo obrigatório!";

  if(field.value === ''){
    setError(field, blankFieldMessage);
  } else {
    clearInfo(field);
  }
}

function validatePhone(number) {
  const regEx = /^\(\d{2}\)\s\d{4,5}-\d{4}/;
  const blankFieldMessage = "Campo obrigatório!";
  const incorrectFieldMessage = "Insira um numero corretamente";

  if(regEx.test(number.value)) {
    return true;
  }
  
  if(number.value === '') {
    setError(number, blankFieldMessage);
  } else {
    setError(number, incorrectFieldMessage);
  }
}

function validateBirthday(birthday) {
  const regEx = /\d{4}-\d{2}-\d{2}/;
  const blankFieldMessage = "Campo obrigatório!"; /* DEFINIR A MENSAGEM DO ERRO */

  if(regEx.test(birthday.value)) {
    return true;
  }
  setError(birthday, blankFieldMessage);
}

function validateEmail(email) {
  const regEx = /[a-z0-9!#$%&'+/=?^_`{|}~-]+(?:.[a-z0-9!#$%&'+/=?^_`{|}~-]+)@(?:[a-z0-9](?:[a-z0-9-][a-z0-9])?.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?/gi;
  const blankFieldMessage = "Campo obrigatório!";
  const incorrectFieldMessage = "Insira um email válido";

  if(regEx.test(email.value)) {
    return true;
  }

  if(email.value === '') {
    setError(email, blankFieldMessage);
  } else {
    setError(email, incorrectFieldMessage);
  }
}

function validatePasswords(password, retypePassword) {
  const regEx = /^(?=.*\d)(?=.*[a-zA-Z])(?=.*[0-9])[0-9a-zA-Z$*&23]{6,}/;
  const blankFieldMessage = "Campo obrigatório";
  const incorrrectPasswordMessage = "Requisitos mínimos: 6 caracteres com pelo menos uma letra e um número";
  const retypePasswordMessage = "Senhas não combinam"

  if(regEx.test(password.value) && (password.value === retypePassword.value)) {
    return true;
  } else if (!regEx.test(password.value)) {
    setError(password, incorrrectPasswordMessage);
  }

  if(password.value === '') {
    setError(password, blankFieldMessage);
  }

  if(retypePassword.value === '') {
    setError(retypePassword, blankFieldMessage);
  }

  else if (password.value != retypePassword.value) {
    setError(retypePassword, retypePasswordMessage);
  }
}

function setError(input, message) {
  const spanElement = document.createElement("span");

  if(input.nextElementSibling) {
    clearInfo(input);
  }

  input.insertAdjacentElement('afterend', spanElement);
  spanElement.classList.add('error');
  spanElement.innerHTML = `${message}`;
}

function clearInfo(input) {
  if(input.nextElementSibling != null){
    input.nextElementSibling.remove();
  }
}

function setSuccess(message) {
  const formElement = document.querySelector('form');
  const divElement = document.createElement('div');

  if(formElement.nextElementSibling) {
    clearInfo(formElement);
  }
  
  formElement.insertAdjacentElement('afterend', divElement);
  divElement.classList.add('success');
  divElement.innerHTML = message;
}

function getUser(id) {
  
  fetch(`${url}/${id}`)
    .then(response => {
      return response.json();
    })
    .then(user => {
      insertUserValuesOnForm(user);
    })

}

function insertUserValuesOnForm(user) {

  inputName.value = user.name;
  inputLastname.value = user.lastname;
  inputPhonenumber.value = phoneMask(user.phone);
  inputBirthday.value = user.birthDate.split("T")[0];
  inputEmail.value = user.email;
  inputActive.checked = user.isActive;

  inputPassword.required = false;
  inputRetypePassword.required = false;

}
