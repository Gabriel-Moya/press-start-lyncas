import clearInfo from "./clearInfo.js";

export default function setSuccess(message) {
  const formElement = document.querySelector('form');
  const divElement = document.createElement('div');

  if(formElement.nextElementSibling) {
    clearInfo(formElement);
  }
  
  formElement.insertAdjacentElement('afterend', divElement);
  divElement.classList.add('success');
  divElement.innerHTML = message;
}