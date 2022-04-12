export default window.logout = () => {
  localStorage.clear();
  window.location.href="/frontend/src/login.html"
}