import setError from "../setError.js";

export default function validatePasswords(password, retypePassword) {
  const regEx = /^(?=.*\d)(?=.*[a-zA-Z])(?=.*[0-9])[0-9a-zA-Z$*&23]{6,}/;
  const blankFieldMessage = "Campo obrigatório";
  const incorrrectPasswordMessage = "Requisitos mínimos: 6 caracteres com pelo menos uma letra e um número";
  const retypePasswordMessage = "Senhas não combinam"

  if(regEx.test(password.value) && (password.value === retypePassword.value)) {
    return true;
  } else if (!regEx.test(password.value)) {
    setError(password, 'error', incorrrectPasswordMessage);
    return;
  }

  if(password.value === '') {
    setError(password, 'error', blankFieldMessage);
    return;
  }

  if(retypePassword.value === '') {
    setError(retypePassword, 'error', blankFieldMessage);
    return;
  }

  else if (password.value != retypePassword.value) {
    setError(retypePassword, 'error', retypePasswordMessage);
    return;
  }
}