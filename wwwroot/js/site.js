// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
window.addEventListener("DOMContentLoaded", (event) => {
    let aside = document.querySelector(".second-menu-page");
    let asideCloseBtn = aside.querySelector(".close-btn");
    asideCloseBtn.addEventListener("click", () => {
        aside.classList.add(".hide-menu");
    });
});