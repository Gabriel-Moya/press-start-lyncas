const iconMenuToggle = document.getElementById('toggle');
const container = document.querySelector('.container');
const sidebar = document.querySelector(".sidebar");
const widthScreen = window.screen.width;

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

  if(widthScreen > 800) {
    container.style.width = "calc(100% - 300px)"
  } else {
    container.style.width = "calc(100% - 250px)"
  }
}

function hideMenu() {
  sidebar.style.display="none";
  iconMenuToggle.style.marginLeft = "30px";
  container.style.width = "100%"
}