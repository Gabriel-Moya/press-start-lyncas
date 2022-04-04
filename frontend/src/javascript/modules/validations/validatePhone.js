import setError from "../setError.js";

export default function validatePhone(number) {
  const regEx = /^\(\d{2}\)\s\d{4,5}-\d{4}/;
  const blankFieldMessage = "Campo obrigatório!";
  const incorrectFieldMessage = "Insira um numero corretamente";

  if(regEx.test(number.value)) {
    return true;
  }
  
  if(number.value === '') {
    setError(number, 'error', blankFieldMessage);
  } else {
    setError(number, 'error', incorrectFieldMessage);
  }
}