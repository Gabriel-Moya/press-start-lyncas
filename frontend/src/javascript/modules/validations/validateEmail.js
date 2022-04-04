import setError from "../setError.js";

export default function validateEmail(email) {
  const regEx = /[a-z0-9!#$%&'+/=?^_`{|}~-]+(?:.[a-z0-9!#$%&'+/=?^_`{|}~-]+)@(?:[a-z0-9](?:[a-z0-9-][a-z0-9])?.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?/gi;
  const blankFieldMessage = "Campo obrigatório!";
  const incorrectFieldMessage = "Insira um email válido";

  if(regEx.test(email.value)) {
    return true;
  }

  if(email.value === '') {
    setError(email, 'error', blankFieldMessage);
  } else {
    setError(email, 'error', incorrectFieldMessage);
  }
}