const form = document.querySelector('form');

export function errorLogin(error) {
  setError(form, error)
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