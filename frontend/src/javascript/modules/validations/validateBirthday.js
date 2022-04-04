import setError from "../setError.js";

export default function validateBirthday(birthday) {
  const regEx = /\d{4}-\d{2}-\d{2}/;
  const blankFieldMessage = "Campo obrigatório!"; /* DEFINIR A MENSAGEM DO ERRO */

  if(regEx.test(birthday.value)) {
    return true;
  }
  setError(birthday, 'error', blankFieldMessage);
}