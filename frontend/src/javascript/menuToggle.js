const iconMenuToggle = document.getElementById('toggle');
const iconCloseMenu = document.getElementById('close');
const container = document.querySelector('.container');
const sidebar = document.querySelector('.sidebar');

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
  
  if (window.matchMedia("(min-width: 801px)").matches) {
    container.style.width = "calc(100% - 300px)";
  } else {
    container.style.width = "100%";
  }
}

function hideMenu() {
  sidebar.style.display = "none";
  container.style.width = "100%"
}

const screenSize = function() {

  const screenResize = function(e) {
    const screenSize = window.matchMedia("(max-width: 801px)");
    if (screenSize.matches) {
      sidebar.style.display = "none"
      container.style.width = "100%";
    } else {
      sidebar.style.display = "block"
      container.style.width = "calc(100% - 300px)";
    };
  }

  window.addEventListener('resize', screenResize, false);
}

document.addEventListener('DOMContentLoaded', screenSize, false);

/* function sidebarSize(screenSize) {
  if (screenSize.matches) {
    sidebar.style.display = "none"
    container.style.width = "100%";
  } else {
    sidebar.style.display = "block"
    container.style.width = "calc(100% - 300px)";
  }
} */

/* var screenSize = window.matchMedia("(max-width: 801px)");
sidebarSize(screenSize);
screenSize.addListener(sidebarSize); */
