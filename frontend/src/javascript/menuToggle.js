const iconMenuToggle = document.getElementById('toggle');
const iconCloseMenu = document.getElementById('close');
const sidebar = document.querySelector(".sidebar");

iconCloseMenu.addEventListener("click", () => {
  hideMenu();
});

iconMenuToggle.addEventListener("click", () => {

  const displaySidebar = window.getComputedStyle(sidebar).display;

  if (displaySidebar === "block") {
    hideMenu();
  } else {
    displayMenu();
  }
});


function displayMenu() {
  sidebar.style.display="block";
}

function hideMenu() {
  sidebar.style.display="none";
  iconMenuToggle.style.marginLeft = "30px";
}