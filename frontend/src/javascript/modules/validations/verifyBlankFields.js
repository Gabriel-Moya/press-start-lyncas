import setError from "../setError.js";
import clearInfo from "../clearInfo.js";

export default function verifyBlankField(field) {
  const blankFieldMessage = "Campo obrigatório!";

  if(field.value === ''){
    setError(field, 'error', blankFieldMessage);
  } else {
    clearInfo(field);
  }
}