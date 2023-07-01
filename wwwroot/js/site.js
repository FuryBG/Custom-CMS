// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
window.addEventListener("DOMContentLoaded", (event) => {
    let aside = document.querySelector(".aside");
    let asideCloseBtn = aside.querySelector("span");
    asideCloseBtn.addEventListener("click", () => {
        aside.classList.add("aside-hidden");
    });
});