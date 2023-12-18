class QuestionWindow {
    constructor() {
        this.mainWindow = document.querySelector("#questionWindow");
    }
    FetchError() {
        this.mainWindow.innerHTML = "Wystąpił błąd podczas pobierania danych.";
    }
}
const questionWindow = new QuestionWindow();