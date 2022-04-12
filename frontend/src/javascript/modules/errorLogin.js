import setError from "./setError.js";

const form = document.querySelector('form');

export function errorLogin(error) {
  setError(form, 'error', error)
}