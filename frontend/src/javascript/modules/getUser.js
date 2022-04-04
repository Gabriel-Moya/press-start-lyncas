import insertUserValuesOnForm from './insertUserValuesOnForm.js';

const url = 'https://localhost:7042/api/Users';

export default function getUser(id) {
  
  const options = {
    'headers': {
      'Accept': 'Application/Json',
      'Content-Type': 'Application/Json',
      'Authorization': localStorage.getItem('auth')
    }
  }

  fetch(`${url}/${id}`, options)
    .then(response => {
      return response.json();
    })
    .then(user => {
      insertUserValuesOnForm(user);
    })

}