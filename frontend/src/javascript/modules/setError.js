import clearInfo from "./clearInfo.js"

export default function setError(input, classError, message) {
  const spanElement = document.createElement("span");

  if(input.nextElementSibling) {
    clearInfo(input);
  }

  input.insertAdjacentElement('afterend', spanElement);
  spanElement.classList.add(classError);
  spanElement.innerHTML = `${message}`;
}