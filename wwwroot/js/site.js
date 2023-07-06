// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
window.addEventListener("DOMContentLoaded", (event) => {
    let aside = document.querySelector(".second-menu-page");
    let asideCloseBtn = aside.querySelector(".close-btn");
    let asideOpenBtn = document.querySelector(".open-toggle");
    asideCloseBtn.addEventListener("click", () => {
        aside.classList.add("hide-menu");
        asideOpenBtn.style.visibility = "visible";
    });
    asideOpenBtn.addEventListener("click", () => {
        aside.classList.remove("hide-menu");
        asideOpenBtn.style.visibility = "hidden";
    });
});

window.addEventListener("DOMContentLoaded", (event) => {
    let editCat = document.querySelector(".category-page-form-container");
    let editClose = editCat.querySelector(".close-btn");
    editClose.addEventListener("click", () => {
        location.replace("https://localhost:7299/Cms/Category")
    })
})